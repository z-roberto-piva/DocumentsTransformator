namespace DocumentsTransformator.Dtos;

public sealed record ShopDTO(
    string Code,
    string? Name,
    string? Address,
    string? City,
    string? Zip,
    string? Province,
    string? Country
);
