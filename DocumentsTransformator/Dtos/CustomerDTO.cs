namespace DocumentsTransformator.Dtos;
public sealed record CustomerDTO(
    string Code,
    string? Name,
    string? VatNumber,
    string? Zip,
    string? City
);