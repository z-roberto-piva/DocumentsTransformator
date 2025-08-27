using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.analytic_items
/// </summary>
public partial class ScmReceiptAnalyticItem
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Category code
    /// </summary>
    public string? CategoryCode { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Weight
    /// </summary>
    public double? Weight { get; set; }

    /// <summary>
    /// Item Datetime
    /// </summary>
    public DateTime? ItemDatetime { get; set; }

    /// <summary>
    /// Till code
    /// </summary>
    public string? TillCode { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    public decimal? Qty { get; set; }

    /// <summary>
    /// Waiter User code
    /// </summary>
    public string? WaiterUserCode { get; set; }

    /// <summary>
    /// Till
    /// </summary>
    public int? TillId { get; set; }

    /// <summary>
    /// Reason
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// Date
    /// </summary>
    public string? ItemDate { get; set; }

    /// <summary>
    /// Item Datetime
    /// </summary>
    public DateTime? ItemRealDatetime { get; set; }

    /// <summary>
    /// Header
    /// </summary>
    public int? HeaderId { get; set; }

    /// <summary>
    /// Product Code
    /// </summary>
    public string? ProductCode { get; set; }

    /// <summary>
    /// Amount
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Product type
    /// </summary>
    public string? ProductType { get; set; }

    /// <summary>
    /// Product
    /// </summary>
    public int? ProductId { get; set; }

    /// <summary>
    /// Message text
    /// </summary>
    public string? MessageText { get; set; }

    /// <summary>
    /// Gift code
    /// </summary>
    public string? GiftCode { get; set; }

    /// <summary>
    /// Unit Price
    /// </summary>
    public decimal? UnitPrice { get; set; }

    /// <summary>
    /// Consumed Points
    /// </summary>
    public int? ConsumedPoints { get; set; }

    /// <summary>
    /// State
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Item Score
    /// </summary>
    public int? Score { get; set; }

    /// <summary>
    /// Item Real Price
    /// </summary>
    public decimal? ItemAppliedPrice { get; set; }

    /// <summary>
    /// Serial number
    /// </summary>
    public string? SerialNumber { get; set; }

    /// <summary>
    /// Time
    /// </summary>
    public string? ItemTime { get; set; }

    /// <summary>
    /// Waiter
    /// </summary>
    public int? WaiterId { get; set; }

    public virtual ScmReceiptHeader? Header { get; set; }

    public virtual ProductProduct? Product { get; set; }

    public virtual ScmTill? Till { get; set; }
}
