using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.coupons_detail
/// </summary>
public partial class ScmReceiptCouponsDetail
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
    /// Coupon Code
    /// </summary>
    public string? CouponCode { get; set; }

    /// <summary>
    /// Coupon Quantity
    /// </summary>
    public int? CouponQty { get; set; }

    public virtual ScmReceiptHeader? Header { get; set; }
}
