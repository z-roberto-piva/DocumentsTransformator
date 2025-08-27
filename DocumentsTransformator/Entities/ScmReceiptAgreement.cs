using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.agreements
/// </summary>
public partial class ScmReceiptAgreement
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Agreement Code
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Agreement
    /// </summary>
    public int? AgreementId { get; set; }

    /// <summary>
    /// Agreement Extra
    /// </summary>
    public decimal? Extra { get; set; }

    /// <summary>
    /// Agreement Date
    /// </summary>
    public string? AgreementDate { get; set; }

    /// <summary>
    /// Agreement Datetime
    /// </summary>
    public DateTime? AgreementDatetime { get; set; }

    /// <summary>
    /// Agreement Quantity
    /// </summary>
    public decimal? Qty { get; set; }

    /// <summary>
    /// Agreement Discount Type
    /// </summary>
    public string? DiscountType { get; set; }

    /// <summary>
    /// Agreement Amount
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Agreement Score
    /// </summary>
    public int? Score { get; set; }

    /// <summary>
    /// Agreement Type
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Header
    /// </summary>
    public int? HeaderId { get; set; }

    /// <summary>
    /// Agreement Badge
    /// </summary>
    public string? Badge { get; set; }

    /// <summary>
    /// Agreement Time
    /// </summary>
    public string? AgreementTime { get; set; }

    /// <summary>
    /// Agreement Discount Amount
    /// </summary>
    public decimal? DiscountAmount { get; set; }

    public virtual ScmReceiptHeader? Header { get; set; }
}
