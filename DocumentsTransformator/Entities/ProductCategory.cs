using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// Product Category
/// </summary>
public partial class ProductCategory
{
    public int Id { get; set; }

    public int? ParentLeft { get; set; }

    public int? ParentRight { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Sequence
    /// </summary>
    public int? Sequence { get; set; }

    /// <summary>
    /// Parent Category
    /// </summary>
    public int? ParentId { get; set; }

    /// <summary>
    /// Category Type
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Code
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// Is for statistics
    /// </summary>
    public bool? IsForStatistics { get; set; }

    /// <summary>
    /// Is sub family
    /// </summary>
    public bool? IsSubFamily { get; set; }

    /// <summary>
    /// Color
    /// </summary>
    public int? PiColor { get; set; }

    /// <summary>
    /// Not Printable on Fiscal
    /// </summary>
    public bool? NotPrintableOnFiscal { get; set; }

    /// <summary>
    /// Tax
    /// </summary>
    public int? ScmTaxId { get; set; }

    /// <summary>
    /// Discountable
    /// </summary>
    public bool? NxDiscountable { get; set; }

    /// <summary>
    /// Is No Food
    /// </summary>
    public bool? IsNoFood { get; set; }

    /// <summary>
    /// Sale Type
    /// </summary>
    public string? SaleType { get; set; }

    /// <summary>
    /// Is for value assignement
    /// </summary>
    public bool? IsForValueAssignement { get; set; }

    /// <summary>
    /// Is for Fees
    /// </summary>
    public bool? IsForFees { get; set; }

    /// <summary>
    /// Print On Secondary Fiscal Printer
    /// </summary>
    public bool? PrintOnSecondaryFiscalPrinter { get; set; }

    /// <summary>
    /// Business Central Code Prefix
    /// </summary>
    public string? BusinessCentralCodePrefix { get; set; }

    public virtual ICollection<ProductCategory> InverseParent { get; set; } = new List<ProductCategory>();

    public virtual ProductCategory? Parent { get; set; }

    public virtual ICollection<ProductTemplate> ProductTemplateCategs { get; set; } = new List<ProductTemplate>();

    public virtual ICollection<ProductTemplate> ProductTemplateFiscalCategs { get; set; } = new List<ProductTemplate>();

    public virtual ICollection<ProductTemplate> ProductTemplateSubfamilies { get; set; } = new List<ProductTemplate>();
}
