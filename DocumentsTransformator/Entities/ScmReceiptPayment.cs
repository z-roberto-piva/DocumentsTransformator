using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.payments
/// </summary>
public partial class ScmReceiptPayment
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
    /// Payment Date
    /// </summary>
    public string? PaymentDate { get; set; }

    /// <summary>
    /// Receipt Datetime
    /// </summary>
    public DateTime? PaymentDatetime { get; set; }

    /// <summary>
    /// Payment Code
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Payment Time
    /// </summary>
    public string? PaymentTime { get; set; }

    /// <summary>
    /// Payment Quantity
    /// </summary>
    public decimal? Qty { get; set; }

    /// <summary>
    /// Payment Currency
    /// </summary>
    public string? Currency { get; set; }

    /// <summary>
    /// Payment Amount
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Payment Ticket Code
    /// </summary>
    public string? TicketCode { get; set; }

    /// <summary>
    /// Header
    /// </summary>
    public int? HeaderId { get; set; }

    /// <summary>
    /// Payment Type
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Recharge Ticket
    /// </summary>
    public bool? IsRechargeTicket { get; set; }

    /// <summary>
    /// Payment Tip
    /// </summary>
    public decimal? PaymentTip { get; set; }

    /// <summary>
    /// Ticket is Dematerialized
    /// </summary>
    public bool? TicketIsDematerialized { get; set; }

    /// <summary>
    /// Ticket Codeline
    /// </summary>
    public string? TicketCodeline { get; set; }

    /// <summary>
    /// Satispay Payment ID
    /// </summary>
    public string? SatispayPaymentId { get; set; }

    /// <summary>
    /// Payment Unit Value
    /// </summary>
    public decimal? UnitValue { get; set; }

    public virtual ScmReceiptHeader? Header { get; set; }

    public virtual ScmPayment? Payment { get; set; }
}
