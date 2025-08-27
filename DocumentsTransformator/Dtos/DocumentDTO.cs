
namespace DocumentsTransformator.Dtos;

public sealed record DocumentDTO(
    int Id,
    IReadOnlyList<RowDto> Rows,
    IReadOnlyList<VatDto> Vats,
    IReadOnlyList<PaymentDto> Payments
);