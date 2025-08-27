namespace DocumentsTransformator.Dtos;

public sealed record VatDto(
      int Id
    , decimal? VatAmount
    , int? AccountTaxId
    , int? HeaderId
    , decimal? NetAmount
    , decimal? GrossAmount
);
