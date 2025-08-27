using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.vats
/// </summary>
public partial class ScmReceiptVat
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Tax Amount
    /// </summary>
    public decimal? VatAmount { get; set; }

    /// <summary>
    /// Tax Code
    /// </summary>
    public int? AccountTaxId { get; set; }

    /// <summary>
    /// Header
    /// </summary>
    public int? HeaderId { get; set; }

    /// <summary>
    /// Net Amount
    /// </summary>
    public decimal? NetAmount { get; set; }

    /// <summary>
    /// Gross Amount
    /// </summary>
    public decimal? GrossAmount { get; set; }

    public virtual AccountTax? AccountTax { get; set; }

    public virtual ScmReceiptHeader? Header { get; set; }
}
