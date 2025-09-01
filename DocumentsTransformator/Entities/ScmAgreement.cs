using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.agreements
/// </summary>
public partial class ScmAgreement
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Lock Manual Discount
    /// </summary>
    public bool? LockManualDiscount { get; set; }

    /// <summary>
    /// Active Saturday
    /// </summary>
    public bool? ActiveSat { get; set; }

    /// <summary>
    /// Code
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// Agreement Score
    /// </summary>
    public int? AgreementScore { get; set; }

    /// <summary>
    /// Active Wednesday
    /// </summary>
    public bool? ActiveWed { get; set; }

    /// <summary>
    /// Article Complete Meal
    /// </summary>
    public int? EanArticleComplete { get; set; }

    /// <summary>
    /// Discount Type
    /// </summary>
    public string? DiscountType { get; set; }

    /// <summary>
    /// Agreement Type
    /// </summary>
    public string AgreementType { get; set; } = null!;

    /// <summary>
    /// Active To
    /// </summary>
    public double? ActiveTo { get; set; }

    /// <summary>
    /// Export to host
    /// </summary>
    public bool? ExportToHost { get; set; }

    /// <summary>
    /// Active From
    /// </summary>
    public double? ActiveFrom { get; set; }

    /// <summary>
    /// Discount Amount
    /// </summary>
    public double? DiscountAmount { get; set; }

    /// <summary>
    /// Payment
    /// </summary>
    public int PaymentId { get; set; }

    /// <summary>
    /// Active Tuesday
    /// </summary>
    public bool? ActiveTue { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Max Passages
    /// </summary>
    public int? MaxPassages { get; set; }

    /// <summary>
    /// Active Sunday
    /// </summary>
    public bool? ActiveSun { get; set; }

    /// <summary>
    /// Track in agreement check
    /// </summary>
    public bool? TrackInAgreementCheck { get; set; }

    /// <summary>
    /// Enabled
    /// </summary>
    public bool? Enabled { get; set; }

    /// <summary>
    /// Note
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Article Fixed Amount
    /// </summary>
    public int? EanArticleFixedAmount { get; set; }

    /// <summary>
    /// Active Thursday
    /// </summary>
    public bool? ActiveThu { get; set; }

    /// <summary>
    /// Calculation Order
    /// </summary>
    public string? ScoreCalculationOrder { get; set; }

    /// <summary>
    /// Agreement Amount
    /// </summary>
    public double? AgreementAmount { get; set; }

    /// <summary>
    /// Active Friday
    /// </summary>
    public bool? ActiveFri { get; set; }

    /// <summary>
    /// Pricelist
    /// </summary>
    public int? PricelistId { get; set; }

    /// <summary>
    /// Article Supplement Agreement
    /// </summary>
    public int EanArticleSupplementAgr { get; set; }

    /// <summary>
    /// Discount only on Extra
    /// </summary>
    public bool? DiscountOnExtra { get; set; }

    /// <summary>
    /// Active Monday
    /// </summary>
    public bool? ActiveMon { get; set; }

    /// <summary>
    /// Show Remaining Poinits Warning
    /// </summary>
    public bool? ShowRemainingPointsWarning { get; set; }

    /// <summary>
    /// Default Invoicing Article
    /// </summary>
    public int? DefaultInvoicingArticle { get; set; }

    /// <summary>
    /// Agreement Fixed Amount
    /// </summary>
    public double? AgreementFixedAmount { get; set; }

    /// <summary>
    /// Discount on total applied on Extra
    /// </summary>
    public bool? DiscountOnTotalAppliedOnExtra { get; set; }

    public virtual ProductProduct? DefaultInvoicingArticleNavigation { get; set; }

    public virtual ProductProduct? EanArticleCompleteNavigation { get; set; }

    public virtual ProductProduct? EanArticleFixedAmountNavigation { get; set; }

    public virtual ProductProduct EanArticleSupplementAgrNavigation { get; set; } = null!;

    public virtual ScmPayment Payment { get; set; } = null!;

    public virtual ICollection<ScmReceiptAgreement> ScmReceiptAgreements { get; set; } = new List<ScmReceiptAgreement>();
}
