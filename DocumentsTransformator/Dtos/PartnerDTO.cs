namespace DocumentsTransformator.Dtos;

public sealed record PartnerDTO(
    string Code,
    string? Name,
    string? VatNumber,
    string? Zip,
    string? City
);
