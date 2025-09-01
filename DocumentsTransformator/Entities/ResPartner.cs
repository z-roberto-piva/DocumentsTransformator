using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

public partial class ResPartner
{
    public int Id { get; set; }

    public string? Lang { get; set; }

    public int? CompanyId { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Notes
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// EAN13
    /// </summary>
    public string? Ean13 { get; set; }

    /// <summary>
    /// Color Index
    /// </summary>
    public int? Color { get; set; }

    /// <summary>
    /// Image
    /// </summary>
    public byte[]? Image { get; set; }

    /// <summary>
    /// Use Company Address
    /// </summary>
    public bool? UseParentAddress { get; set; }

    /// <summary>
    /// Active
    /// </summary>
    public bool? Active { get; set; }

    /// <summary>
    /// Street
    /// </summary>
    public string? Street { get; set; }

    /// <summary>
    /// Supplier
    /// </summary>
    public bool? Supplier { get; set; }

    /// <summary>
    /// Salesperson
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// Zip
    /// </summary>
    public string? Zip { get; set; }

    /// <summary>
    /// Title
    /// </summary>
    public int? Title { get; set; }

    /// <summary>
    /// Job Position
    /// </summary>
    public string? Function { get; set; }

    /// <summary>
    /// Country
    /// </summary>
    public int? CountryId { get; set; }

    /// <summary>
    /// Related Company
    /// </summary>
    public int? ParentId { get; set; }

    /// <summary>
    /// Employee
    /// </summary>
    public bool? Employee { get; set; }

    /// <summary>
    /// Address Type
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// TIN
    /// </summary>
    public string? Vat { get; set; }

    /// <summary>
    /// Website
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// Fax
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    /// City
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Street2
    /// </summary>
    public string? Street2 { get; set; }

    /// <summary>
    /// Phone
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Credit Limit
    /// </summary>
    public double? CreditLimit { get; set; }

    /// <summary>
    /// Date
    /// </summary>
    public DateOnly? Date { get; set; }

    /// <summary>
    /// Timezone
    /// </summary>
    public string? Tz { get; set; }

    /// <summary>
    /// Customer
    /// </summary>
    public bool? Customer { get; set; }

    /// <summary>
    /// Medium-sized image
    /// </summary>
    public byte[]? ImageMedium { get; set; }

    /// <summary>
    /// Mobile
    /// </summary>
    public string? Mobile { get; set; }

    /// <summary>
    /// Reference
    /// </summary>
    public string? Ref { get; set; }

    /// <summary>
    /// Small-sized image
    /// </summary>
    public byte[]? ImageSmall { get; set; }

    /// <summary>
    /// Birthdate
    /// </summary>
    public string? Birthdate { get; set; }

    /// <summary>
    /// Is a Company
    /// </summary>
    public bool? IsCompany { get; set; }

    /// <summary>
    /// State
    /// </summary>
    public int? StateId { get; set; }

    /// <summary>
    /// Receive Messages by Email
    /// </summary>
    public string NotificationEmailSend { get; set; } = null!;

    /// <summary>
    /// Opt-Out
    /// </summary>
    public bool? OptOut { get; set; }

    /// <summary>
    /// Signup Token Type
    /// </summary>
    public string? SignupType { get; set; }

    /// <summary>
    /// Signup Expiration
    /// </summary>
    public DateTime? SignupExpiration { get; set; }

    /// <summary>
    /// Signup Token
    /// </summary>
    public string? SignupToken { get; set; }

    /// <summary>
    /// Latest Full Reconciliation Date
    /// </summary>
    public DateTime? LastReconciliationDate { get; set; }

    /// <summary>
    /// Payable Limit
    /// </summary>
    public double? DebitLimit { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    /// Code
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Is Manual
    /// </summary>
    public bool? IsManual { get; set; }

    /// <summary>
    /// Invoice Request
    /// </summary>
    public bool? InvoiceRequest { get; set; }

    /// <summary>
    /// Pin Card
    /// </summary>
    public string? CardPin { get; set; }

    /// <summary>
    /// Card Expiration Date
    /// </summary>
    public DateOnly? CardExpirationDate { get; set; }

    /// <summary>
    /// Date Of Birth
    /// </summary>
    public DateOnly? DateOfBirth { get; set; }

    /// <summary>
    /// VAT Legal Statement
    /// </summary>
    public bool? VatSubjected { get; set; }

    /// <summary>
    /// Province
    /// </summary>
    public int? Province { get; set; }

    /// <summary>
    /// Region
    /// </summary>
    public int? Region { get; set; }

    /// <summary>
    /// Fiscal Code
    /// </summary>
    public string? Fiscalcode { get; set; }

    /// <summary>
    /// Individual
    /// </summary>
    public bool? Individual { get; set; }

    /// <summary>
    /// Reason for transportation
    /// </summary>
    public int? TransportationReasonId { get; set; }

    /// <summary>
    /// Description of goods
    /// </summary>
    public int? GoodsDescriptionId { get; set; }

    /// <summary>
    /// Carriage condition
    /// </summary>
    public int? CarriageConditionId { get; set; }

    /// <summary>
    /// Is Prepaid On DB
    /// </summary>
    public bool? IsPrepaidOnDb { get; set; }

    /// <summary>
    /// Cash Balance
    /// </summary>
    public double? CashBalance { get; set; }

    /// <summary>
    /// Prepaid On DB Balance
    /// </summary>
    public decimal? PrepaidOnDbBalance { get; set; }

    /// <summary>
    /// Ticket Balance
    /// </summary>
    public double? TicketBalance { get; set; }

    /// <summary>
    /// Revaluation Balance
    /// </summary>
    public double? RevaluationBalance { get; set; }

    /// <summary>
    /// Total Points Consumed
    /// </summary>
    public int? GrandTotalConsumedPointsBalance { get; set; }

    /// <summary>
    /// Loyalty Enabled
    /// </summary>
    public bool? IsLoyalty { get; set; }

    /// <summary>
    /// Current Points Balance
    /// </summary>
    public int? CurrentPointsBalance { get; set; }

    /// <summary>
    /// Total Points Accumulated
    /// </summary>
    public int? GrandTotalPointsBalance { get; set; }

    /// <summary>
    /// Is Tobacco Supplyer
    /// </summary>
    public bool? IsTobaccoSupplier { get; set; }

    /// <summary>
    /// Public administration
    /// </summary>
    public bool? IsPa { get; set; }

    /// <summary>
    /// IPA Code
    /// </summary>
    public string? IpaCode { get; set; }

    /// <summary>
    /// REA Code
    /// </summary>
    public string? ReaCode { get; set; }

    /// <summary>
    /// Office Province
    /// </summary>
    public int? ReaOffice { get; set; }

    /// <summary>
    /// Capital
    /// </summary>
    public double? ReaCapital { get; set; }

    /// <summary>
    /// Liquidation State
    /// </summary>
    public string? ReaLiquidationState { get; set; }

    /// <summary>
    /// Member Type
    /// </summary>
    public string? ReaMemberType { get; set; }

    /// <summary>
    /// PEC destinatario
    /// </summary>
    public string? PecDestinatario { get; set; }

    /// <summary>
    /// Register Fiscal Position
    /// </summary>
    public int? RegisterFiscalpos { get; set; }

    /// <summary>
    /// Subjected to electronic invoice
    /// </summary>
    public bool? ElectronicInvoiceSubjected { get; set; }

    /// <summary>
    /// PA Code for partner
    /// </summary>
    public string? PaPartnerCode { get; set; }

    /// <summary>
    /// Codice Destinatario
    /// </summary>
    public string? CodiceDestinatario { get; set; }

    /// <summary>
    /// Register Registration Date
    /// </summary>
    public DateOnly? RegisterRegdate { get; set; }

    /// <summary>
    /// Register Province
    /// </summary>
    public int? RegisterProvince { get; set; }

    /// <summary>
    /// License Code
    /// </summary>
    public string? LicenseNumber { get; set; }

    /// <summary>
    /// EORI Code
    /// </summary>
    public string? EoriCode { get; set; }

    /// <summary>
    /// Professional Register
    /// </summary>
    public string? Register { get; set; }

    /// <summary>
    /// Register Code
    /// </summary>
    public string? RegisterCode { get; set; }

    /// <summary>
    /// Prepaid On DB Credit Used
    /// </summary>
    public double? PrepaidCreditAmountUsed { get; set; }

    /// <summary>
    /// Max Prepaid On DB Credit
    /// </summary>
    public double? PrepaidCreditAmount { get; set; }

    /// <summary>
    /// Gift Card Expiration Date
    /// </summary>
    public DateOnly? GiftCardExpirationDate { get; set; }

    /// <summary>
    /// Numero rivendita
    /// </summary>
    public int? NumRivendita { get; set; }

    /// <summary>
    /// Aggio Percentage
    /// </summary>
    public double? Aggio { get; set; }

    /// <summary>
    /// Is Tobacco Reseller
    /// </summary>
    public bool? IsTobaccoReseller { get; set; }

    /// <summary>
    /// Customer Note
    /// </summary>
    public string? CustomerNote { get; set; }

    /// <summary>
    /// Pricelist
    /// </summary>
    public int? PricelistId { get; set; }

    /// <summary>
    /// Pos/EFT Balance
    /// </summary>
    public double? PosBalance { get; set; }

    public string? CardCode { get; set; }

    /// <summary>
    /// Override Prepaid Payment
    /// </summary>
    public int? OverridePrepaidPayment { get; set; }

    /// <summary>
    /// Recharge Vat Rate
    /// </summary>
    public double? RechargeVatRate { get; set; }

    /// <summary>
    /// Is Multiuse Card
    /// </summary>
    public bool? IsMultiuseCard { get; set; }

    /// <summary>
    /// Lastname
    /// </summary>
    public string? Lastname { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// Firstname
    /// </summary>
    public string? Firstname { get; set; }

    /// <summary>
    /// In Fiscal Document Type
    /// </summary>
    public int? InFiscalDocumentType { get; set; }

    /// <summary>
    /// Out Fiscal Document Type
    /// </summary>
    public int? OutFiscalDocumentType { get; set; }

    /// <summary>
    /// Do not update the contact from Electronic Invoice Details
    /// </summary>
    public bool? ElectronicInvoiceNoContactUpdate { get; set; }

    /// <summary>
    /// Obliged Subject
    /// </summary>
    public bool? ElectronicInvoiceObligedSubject { get; set; }

    /// <summary>
    /// unknown
    /// </summary>
    public bool? ElectronicInvoiceDataComplete { get; set; }

    /// <summary>
    /// Use this e-invoicing data when invoicing to this address
    /// </summary>
    public bool? ElectronicInvoiceUseThisAddress { get; set; }

    /// <summary>
    /// Lottery Code
    /// </summary>
    public string? LotteryCode { get; set; }

    /// <summary>
    /// Card of Employee
    /// </summary>
    public bool? IsEmployeeCard { get; set; }

    /// <summary>
    /// Ignore Not Discountable Flag
    /// </summary>
    public bool? IgnoreNotDiscountableFlag { get; set; }

    /// <summary>
    /// Accepted privacy policy
    /// </summary>
    public bool? AcceptedPrivacyPolicy { get; set; }

    /// <summary>
    /// Entrance Bonus Earned
    /// </summary>
    public bool? EntranceBonusEarned { get; set; }

    /// <summary>
    /// Completed Personal Data
    /// </summary>
    public bool? CompletedPersonalData { get; set; }

    /// <summary>
    /// Accepted terms and conditions
    /// </summary>
    public bool? AcceptedTermsAndConditions { get; set; }

    /// <summary>
    /// Last Balances Rectification
    /// </summary>
    public DateTime? LastBalancesRectification { get; set; }

    /// <summary>
    /// Last Prepaid Usage
    /// </summary>
    public DateTime? LastPrepaidUsage { get; set; }

    /// <summary>
    /// Last Card Usage
    /// </summary>
    public DateTime? LastCardUsage { get; set; }

    /// <summary>
    /// Smart Bill Active
    /// </summary>
    public bool? SmartBillActive { get; set; }

    /// <summary>
    /// External Employee Code
    /// </summary>
    public string? ExternalEmployeeCode { get; set; }

    /// <summary>
    /// Only Prepaid Card
    /// </summary>
    public bool? OnlyPrepaidCard { get; set; }

    public virtual ICollection<ResPartner> InverseParent { get; set; } = new List<ResPartner>();

    public virtual ScmPayment? OverridePrepaidPaymentNavigation { get; set; }

    public virtual ResPartner? Parent { get; set; }

    public virtual ICollection<ScmPayment> ScmPayments { get; set; } = new List<ScmPayment>();

    public virtual ICollection<ScmReceiptHeader> ScmReceiptHeaders { get; set; } = new List<ScmReceiptHeader>();

    public virtual ICollection<ScmShop> ScmShopPanariaPartnerNavigations { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmShop> ScmShopPartners { get; set; } = new List<ScmShop>();
}
