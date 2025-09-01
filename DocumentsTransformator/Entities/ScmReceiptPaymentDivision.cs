using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.payment_division
/// </summary>
public partial class ScmReceiptPaymentDivision
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Payment
    /// </summary>
    public int? PaymentId { get; set; }

    /// <summary>
    /// Vat
    /// </summary>
    public int? VatId { get; set; }

    /// <summary>
    /// Product
    /// </summary>
    public int? ProductId { get; set; }

    /// <summary>
    /// Amount Vat
    /// </summary>
    public double? VatAmount { get; set; }

    /// <summary>
    /// Header
    /// </summary>
    public int? HeaderId { get; set; }

    /// <summary>
    /// Net Amount Vat
    /// </summary>
    public double? NetAmountVat { get; set; }

    /// <summary>
    /// Gross Amount Vat
    /// </summary>
    public double? GrossAmountVat { get; set; }

    public virtual ScmReceiptHeader? Header { get; set; }

    public virtual ScmPayment? Payment { get; set; }

    public virtual ProductProduct? Product { get; set; }

    public virtual AccountTax? Vat { get; set; }
}
