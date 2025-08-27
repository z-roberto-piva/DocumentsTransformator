using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.headers
/// </summary>
public partial class ScmReceiptHeader
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Receipt Datetime
    /// </summary>
    public DateTime? ReceiptRealDatetime { get; set; }

    /// <summary>
    /// Till code
    /// </summary>
    public string? TillCode { get; set; }

    /// <summary>
    /// Canceled by
    /// </summary>
    public int? CancelUserId { get; set; }

    /// <summary>
    /// Canceled
    /// </summary>
    public bool? Canceled { get; set; }

    /// <summary>
    /// Shop
    /// </summary>
    public int? ShopId { get; set; }

    /// <summary>
    /// Cashier
    /// </summary>
    public int? CashierId { get; set; }

    /// <summary>
    /// Till
    /// </summary>
    public int? TillId { get; set; }

    /// <summary>
    /// Total
    /// </summary>
    public decimal? Total { get; set; }

    /// <summary>
    /// Partner
    /// </summary>
    public int? PartnerId { get; set; }

    /// <summary>
    /// Invoice header
    /// </summary>
    public string? CustomerInvoiceHeader { get; set; }

    /// <summary>
    /// Receipt date
    /// </summary>
    public string? ReceiptDate { get; set; }

    /// <summary>
    /// Handled
    /// </summary>
    public bool? Handled { get; set; }

    /// <summary>
    /// Company
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// Reversal
    /// </summary>
    public bool? IsReversal { get; set; }

    /// <summary>
    /// Receipt time
    /// </summary>
    public string? ReceiptTime { get; set; }

    /// <summary>
    /// Reversed receipt
    /// </summary>
    public int? ReversedTransactionId { get; set; }

    /// <summary>
    /// Billable
    /// </summary>
    public bool? Billable { get; set; }

    /// <summary>
    /// Shop code
    /// </summary>
    public string? ShopCode { get; set; }

    /// <summary>
    /// Fiscal number
    /// </summary>
    public int? FiscalNumber { get; set; }

    /// <summary>
    /// Transaction number
    /// </summary>
    public string? TransactionNumber { get; set; }

    /// <summary>
    /// Ticket reason
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// Partner Anomaly
    /// </summary>
    public bool? PartnerAnomaly { get; set; }

    /// <summary>
    /// Invoice number
    /// </summary>
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// Hall code
    /// </summary>
    public string? HallCode { get; set; }

    /// <summary>
    /// Number of items
    /// </summary>
    public int? NumberOfItems { get; set; }

    /// <summary>
    /// Cover charge quantity
    /// </summary>
    public int? CoverChargeQty { get; set; }

    /// <summary>
    /// Bookkeeping date
    /// </summary>
    public DateOnly? BookkeepingDate { get; set; }

    /// <summary>
    /// Cashier user code
    /// </summary>
    public string? CashierUserCode { get; set; }

    /// <summary>
    /// Reversal transaction
    /// </summary>
    public int? ReversalTransactionId { get; set; }

    /// <summary>
    /// Transaction reference
    /// </summary>
    public string? ReferenceReceipt { get; set; }

    /// <summary>
    /// Cancel date
    /// </summary>
    public DateTime? CancelDate { get; set; }

    /// <summary>
    /// Customer number
    /// </summary>
    public string? CustomerNumber { get; set; }

    /// <summary>
    /// Table code
    /// </summary>
    public string? TableCode { get; set; }

    /// <summary>
    /// Receipt Datetime
    /// </summary>
    public DateTime? ReceiptDatetime { get; set; }

    /// <summary>
    /// Service
    /// </summary>
    public int? ServiceId { get; set; }

    /// <summary>
    /// Provenience
    /// </summary>
    public string? Provenience { get; set; }

    /// <summary>
    /// Picking
    /// </summary>
    public int? PickingId { get; set; }

    /// <summary>
    /// Company Currency
    /// </summary>
    public int? CompanyCurrencyId { get; set; }

    /// <summary>
    /// Parent Transaction
    /// </summary>
    public int? ParentTransactionId { get; set; }

    /// <summary>
    /// Total without taxes
    /// </summary>
    public decimal? TotalWithoutTaxes { get; set; }

    /// <summary>
    /// Points Campaign
    /// </summary>
    public int? PointsCampaignId { get; set; }

    /// <summary>
    /// Ergo Movement ID
    /// </summary>
    public int? ErgoMovementId { get; set; }

    /// <summary>
    /// Notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Bedzzle Reservation Name
    /// </summary>
    public string? BedzzleReservationName { get; set; }

    /// <summary>
    /// Bedzzle Hotel
    /// </summary>
    public int? BedzzleHotelId { get; set; }

    /// <summary>
    /// Is Misc Sale
    /// </summary>
    public bool? BedzzleIsMiscSale { get; set; }

    /// <summary>
    /// Bedzzle Bill Alias
    /// </summary>
    public string? BedzzleBillAlias { get; set; }

    /// <summary>
    /// Company Name
    /// </summary>
    public string? BedzzleCompanyName { get; set; }

    /// <summary>
    /// Is Paid
    /// </summary>
    public bool? BedzzleIsPaid { get; set; }

    /// <summary>
    /// Bedzzle Room Alias
    /// </summary>
    public string? BedzzleRoomAlias { get; set; }

    /// <summary>
    /// Invoice
    /// </summary>
    public int? AccountInvoiceId { get; set; }

    /// <summary>
    /// Z Report Number
    /// </summary>
    public int? ZReportNumber { get; set; }

    /// <summary>
    /// Fiscal Printer ID
    /// </summary>
    public string? FiscalPrinterId { get; set; }

    /// <summary>
    /// App Order 
    /// </summary>
    public int? AppOrderId { get; set; }

    /// <summary>
    /// Is manual
    /// </summary>
    public bool? IsManual { get; set; }

    /// <summary>
    /// Tickets Count
    /// </summary>
    public int? TicketsCount { get; set; }

    /// <summary>
    /// Operator Shift Id
    /// </summary>
    public int? OperatorShiftId { get; set; }

    /// <summary>
    /// Total Taxes
    /// </summary>
    public decimal? TotalTaxes { get; set; }

    /// <summary>
    /// Temporary Bill Printed
    /// </summary>
    public bool? TemporaryBillPrinted { get; set; }

    /// <summary>
    /// Discount On Total Value
    /// </summary>
    public double? DiscountOnTotalValue { get; set; }

    /// <summary>
    /// Discount On Total
    /// </summary>
    public int? DiscountOnTotalId { get; set; }

    /// <summary>
    /// Extra Order Service Name
    /// </summary>
    public string? ExtraOrderServiceName { get; set; }

    /// <summary>
    /// Z Report reference
    /// </summary>
    public int? ReferenceZreport { get; set; }

    /// <summary>
    /// Linked transaction
    /// </summary>
    public int? LinkedTransactionId { get; set; }

    /// <summary>
    /// Extra Order ID
    /// </summary>
    public string? ExtraOrderId { get; set; }

    /// <summary>
    /// Add-For Reading ID
    /// </summary>
    public string? AddforReadingId { get; set; }

    /// <summary>
    /// Add-For Reader
    /// </summary>
    public int? AddforReaderId { get; set; }

    /// <summary>
    /// Service Time slot
    /// </summary>
    public string? ServiceTimeSlot { get; set; }

    /// <summary>
    /// Lottery Code
    /// </summary>
    public string? LotteryCode { get; set; }

    /// <summary>
    /// Bill is printed On Fiscal Printer
    /// </summary>
    public bool? IsPrintedOnFiscalPrinter { get; set; }

    /// <summary>
    /// Program Version
    /// </summary>
    public string? ProgramVersion { get; set; }

    /// <summary>
    /// Is Waste
    /// </summary>
    public bool? IsWaste { get; set; }

    /// <summary>
    /// Panaria Employee Name
    /// </summary>
    public string? PanariaEmployeeName { get; set; }

    /// <summary>
    /// Panaria Data From Server
    /// </summary>
    public bool? PanariaDataFromServer { get; set; }

    /// <summary>
    /// Panaria Voucher Id
    /// </summary>
    public string? PanariaVoucherId { get; set; }

    /// <summary>
    /// Is Online Transaction
    /// </summary>
    public bool? IsOnline { get; set; }

    /// <summary>
    /// Panaria Employee Id
    /// </summary>
    public string? PanariaUserId { get; set; }

    public virtual ScmUser? Cashier { get; set; }

    public virtual ICollection<ScmReceiptHeader> InverseLinkedTransaction { get; set; } = new List<ScmReceiptHeader>();

    public virtual ICollection<ScmReceiptHeader> InverseParentTransaction { get; set; } = new List<ScmReceiptHeader>();

    public virtual ICollection<ScmReceiptHeader> InverseReversalTransaction { get; set; } = new List<ScmReceiptHeader>();

    public virtual ICollection<ScmReceiptHeader> InverseReversedTransaction { get; set; } = new List<ScmReceiptHeader>();

    public virtual ScmReceiptHeader? LinkedTransaction { get; set; }

    public virtual ScmReceiptHeader? ParentTransaction { get; set; }

    public virtual ScmReceiptHeader? ReversalTransaction { get; set; }

    public virtual ScmReceiptHeader? ReversedTransaction { get; set; }

    public virtual ICollection<ScmReceiptAgreement> ScmReceiptAgreements { get; set; } = new List<ScmReceiptAgreement>();

    public virtual ICollection<ScmReceiptAnalyticItem> ScmReceiptAnalyticItems { get; set; } = new List<ScmReceiptAnalyticItem>();

    public virtual ICollection<ScmReceiptCouponsDetail> ScmReceiptCouponsDetails { get; set; } = new List<ScmReceiptCouponsDetail>();

    public virtual ICollection<ScmReceiptDiscountDetail> ScmReceiptDiscountDetails { get; set; } = new List<ScmReceiptDiscountDetail>();

    public virtual ICollection<ScmReceiptInvoiceDetail> ScmReceiptInvoiceDetails { get; set; } = new List<ScmReceiptInvoiceDetail>();

    public virtual ICollection<ScmReceiptItem> ScmReceiptItems { get; set; } = new List<ScmReceiptItem>();

    public virtual ICollection<ScmReceiptPaymentDivision> ScmReceiptPaymentDivisions { get; set; } = new List<ScmReceiptPaymentDivision>();

    public virtual ICollection<ScmReceiptPayment> ScmReceiptPayments { get; set; } = new List<ScmReceiptPayment>();

    public virtual ICollection<ScmReceiptPointCampaignDetail> ScmReceiptPointCampaignDetails { get; set; } = new List<ScmReceiptPointCampaignDetail>();

    public virtual ICollection<ScmReceiptPrepaidDetail> ScmReceiptPrepaidDetails { get; set; } = new List<ScmReceiptPrepaidDetail>();

    public virtual ICollection<ScmReceiptProfitCenter> ScmReceiptProfitCenters { get; set; } = new List<ScmReceiptProfitCenter>();

    public virtual ICollection<ScmReceiptVat> ScmReceiptVats { get; set; } = new List<ScmReceiptVat>();

    public virtual ScmShop? Shop { get; set; }

    public virtual ScmTill? Till { get; set; }
}
