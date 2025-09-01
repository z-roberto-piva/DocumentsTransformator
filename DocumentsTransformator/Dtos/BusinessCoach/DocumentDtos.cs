namespace DocumentsTransformator.Dtos.BusinessCoach;

public sealed record BusinessCoachDocumentDto(
    string ExternalId,
    string ServiceType,
    DateTime BillDateTime,
    int Covers,
    string TableCode,
    RoomDto Room,
    OperatorDto Operator,
    DocumentTypeDto DocumentType,
    ShiftDto Shift,
    CashDeskDto CashDesk,
    IReadOnlyList<DetailDto> Details,
    IReadOnlyList<PaymentDetailDto> PaymentDetails
);

public sealed record RoomDto(
    string ExternalId,
    string? Name
);

public sealed record OperatorDto(
    string ExternalId,
    string? Name
);

public sealed record DocumentTypeDto(
    string ExternalId,
    string? Name
);

public sealed record ShiftDto(
    string ExternalId,
    string? Name
);

public sealed record CashDeskDto(
    string ExternalId,
    string? Name
);

public sealed record CategoryDto(
    string ExternalId,
    string? Name
);

public sealed record ProductDto(
    string ExternalId,
    string? Name,
    CategoryDto Category
);

public sealed record DetailDto(
    string Type,
    string ExternalId,
    int RowNumber,
    ProductDto Product,
    decimal Quantity,
    decimal TotalIncome,
    decimal Vat
);

public sealed record PaymentDetailDto(
    string ExternalId,
    decimal Amount,
    string Category,
    string? PaymentMethodDescription,
    string? TerminalId,
    string? Acquirer,
    string? Application,
    string? PaymentType
);

