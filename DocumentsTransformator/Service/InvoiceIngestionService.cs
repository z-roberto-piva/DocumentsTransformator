// InvoiceIngestionService.cs
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
    private readonly int _batchSize = int.TryParse(cfg["BatchSize"], out var b) ? b : 2000;
    private readonly int? maxRecords = int.TryParse(cfg["MaxNumberOfDocuments"], out var m) ? m : null;

    public async Task RunAsync(CancellationToken ct = default)
    {
        await EnsureIndexAsync(ct);

        var total = await _db.ScmReceiptHeaders.AsNoTracking().CountAsync(ct);
        Console.WriteLine($"[Invoices] Totali: {total}");

        for (int skip = 0; skip < total; skip += _batchSize)
        {
            if (maxRecords.HasValue && skip >= maxRecords.Value)
            {
                Console.WriteLine($"[Invoices] Limite massimo di documenti ({maxRecords.Value}) raggiunto. Interrompo l'elaborazione.");
                break;
            }
            var chunk = await _db.ScmReceiptHeaders
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

            if (chunk.Count == 0) break;

            var bulk = await _os.BulkAsync(b => b
                .Index(_index)
                .IndexMany(chunk, (descriptor, doc) => descriptor.Id(doc.Id)), ct);

            if (bulk.Errors)
            {
                var errors = string.Join("; ", bulk.ItemsWithErrors.Select(e => $"{e.Id}:{e.Error?.Reason}"));
                throw new InvalidOperationException($"Bulk fallito: {errors}");
            }

            Console.WriteLine($"Indicizzate {skip + chunk.Count}/{total}");
        }

        await _os.Indices.RefreshAsync(_index, r => r, ct);
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
}
