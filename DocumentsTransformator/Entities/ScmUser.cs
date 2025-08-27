using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.users
/// </summary>
public partial class ScmUser
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Till operator
    /// </summary>
    public bool? IsTillOperator { get; set; }

    /// <summary>
    /// Code
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Enabled
    /// </summary>
    public bool? Enabled { get; set; }

    /// <summary>
    /// Company
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// Employee
    /// </summary>
    public int? HrEmployeeId { get; set; }

    /// <summary>
    /// List on Left part of Screen
    /// </summary>
    public bool? ListOnLeft { get; set; }

    /// <summary>
    /// Passcode
    /// </summary>
    public string? Passcode { get; set; }

    /// <summary>
    /// Operator Card Number
    /// </summary>
    public string? OperatorCardNum { get; set; }

    /// <summary>
    /// Security Level
    /// </summary>
    public string? SecurityLevel { get; set; }

    /// <summary>
    /// Start Page Number
    /// </summary>
    public int? StartPageNumber { get; set; }

    /// <summary>
    /// Change Price List
    /// </summary>
    public int? PriceListId { get; set; }

    /// <summary>
    /// Override Enabled
    /// </summary>
    public bool? OverrideCashlogy { get; set; }

    /// <summary>
    /// Set Manual Cash on Payment
    /// </summary>
    public bool? ManualCash { get; set; }

    /// <summary>
    /// Set Manual Close on Payment
    /// </summary>
    public bool? ManualClosePayment { get; set; }

    /// <summary>
    /// User ID
    /// </summary>
    public string? SimsolUserId { get; set; }

    /// <summary>
    /// User API Key
    /// </summary>
    public string? SimsolUserApiKey { get; set; }

    /// <summary>
    /// Modify Product Description
    /// </summary>
    public bool? ModifyProductDescription { get; set; }

    /// <summary>
    /// Modify Product Barcodes
    /// </summary>
    public bool? ModifyProductBarcodes { get; set; }

    /// <summary>
    /// Modify Product Prices
    /// </summary>
    public bool? ModifyProductPrices { get; set; }

    public virtual ICollection<ScmReceiptHeader> ScmReceiptHeaders { get; set; } = new List<ScmReceiptHeader>();

    public virtual ICollection<ScmReceiptItem> ScmReceiptItems { get; set; } = new List<ScmReceiptItem>();

    public virtual ICollection<ScmShop> ScmShops { get; set; } = new List<ScmShop>();

    public virtual ICollection<ScmTill> ScmTillDefaultPettyCashOperatorNavigations { get; set; } = new List<ScmTill>();

    public virtual ICollection<ScmTill> ScmTillUserAutologinNavigations { get; set; } = new List<ScmTill>();
}
