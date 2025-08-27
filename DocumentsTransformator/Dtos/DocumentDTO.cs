
namespace DocumentsTransformator.Dtos;

public sealed record DocumentDTO(
    int Id,
    DateTime? ReceiptRealDatetime,
    string? TillCode,
    int? CancelUserId,
    bool? Canceled,
    int? ShopId,
    int? CashierId,
    int? TillId,
    decimal? Total,
    int? PartnerId,
    string? ReceiptDate,
    // bool? Handled
    // int? CompanyId
    bool? IsReversal,
    string? ReceiptTime,
    int? ReversedTransactionId,
    string? ShopCode,
    int? FiscalNumber,
    string? TransactionNumber,
    string? Reason,
    bool? PartnerAnomaly,
    string? InvoiceNumber,
    string? HallCode,
    int? NumberOfItems,
    int? CoverChargeQty,
    DateOnly? BookkeepingDate,
    string? CashierUserCode,
    int? ReversalTransactionId,
    string? ReferenceReceipt,
    DateTime? CancelDate,
    string? CustomerNumber,
    string? TableCode,
    DateTime? ReceiptDatetime,
    int? ServiceId,
    string? Provenience,
    int? CompanyCurrencyId,
    decimal? TotalWithoutTaxes,
    // int? PointsCampaignId
    int? AccountInvoiceId,
    int? ZReportNumber,
    // string? FiscalPrinterId
    // int? AppOrderId
    bool? IsManual,
    int? TicketsCount,
    int? OperatorShiftId,
    decimal? TotalTaxes,
    bool? TemporaryBillPrinted,
    double? DiscountOnTotalValue,
    // int? DiscountOnTotalId
    // string? ExtraOrderServiceName
    int? ReferenceZreport,
    // int? LinkedTransactionId
    // string? ExtraOrderId
    string? ServiceTimeSlot,
    string? LotteryCode,
    bool? IsPrintedOnFiscalPrinter,
    string? ProgramVersion,
    bool? IsWaste,
    bool? IsOnline,

    PartnerDTO? Customer,
    UserDTO? Cashier,
    ShopDTO? Shop,
    TillDTO? Till,
    IReadOnlyList<RowDto>? Rows,
    IReadOnlyList<VatDto>? Vats,
    IReadOnlyList<PaymentDto>? Payments
);