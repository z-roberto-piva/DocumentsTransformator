using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.items
/// </summary>
public partial class ScmReceiptItem
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Category code
    /// </summary>
    public string? CategoryCode { get; set; }

    /// <summary>
    /// Vat Code
    /// </summary>
    public int? VatCodeId { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    public decimal? Qty { get; set; }

    /// <summary>
    /// Waiter User code
    /// </summary>
    public string? WaiterUserCode { get; set; }

    /// <summary>
    /// Date
    /// </summary>
    public string? ItemDate { get; set; }

    /// <summary>
    /// Discount rate
    /// </summary>
    public decimal? DiscountRate { get; set; }

    /// <summary>
    /// Header
    /// </summary>
    public int? HeaderId { get; set; }

    /// <summary>
    /// Product Code
    /// </summary>
    public string? ProductCode { get; set; }

    /// <summary>
    /// Fiscal Net Amount
    /// </summary>
    public decimal? FiscalNetAmount { get; set; }

    /// <summary>
    /// Fiscal Amount
    /// </summary>
    public decimal? FiscalAmount { get; set; }

    /// <summary>
    /// Unit Price
    /// </summary>
    public decimal? UnitPrice { get; set; }

    /// <summary>
    /// Gift code
    /// </summary>
    public string? GiftCode { get; set; }

    /// <summary>
    /// State
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Item Score
    /// </summary>
    public int? Score { get; set; }

    /// <summary>
    /// Serial number
    /// </summary>
    public string? SerialNumber { get; set; }

    /// <summary>
    /// Time
    /// </summary>
    public string? ItemTime { get; set; }

    /// <summary>
    /// Waiter
    /// </summary>
    public int? WaiterId { get; set; }

    /// <summary>
    /// Discountable
    /// </summary>
    public bool? Discountable { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Item Datetime
    /// </summary>
    public DateTime? ItemDatetime { get; set; }

    /// <summary>
    /// Barcode
    /// </summary>
    public string? Barcode { get; set; }

    /// <summary>
    /// Vat Code
    /// </summary>
    public string? VatCode { get; set; }

    /// <summary>
    /// Reason
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// Discount from total
    /// </summary>
    public decimal? DiscountFromTotal { get; set; }

    /// <summary>
    /// Mixmatch code
    /// </summary>
    public string? MixmatchCode { get; set; }

    /// <summary>
    /// Discount amount
    /// </summary>
    public decimal? DiscountAmount { get; set; }

    /// <summary>
    /// Product type
    /// </summary>
    public string? ProductType { get; set; }

    /// <summary>
    /// Product
    /// </summary>
    public int? ProductId { get; set; }

    /// <summary>
    /// Message text
    /// </summary>
    public string? MessageText { get; set; }

    /// <summary>
    /// Amount
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Vat Rate
    /// </summary>
    public decimal? VatRate { get; set; }

    /// <summary>
    /// Net Amount
    /// </summary>
    public decimal? NetAmount { get; set; }

    public double? Weight { get; set; }

    /// <summary>
    /// Father Product
    /// </summary>
    public string? FatherProduct { get; set; }

    /// <summary>
    /// Father Product
    /// </summary>
    public int? FatherProductId { get; set; }

    /// <summary>
    /// Product Pricelist
    /// </summary>
    public int? PriceListId { get; set; }

    /// <summary>
    /// Item Pricelist
    /// </summary>
    public string? PriceList { get; set; }

    /// <summary>
    /// Consumed Points
    /// </summary>
    public int? ConsumedPoints { get; set; }

    /// <summary>
    /// Item Real Price
    /// </summary>
    public decimal? ItemRealPrice { get; set; }

    /// <summary>
    /// Item Real Price Fiscal Net
    /// </summary>
    public decimal? ItemRealPriceFiscalNet { get; set; }

    /// <summary>
    /// Item In Menu Price
    /// </summary>
    public decimal? ItemInmenuPrice { get; set; }

    /// <summary>
    /// Menu Price
    /// </summary>
    public decimal? ItemMenuPrice { get; set; }

    /// <summary>
    /// Menu Price Fiscal Net
    /// </summary>
    public decimal? ItemMenuPriceFiscalNet { get; set; }

    /// <summary>
    /// Item In Menu Price Fiscal Net
    /// </summary>
    public decimal? ItemInmenuPriceFiscalNet { get; set; }

    /// <summary>
    /// Not Printable
    /// </summary>
    public bool? ItemNotPrintable { get; set; }

    /// <summary>
    /// Suspension Time
    /// </summary>
    public string? SuspensionTime { get; set; }

    /// <summary>
    /// Wine Emotion Barcode
    /// </summary>
    public string? ItemWineemotionBarcode { get; set; }

    /// <summary>
    /// Discount Name
    /// </summary>
    public int? DiscountOnRowId { get; set; }

    /// <summary>
    /// Promotion Label
    /// </summary>
    public string? ItemPromoLabel { get; set; }

    /// <summary>
    /// Promotion Applied
    /// </summary>
    public int? ItemPromoId { get; set; }

    /// <summary>
    /// Suspension Till
    /// </summary>
    public int? ItemTillId { get; set; }

    public virtual ProductProduct? FatherProductNavigation { get; set; }

    public virtual ScmReceiptHeader? Header { get; set; }

    public virtual ScmTill? ItemTill { get; set; }

    public virtual ProductProduct? Product { get; set; }

    public virtual ICollection<ScmReceiptItemNote> ScmReceiptItemNotes { get; set; } = new List<ScmReceiptItemNote>();

    public virtual ICollection<ScmReceiptItemPromotion> ScmReceiptItemPromotions { get; set; } = new List<ScmReceiptItemPromotion>();

    public virtual AccountTax? VatCodeNavigation { get; set; }

    public virtual ScmUser? Waiter { get; set; }
}
