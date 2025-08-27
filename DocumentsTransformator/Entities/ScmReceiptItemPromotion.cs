using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.item.promotions
/// </summary>
public partial class ScmReceiptItemPromotion
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Promotion Category Code
    /// </summary>
    public string? CategoryCode { get; set; }

    /// <summary>
    /// Promotion Code
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Promotion Group Mixmatch
    /// </summary>
    public decimal? GroupMixMatch { get; set; }

    /// <summary>
    /// Promotion Bonus
    /// </summary>
    public decimal? Bonus { get; set; }

    /// <summary>
    /// Item
    /// </summary>
    public int? ItemId { get; set; }

    /// <summary>
    /// Promotion Quantity
    /// </summary>
    public decimal? Qty { get; set; }

    /// <summary>
    /// Promotion Discount Type
    /// </summary>
    public string? DiscountType { get; set; }

    /// <summary>
    /// Promotion Quantity Discount
    /// </summary>
    public decimal? QuantityDiscounted { get; set; }

    /// <summary>
    /// Promotion Initiative
    /// </summary>
    public string? Initiative { get; set; }

    /// <summary>
    /// Promotion Threshold
    /// </summary>
    public decimal? Threshold { get; set; }

    /// <summary>
    /// Promotion Thresold Discount
    /// </summary>
    public decimal? ThresholdDiscount { get; set; }

    /// <summary>
    /// Promotion Points
    /// </summary>
    public decimal? Points { get; set; }

    public virtual ScmReceiptItem? Item { get; set; }
}
