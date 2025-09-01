namespace DocumentsTransformator.Entities.BusinessCoach;

public class BusinessCoachDocument
{
    public string ExternalId { get; set; } = string.Empty;
    public string ServiceType { get; set; } = string.Empty;
    public DateTime BillDateTime { get; set; }
    public int Covers { get; set; }
    public string TableCode { get; set; } = string.Empty;
    public Room Room { get; set; } = new();
    public Operator Operator { get; set; } = new();
    public DocumentType DocumentType { get; set; } = new();
    public Shift Shift { get; set; } = new();
    public CashDesk CashDesk { get; set; } = new();
    public List<Detail> Details { get; set; } = new();
    public List<PaymentDetail> PaymentDetails { get; set; } = new();
}

public class Room
{
    public string ExternalId { get; set; } = string.Empty;
    public string? Name { get; set; }
}

public class Operator
{
    public string ExternalId { get; set; } = string.Empty;
    public string? Name { get; set; }
}

public class DocumentType
{
    public string ExternalId { get; set; } = string.Empty;
    public string? Name { get; set; }
}

public class Shift
{
    public string ExternalId { get; set; } = string.Empty;
    public string? Name { get; set; }
}

public class CashDesk
{
    public string ExternalId { get; set; } = string.Empty;
    public string? Name { get; set; }
}

public class Category
{
    public string ExternalId { get; set; } = string.Empty;
    public string? Name { get; set; }
}

public class Product
{
    public string ExternalId { get; set; } = string.Empty;
    public string? Name { get; set; }
    public Category Category { get; set; } = new();
}

public class Detail
{
    public string Type { get; set; } = string.Empty;
    public string ExternalId { get; set; } = string.Empty;
    public int RowNumber { get; set; }
    public Product Product { get; set; } = new();
    public decimal Quantity { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal Vat { get; set; }
}

public class PaymentDetail
{
    public string ExternalId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Category { get; set; } = string.Empty;
    public string? PaymentMethodDescription { get; set; }
    public string? TerminalId { get; set; }
    public string? Acquirer { get; set; }
    public string? Application { get; set; }
    public string? PaymentType { get; set; }
}

