using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.payments
/// </summary>
public partial class ScmPayment
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Supplement Product
    /// </summary>
    public int? SupplementProduct { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Amount Input Flag
    /// </summary>
    public bool? AmountInputFlag { get; set; }

    /// <summary>
    /// Value
    /// </summary>
    public double? Value { get; set; }

    /// <summary>
    /// Invoice Customer
    /// </summary>
    public int? InvoiceCustomerId { get; set; }

    /// <summary>
    /// Payment Depositable
    /// </summary>
    public bool? PaymentDepositable { get; set; }

    /// <summary>
    /// Code
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// Payment Type id
    /// </summary>
    public int PaymentTypeId { get; set; }

    /// <summary>
    /// Payment Account
    /// </summary>
    public int? OepaymentId { get; set; }

    /// <summary>
    /// Leftover Flag
    /// </summary>
    public bool? LeftoverFlag { get; set; }

    /// <summary>
    /// Invoice Product
    /// </summary>
    public int? InvoiceProductId { get; set; }

    /// <summary>
    /// Payment Type
    /// </summary>
    public string? PaymentType { get; set; }

    /// <summary>
    /// Tax
    /// </summary>
    public int? TaxId { get; set; }

    /// <summary>
    /// Use Shop Tax
    /// </summary>
    public bool? UseShopTax { get; set; }

    /// <summary>
    /// Tiket Discount fo Invoicing
    /// </summary>
    public double? TicketDiscountInvoicing { get; set; }

    /// <summary>
    /// BPE Issuer Code
    /// </summary>
    public string? BpeIssuerCode { get; set; }

    /// <summary>
    /// Is Refundable
    /// </summary>
    public bool? IsRefundable { get; set; }

    /// <summary>
    /// Is for Primanota
    /// </summary>
    public bool? IsForPrimanota { get; set; }

    /// <summary>
    /// Is Collected Prepaid
    /// </summary>
    public bool? IsCollectedPrepaid { get; set; }

    /// <summary>
    /// Is Celiac Disease Voucher
    /// </summary>
    public bool? IsCeliacDiseaseVoucher { get; set; }

    /// <summary>
    /// Open drawer
    /// </summary>
    public bool? OpenDrawer { get; set; }

    public virtual ResPartner? InvoiceCustomer { get; set; }

    public virtual ProductProduct? InvoiceProduct { get; set; }

    public virtual ICollection<ProductProduct> ProductProducts { get; set; } = new List<ProductProduct>();

    public virtual ICollection<ResPartner> ResPartners { get; set; } = new List<ResPartner>();

    public virtual ICollection<ScmAgreement> ScmAgreements { get; set; } = new List<ScmAgreement>();

    public virtual ICollection<ScmReceiptPaymentDivision> ScmReceiptPaymentDivisions { get; set; } = new List<ScmReceiptPaymentDivision>();

    public virtual ICollection<ScmReceiptPayment> ScmReceiptPayments { get; set; } = new List<ScmReceiptPayment>();

    public virtual ICollection<ScmShop> ScmShopPrepaidRevaluationPaymentNavigations { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmShop> ScmShopSatispayPayments { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmTill> ScmTillBedzzlePayments { get; set; } = new List<ScmTill>();

    public virtual ICollection<ScmTill> ScmTillPrepaidv2ErgoPaymentNavigations { get; set; } = new List<ScmTill>();

    public virtual ProductProduct? SupplementProductNavigation { get; set; }

    public virtual AccountTax? Tax { get; set; }
}
