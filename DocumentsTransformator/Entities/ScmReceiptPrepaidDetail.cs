using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.prepaid.details
/// </summary>
public partial class ScmReceiptPrepaidDetail
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Prepaid Amount Discharged
    /// </summary>
    public decimal? AmountDischarged { get; set; }

    /// <summary>
    /// Prepaid Current Total Amount
    /// </summary>
    public decimal? CurrentTotalAmount { get; set; }

    /// <summary>
    /// Prepaid Amount Evaluation
    /// </summary>
    public decimal? AmountRevaluation { get; set; }

    /// <summary>
    /// Prepaid Amount Ticket
    /// </summary>
    public decimal? AmountTicket { get; set; }

    /// <summary>
    /// Header
    /// </summary>
    public int? HeaderId { get; set; }

    /// <summary>
    /// Prepaid Previous Amount Ticket
    /// </summary>
    public decimal? PreviousAmountTicket { get; set; }

    /// <summary>
    /// Prepaid Previous Amount Cash
    /// </summary>
    public decimal? PreviousAmountCash { get; set; }

    /// <summary>
    /// Prepaid Previous Amount Rev.
    /// </summary>
    public decimal? PreviousAmountRevaluation { get; set; }

    /// <summary>
    /// Prepaid Expiration Date
    /// </summary>
    public DateOnly? ExpirationDate { get; set; }

    /// <summary>
    /// Prepaid Cash Charged
    /// </summary>
    public decimal? CashCharged { get; set; }

    /// <summary>
    /// Prepaid Transaction
    /// </summary>
    public int? TransactionNumber { get; set; }

    /// <summary>
    /// Prepaid Amount Cash
    /// </summary>
    public decimal? AmountCash { get; set; }

    /// <summary>
    /// Prepaid Circuit
    /// </summary>
    public string? Circuit { get; set; }

    /// <summary>
    /// Prepaid Cash ticket
    /// </summary>
    public decimal? TicketCharged { get; set; }

    /// <summary>
    /// Prepaid Revaluation Earned
    /// </summary>
    public decimal? RevaluationEarned { get; set; }

    /// <summary>
    /// Prepaid Card Number
    /// </summary>
    public string? CardNumber { get; set; }

    /// <summary>
    /// Transaction Number
    /// </summary>
    public string? TransNumber { get; set; }

    /// <summary>
    /// Transaction Datetime
    /// </summary>
    public DateTime? TransDate { get; set; }

    /// <summary>
    /// Prepaid Credit Amount
    /// </summary>
    public decimal? PrepaidCreditAmount { get; set; }

    /// <summary>
    /// Prepaid Credit Amount Paid Off
    /// </summary>
    public decimal? PrepaidCreditAmountCharged { get; set; }

    /// <summary>
    /// Prepaid Credit Amount Used
    /// </summary>
    public decimal? PrepaidCreditAmountDischarged { get; set; }

    public virtual ScmReceiptHeader? Header { get; set; }
}
