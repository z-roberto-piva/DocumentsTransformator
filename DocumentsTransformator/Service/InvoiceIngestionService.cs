// InvoiceIngestionService.cs
using System.Reflection;
using DocumentsTransformator.Data;
using DocumentsTransformator.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenSearch.Client;

namespace DocumentsTransformator.Service;

public class InvoiceIngestionService(AppDbContext db, IOpenSearchClient os, IConfiguration cfg)
{
    private readonly AppDbContext _db = db;
    private readonly IOpenSearchClient _os = os;
    private readonly string _index = cfg["OpenSearch:Index"] ?? "invoices";
    private int _batchSize = int.TryParse(cfg["BatchSize"], out var b) ? b : 2000;
    private readonly int _batchSizeEmergency = int.TryParse(cfg["BatchSizeEmergency"], out var be) ? be : 0;
    private readonly int _startingSkip = int.TryParse(cfg["StartingSkip"], out var ss) ? ss : 0;
    private readonly int _endEmergencyBatchSize = int.TryParse(cfg["EndEmergencyBatchSize"], out var es) ? es : 0;
    private readonly int _maxNumberOfErrors = int.TryParse(cfg["MaxNumberOfErrors"], out var me) ? me : 10;
    private readonly int? maxRecords = int.TryParse(cfg["MaxNumberOfDocuments"], out var m) ? m : null;


    public async Task RunAsync(CancellationToken ct = default)
    {
        DateTime startingTime = DateTime.Now;
        Console.WriteLine($"[Index Documents Batches] Inizio indicizzazione fatture: {startingTime}");
        await EnsureIndexAsync(ct);

        bool isEmergencyMode = false;  // Indica che siamo in modalità emergenza
        int emergencyErrorCount = 0;  // Contatore di errori in modalità emergenza

        var totalNumberOfRows = await _db.ScmReceiptHeaders.AsNoTracking().CountAsync(ct);
        Console.WriteLine($"[Index Documents Batches] Totali: {totalNumberOfRows}");

        int skip = _startingSkip == 0 ? 0 : _startingSkip;
        int preEmergencySkip = skip;  // Salvo lo skip prima di entrare in modalità emergenza
        // _batchSize = _batchSizeEmergency == 0 ? _batchSize : _batchSizeEmergency;

        // Gestisco la procedura di caricamento con un while per poter eventualmente riavviare il caricamento in caso di errori
        while (skip <= totalNumberOfRows)
        {
            try
            {
                DateTime batchStartTime = DateTime.Now;
                Console.WriteLine($"[Index Documents Batches] Elaborazione batch da {skip} a {Math.Min(skip + _batchSize, totalNumberOfRows)}... Inizio: {batchStartTime}");

                // Estraggo il chunk di dati dal DB
                List<DocumentDTO> chunk = await GetChunk(_db, skip, ct);

                if (chunk.Count == 0) break;
                DateTime indexingStart = DateTime.Now;
                Console.WriteLine($"[Index Documents Batches] Estrazione dati batch da {skip} a {Math.Min(skip + _batchSize, totalNumberOfRows)} completata. Fine: {DateTime.Now}. Durata: {DateTime.Now - batchStartTime}");
                Console.WriteLine($"[Index Documents Batches] Indicizzazione batch da {skip} a {skip + chunk.Count}... Inizio: {indexingStart}");

                // Carico i dati su OpenSearch
                var bulk = await _os.BulkAsync(b => b
                    .Index(_index)
                    .IndexMany(chunk, (descriptor, doc) => descriptor.Id(doc.Id)), ct);

                DateTime indexingEnd = DateTime.Now;
                Console.WriteLine($"[Index Documents Batches] Indicizzazione batch da {skip} a {skip + chunk.Count} completata. Fine: {indexingEnd}. Durata: {indexingEnd - indexingStart}");

                if (bulk.Errors)
                {
                    var errors = string.Join("; ", bulk.ItemsWithErrors.Select(e => $"{e.Id}:{e.Error?.Reason}"));
                    throw new InvalidOperationException($"Bulk fallito: {errors}");
                }

                Console.WriteLine($"[Index Documents Batches] Indicizzate {skip + chunk.Count}/{totalNumberOfRows}");
                Console.WriteLine($"[Index Documents Batches] Durata totale elaborazione batch da {skip} a {Math.Min(skip + _batchSize, totalNumberOfRows)}: {DateTime.Now - batchStartTime}");
                skip += _batchSize; // Aggiorno lo skip solo se il batch è andato a buon fine
                preEmergencySkip = skip + chunk.Count;
                if (preEmergencySkip % 100000 == 0)
                {
                    Console.WriteLine($"[Index Documents Batches] Tempo di elaborazione per {preEmergencySkip} documenti: {(DateTime.Now - startingTime).TotalMinutes / ((skip + chunk.Count) / 100000)} minuti");
                }

                if (isEmergencyMode && (skip + _batchSize) > preEmergencySkip)
                {
                    // Se ero in modalità emergenza e sono riuscito a processare un batch completo, esco dalla modalità emergenza
                    isEmergencyMode = false;
                    emergencyErrorCount = 0;
                    _batchSize = int.TryParse(cfg["BatchSize"], out var b) ? b : 2000; // Reimposto il batch size normale
                    Console.WriteLine($"[Index Documents Batches] Uscito dalla modalità emergenza. Reimpostato batch size a {_batchSize}.");
                }

            }
            catch (Exception ex)
            {
                if (!isEmergencyMode)
                {
                    // Entro in modalità emergenza
                    Console.Error.WriteLine($"[Index Documents Batches] Errore durante l'elaborazione del batch da {skip} a {Math.Min(skip + _batchSize, totalNumberOfRows)}: {ex}");
                    Console.WriteLine($"[Index Documents Batches] Entrato in modalità emergenza. Impostato batch size a {_batchSizeEmergency}.");
                    isEmergencyMode = true;
                    emergencyErrorCount = 1;
                    skip = preEmergencySkip; // Torno allo skip precedente
                    _batchSize = _batchSizeEmergency; // Imposto un batch size molto piccolo per individuare i documenti problematici
                }
                else
                {
                    // Sono già in modalità emergenza
                    emergencyErrorCount++;
                    Console.Error.WriteLine($"[Index Documents Batches] Errore durante l'elaborazione del batch da {skip} a {Math.Min(skip + _batchSize, totalNumberOfRows)}: {ex}");
                    if (emergencyErrorCount >= _maxNumberOfErrors)
                    {
                        Console.Error.WriteLine($"[Index Documents Batches] Raggiunto il numero massimo di errori consecutivi in modalità emergenza ({emergencyErrorCount}). Interrompo l'elaborazione.");
                        break;
                    }

                }
            }
        }

    }


    public async Task RunAsync2(CancellationToken ct = default)
    {
        DateTime start = DateTime.Now;
        Console.WriteLine($"[Index Documents Batches] Inizio indicizzazione fatture: {start}");
        await EnsureIndexAsync(ct);

        bool errorState = false;
        int errorCount = 0;

        var total = await _db.ScmReceiptHeaders.AsNoTracking().CountAsync(ct);
        Console.WriteLine($"[Index Documents Batches] Totali: {total}");

        // Gestisco momentaneamente il caricamento dei documenti problematici superiori a 970000
        // Con un batchsize molto piccolo per individuare con precisione i documenti che danno errore

        int initialSkip = _startingSkip == 0 ? 0 : _startingSkip;
        _batchSize = _batchSizeEmergency == 0 ? _batchSize : _batchSizeEmergency;


        for (int skip = initialSkip; skip < total; skip += _batchSize)
        {
            if (_endEmergencyBatchSize > 0 && skip >= _endEmergencyBatchSize)
            {
                Console.WriteLine($"[Index Documents Batches] Raggiunto il limite di fine emergenza a {skip} documenti. Reimposto batch size a {_batchSize}.");
                _batchSize = int.TryParse(cfg["BatchSize"], out var b) ? b : 2000;
            }

            if (maxRecords.HasValue && skip >= maxRecords.Value)
            {
                Console.WriteLine($"[Index Documents Batches] Limite massimo di documenti ({maxRecords.Value}) raggiunto. Interrompo l'elaborazione.");
                break;
            }
            DateTime batchStart = DateTime.Now;
            Console.WriteLine($"[Index Documents Batches] Elaborazione batch da {skip} a {Math.Min(skip + _batchSize, total)}... Inizio: {batchStart}");

            try
            {
                List<DocumentDTO> chunk = await GetChunk(_db, skip, ct);

                if (chunk.Count == 0) break;
                DateTime indexingStart = DateTime.Now;
                Console.WriteLine($"[Index Documents Batches] Estrazione dati batch da {skip} a {Math.Min(skip + _batchSize, total)} completata. Fine: {DateTime.Now}. Durata: {DateTime.Now - batchStart}");
                Console.WriteLine($"[Index Documents Batches] Indicizzazione batch da {skip} a {skip + chunk.Count}... Inizio: {indexingStart}");
                var bulk = await _os.BulkAsync(b => b
                    .Index(_index)
                    .IndexMany(chunk, (descriptor, doc) => descriptor.Id(doc.Id)), ct);

                DateTime indexingEnd = DateTime.Now;
                Console.WriteLine($"[Index Documents Batches] Indicizzazione batch da {skip} a {skip + chunk.Count} completata. Fine: {indexingEnd}. Durata: {indexingEnd - indexingStart}");

                if (bulk.Errors)
                {
                    var errors = string.Join("; ", bulk.ItemsWithErrors.Select(e => $"{e.Id}:{e.Error?.Reason}"));
                    throw new InvalidOperationException($"Bulk fallito: {errors}");
                }

                Console.WriteLine($"[Index Documents Batches] Indicizzate {skip + chunk.Count}/{total}");
                Console.WriteLine($"[Index Documents Batches] Durata totale elaborazione batch da {skip} a {Math.Min(skip + _batchSize, total)}: {DateTime.Now - batchStart}");
                int DocsTillNow = skip + chunk.Count;
                if (DocsTillNow % 100000 == 0)
                {
                    Console.WriteLine($"[Index Documents Batches] Tempo di elaborazione per {DocsTillNow} documenti: {(DateTime.Now - start).TotalMinutes / ((skip + chunk.Count) / 100000)} minuti");
                }
                if (errorState)
                {
                    errorState = false;
                    errorCount = 0;
                    Console.WriteLine($"[Index Documents Batches] Riepilogo: superato errore, errori consecutivi: {errorCount}. Resetto gli errori e proseguo l'elaborazione.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[Index Documents Batches] Errore durante l'elaborazione del batch da {skip} a {Math.Min(skip + _batchSize, total)}: {ex}");
                errorState = true;
                errorCount++;
                if (errorCount >= 10)
                {
                    Console.Error.WriteLine($"[Index Documents Batches] Raggiunto il numero massimo di errori consecutivi ({errorCount}). Interrompo l'elaborazione.");
                    break;
                }
            }
        }

        await _os.Indices.RefreshAsync(_index, r => r, ct);
        Console.WriteLine($"[Index Documents Batches] Fine indicizzazione fatture: {DateTime.Now}. Durata totale: {DateTime.Now - start}");
    }

    // Metodo che verifica l'esistenza dell'indice e lo crea se non esiste
    // L'indice viene creato con il mapping basato su DocumentDTO
    private async Task EnsureIndexAsync(CancellationToken ct)
    {
        var exists = await _os.Indices.ExistsAsync(_index, ct: ct);
        if (exists.Exists) return;

        var create = await _os.Indices.CreateAsync(_index, c => c
            .Map<DocumentDTO>(m => m
                .AutoMap()
                .Properties(ps => ps
                    .Nested<PartnerDTO>(n => n.Name(p => p.Customer).AutoMap())
                    .Nested<UserDTO>(n => n.Name(p => p.Cashier).AutoMap())
                    .Nested<ShopDTO>(n => n.Name(p => p.Shop).AutoMap())
                    .Nested<TillDTO>(n => n.Name(p => p.Till).AutoMap())
                    .Nested<RowDto>(n => n.Name(p => p.Rows).AutoMap())
                    .Nested<VatDto>(n => n.Name(p => p.Vats).AutoMap())
                    .Nested<PaymentDto>(n => n.Name(p => p.Payments).AutoMap())
                )
            ), ct);

        if (!create.IsValid)
            throw new InvalidOperationException($"Creazione indice '{_index}' fallita: {create.DebugInformation}");
    }

    private async Task<List<DocumentDTO>> GetChunk(DbContext db, int skip, CancellationToken ct)
    {
        return await _db.ScmReceiptHeaders
                .AsNoTracking()
                .OrderBy(i => i.Id)
                .Skip(skip).Take(_batchSize)
                .Select(i => new DocumentDTO(
                      i.Id
                    , i.ReceiptRealDatetime
                    , i.TillCode
                    , i.CancelUserId
                    , i.Canceled
                    , i.ShopId
                    , i.CashierId
                    , i.TillId
                    , i.Total
                    , i.PartnerId
                    , i.ReceiptDate
                    , i.IsReversal
                    , i.ReceiptTime
                    , i.ReversedTransactionId
                    , i.ShopCode
                    , i.FiscalNumber
                    , i.TransactionNumber
                    , i.Reason
                    , i.PartnerAnomaly
                    , i.InvoiceNumber
                    , i.HallCode
                    , i.NumberOfItems
                    , i.CoverChargeQty
                    , i.BookkeepingDate.HasValue ? i.BookkeepingDate.Value.ToDateTime(TimeOnly.Parse("00:00 AM")) : null
                    , i.CashierUserCode
                    , i.ReversalTransactionId
                    , i.ReferenceReceipt
                    , i.CancelDate
                    , i.CustomerNumber
                    , i.TableCode
                    , i.ReceiptDatetime
                    , i.ServiceId
                    , i.Provenience
                    , i.CompanyCurrencyId
                    , i.TotalWithoutTaxes
                    , i.AccountInvoiceId
                    , i.ZReportNumber
                    , i.IsManual
                    , i.TicketsCount
                    , i.OperatorShiftId
                    , i.TotalTaxes
                    , i.TemporaryBillPrinted
                    , i.DiscountOnTotalValue
                    , i.ReferenceZreport
                    , i.ServiceTimeSlot
                    , i.LotteryCode
                    , i.IsPrintedOnFiscalPrinter
                    , i.ProgramVersion
                    , i.IsWaste
                    , i.IsOnline
                    , i.Partner != null ? new PartnerDTO(
                                                    i.Partner.CardCode ?? "NoCode"
                                                , i.Partner.Name
                                                , i.Partner.Vat
                                                , i.Partner.Zip
                                                , i.Partner.City
                                                ) : null
                    , i.Cashier != null ? new UserDTO(i.Cashier.Code, i.Cashier.Name) : null
                    , i.Shop != null ? new ShopDTO(
                              i.Shop.Code
                            , i.Shop.Name
                            , ""
                            , ""
                            , ""
                            , ""
                            , ""
                        ) : null
                    , i.Till != null ? new TillDTO(
                              i.Till.Code
                            , i.Till.Name
                            , i.Till.IpAddress
                            , i.Till.TillsReceiptPrinterModel
                            , i.Till.TillTypeId.ToString()
                        ) : null
                    , i.ScmReceiptItems
                        .OrderBy(r => r.Id)
                        .Select(r => new RowDto(
                              r.Id
                            , r.CategoryCode
                            , r.VatCodeId
                            , r.Qty
                            , r.WaiterUserCode
                            , r.ItemDate
                            , r.DiscountRate
                            , r.HeaderId
                            , r.ProductCode
                            , r.FiscalNetAmount
                            , r.FiscalAmount
                            , r.UnitPrice
                            , r.GiftCode
                            , r.State
                            , r.Score
                            , r.SerialNumber
                            , r.ItemTime
                            , r.WaiterId
                            , r.Discountable
                            , r.Description
                            , r.ItemDatetime
                            , r.Barcode
                            , r.VatCode
                            , r.Reason
                            , r.DiscountFromTotal
                            , r.MixmatchCode
                            , r.DiscountAmount
                            , r.ProductType
                            , r.ProductId
                            , r.MessageText
                            , r.Amount
                            , r.VatRate
                            , r.NetAmount
                            , r.Weight
                            , r.FatherProduct
                            , r.FatherProductId
                            , r.PriceListId
                            , r.PriceList
                            , r.ConsumedPoints
                            , r.ItemRealPrice
                            , r.ItemRealPriceFiscalNet
                            , r.ItemInmenuPrice
                            , r.ItemMenuPrice
                            , r.ItemMenuPriceFiscalNet
                            , r.ItemInmenuPriceFiscalNet
                            , r.ItemNotPrintable
                            , r.SuspensionTime
                            , r.ItemWineemotionBarcode
                            , r.DiscountOnRowId
                            , r.ItemPromoLabel
                            , r.ItemPromoId
                            , r.ItemTillId
                        ))
                        .ToList()
                    , i.ScmReceiptVats
                        .OrderBy(v => v.Id)
                        .Select(v => new VatDto(
                                  v.Id
                                , v.VatAmount
                                , v.AccountTaxId
                                , v.HeaderId
                                , v.NetAmount
                                , v.GrossAmount
                        ))
                        .ToList()
                    , i.ScmReceiptPayments
                        .OrderBy(p => p.Id)
                        .Select(p => new PaymentDto(
                                  p.Id
                                , p.PaymentId
                                , p.PaymentDate
                                , p.PaymentDatetime
                                , p.Code
                                , p.PaymentTime
                                , p.Qty
                                , p.Currency
                                , p.Amount
                                , p.TicketCode
                                , p.HeaderId
                                , p.Type
                                , p.IsRechargeTicket
                                , p.PaymentTip
                                , p.TicketIsDematerialized
                                , p.TicketCodeline
                                , p.SatispayPaymentId
                        ))
                        .ToList()
                ))
                .ToListAsync(ct);
    }


}
