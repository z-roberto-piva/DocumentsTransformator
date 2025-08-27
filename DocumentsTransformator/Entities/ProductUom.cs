using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// Product Unit of Measure
/// </summary>
public partial class ProductUom
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Type
    /// </summary>
    public string UomType { get; set; } = null!;

    /// <summary>
    /// Category
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Unit of Measure
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Rounding Precision
    /// </summary>
    public decimal Rounding { get; set; }

    /// <summary>
    /// Ratio
    /// </summary>
    public decimal Factor { get; set; }

    /// <summary>
    /// Active
    /// </summary>
    public bool? Active { get; set; }

    public virtual ICollection<ProductTemplate> ProductTemplateUomPos { get; set; } = new List<ProductTemplate>();

    public virtual ICollection<ProductTemplate> ProductTemplateUoms { get; set; } = new List<ProductTemplate>();

    public virtual ICollection<ProductTemplate> ProductTemplateUos { get; set; } = new List<ProductTemplate>();
}
