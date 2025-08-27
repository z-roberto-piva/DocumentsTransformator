using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// Product Template
/// </summary>
public partial class ProductTemplate
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Warranty
    /// </summary>
    public double? Warranty { get; set; }

    /// <summary>
    /// Unit of Sale
    /// </summary>
    public int? UosId { get; set; }

    /// <summary>
    /// Sale Price
    /// </summary>
    public decimal? ListPrice { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gross Weight
    /// </summary>
    public decimal? Weight { get; set; }

    /// <summary>
    /// Net Weight
    /// </summary>
    public decimal? WeightNet { get; set; }

    /// <summary>
    /// Cost
    /// </summary>
    public decimal? StandardPrice { get; set; }

    /// <summary>
    /// Measure Type
    /// </summary>
    public string? MesType { get; set; }

    /// <summary>
    /// Unit of Measure
    /// </summary>
    public int UomId { get; set; }

    /// <summary>
    /// Purchase Description
    /// </summary>
    public string? DescriptionPurchase { get; set; }

    /// <summary>
    /// Costing Method
    /// </summary>
    public string CostMethod { get; set; } = null!;

    /// <summary>
    /// Category
    /// </summary>
    public int CategId { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Unit of Measure -&gt; UOS Coeff
    /// </summary>
    public decimal? UosCoeff { get; set; }

    /// <summary>
    /// Volume
    /// </summary>
    public double? Volume { get; set; }

    /// <summary>
    /// Can be Sold
    /// </summary>
    public bool? SaleOk { get; set; }

    /// <summary>
    /// Sale Description
    /// </summary>
    public string? DescriptionSale { get; set; }

    /// <summary>
    /// Product Manager
    /// </summary>
    public int? ProductManager { get; set; }

    /// <summary>
    /// Company
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Manufacturing Lead Time
    /// </summary>
    public double? ProduceDelay { get; set; }

    /// <summary>
    /// Purchase Unit of Measure
    /// </summary>
    public int UomPoId { get; set; }

    /// <summary>
    /// Can be Rent
    /// </summary>
    public bool? Rental { get; set; }

    /// <summary>
    /// Product Type
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// Rack
    /// </summary>
    public string? LocRack { get; set; }

    /// <summary>
    /// Row
    /// </summary>
    public string? LocRow { get; set; }

    /// <summary>
    /// Customer Lead Time
    /// </summary>
    public double? SaleDelay { get; set; }

    /// <summary>
    /// Case
    /// </summary>
    public string? LocCase { get; set; }

    /// <summary>
    /// Supply Method
    /// </summary>
    public string SupplyMethod { get; set; } = null!;

    /// <summary>
    /// Procurement Method
    /// </summary>
    public string ProcureMethod { get; set; } = null!;

    /// <summary>
    /// Can be Purchased
    /// </summary>
    public bool? PurchaseOk { get; set; }

    /// <summary>
    /// Sub Family
    /// </summary>
    public int? SubfamilyId { get; set; }

    /// <summary>
    /// Fiscal category
    /// </summary>
    public int? FiscalCategId { get; set; }

    public virtual ProductCategory Categ { get; set; } = null!;

    public virtual ProductCategory? FiscalCateg { get; set; }

    public virtual ICollection<ProductProduct> ProductProducts { get; set; } = new List<ProductProduct>();

    public virtual ProductCategory? Subfamily { get; set; }

    public virtual ProductUom Uom { get; set; } = null!;

    public virtual ProductUom UomPo { get; set; } = null!;

    public virtual ProductUom? Uos { get; set; }
}
