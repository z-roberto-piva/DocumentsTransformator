using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// Tax
/// </summary>
public partial class AccountTax
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Refund Base Code
    /// </summary>
    public int? RefBaseCodeId { get; set; }

    /// <summary>
    /// Domain
    /// </summary>
    public string? Domain { get; set; }

    /// <summary>
    /// Tax Code
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Refund Tax Code
    /// </summary>
    public int? RefTaxCodeId { get; set; }

    /// <summary>
    /// Sequence
    /// </summary>
    public int Sequence { get; set; }

    /// <summary>
    /// Refund Tax Account
    /// </summary>
    public int? AccountPaidId { get; set; }

    /// <summary>
    /// Base Code Sign
    /// </summary>
    public decimal? RefBaseSign { get; set; }

    /// <summary>
    /// Tax Application
    /// </summary>
    public string TypeTaxUse { get; set; } = null!;

    /// <summary>
    /// Account Base Code
    /// </summary>
    public int? BaseCodeId { get; set; }

    /// <summary>
    /// Base Code Sign
    /// </summary>
    public decimal? BaseSign { get; set; }

    /// <summary>
    /// Tax on Children
    /// </summary>
    public bool? ChildDepend { get; set; }

    /// <summary>
    /// Included in base amount
    /// </summary>
    public bool? IncludeBaseAmount { get; set; }

    /// <summary>
    /// Invoice Tax Analytic Account
    /// </summary>
    public int? AccountAnalyticCollectedId { get; set; }

    /// <summary>
    /// Refund Tax Analytic Account
    /// </summary>
    public int? AccountAnalyticPaidId { get; set; }

    /// <summary>
    /// Active
    /// </summary>
    public bool? Active { get; set; }

    /// <summary>
    /// Tax Code Sign
    /// </summary>
    public decimal? RefTaxSign { get; set; }

    /// <summary>
    /// Applicability
    /// </summary>
    public string ApplicableType { get; set; } = null!;

    /// <summary>
    /// Invoice Tax Account
    /// </summary>
    public int? AccountCollectedId { get; set; }

    /// <summary>
    /// Company
    /// </summary>
    public int CompanyId { get; set; }

    /// <summary>
    /// Tax Name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Account Tax Code
    /// </summary>
    public int? TaxCodeId { get; set; }

    /// <summary>
    /// Parent Tax Account
    /// </summary>
    public int? ParentId { get; set; }

    /// <summary>
    /// Amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Python Code
    /// </summary>
    public string? PythonCompute { get; set; }

    /// <summary>
    /// Tax Code Sign
    /// </summary>
    public decimal? TaxSign { get; set; }

    /// <summary>
    /// Python Code (reverse)
    /// </summary>
    public string? PythonComputeInv { get; set; }

    /// <summary>
    /// Python Code
    /// </summary>
    public string? PythonApplicable { get; set; }

    /// <summary>
    /// Tax Type
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// Tax Included in Price
    /// </summary>
    public bool? PriceInclude { get; set; }

    /// <summary>
    /// Index on PI till
    /// </summary>
    public int? ScmPiIndex { get; set; }

    /// <summary>
    /// VAT payability
    /// </summary>
    public string? Payability { get; set; }

    /// <summary>
    /// Non taxable nature
    /// </summary>
    public string? NonTaxableNature { get; set; }

    /// <summary>
    /// Exemption Kind
    /// </summary>
    public int? KindId { get; set; }

    public string? LawReference { get; set; }

    public virtual ICollection<AccountTax> InverseParent { get; set; } = new List<AccountTax>();

    public virtual AccountTax? Parent { get; set; }

    public virtual ICollection<ScmPayment> ScmPayments { get; set; } = new List<ScmPayment>();

    public virtual ICollection<ScmReceiptItem> ScmReceiptItems { get; set; } = new List<ScmReceiptItem>();

    public virtual ICollection<ScmReceiptPaymentDivision> ScmReceiptPaymentDivisions { get; set; } = new List<ScmReceiptPaymentDivision>();

    public virtual ICollection<ScmReceiptVat> ScmReceiptVats { get; set; } = new List<ScmReceiptVat>();

    public virtual ICollection<ScmShop> ScmShops { get; set; } = new List<ScmShop>();
}
