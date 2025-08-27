using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// Product
/// </summary>
public partial class ProductProduct
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// EAN13 Barcode
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
    /// Variant Price Extra
    /// </summary>
    public decimal? PriceExtra { get; set; }

    /// <summary>
    /// Internal Reference
    /// </summary>
    public string DefaultCode { get; set; } = null!;

    /// <summary>
    /// Template Name
    /// </summary>
    public string? NameTemplate { get; set; }

    /// <summary>
    /// Active
    /// </summary>
    public bool? Active { get; set; }

    /// <summary>
    /// Variants
    /// </summary>
    public string? Variants { get; set; }

    /// <summary>
    /// Medium-sized image
    /// </summary>
    public byte[]? ImageMedium { get; set; }

    /// <summary>
    /// Small-sized image
    /// </summary>
    public byte[]? ImageSmall { get; set; }

    /// <summary>
    /// Product Template
    /// </summary>
    public int ProductTmplId { get; set; }

    /// <summary>
    /// Variant Price Margin
    /// </summary>
    public decimal? PriceMargin { get; set; }

    /// <summary>
    /// Track Outgoing Lots
    /// </summary>
    public bool? TrackOutgoing { get; set; }

    /// <summary>
    /// Track Incoming Lots
    /// </summary>
    public bool? TrackIncoming { get; set; }

    /// <summary>
    /// Inventory Valuation
    /// </summary>
    public string Valuation { get; set; } = null!;

    /// <summary>
    /// Track Manufacturing Lots
    /// </summary>
    public bool? TrackProduction { get; set; }

    /// <summary>
    /// Agreement Score
    /// </summary>
    public int? AgreementScore { get; set; }

    /// <summary>
    /// Discountable
    /// </summary>
    public bool? PiStatusType { get; set; }

    /// <summary>
    /// Ask For Serial Number
    /// </summary>
    public bool? AskSerialNumber { get; set; }

    /// <summary>
    /// Mix Match Promotion
    /// </summary>
    public string? MixMatchGroup { get; set; }

    /// <summary>
    /// On Ticket description
    /// </summary>
    public string? TicketDesc { get; set; }

    /// <summary>
    /// Article Reference Formula
    /// </summary>
    public string? ReferenceFormula { get; set; }

    /// <summary>
    /// Revaluation Discount Type
    /// </summary>
    public string? RevaluationDiscountType { get; set; }

    /// <summary>
    /// Price Not Modifiable
    /// </summary>
    public bool? FixedPricelist { get; set; }

    /// <summary>
    /// Production center
    /// </summary>
    public int? ProductionCenterId { get; set; }

    /// <summary>
    /// Product To Be Weighed
    /// </summary>
    public bool? IsScaleItem { get; set; }

    /// <summary>
    /// Article type
    /// </summary>
    public string? PiStatusGroup { get; set; }

    /// <summary>
    /// Discountable
    /// </summary>
    public bool? NxDiscountable { get; set; }

    /// <summary>
    /// Image Filename
    /// </summary>
    public string? ImageFilename { get; set; }

    /// <summary>
    /// Force comment
    /// </summary>
    public bool? PiStatusComment { get; set; }

    /// <summary>
    /// Product To Sell By Weight
    /// </summary>
    public bool? IsSellByWeight { get; set; }

    /// <summary>
    /// In Promotion
    /// </summary>
    public bool? InPromotion { get; set; }

    /// <summary>
    /// Revaluation Discount Value
    /// </summary>
    public double? RevaluationDiscountValue { get; set; }

    /// <summary>
    /// Price mode
    /// </summary>
    public string? PiStatusPrice { get; set; }

    /// <summary>
    /// Item status
    /// </summary>
    public int? StatusValue { get; set; }

    /// <summary>
    /// Service included
    /// </summary>
    public bool? PiStatusService { get; set; }

    /// <summary>
    /// Article Type 
    /// </summary>
    public string? SubType { get; set; }

    /// <summary>
    /// Don&apos;t print if value is zero
    /// </summary>
    public bool? DontPrintIfZero { get; set; }

    /// <summary>
    /// Article Reference Price
    /// </summary>
    public string? ReferencePrice { get; set; }

    /// <summary>
    /// Is Service Article
    /// </summary>
    public bool? IsServiceArticle { get; set; }

    /// <summary>
    /// Ask for Price
    /// </summary>
    public bool? AskPromptPrice { get; set; }

    /// <summary>
    /// Have Stock Moves
    /// </summary>
    public bool? HaveStockMoves { get; set; }

    /// <summary>
    /// Is Negative
    /// </summary>
    public bool? IsNegative { get; set; }

    /// <summary>
    /// Is Addition
    /// </summary>
    public bool? IsAddition { get; set; }

    /// <summary>
    /// Is No Food
    /// </summary>
    public bool? IsNoFood { get; set; }

    /// <summary>
    /// Not managed in stock
    /// </summary>
    public bool? NotManagedInStock { get; set; }

    /// <summary>
    /// Is Service Variable
    /// </summary>
    public bool? IsServiceVariable { get; set; }

    /// <summary>
    /// Is Service Applicable
    /// </summary>
    public bool? IsServiceApplicable { get; set; }

    /// <summary>
    /// Status Max Price
    /// </summary>
    public string? PiStatusMaxPrice { get; set; }

    /// <summary>
    /// Status Min price
    /// </summary>
    public string? PiStatusMinPrice { get; set; }

    /// <summary>
    /// Blocked Prices
    /// </summary>
    public bool? PiStatusBlockedPrices { get; set; }

    /// <summary>
    /// Not for Points Accumulation
    /// </summary>
    public bool? NotForPointsAccumulation { get; set; }

    /// <summary>
    /// Note
    /// </summary>
    public string? ProductNotes { get; set; }

    /// <summary>
    /// Print Reverse on Kitchen
    /// </summary>
    public bool? PrintReverse { get; set; }

    /// <summary>
    /// Sort Kitchen
    /// </summary>
    public int? PiSortKitchen { get; set; }

    /// <summary>
    /// Aggio Percentage
    /// </summary>
    public double? AggioPerc { get; set; }

    /// <summary>
    /// Aggio Value
    /// </summary>
    public double? AggioValue { get; set; }

    /// <summary>
    /// Not Printable on Fiscal
    /// </summary>
    public bool? NotPrintableOnFiscal { get; set; }

    /// <summary>
    /// Win Payment
    /// </summary>
    public int? WinPayment { get; set; }

    /// <summary>
    /// Linked Product Voucher
    /// </summary>
    public int? LinkedProductVoucher { get; set; }

    /// <summary>
    /// Validity days of the voucher
    /// </summary>
    public int? LinkedProductVoucherDays { get; set; }

    /// <summary>
    /// Is for Adults
    /// </summary>
    public bool? IsForAdults { get; set; }

    /// <summary>
    /// Is for Primanota
    /// </summary>
    public bool? IsForPrimanota { get; set; }

    /// <summary>
    /// Print Voucher
    /// </summary>
    public bool? PrintVoucher { get; set; }

    /// <summary>
    /// Pieces for carton
    /// </summary>
    public int? LabelCp { get; set; }

    /// <summary>
    /// Label UM
    /// </summary>
    public string? LabelUm { get; set; }

    /// <summary>
    /// Label Quantity
    /// </summary>
    public double? LabelQty { get; set; }

    /// <summary>
    /// Sale Type
    /// </summary>
    public string? SaleType { get; set; }

    /// <summary>
    /// Scale PLU
    /// </summary>
    public string? PluScale { get; set; }

    /// <summary>
    /// Mandatory Note
    /// </summary>
    public bool? MandatoryNote { get; set; }

    /// <summary>
    /// Single Print in Kitchen
    /// </summary>
    public bool? SinglePrintInKitchen { get; set; }

    /// <summary>
    /// Image timestamp
    /// </summary>
    public decimal? ImageTimestamp { get; set; }

    /// <summary>
    /// Vat Description
    /// </summary>
    public string? TicVatDescription { get; set; }

    /// <summary>
    /// Vat Code
    /// </summary>
    public string? TicVatCode { get; set; }

    /// <summary>
    /// Eans
    /// </summary>
    public string? TicEans { get; set; }

    /// <summary>
    /// Euro/Kg price
    /// </summary>
    public double? TicWeightSellingPrice { get; set; }

    /// <summary>
    /// Minimum purchasable quantity in kg
    /// </summary>
    public double? TicMinBuyingKg { get; set; }

    /// <summary>
    /// Product Description
    /// </summary>
    public string? TicDescription { get; set; }

    /// <summary>
    /// Category
    /// </summary>
    public string? TicCategory { get; set; }

    /// <summary>
    /// Last Time Updated
    /// </summary>
    public DateTime? TicLastTimeUpdated { get; set; }

    /// <summary>
    /// Is radiated
    /// </summary>
    public bool? TicIsRadiato { get; set; }

    /// <summary>
    /// AAMS Code
    /// </summary>
    public string? TicAamsCode { get; set; }

    /// <summary>
    /// Alias
    /// </summary>
    public string? TicAlias { get; set; }

    /// <summary>
    /// Vat Amount %
    /// </summary>
    public double? TicVatAmount { get; set; }

    /// <summary>
    /// Euro/piece price
    /// </summary>
    public double? TicPackagingSellingPrice { get; set; }

    /// <summary>
    /// Description Type
    /// </summary>
    public string? TicDescriptionType { get; set; }

    /// <summary>
    /// Product Code
    /// </summary>
    public string? TicCode { get; set; }

    /// <summary>
    /// Minimum purchasable quantity in pieces
    /// </summary>
    public double? TicMinBuyingQty { get; set; }

    public virtual ICollection<ProductProduct> InverseLinkedProductVoucherNavigation { get; set; } = new List<ProductProduct>();

    public virtual ProductProduct? LinkedProductVoucherNavigation { get; set; }

    public virtual ProductTemplate ProductTmpl { get; set; } = null!;

    public virtual ICollection<ScmReceiptAnalyticItem> ScmReceiptAnalyticItems { get; set; } = new List<ScmReceiptAnalyticItem>();

    public virtual ICollection<ScmReceiptItem> ScmReceiptItemFatherProductNavigations { get; set; } = new List<ScmReceiptItem>();

    public virtual ICollection<ScmReceiptItem> ScmReceiptItemProducts { get; set; } = new List<ScmReceiptItem>();

    public virtual ICollection<ScmReceiptPaymentDivision> ScmReceiptPaymentDivisions { get; set; } = new List<ScmReceiptPaymentDivision>();

    public virtual ICollection<ScmShop> ScmShopCompleteMealProductNavigations { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmShop> ScmShopDefaultCoverArticleForTableServiceNavigations { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmShop> ScmShopDefaultPrepaidTicketRechargeProductNavigations { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmShop> ScmShopDeliveryProductId2Navigations { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmShop> ScmShopDeliveryProductId3Navigations { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmShop> ScmShopDeliveryProducts { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmShop> ScmShopExpressProducts { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmShop> ScmShopGiftProducts { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmShop> ScmShopPikupProducts { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmShop> ScmShopRechargeBonusItemNavigations { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmShop> ScmShopTableCoverProducts { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmTill> ScmTillEanCopertoNavigations { get; set; } = new List<ScmTill>();

    public virtual ICollection<ScmTill> ScmTillRoundingProductNavigations { get; set; } = new List<ScmTill>();

    public virtual ICollection<ScmTill> ScmTillServiceProductNavigations { get; set; } = new List<ScmTill>();
}
