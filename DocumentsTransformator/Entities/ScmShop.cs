using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.shops
/// </summary>
public partial class ScmShop
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Code
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// Fund management
    /// </summary>
    public bool? FundManagement { get; set; }

    /// <summary>
    /// Suspension Label
    /// </summary>
    public string? SuspensionLabel { get; set; }

    /// <summary>
    /// Company
    /// </summary>
    public int CompanyId { get; set; }

    /// <summary>
    /// Safes For Withdrawals
    /// </summary>
    public int? WithdrawalSafeId { get; set; }

    /// <summary>
    /// Maximum recharge on prepaid
    /// </summary>
    public double? MaxRecharge { get; set; }

    /// <summary>
    /// Dropbox DB Backup Retention
    /// </summary>
    public int? DropboxDbBackupRetention { get; set; }

    /// <summary>
    /// Time From Last Suspension
    /// </summary>
    public int? TimeFromLastSuspension { get; set; }

    /// <summary>
    /// IP main server
    /// </summary>
    public string? HqIpAddress { get; set; }

    /// <summary>
    /// 24H Shop
    /// </summary>
    public bool? Is24h { get; set; }

    /// <summary>
    /// Maximum amount for payments
    /// </summary>
    public double? MaxPaymentAmount { get; set; }

    /// <summary>
    /// Maximum price for sales by department
    /// </summary>
    public double? MaxSaleByDept { get; set; }

    /// <summary>
    /// Higher price list
    /// </summary>
    public int? HigherPriceListId { get; set; }

    /// <summary>
    /// Dropbox Transactions Save Path
    /// </summary>
    public string? DropboxSaveTransPath { get; set; }

    /// <summary>
    /// Closing hour
    /// </summary>
    public string? ClosingHour { get; set; }

    /// <summary>
    /// Prepaid Management
    /// </summary>
    public bool? PrepaidManagement { get; set; }

    /// <summary>
    /// Status Requests Interval
    /// </summary>
    public int? StatusInterval { get; set; }

    /// <summary>
    /// Helpdesk Phone Number
    /// </summary>
    public string? HelpdeskPhonenumber { get; set; }

    /// <summary>
    /// Updater Server User
    /// </summary>
    public string? UpdaterServerUser { get; set; }

    /// <summary>
    /// Visibility
    /// </summary>
    public int? VisibilityId { get; set; }

    /// <summary>
    /// Complete Meal Product
    /// </summary>
    public int? CompleteMealProduct { get; set; }

    /// <summary>
    /// Database Version
    /// </summary>
    public string? DatabaseVersion { get; set; }

    /// <summary>
    /// News Filename
    /// </summary>
    public string? NewsFilename { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Service Management
    /// </summary>
    public string? ServiceManagement { get; set; }

    /// <summary>
    /// Helpdesk Email
    /// </summary>
    public string? HelpdeskEmail { get; set; }

    /// <summary>
    /// Lower price list
    /// </summary>
    public int? LowerPriceListId { get; set; }

    /// <summary>
    /// Group
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    /// Dropbox Token
    /// </summary>
    public string? DropboxToken { get; set; }

    /// <summary>
    /// Supervisor
    /// </summary>
    public string? Supervisor { get; set; }

    /// <summary>
    /// Default price list
    /// </summary>
    public int DefaultPriceListId { get; set; }

    /// <summary>
    /// Withdrawal Mandatory
    /// </summary>
    public bool? WithdrawalMandatory { get; set; }

    /// <summary>
    /// Updater Server Pass
    /// </summary>
    public string? UpdaterServerPass { get; set; }

    /// <summary>
    /// Linked partner
    /// </summary>
    public int PartnerId { get; set; }

    /// <summary>
    /// Activation key
    /// </summary>
    public string? ActivationKey { get; set; }

    /// <summary>
    /// IP local server
    /// </summary>
    public string? ShopIpAddress { get; set; }

    /// <summary>
    /// Support Mail
    /// </summary>
    public string? SupportMail { get; set; }

    /// <summary>
    /// Support Contact
    /// </summary>
    public string? SupportContact { get; set; }

    /// <summary>
    /// Drawer Difference Threshold #1
    /// </summary>
    public double? DrawerDifferenceThreshold1 { get; set; }

    /// <summary>
    /// Stock Warehouse
    /// </summary>
    public int? StockWarehouseId { get; set; }

    /// <summary>
    /// SMS Support
    /// </summary>
    public string? SmsSupport { get; set; }

    /// <summary>
    /// Support Phone
    /// </summary>
    public string? SupportPhone { get; set; }

    /// <summary>
    /// Dropbox DB Backup Scheduled
    /// </summary>
    public string? DropboxDbBackupSched { get; set; }

    /// <summary>
    /// Manage SetMenu
    /// </summary>
    public bool? PiSetmenuSystem { get; set; }

    /// <summary>
    /// Dropbox DB Save Path
    /// </summary>
    public string? DropboxSaveDbPath { get; set; }

    /// <summary>
    /// Bill header row 1
    /// </summary>
    public string? BillHeaderR1 { get; set; }

    /// <summary>
    /// Bill header row 2
    /// </summary>
    public string? BillHeaderR2 { get; set; }

    /// <summary>
    /// Bill header row 3
    /// </summary>
    public string? BillHeaderR3 { get; set; }

    /// <summary>
    /// Bill header row 4
    /// </summary>
    public string? BillHeaderR4 { get; set; }

    /// <summary>
    /// Bill header row 5
    /// </summary>
    public string? BillHeaderR5 { get; set; }

    /// <summary>
    /// Bill header row 6
    /// </summary>
    public string? BillHeaderR6 { get; set; }

    /// <summary>
    /// Bill header row 7
    /// </summary>
    public string? BillHeaderR7 { get; set; }

    /// <summary>
    /// Bill header row 8
    /// </summary>
    public string? BillHeaderR8 { get; set; }

    /// <summary>
    /// Credits filename
    /// </summary>
    public string? CreditsFilename { get; set; }

    /// <summary>
    /// License
    /// </summary>
    public string? License { get; set; }

    /// <summary>
    /// Opening hour
    /// </summary>
    public string? OpeningHour { get; set; }

    /// <summary>
    /// Updater Server
    /// </summary>
    public string? UpdaterServer { get; set; }

    /// <summary>
    /// Manage Windows
    /// </summary>
    public bool? PiWindowSystem { get; set; }

    /// <summary>
    /// Supervisor Password
    /// </summary>
    public string? SupervisorPassword { get; set; }

    /// <summary>
    /// Manager Safes
    /// </summary>
    public int? ManagerSafeId { get; set; }

    /// <summary>
    /// Default PI Menu
    /// </summary>
    public int? PiMenuId { get; set; }

    /// <summary>
    /// Dropbox Backup Enabled
    /// </summary>
    public bool? DropboxBackupEnabled { get; set; }

    /// <summary>
    /// Print Difference Details on Withdrawal
    /// </summary>
    public bool? PrintDifferenceDetailsOnWithdrawal { get; set; }

    /// <summary>
    /// Tax
    /// </summary>
    public int? TaxId { get; set; }

    /// <summary>
    /// Show Dashboard on Till Closure
    /// </summary>
    public bool? ShowDashboardOnTillClosure { get; set; }

    /// <summary>
    /// Prepaid on DB
    /// </summary>
    public bool? PrepaidOnDbEnabled { get; set; }

    /// <summary>
    /// Prepaid on DB OffLine Mode
    /// </summary>
    public string? PrepaidOnDbOfflineMode { get; set; }

    /// <summary>
    /// Export PI Template
    /// </summary>
    public bool? ExportPiTemplate { get; set; }

    /// <summary>
    /// Table Service Management
    /// </summary>
    public bool? TableServiceManagement { get; set; }

    /// <summary>
    /// Servings Print Mode
    /// </summary>
    public string? ServingsPrintMode { get; set; }

    /// <summary>
    /// Servings Enabled
    /// </summary>
    public bool? ServingsEnabled { get; set; }

    /// <summary>
    /// New Production Centers Mode
    /// </summary>
    public bool? NewProductionCentersMode { get; set; }

    /// <summary>
    /// Prepaid Discharge On Not Fiscal
    /// </summary>
    public bool? PrepaidDischargeOnNotFiscal { get; set; }

    /// <summary>
    /// Swap Category/Sector on Export 
    /// </summary>
    public bool? ExportPiSwapCategory { get; set; }

    /// <summary>
    /// Default Cover Article for Table Service
    /// </summary>
    public int? DefaultCoverArticleForTableService { get; set; }

    /// <summary>
    /// Kitchen Template
    /// </summary>
    public int? KitchenTemplateId { get; set; }

    /// <summary>
    /// Prepaid Billing Unified
    /// </summary>
    public bool? PrepaidBillingUnified { get; set; }

    /// <summary>
    /// Manage Bill Items For Operator
    /// </summary>
    public bool? ManageItemForOperator { get; set; }

    /// <summary>
    /// Numero rivendita
    /// </summary>
    public int? NumRivendita { get; set; }

    /// <summary>
    /// Manage Real Time Product Stocks
    /// </summary>
    public bool? ManageRealTimeStock { get; set; }

    /// <summary>
    /// Enable NemPOS dashboard
    /// </summary>
    public bool? NemposDashboardEnabled { get; set; }

    /// <summary>
    /// NemPOS dashboard synchronization status
    /// </summary>
    public string? NemposDashboardStatus { get; set; }

    /// <summary>
    /// Electronic Invoice Works Only ONLINE
    /// </summary>
    public bool? ElectronicInvoiceOnlyOnline { get; set; }

    /// <summary>
    /// Electronic Invoice Message
    /// </summary>
    public string? CourtesyElectronicInvoiceMsg { get; set; }

    /// <summary>
    /// Default Prepaid Ticket Recharge product
    /// </summary>
    public int? DefaultPrepaidTicketRechargeProduct { get; set; }

    /// <summary>
    /// Force Immediate Order
    /// </summary>
    public bool? ForceImmediateOrder { get; set; }

    /// <summary>
    /// Manage Transaction Payments division
    /// </summary>
    public bool? ManagePaymentDivision { get; set; }

    /// <summary>
    /// Advanced Pricelist Escalation
    /// </summary>
    public bool? AdvancedPricelistEscalation { get; set; }

    /// <summary>
    /// Virtual license
    /// </summary>
    public bool? Virtual { get; set; }

    /// <summary>
    /// Active
    /// </summary>
    public bool? Active { get; set; }

    /// <summary>
    /// Recharge Bouns Item for Gift Card
    /// </summary>
    public int? RechargeBonusItem { get; set; }

    /// <summary>
    /// Cut On Next
    /// </summary>
    public bool? CutOnNext { get; set; }

    /// <summary>
    /// Use Default Rules
    /// </summary>
    public bool? UseDefaultRulesNewCard { get; set; }

    /// <summary>
    /// Use Menus New Gui
    /// </summary>
    public bool? UseMenusNewGui { get; set; }

    /// <summary>
    /// API Url
    /// </summary>
    public string? SimsolApiUrl { get; set; }

    /// <summary>
    /// Account API Key
    /// </summary>
    public string? SimsolAccountApiKey { get; set; }

    /// <summary>
    /// Account ID
    /// </summary>
    public string? SimsolAccountId { get; set; }

    /// <summary>
    /// Default Recharge Vat Rate %
    /// </summary>
    public double? DefaultRechargeVatRate { get; set; }

    /// <summary>
    /// Default Card Mode
    /// </summary>
    public string DefaultCardMode { get; set; } = null!;

    /// <summary>
    /// Pays products with VAT less than or equal to the monouse cards rate VAT
    /// </summary>
    public bool? MonouseCardPayLessEqualVat { get; set; }

    /// <summary>
    /// Key ID
    /// </summary>
    public string? SatispayKeyId { get; set; }

    /// <summary>
    /// Payment to Use
    /// </summary>
    public int? SatispayPaymentId { get; set; }

    /// <summary>
    /// Private Key File
    /// </summary>
    public byte[]? SatispayPrivateKeyFile { get; set; }

    /// <summary>
    /// Private Key File Name
    /// </summary>
    public string? SatispayPrivateKeyFilepath { get; set; }

    /// <summary>
    /// Satispay Enabled
    /// </summary>
    public bool? SatispayEnabled { get; set; }

    /// <summary>
    /// Is Staging
    /// </summary>
    public bool? SatispayIsStaging { get; set; }

    /// <summary>
    /// Currency
    /// </summary>
    public string? SatispayCurrency { get; set; }

    /// <summary>
    /// Enabled
    /// </summary>
    public bool? OpenapiEnabled { get; set; }

    /// <summary>
    /// Card serial add check digit
    /// </summary>
    public bool? CardAddCheckdigit { get; set; }

    /// <summary>
    /// Card Suffix
    /// </summary>
    public string? CardSuffix { get; set; }

    /// <summary>
    /// Print Bill
    /// </summary>
    public bool? SatispayPrintBill { get; set; }

    /// <summary>
    /// Show Comments On The Receipt
    /// </summary>
    public bool? ShowCommentsOnTheReceipt { get; set; }

    /// <summary>
    /// Authorization Code
    /// </summary>
    public string? SatispayAuthorizationCode { get; set; }

    /// <summary>
    /// Card print note copy
    /// </summary>
    public int? CardNoteCopyNumber { get; set; }

    /// <summary>
    /// Card Prefix
    /// </summary>
    public string? CardPrefix { get; set; }

    /// <summary>
    /// OpenApi Username
    /// </summary>
    public string? OpenapiUsername { get; set; }

    /// <summary>
    /// Use Sandbox
    /// </summary>
    public bool? OpenapiSandbox { get; set; }

    /// <summary>
    /// Card next progressive number
    /// </summary>
    public string? CardNextNumber { get; set; }

    /// <summary>
    /// OpenApi Password
    /// </summary>
    public string? OpenapiPassword { get; set; }

    /// <summary>
    /// Card print QR Code
    /// </summary>
    public bool? CardPrintQrcode { get; set; }

    /// <summary>
    /// Card note
    /// </summary>
    public string? CardNote { get; set; }

    /// <summary>
    /// Abilitato
    /// </summary>
    public bool? PanariaEnabled { get; set; }

    /// <summary>
    /// Token Negozio Panaria
    /// </summary>
    public string? PanariaShopToken { get; set; }

    /// <summary>
    /// ID Ristorante
    /// </summary>
    public int? PanariaRestaurantId { get; set; }

    /// <summary>
    /// Cliente Panaria
    /// </summary>
    public int? PanariaPartner { get; set; }

    /// <summary>
    /// Test
    /// </summary>
    public bool? PanariaIsTest { get; set; }

    /// <summary>
    /// Revaluation Payment
    /// </summary>
    public int? PrepaidRevaluationPayment { get; set; }

    /// <summary>
    /// Prepaid Revaluation As Sconto a Pagare
    /// </summary>
    public bool? PrepaidRevaluationAsScontoAPagare { get; set; }

    /// <summary>
    /// Booking End Time Lunch
    /// </summary>
    public double? BookingDeadline { get; set; }

    /// <summary>
    /// Booking End Time Dinner
    /// </summary>
    public double? BookingDeadline2 { get; set; }

    /// <summary>
    /// Max order amount
    /// </summary>
    public decimal? MaxOrderAmount { get; set; }

    /// <summary>
    /// URL to Facebook profile
    /// </summary>
    public string? UrlFacebook { get; set; }

    /// <summary>
    /// Threshold for free express ticket costs
    /// </summary>
    public decimal? ExpressCostThreshold { get; set; }

    /// <summary>
    /// POS user for e-wallet recharges
    /// </summary>
    public int? PrepaidUser { get; set; }

    /// <summary>
    /// Enable self parking
    /// </summary>
    public bool? EnableParking { get; set; }

    /// <summary>
    /// Discount on pickup
    /// </summary>
    public int? DiscountOnPickupId { get; set; }

    /// <summary>
    /// Enable delivery
    /// </summary>
    public bool? EnableDelivery { get; set; }

    /// <summary>
    /// URL for privacy policy
    /// </summary>
    public string? UrlPrivacy { get; set; }

    /// <summary>
    /// URL for terms and conditions
    /// </summary>
    public string? UrlTermsConditions { get; set; }

    /// <summary>
    /// Reduced delivery cost 1
    /// </summary>
    public int? DeliveryProductId2 { get; set; }

    /// <summary>
    /// Reduced delivery cost 2
    /// </summary>
    public int? DeliveryProductId3 { get; set; }

    /// <summary>
    /// Delivery notes
    /// </summary>
    public string? DeliveryInfo { get; set; }

    /// <summary>
    /// Enable delivery button info
    /// </summary>
    public bool? EnableDeliveryInfoButton { get; set; }

    /// <summary>
    /// Gift fee product
    /// </summary>
    public int? GiftProductId { get; set; }

    /// <summary>
    /// Product for pickup costs
    /// </summary>
    public int? PikupProductId { get; set; }

    /// <summary>
    /// Min order amount takeaway
    /// </summary>
    public decimal? MinOrderAmountTakeaway { get; set; }

    /// <summary>
    /// URL to Youtube channel
    /// </summary>
    public string? UrlYoutube { get; set; }

    /// <summary>
    /// URL to Pinterest profile
    /// </summary>
    public string? UrlPinterest { get; set; }

    /// <summary>
    /// Cover product for self order
    /// </summary>
    public int? TableCoverProductId { get; set; }

    /// <summary>
    /// URL to Tiktok profile
    /// </summary>
    public string? UrlTiktok { get; set; }

    /// <summary>
    /// Min order amount
    /// </summary>
    public decimal? MinOrderAmount { get; set; }

    /// <summary>
    /// Shop image
    /// </summary>
    public byte[]? ShopImgMedium { get; set; }

    /// <summary>
    /// Threshold for free table order costs
    /// </summary>
    public decimal? TableCostThreshold { get; set; }

    /// <summary>
    /// Enable pickup
    /// </summary>
    public bool? EnablePickup { get; set; }

    /// <summary>
    /// Product for express ticket costs
    /// </summary>
    public int? ExpressProductId { get; set; }

    /// <summary>
    /// Express ticket
    /// </summary>
    public bool? EnableExpress { get; set; }

    /// <summary>
    /// Threshold for free pickup costs
    /// </summary>
    public decimal? PickUpCostThreshold { get; set; }

    /// <summary>
    /// Threshold for free shipping costs
    /// </summary>
    public decimal? DeliveryCostThreshold { get; set; }

    /// <summary>
    /// Till for e-wallet recharges
    /// </summary>
    public int? PrepaidTill { get; set; }

    /// <summary>
    /// Min order amount for self orders
    /// </summary>
    public decimal? MinAmountTable { get; set; }

    /// <summary>
    /// Enabled for NemPOS Orders
    /// </summary>
    public bool? BookingAppEnabled { get; set; }

    /// <summary>
    /// URL to Instagram profile
    /// </summary>
    public string? UrlInstagram { get; set; }

    /// <summary>
    /// Enable self order
    /// </summary>
    public bool? EnableSelfOrders { get; set; }

    /// <summary>
    /// Product for delivery costs
    /// </summary>
    public int? DeliveryProductId { get; set; }

    /// <summary>
    /// URL to Linkedin profile
    /// </summary>
    public string? UrlLinkedin { get; set; }

    /// <summary>
    /// Image timestamp
    /// </summary>
    public decimal? ShopImgTimestamp { get; set; }

    /// <summary>
    /// Min order amount for express orders
    /// </summary>
    public decimal? MinAmountExpress { get; set; }

    /// <summary>
    /// Shop Image
    /// </summary>
    public byte[]? ShopImg { get; set; }

    /// <summary>
    /// Tabacchi in Cloud Client ID
    /// </summary>
    public string? TicClientId { get; set; }

    /// <summary>
    /// Reservations System
    /// </summary>
    public string? TableReservationSystem { get; set; }

    /// <summary>
    /// Reservations server URL
    /// </summary>
    public string? TableReservationServerUrl { get; set; }

    /// <summary>
    /// Reservations API key
    /// </summary>
    public string? TableReservationApiKey { get; set; }

    public virtual ProductProduct? CompleteMealProductNavigation { get; set; }

    public virtual ProductProduct? DefaultCoverArticleForTableServiceNavigation { get; set; }

    public virtual ProductProduct? DefaultPrepaidTicketRechargeProductNavigation { get; set; }

    public virtual ProductProduct? DeliveryProduct { get; set; }

    public virtual ProductProduct? DeliveryProductId2Navigation { get; set; }

    public virtual ProductProduct? DeliveryProductId3Navigation { get; set; }

    public virtual ProductProduct? ExpressProduct { get; set; }

    public virtual ProductProduct? GiftProduct { get; set; }

    public virtual ResPartner? PanariaPartnerNavigation { get; set; }

    public virtual ResPartner Partner { get; set; } = null!;

    public virtual ProductProduct? PikupProduct { get; set; }

    public virtual ScmTill? PrepaidTillNavigation { get; set; }

    public virtual ScmUser? PrepaidUserNavigation { get; set; }

    public virtual ProductProduct? RechargeBonusItemNavigation { get; set; }

    public virtual ICollection<ScmReceiptHeader> ScmReceiptHeaders { get; set; } = new List<ScmReceiptHeader>();

    public virtual ICollection<ScmTill> ScmTills { get; set; } = new List<ScmTill>();

    public virtual ProductProduct? TableCoverProduct { get; set; }

    public virtual AccountTax? Tax { get; set; }
}
