namespace DocumentsTransformator.Dtos;

public sealed record TillDTO(
    string Code,
    string? Name,
    string? IpAddress,
    string? PrinterModel,
    string? TillType
);
