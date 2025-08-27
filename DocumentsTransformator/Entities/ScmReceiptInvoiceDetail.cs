using System;
using System.Collections.Generic;

namespace DocumentsTransformator.Entities;

/// <summary>
/// scm.receipt.invoice.details
/// </summary>
public partial class ScmReceiptInvoiceDetail
{
    public int Id { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? WriteUid { get; set; }

    /// <summary>
    /// Company Phone
    /// </summary>
    public string? CompanyPhone { get; set; }

    /// <summary>
    /// Company Street
    /// </summary>
    public string? CompanyStreet { get; set; }

    /// <summary>
    /// Company Zip
    /// </summary>
    public string? CompanyZip { get; set; }

    /// <summary>
    /// Company Vat Code
    /// </summary>
    public string? CompanyVatCode { get; set; }

    /// <summary>
    /// Company Mail
    /// </summary>
    public string? CompanyMail { get; set; }

    /// <summary>
    /// Company Number
    /// </summary>
    public string? CompanyNumber { get; set; }

    /// <summary>
    /// Company City
    /// </summary>
    public string? CompanyCity { get; set; }

    /// <summary>
    /// Company Name
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// Company Country
    /// </summary>
    public string? CompanyCountry { get; set; }

    /// <summary>
    /// Header
    /// </summary>
    public int? HeaderId { get; set; }

    /// <summary>
    /// Company Is For invoice
    /// </summary>
    public bool? CompanyIsForInvoice { get; set; }

    /// <summary>
    /// Company Fiscal Code
    /// </summary>
    public string? CompanyFiscalCode { get; set; }

    /// <summary>
    /// Card Expiration Date
    /// </summary>
    public string? ExpirationDate { get; set; }

    /// <summary>
    /// Birthday Date
    /// </summary>
    public string? BirthdayDate { get; set; }

    /// <summary>
    /// Company Is For invoice
    /// </summary>
    public bool? IsPrepaidOnDb { get; set; }

    /// <summary>
    /// Company Codice Destinatario
    /// </summary>
    public string? CompanyCodiceDestinatario { get; set; }

    /// <summary>
    /// Company Cod SDI
    /// </summary>
    public string? CompanyCodsdi { get; set; }

    /// <summary>
    /// Company Pec
    /// </summary>
    public string? CompanyPec { get; set; }

    public virtual ScmReceiptHeader? Header { get; set; }
}
