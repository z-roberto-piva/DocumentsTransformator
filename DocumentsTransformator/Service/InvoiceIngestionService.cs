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

    public async Task RunAsync(CancellationToken ct = default)
    {
        await EnsureIndexAsync(ct);

        var total = await _db.ScmReceiptHeaders.AsNoTracking().CountAsync(ct);
        Console.WriteLine($"[Invoices] Totali: {total}");

        for (int skip = 0; skip < total; skip += _batchSize)
        {
            var chunk = await _db.ScmReceiptHeaders
                .AsNoTracking()
                .OrderBy(i => i.Id)
                .Skip(skip).Take(_batchSize)
                .Select(i => new DocumentDTO(
                      Id: i.Id
                    , ReceiptRealDatetime: i.ReceiptRealDatetime
                    , TillCode: i.TillCode
                    , CancelUserId: i.CancelUserId
                    , Canceled: i.Canceled
                    , ShopId: i.ShopId
                    , CashierId: i.CashierId
                    , TillId: i.TillId
                    , Total: i.Total
                    , PartnerId: i.PartnerId
                    , ReceiptDate: i.ReceiptDate
                    , IsReversal: i.IsReversal
                    , ReceiptTime: i.ReceiptTime
                    , ReversedTransactionId: i.ReversedTransactionId
                    , ShopCode: i.ShopCode
                    , FiscalNumber: i.FiscalNumber
                    , TransactionNumber: i.TransactionNumber
                    , Reason: i.Reason
                    , PartnerAnomaly: i.PartnerAnomaly
                    , InvoiceNumber: i.InvoiceNumber
                    , HallCode: i.HallCode
                    , NumberOfItems: i.NumberOfItems
                    , CoverChargeQty: i.CoverChargeQty
                    , BookkeepingDate: i.BookkeepingDate
                    , CashierUserCode: i.CashierUserCode
                    , ReversalTransactionId: i.ReversalTransactionId
                    , ReferenceReceipt: i.ReferenceReceipt
                    , CancelDate: i.CancelDate
                    , CustomerNumber: i.CustomerNumber
                    , TableCode: i.TableCode
                    , ReceiptDatetime: i.ReceiptDatetime
                    , ServiceId: i.ServiceId
                    , Provenience: i.Provenience
                    , CompanyCurrencyId: i.CompanyCurrencyId
                    , TotalWithoutTaxes: i.TotalWithoutTaxes
                    , AccountInvoiceId: i.AccountInvoiceId
                    , ZReportNumber: i.ZReportNumber
                    , IsManual: i.IsManual
                    , TicketsCount: i.TicketsCount
                    , OperatorShiftId: i.OperatorShiftId
                    , TotalTaxes: i.TotalTaxes
                    , TemporaryBillPrinted: i.TemporaryBillPrinted
                    , DiscountOnTotalValue: i.DiscountOnTotalValue
                    , ReferenceZreport: i.ReferenceZreport
                    , ServiceTimeSlot: i.ServiceTimeSlot
                    , LotteryCode: i.LotteryCode
                    , IsPrintedOnFiscalPrinter: i.IsPrintedOnFiscalPrinter
                    , ProgramVersion: i.ProgramVersion
                    , IsWaste: i.IsWaste
                    , IsOnline: i.IsOnline
                    , Customer: i.Partner != null ? new PartnerDTO(
                                                              Code: i.Partner.CardCode ?? "NoCode"
                                                            , Name: i.Partner.Name
                                                            , VatNumber: i.Partner.Vat
                                                            , Zip: i.Partner.Zip
                                                            , City: i.Partner.City
                                                            ) : null
                    , Cashier: i.Cashier != null ? new UserDTO(i.Cashier.Code, i.Cashier.Name) : null
                    , Shop: i.Shop != null ? new ShopDTO(
                              Code: i.Shop.Code
                            , Name: i.Shop.Name
                            , Address: ""
                            , City: ""
                            , Zip: ""
                            , Province: ""
                            , Country: ""
                        ) : null
                    , Till: i.Till != null ? new TillDTO(
                            Code: i.Till.Code
                            , Name: i.Till.Name
                            , IpAddress: i.Till.IpAddress
                            , PrinterModel: i.Till.TillsReceiptPrinterModel
                            , TillType: i.Till.TillTypeId.ToString()
                        ) : null
                    , Rows: i.ScmReceiptItems
                        .OrderBy(r => r.Id)
                        .Select(r => new RowDto(
                              Id: r.Id
                            , CategoryCode: r.CategoryCode
                            , VatCodeId: r.VatCodeId
                            , Qty: r.Qty
                            , WaiterUserCode: r.WaiterUserCode
                            , ItemDate: r.ItemDate
                            , DiscountRate: r.DiscountRate
                            , HeaderId: r.HeaderId
                            , ProductCode: r.ProductCode
                            , FiscalNetAmount: r.FiscalNetAmount
                            , FiscalAmount: r.FiscalAmount
                            , UnitPrice: r.UnitPrice
                            , GiftCode: r.GiftCode
                            , State: r.State
                            , Score: r.Score
                            , SerialNumber: r.SerialNumber
                            , ItemTime: r.ItemTime
                            , WaiterId: r.WaiterId
                            , Discountable: r.Discountable
                            , Description: r.Description
                            , ItemDatetime: r.ItemDatetime
                            , Barcode: r.Barcode
                            , VatCode: r.VatCode
                            , Reason: r.Reason
                            , DiscountFromTotal: r.DiscountFromTotal
                            , MixmatchCode: r.MixmatchCode
                            , DiscountAmount: r.DiscountAmount
                            , ProductType: r.ProductType
                            , ProductId: r.ProductId
                            , MessageText: r.MessageText
                            , Amount: r.Amount
                            , VatRate: r.VatRate
                            , NetAmount: r.NetAmount
                            , Weight: r.Weight
                            , FatherProduct: r.FatherProduct
                            , FatherProductId: r.FatherProductId
                            , PriceListId: r.PriceListId
                            , PriceList: r.PriceList
                            , ConsumedPoints: r.ConsumedPoints
                            , ItemRealPrice: r.ItemRealPrice
                            , ItemRealPriceFiscalNet: r.ItemRealPriceFiscalNet
                            , ItemInmenuPrice: r.ItemInmenuPrice
                            , ItemMenuPrice: r.ItemMenuPrice
                            , ItemMenuPriceFiscalNet: r.ItemMenuPriceFiscalNet
                            , ItemInmenuPriceFiscalNet: r.ItemInmenuPriceFiscalNet
                            , ItemNotPrintable: r.ItemNotPrintable
                            , SuspensionTime: r.SuspensionTime
                            , ItemWineemotionBarcode: r.ItemWineemotionBarcode
                            , DiscountOnRowId: r.DiscountOnRowId
                            , ItemPromoLabel: r.ItemPromoLabel
                            , ItemPromoId: r.ItemPromoId
                            , ItemTillId: r.ItemTillId
                        ))
                        .ToList()
                    , Vats: i.ScmReceiptVats
                        .OrderBy(v => v.Id)
                        .Select(v => new VatDto(
                                Id: v.Id
                                , VatAmount: v.VatAmount
                                , AccountTaxId: v.AccountTaxId
                                , HeaderId: v.HeaderId
                                , NetAmount: v.NetAmount
                                , GrossAmount: v.GrossAmount
                        ))
                        .ToList()
                    , Payments: i.ScmReceiptPayments
                        .OrderBy(p => p.Id)
                        .Select(p => new PaymentDto(
                                  Id: p.Id
                                , PaymentId: p.PaymentId
                                , PaymentDate: p.PaymentDate
                                , PaymentDatetime: p.PaymentDatetime
                                , Code: p.Code
                                , PaymentTime: p.PaymentTime
                                , Qty: p.Qty
                                , Currency: p.Currency
                                , Amount: p.Amount
                                , TicketCode: p.TicketCode
                                , HeaderId: p.HeaderId
                                , Type: p.Type
                                , IsRechargeTicket: p.IsRechargeTicket
                                , PaymentTip: p.PaymentTip
                                , TicketIsDematerialized: p.TicketIsDematerialized
                                , TicketCodeline: p.TicketCodeline
                                , SatispayPaymentId: p.SatispayPaymentId
                        ))
                        .ToList()
                ))
                .ToListAsync(ct);

            if (chunk.Count == 0) break;

            var bulk = await _os.BulkAsync(b => b
                .Index(_index)
                .IndexMany(chunk, d => d.Id(doc => doc.Id)), ct);

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
                    .Nested<RowDto>(n => n.Name(p => p.Rows).AutoMap())
                    .Nested<VatDto>(n => n.Name(p => p.Vats).AutoMap())
                    .Nested<PaymentDto>(n => n.Name(p => p.Payments).AutoMap())
                )
            ), ct);

        if (!create.IsValid)
            throw new InvalidOperationException($"Creazione indice '{_index}' fallita: {create.ServerError}");
    }
}
