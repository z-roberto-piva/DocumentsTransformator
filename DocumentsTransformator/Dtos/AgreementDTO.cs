namespace DocumentsTransformator.Dtos;

public sealed record AgreementDto(
      int Id
    , string? Code
    , int? AgreementId
    , string? AgreementCode
    , string? AgreementName
    , decimal? Extra
    , string? AgreementDate
    , DateTime? AgreementDatetime
    , decimal? Qty
    , string? DiscountType
    , decimal? Amount
    , int? Score
    , string? Type
    , string? Badge
    , string? AgreementTime
    , decimal? DiscountAmount
);