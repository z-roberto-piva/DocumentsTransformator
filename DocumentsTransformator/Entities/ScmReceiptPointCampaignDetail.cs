using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.point.campaign.details
/// </summary>
public partial class ScmReceiptPointCampaignDetail
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Points Accumulated
    /// </summary>
    public int? PointsAccumulated { get; set; }

    /// <summary>
    /// Current Points Balance
    /// </summary>
    public int? CurrentPointsBalance { get; set; }

    /// <summary>
    /// Previous Points Balance
    /// </summary>
    public int? PreviousPointsBalance { get; set; }

    /// <summary>
    /// Transaction Number
    /// </summary>
    public string? TransNumber { get; set; }

    /// <summary>
    /// Extra Points Accumulated
    /// </summary>
    public int? ExtraPointsAccumulated { get; set; }

    /// <summary>
    /// Points Campaign
    /// </summary>
    public int? CampaignId { get; set; }

    /// <summary>
    /// Points Consumed
    /// </summary>
    public int? PointsConsumed { get; set; }

    /// <summary>
    /// Transaction Datetime
    /// </summary>
    public DateTime? TransDate { get; set; }

    /// <summary>
    /// Header
    /// </summary>
    public int? HeaderId { get; set; }

    /// <summary>
    /// Card Number
    /// </summary>
    public string? CardNumber { get; set; }

    public virtual ScmReceiptHeader? Header { get; set; }
}
