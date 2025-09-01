using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.tills
/// </summary>
public partial class ScmTill
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Request Supervisor for Fiscal closure
    /// </summary>
    public bool? ReqSupervisorForFiscalClosure { get; set; }

    /// <summary>
    /// Code
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// Receipt printer name
    /// </summary>
    public string? ReceiptPrinterName { get; set; }

    /// <summary>
    /// Total timeout
    /// </summary>
    public decimal? TotalTimeout { get; set; }

    /// <summary>
    /// Till type
    /// </summary>
    public int TillTypeId { get; set; }

    /// <summary>
    /// View in window frame
    /// </summary>
    public bool? ViewInWindowFrame { get; set; }

    /// <summary>
    /// Shop
    /// </summary>
    public int ShopId { get; set; }

    /// <summary>
    /// Table refresh timeout
    /// </summary>
    public decimal? TableRefreshTimeout { get; set; }

    /// <summary>
    /// Visibility criteria
    /// </summary>
    public int? VisibilityId { get; set; }

    /// <summary>
    /// Base Pricelist
    /// </summary>
    public string? ListinoBase { get; set; }

    /// <summary>
    /// Windows size y
    /// </summary>
    public int? WindowFrameY { get; set; }

    /// <summary>
    /// Windows size x
    /// </summary>
    public int? WindowFrameX { get; set; }

    /// <summary>
    /// Company
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// Print Temporary Bill on Fiscal Printer
    /// </summary>
    public bool? PrintTemporaryBillOnFiscalPrinter { get; set; }

    /// <summary>
    /// Ean Coperto
    /// </summary>
    public int? EanCoperto { get; set; }

    /// <summary>
    /// MAC address
    /// </summary>
    public string? MacAddress { get; set; }

    /// <summary>
    /// Higher price list
    /// </summary>
    public int? HigherPriceListId { get; set; }

    /// <summary>
    /// Receipt printer driver
    /// </summary>
    public string? ReceiptPrinterDriver { get; set; }

    /// <summary>
    /// Till opened (customer) - Row1
    /// </summary>
    public string? DisplayCustomerOpenR1 { get; set; }

    /// <summary>
    /// Ask Customer Name
    /// </summary>
    public bool? AskCustomerName { get; set; }

    /// <summary>
    /// Till opened (customer) - Row2
    /// </summary>
    public string? DisplayCustomerOpenR2 { get; set; }

    /// <summary>
    /// Internal Rest port
    /// </summary>
    public int? RestPort { get; set; }

    /// <summary>
    /// Operator display port
    /// </summary>
    public string? OperatorDisplayPort { get; set; }

    /// <summary>
    /// Default price list
    /// </summary>
    public int DefaultPriceListId { get; set; }

    /// <summary>
    /// Print Report Before Z
    /// </summary>
    public bool? PrintReportBeforeZ { get; set; }

    /// <summary>
    /// Customer display port
    /// </summary>
    public string? CustomerDisplayPort { get; set; }

    /// <summary>
    /// Inactivity timeout
    /// </summary>
    public decimal? InactivityTimeout { get; set; }

    /// <summary>
    /// Receipt printer port
    /// </summary>
    public string? ReceiptPrinterPort { get; set; }

    /// <summary>
    /// IP address
    /// </summary>
    public string? IpAddress { get; set; }

    /// <summary>
    /// Prepaid Device Parameters
    /// </summary>
    public string? PrepaidDeviceParameters { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Enabled
    /// </summary>
    public bool? Enabled { get; set; }

    /// <summary>
    /// Cash drawer name
    /// </summary>
    public string? CashDrawerName { get; set; }

    /// <summary>
    /// Till model
    /// </summary>
    public string TillModel { get; set; } = null!;

    /// <summary>
    /// Hand scanner driver
    /// </summary>
    public string? HandHeldScannerDriver { get; set; }

    /// <summary>
    /// Void transaction
    /// </summary>
    public bool? VoidTransaction { get; set; }

    /// <summary>
    /// Receipt printer type
    /// </summary>
    public string? ReceiptPrinterType { get; set; }

    /// <summary>
    /// Stock location
    /// </summary>
    public int? StockLocationId { get; set; }

    /// <summary>
    /// Void item
    /// </summary>
    public bool? VoidItem { get; set; }

    /// <summary>
    /// Default PI Menu
    /// </summary>
    public int? PiMenuId { get; set; }

    /// <summary>
    /// Prepaid Device Type
    /// </summary>
    public string? PrepaidDeviceType { get; set; }

    /// <summary>
    /// Void last
    /// </summary>
    public bool? VoidLast { get; set; }

    /// <summary>
    /// Lower price list
    /// </summary>
    public int? LowerPriceListId { get; set; }

    /// <summary>
    /// Print Waste on Fiscal Printer
    /// </summary>
    public bool? PrintWasteOnFiscalPrinter { get; set; }

    /// <summary>
    /// Electronic Drawer
    /// </summary>
    public int? ElectronicDrawerId { get; set; }

    /// <summary>
    /// Preferred Safe
    /// </summary>
    public int? PreferredSafeId { get; set; }

    /// <summary>
    /// Display name
    /// </summary>
    public string? JposDisplayName { get; set; }

    /// <summary>
    /// Print on Production Centers
    /// </summary>
    public bool? PrintOnProductionCenters { get; set; }

    /// <summary>
    /// Till opened (operator) - Row1
    /// </summary>
    public string? DisplayOperatorOpenR1 { get; set; }

    /// <summary>
    /// Till opened (operator) - Row2
    /// </summary>
    public string? DisplayOperatorOpenR2 { get; set; }

    /// <summary>
    /// Bill header
    /// </summary>
    public string BillHeader { get; set; } = null!;

    /// <summary>
    /// Prepaid Device Port
    /// </summary>
    public string? PrepaidDevicePort { get; set; }

    /// <summary>
    /// Logout timeout
    /// </summary>
    public decimal? LogoutTimeout { get; set; }

    /// <summary>
    /// Drawer On Non Fiscal Printer
    /// </summary>
    public bool? DrawerOnNonFiscalPrinter { get; set; }

    /// <summary>
    /// CDC Code
    /// </summary>
    public int? CodCdc { get; set; }

    /// <summary>
    /// Till closed (customer) - Row2
    /// </summary>
    public string? DisplayCustomerClosedR2 { get; set; }

    /// <summary>
    /// Till closed (customer) - Row1
    /// </summary>
    public string? DisplayCustomerClosedR1 { get; set; }

    /// <summary>
    /// Bill footer
    /// </summary>
    public string BillFooter { get; set; } = null!;

    /// <summary>
    /// Printer Model Receipt
    /// </summary>
    public string? TillsReceiptPrinterModel { get; set; }

    /// <summary>
    /// Force price list
    /// </summary>
    public bool? ForcePriceList { get; set; }

    /// <summary>
    /// Prepaid Device Port Type
    /// </summary>
    public string? PrepaidDevicePortType { get; set; }

    /// <summary>
    /// Hand scanner name
    /// </summary>
    public string? HandHeldScannerName { get; set; }

    /// <summary>
    /// Till Group
    /// </summary>
    public int TillGroupId { get; set; }

    /// <summary>
    /// DFW06 STD Device Parameters
    /// </summary>
    public string? Dfw06StdDeviceParameters { get; set; }

    /// <summary>
    /// DFW06 STD Device Port
    /// </summary>
    public string? Dfw06StdDevicePort { get; set; }

    /// <summary>
    /// DFW06 STD Port Type
    /// </summary>
    public string? Dfw06StdPortType { get; set; }

    /// <summary>
    /// DFW06 STD Device Type
    /// </summary>
    public string? Dfw06StdDeviceType { get; set; }

    /// <summary>
    /// Deny Payments
    /// </summary>
    public bool? DenyPayments { get; set; }

    /// <summary>
    /// Service Product
    /// </summary>
    public int? ServiceProduct { get; set; }

    /// <summary>
    /// ESC/POS Line Display Port Parameters
    /// </summary>
    public string? EscposLinedisplayPortParameters { get; set; }

    /// <summary>
    /// ESC/POS Line Display Port
    /// </summary>
    public string? EscposLinedisplayPort { get; set; }

    /// <summary>
    /// Font Increment
    /// </summary>
    public string? FontIncrement { get; set; }

    /// <summary>
    /// Country
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// Print Vat Details
    /// </summary>
    public bool? PrintVatDetails { get; set; }

    /// <summary>
    /// PI Spin Pad Key Template
    /// </summary>
    public int? PiHandyKeybTemplate { get; set; }

    /// <summary>
    /// Start Page Number
    /// </summary>
    public int? StartPageNumber { get; set; }

    /// <summary>
    /// Attendance Disabled
    /// </summary>
    public bool? AttendanceDisabled { get; set; }

    /// <summary>
    /// Numbers Panel in the bottom
    /// </summary>
    public bool? NumbersPanelBottom { get; set; }

    /// <summary>
    /// User Auto Login
    /// </summary>
    public int? UserAutologin { get; set; }

    /// <summary>
    /// Is RT
    /// </summary>
    public bool? IsRt { get; set; }

    /// <summary>
    /// Default Not Fiscal Device
    /// </summary>
    public int? DefaultNotfiscalDeviceId { get; set; }

    /// <summary>
    /// NemPos FE License For Test
    /// </summary>
    public bool? NemposfeLicenseForTest { get; set; }

    /// <summary>
    /// Vertical Layout
    /// </summary>
    public bool? VerticalLayout { get; set; }

    /// <summary>
    /// Backup Not Fiscal Device
    /// </summary>
    public int? BackupNotfiscalDeviceId { get; set; }

    /// <summary>
    /// Is Ergo
    /// </summary>
    public bool? IsErgo { get; set; }

    /// <summary>
    /// Year Position
    /// </summary>
    public string? YearPosition { get; set; }

    /// <summary>
    /// Centralized Invoice Number
    /// </summary>
    public bool? CentralizedInvoiceNumber { get; set; }

    /// <summary>
    /// Invoice Number Prefix
    /// </summary>
    public string? InvoiceNumberPrefix { get; set; }

    /// <summary>
    /// Invoice Print Mode
    /// </summary>
    public string? InvoicePrintMode { get; set; }

    /// <summary>
    /// Attendance Mode
    /// </summary>
    public string AttendanceMode { get; set; } = null!;

    /// <summary>
    /// Default Hall
    /// </summary>
    public int? HallId { get; set; }

    /// <summary>
    /// Show Default Hall On New Bill
    /// </summary>
    public bool? ShowDefaultHall { get; set; }

    /// <summary>
    /// Ask Covers
    /// </summary>
    public bool? AskCovers { get; set; }

    /// <summary>
    /// Manage Fiscal on Non Fiscal Printer
    /// </summary>
    public bool? ManageFiscal { get; set; }

    /// <summary>
    /// Reset Bill Counter on ZReport
    /// </summary>
    public bool? ResetBillCounterOnZReport { get; set; }

    /// <summary>
    /// Connection Mode
    /// </summary>
    public string Ingenico17Mode { get; set; } = null!;

    /// <summary>
    /// Serial Port Configuration
    /// </summary>
    public string? Ingenico17SerConf { get; set; }

    /// <summary>
    /// Ip Address
    /// </summary>
    public string? Ingenico17IpAddress { get; set; }

    /// <summary>
    /// Ethernet Port Number
    /// </summary>
    public int? Ingenico17EthPort { get; set; }

    /// <summary>
    /// POS Code
    /// </summary>
    public string? Ingenico17PosCode { get; set; }

    /// <summary>
    /// Reverse Mode
    /// </summary>
    public string Ingenico17ReverseMode { get; set; } = null!;

    /// <summary>
    /// Printer On Board
    /// </summary>
    public bool? Ingenico17PrinterOnBoard { get; set; }

    /// <summary>
    /// TILL Code
    /// </summary>
    public string? Ingenico17TillCode { get; set; }

    /// <summary>
    /// Serial Port Name
    /// </summary>
    public string? Ingenico17SerPort { get; set; }

    /// <summary>
    /// Bill Footer
    /// </summary>
    public string? Ingenico17BillFooter { get; set; }

    /// <summary>
    /// Not Fiscal Products Mode
    /// </summary>
    public string NotfiscalProductMode { get; set; } = null!;

    /// <summary>
    /// Deny Not Collected Payments
    /// </summary>
    public bool? DenyNotCollectedPaymentsNotFiscal { get; set; }

    /// <summary>
    /// Generates Suspension on Receipt Closing
    /// </summary>
    public bool? GenerateSuspensionOnCloseBill { get; set; }

    /// <summary>
    /// Mercury Gateway
    /// </summary>
    public int? MercuryGatewayId { get; set; }

    /// <summary>
    /// Products Background Color
    /// </summary>
    public string? ProductsBackgroundColor { get; set; }

    /// <summary>
    /// Back To Login Code
    /// </summary>
    public string? BackToLoginCode { get; set; }

    /// <summary>
    /// Bedzzle Username
    /// </summary>
    public string? BedzzleUsername { get; set; }

    /// <summary>
    /// Ergo price list
    /// </summary>
    public int? ErgoPricelist { get; set; }

    /// <summary>
    /// Bedzzle Password
    /// </summary>
    public string? BedzzlePassword { get; set; }

    /// <summary>
    /// Room Transfer Payment
    /// </summary>
    public int? BedzzlePaymentId { get; set; }

    /// <summary>
    /// Active
    /// </summary>
    public bool? BedzzleActive { get; set; }

    /// <summary>
    /// Bedzzle Host Port
    /// </summary>
    public int? BedzzlePort { get; set; }

    /// <summary>
    /// Bedzzle Host
    /// </summary>
    public string? BedzzleHost { get; set; }

    /// <summary>
    /// Port Number
    /// </summary>
    public int? MercuryGatewayPort { get; set; }

    /// <summary>
    /// RFID Enabled
    /// </summary>
    public bool? PrepaidRfidEnabled { get; set; }

    /// <summary>
    /// Argentea Pos Model
    /// </summary>
    public string ArgenteaPosModel { get; set; } = null!;

    /// <summary>
    /// Printer On Board
    /// </summary>
    public bool? ArgenteaPrinterOnBoard { get; set; }

    /// <summary>
    /// Pos Port Number
    /// </summary>
    public int? ArgenteaPosPort { get; set; }

    /// <summary>
    /// Use Demat
    /// </summary>
    public bool? ArgenteaUseDemat { get; set; }

    /// <summary>
    /// Use BPE
    /// </summary>
    public bool? ArgenteaUseBpe { get; set; }

    /// <summary>
    /// Use Payment and Void PLUS
    /// </summary>
    public bool? ArgenteaPayVoidPlus { get; set; }

    /// <summary>
    /// RUPP Code
    /// </summary>
    public string ArgenteaRupp { get; set; } = null!;

    /// <summary>
    /// Active
    /// </summary>
    public bool? ArgenteaEnabled { get; set; }

    /// <summary>
    /// Tracking Code for PLUS Methods
    /// </summary>
    public string? ArgenteaTrackCodePlus { get; set; }

    /// <summary>
    /// Pos Ip Address
    /// </summary>
    public string? ArgenteaPosIp { get; set; }

    /// <summary>
    /// Automatic Demat Void in voiding bill
    /// </summary>
    public bool? ArgenteaAutomaticDematVoid { get; set; }

    /// <summary>
    /// Automatic Bpe Void in voiding bill
    /// </summary>
    public bool? ArgenteaAutomaticBpeVoid { get; set; }

    /// <summary>
    /// Show Price on Buttons
    /// </summary>
    public bool? ShowPriceOnButtons { get; set; }

    /// <summary>
    /// Enabled
    /// </summary>
    public bool? Active { get; set; }

    /// <summary>
    /// Fusion Printer Drawer
    /// </summary>
    public bool? FusionPrinterDrawer { get; set; }

    /// <summary>
    /// Print Articles Detail on Fiscal Closure
    /// </summary>
    public bool? ArticlesDetailEnabled { get; set; }

    /// <summary>
    /// Show All
    /// </summary>
    public bool? ArticlesDetailShowAll { get; set; }

    /// <summary>
    /// Cost Center
    /// </summary>
    public int? TillCostCenterId { get; set; }

    /// <summary>
    /// Show Operators Detail
    /// </summary>
    public bool? ArticlesDetailShowOperator { get; set; }

    /// <summary>
    /// Show Products Detail
    /// </summary>
    public bool? ArticlesDetailShowProduct { get; set; }

    /// <summary>
    /// NemPos FE License Virtual
    /// </summary>
    public bool? NemposfeLicenseVirtual { get; set; }

    /// <summary>
    /// Not Fiscal Bill Copies
    /// </summary>
    public int? NotFiscalBillCopies { get; set; }

    /// <summary>
    /// Print only when Table is Selected
    /// </summary>
    public bool? PrintOnlyTableSelected { get; set; }

    /// <summary>
    /// QR Code on Footer
    /// </summary>
    public string? QrcodeTypeOnFooter { get; set; }

    /// <summary>
    /// Print On
    /// </summary>
    public string? WineemotionPrintOn { get; set; }

    /// <summary>
    /// Secondary Fiscal Printer Drawer Name
    /// </summary>
    public string? SecondaryFiscalPrinterDrawerName { get; set; }

    /// <summary>
    /// Secondary Fiscal Printer Is RT
    /// </summary>
    public bool? SecondaryFiscalPrinterIsRt { get; set; }

    /// <summary>
    /// Totem Number
    /// </summary>
    public int WineemotionTotemNumber { get; set; }

    /// <summary>
    /// Secondary Fiscal Printer Model
    /// </summary>
    public string? SecondaryFiscalPrinterModel { get; set; }

    /// <summary>
    /// Print on Separated Bill
    /// </summary>
    public bool? WineemotionPrintOnSeparatedBill { get; set; }

    /// <summary>
    /// Use Shared Printer Queue
    /// </summary>
    public bool? UseSharedPrinterQueue { get; set; }

    /// <summary>
    /// Shared Printer Queue Enabled
    /// </summary>
    public bool? SharedPrinterQueueEnabled { get; set; }

    /// <summary>
    /// Secondary Fiscal Printer Line Display Name
    /// </summary>
    public string? SecondaryFiscalPrinterLineDisplayName { get; set; }

    /// <summary>
    /// Shows Dashboard At Login
    /// </summary>
    public bool? ShowsSharedPrinterDashboardAtLogin { get; set; }

    /// <summary>
    /// Secondary Fiscal Printer Enabled
    /// </summary>
    public bool? SecondaryFiscalPrinterEnabled { get; set; }

    /// <summary>
    /// Passphrase
    /// </summary>
    public string WineemotionPassphrase { get; set; } = null!;

    /// <summary>
    /// Default Shared Printer Queue
    /// </summary>
    public int? DefaultSharedPrinterQueue { get; set; }

    /// <summary>
    /// Barcode Enabled
    /// </summary>
    public bool? WineemotionBarcodeEnabled { get; set; }

    /// <summary>
    /// Secondary Fiscal Printer Name
    /// </summary>
    public string? SecondaryFiscalPrinterName { get; set; }

    /// <summary>
    /// Barcode Type
    /// </summary>
    public string WineemotionBarcodeType { get; set; } = null!;

    /// <summary>
    /// Print Temporary Bill after Bill Closing
    /// </summary>
    public bool? PrintTemporaryBillAfterBillClosing { get; set; }

    /// <summary>
    /// User ID
    /// </summary>
    public string? SimsolUserId { get; set; }

    /// <summary>
    /// Simsol Enabled
    /// </summary>
    public bool? SimsolEnabled { get; set; }

    /// <summary>
    /// User API Key
    /// </summary>
    public string? SimsolUserApiKey { get; set; }

    /// <summary>
    /// Rounding Value
    /// </summary>
    public string? RoundingValue { get; set; }

    /// <summary>
    /// Rounding Product
    /// </summary>
    public int? RoundingProduct { get; set; }

    /// <summary>
    /// Rounding By Fiscal Printer
    /// </summary>
    public bool? RoundingByFiscalPrinter { get; set; }

    /// <summary>
    /// Print Petty Cash Report Before Z
    /// </summary>
    public bool? PrintPettycashMovementReportBeforeZ { get; set; }

    /// <summary>
    /// Rounding Mode
    /// </summary>
    public string? RoundingMode { get; set; }

    /// <summary>
    /// Base Url
    /// </summary>
    public string? AddforBaseUrl { get; set; }

    /// <summary>
    /// Show Bill Windows
    /// </summary>
    public bool? AddforDevicesShowBillsWindow { get; set; }

    /// <summary>
    /// Password
    /// </summary>
    public string? AddforPassword { get; set; }

    /// <summary>
    /// Enabled
    /// </summary>
    public bool? AddforEnabled { get; set; }

    /// <summary>
    /// User
    /// </summary>
    public string? AddforUser { get; set; }

    /// <summary>
    /// Pay Out On Mercury Error
    /// </summary>
    public string? PayOutOnMercuryError { get; set; }

    /// <summary>
    /// Primary Fiscal Printer
    /// </summary>
    public int? PrimaryFiscalPrinter { get; set; }

    /// <summary>
    /// Secondary Fiscal Printer
    /// </summary>
    public int? SecondaryFiscalPrinter { get; set; }

    /// <summary>
    /// Logout Mode
    /// </summary>
    public string LogoutMode { get; set; } = null!;

    /// <summary>
    /// Logout in Closing Transaction
    /// </summary>
    public bool? LogoutClosingTransaction { get; set; }

    /// <summary>
    /// Ergo default Tax Perc.
    /// </summary>
    public double? ErgoDefaultTaxPerc { get; set; }

    /// <summary>
    /// NemPos FE Maintenance Due Date
    /// </summary>
    public DateOnly? NemposfeEndMaintenance { get; set; }

    /// <summary>
    /// Keep Fixed Tables DB
    /// </summary>
    public bool? FixedTablesDb { get; set; }

    /// <summary>
    /// Baud Rate
    /// </summary>
    public string? IButtonComBaudRate { get; set; }

    /// <summary>
    /// COM Port Name
    /// </summary>
    public string? IButtonComPort { get; set; }

    /// <summary>
    /// Parity
    /// </summary>
    public string? IButtonComParity { get; set; }

    /// <summary>
    /// Select Last Tabels Hall
    /// </summary>
    public bool? SelectLastTablesHall { get; set; }

    /// <summary>
    /// StopBits
    /// </summary>
    public string? IButtonComStopbits { get; set; }

    /// <summary>
    /// Enabled
    /// </summary>
    public bool? IButtonEnabled { get; set; }

    /// <summary>
    /// DataBits
    /// </summary>
    public string? IButtonComDatabits { get; set; }

    /// <summary>
    /// Wait Electronic Invoice Result
    /// </summary>
    public bool? WaitElectronicInvoiceResult { get; set; }

    /// <summary>
    /// Block Shift If Already Closed
    /// </summary>
    public bool? BlockShiftIfAlreadyClosed { get; set; }

    /// <summary>
    /// Void Suspended Item
    /// </summary>
    public bool? VoidSuspendedItem { get; set; }

    /// <summary>
    /// Void Suspended Transaction
    /// </summary>
    public bool? VoidSuspendedTransaction { get; set; }

    /// <summary>
    /// Ergo default Tax Perc.
    /// </summary>
    public double? Prepaidv2ErgoDefaultTaxPerc { get; set; }

    /// <summary>
    /// Send Transactions Immediately
    /// </summary>
    public bool? Prepaidv2SendTransactionsImmediately { get; set; }

    /// <summary>
    /// Qr-Code Prefix Block Keys
    /// </summary>
    public string? QrcodePrefixBlockKeys { get; set; }

    /// <summary>
    /// Ergo price list
    /// </summary>
    public int? Prepaidv2ErgoPricelist { get; set; }

    /// <summary>
    /// Enabled
    /// </summary>
    public bool? Prepaidv2Ergo { get; set; }

    /// <summary>
    /// Authorization Token
    /// </summary>
    public string? Prepaidv2AuthorizationToken { get; set; }

    /// <summary>
    /// Enabled
    /// </summary>
    public bool? Prepaidv2Enabled { get; set; }

    /// <summary>
    /// Ergo Shop Code
    /// </summary>
    public string? Prepaidv2ErgoShopCode { get; set; }

    /// <summary>
    /// Server Url
    /// </summary>
    public string? Prepaidv2ServerUrl { get; set; }

    /// <summary>
    /// Ergo Till Code
    /// </summary>
    public string? Prepaidv2ErgoTillCode { get; set; }

    /// <summary>
    /// Payment
    /// </summary>
    public int? Prepaidv2ErgoPayment { get; set; }

    /// <summary>
    /// After Login Page
    /// </summary>
    public int? AfterLoginPage { get; set; }

    /// <summary>
    /// Maintenance Expiration Tolerance Days
    /// </summary>
    public int? NemposfeMaintenanceExpirationToleranceDays { get; set; }

    /// <summary>
    /// Maintenance Delay Factor
    /// </summary>
    public int? NemposfeMaintenanceDelayFactor { get; set; }

    /// <summary>
    /// Ask Print Non Fiscal Bill
    /// </summary>
    public bool? AskPrintNonFiscalBill { get; set; }

    /// <summary>
    /// Auto ZReport Enabled
    /// </summary>
    public bool? AutoZReportEnabled { get; set; }

    /// <summary>
    /// Auto ZReport At
    /// </summary>
    public string? AutoZReportAt { get; set; }

    /// <summary>
    /// Order Number Big
    /// </summary>
    public bool? OrderNumberBig { get; set; }

    /// <summary>
    /// Max Order Num
    /// </summary>
    public int? MaxOrderNumber { get; set; }

    /// <summary>
    /// Default Petty Cash Operator
    /// </summary>
    public int? DefaultPettyCashOperator { get; set; }

    /// <summary>
    /// Invoice Copies Number
    /// </summary>
    public int? InvoiceCopiesNumber { get; set; }

    /// <summary>
    /// Business Central Code
    /// </summary>
    public string? BusinessCentralCode { get; set; }

    public virtual ScmPayment? BedzzlePayment { get; set; }

    public virtual ScmUser? DefaultPettyCashOperatorNavigation { get; set; }

    public virtual ScmTill? DefaultSharedPrinterQueueNavigation { get; set; }

    public virtual ProductProduct? EanCopertoNavigation { get; set; }

    public virtual ICollection<ScmTill> InverseDefaultSharedPrinterQueueNavigation { get; set; } = new List<ScmTill>();

    public virtual ICollection<ScmTill> InverseMercuryGateway { get; set; } = new List<ScmTill>();

    public virtual ScmTill? MercuryGateway { get; set; }

    public virtual ScmPayment? Prepaidv2ErgoPaymentNavigation { get; set; }

    public virtual ProductProduct? RoundingProductNavigation { get; set; }

    public virtual ICollection<ScmReceiptAnalyticItem> ScmReceiptAnalyticItems { get; set; } = new List<ScmReceiptAnalyticItem>();

    public virtual ICollection<ScmReceiptHeader> ScmReceiptHeaders { get; set; } = new List<ScmReceiptHeader>();

    public virtual ICollection<ScmReceiptItem> ScmReceiptItems { get; set; } = new List<ScmReceiptItem>();

    public virtual ICollection<ScmShop> ScmShops { get; set; } = new List<ScmShop>();

    public virtual ProductProduct? ServiceProductNavigation { get; set; }

    public virtual ScmShop Shop { get; set; } = null!;

    public virtual ScmUser? UserAutologinNavigation { get; set; }
}
