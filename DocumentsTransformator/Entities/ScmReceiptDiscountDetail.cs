using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.discount.details
/// </summary>
public partial class ScmReceiptDiscountDetail
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Discount Mechanics
    /// </summary>
    public string? Mechanics { get; set; }

    /// <summary>
    /// Discount Category Code
    /// </summary>
    public string? CategoryCode { get; set; }

    /// <summary>
    /// Total amount
    /// </summary>
    public decimal? TotalAmount { get; set; }

    /// <summary>
    /// Accumulator
    /// </summary>
    public decimal? Accumulator { get; set; }

    /// <summary>
    /// Coupon
    /// </summary>
    public string? Coupon { get; set; }

    /// <summary>
    /// Text
    /// </summary>
    public string? MessageText { get; set; }

    /// <summary>
    /// Total rate
    /// </summary>
    public decimal? TotalRate { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    public decimal? Qty { get; set; }

    /// <summary>
    /// Discount
    /// </summary>
    public int? DiscountId { get; set; }

    /// <summary>
    /// Header
    /// </summary>
    public int? HeaderId { get; set; }

    /// <summary>
    /// Points
    /// </summary>
    public decimal? Points { get; set; }

    /// <summary>
    /// Discount Initiative
    /// </summary>
    public string? Initiative { get; set; }

    /// <summary>
    /// Threshold
    /// </summary>
    public decimal? Threshold { get; set; }

    /// <summary>
    /// Discount Code
    /// </summary>
    public string? DiscountCode { get; set; }

    public virtual ScmReceiptHeader? Header { get; set; }
}
