using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.profit_centers
/// </summary>
public partial class ScmReceiptProfitCenter
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Header
    /// </summary>
    public int? HeaderId { get; set; }

    /// <summary>
    /// Amount
    /// </summary>
    public decimal? Amounts { get; set; }

    /// <summary>
    /// Covers Quantity
    /// </summary>
    public decimal? QtyCovers { get; set; }

    /// <summary>
    /// Profit Center
    /// </summary>
    public int? ProfitCenterId { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    public decimal? Qty { get; set; }

    public virtual ScmReceiptHeader? Header { get; set; }
}
