namespace DocumentsTransformator.Dtos;

public sealed record PaymentDto(
      int Id
    , int? PaymentId
    , string? PaymentDate
    , DateTime? PaymentDatetime
    , string? PaymentCode
    , string? PaymentName
    , string? PaymentTime
    , decimal? Qty
    , string? Currency
    , decimal? Amount
    , string? TicketCode
    , int? HeaderId
    , string? Type
    , bool? IsRechargeTicket
    , decimal? PaymentTip
    , bool? TicketIsDematerialized
    , string? TicketCodeline
    , string? SatispayPaymentId
);
