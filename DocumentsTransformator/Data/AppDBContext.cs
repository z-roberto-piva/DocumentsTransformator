using System;
using System.Collections.Generic;
using DocumentsTransformator.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocumentsTransformator.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountTax> AccountTaxes { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductProduct> ProductProducts { get; set; }

    public virtual DbSet<ProductTemplate> ProductTemplates { get; set; }

    public virtual DbSet<ProductUom> ProductUoms { get; set; }

    public virtual DbSet<ResPartner> ResPartners { get; set; }

    public virtual DbSet<ScmReceiptAgreement> ScmReceiptAgreements { get; set; }

    public virtual DbSet<ScmReceiptAnalyticItem> ScmReceiptAnalyticItems { get; set; }

    public virtual DbSet<ScmReceiptCouponsDetail> ScmReceiptCouponsDetails { get; set; }

    public virtual DbSet<ScmReceiptDiscountDetail> ScmReceiptDiscountDetails { get; set; }

    public virtual DbSet<ScmReceiptHeader> ScmReceiptHeaders { get; set; }

    public virtual DbSet<ScmReceiptInvoiceDetail> ScmReceiptInvoiceDetails { get; set; }

    public virtual DbSet<ScmReceiptItem> ScmReceiptItems { get; set; }

    public virtual DbSet<ScmReceiptItemNote> ScmReceiptItemNotes { get; set; }

    public virtual DbSet<ScmReceiptItemPromotion> ScmReceiptItemPromotions { get; set; }

    public virtual DbSet<ScmReceiptPayment> ScmReceiptPayments { get; set; }

    public virtual DbSet<ScmReceiptPaymentDivision> ScmReceiptPaymentDivisions { get; set; }

    public virtual DbSet<ScmReceiptPointCampaignDetail> ScmReceiptPointCampaignDetails { get; set; }

    public virtual DbSet<ScmReceiptPrepaidDetail> ScmReceiptPrepaidDetails { get; set; }

    public virtual DbSet<ScmReceiptProfitCenter> ScmReceiptProfitCenters { get; set; }

    public virtual DbSet<ScmReceiptVat> ScmReceiptVats { get; set; }

    public virtual DbSet<ScmShop> ScmShops { get; set; }

    public virtual DbSet<ScmTill> ScmTills { get; set; }

    public virtual DbSet<ScmUser> ScmUsers { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseNpgsql("Host=localhost;Username=zmenu;Password=sviluppo;Database=anondb_dev");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("dblink")
            .HasPostgresExtension("multicorn")
            .HasPostgresExtension("postgres_fdw")
            .HasPostgresExtension("tablefunc");

        modelBuilder.Entity<AccountTax>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_tax_pkey");

            entity.ToTable("account_tax", tb => tb.HasComment("Tax"));

            entity.HasIndex(e => new { e.Name, e.CompanyId }, "account_tax_name_company_uniq").IsUnique();

            entity.HasIndex(e => e.ParentId, "account_tax_parent_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountAnalyticCollectedId)
                .HasComment("Invoice Tax Analytic Account")
                .HasColumnName("account_analytic_collected_id");
            entity.Property(e => e.AccountAnalyticPaidId)
                .HasComment("Refund Tax Analytic Account")
                .HasColumnName("account_analytic_paid_id");
            entity.Property(e => e.AccountCollectedId)
                .HasComment("Invoice Tax Account")
                .HasColumnName("account_collected_id");
            entity.Property(e => e.AccountPaidId)
                .HasComment("Refund Tax Account")
                .HasColumnName("account_paid_id");
            entity.Property(e => e.Active)
                .HasComment("Active")
                .HasColumnName("active");
            entity.Property(e => e.Amount)
                .HasComment("Amount")
                .HasColumnName("amount");
            entity.Property(e => e.ApplicableType)
                .HasComment("Applicability")
                .HasColumnType("character varying")
                .HasColumnName("applicable_type");
            entity.Property(e => e.BaseCodeId)
                .HasComment("Account Base Code")
                .HasColumnName("base_code_id");
            entity.Property(e => e.BaseSign)
                .HasComment("Base Code Sign")
                .HasColumnName("base_sign");
            entity.Property(e => e.ChildDepend)
                .HasComment("Tax on Children")
                .HasColumnName("child_depend");
            entity.Property(e => e.CompanyId)
                .HasComment("Company")
                .HasColumnName("company_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.Description)
                .HasComment("Tax Code")
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Domain)
                .HasMaxLength(32)
                .HasComment("Domain")
                .HasColumnName("domain");
            entity.Property(e => e.IncludeBaseAmount)
                .HasComment("Included in base amount")
                .HasColumnName("include_base_amount");
            entity.Property(e => e.KindId)
                .HasComment("Exemption Kind")
                .HasColumnName("kind_id");
            entity.Property(e => e.LawReference)
                .HasColumnType("character varying")
                .HasColumnName("law_reference");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasComment("Tax Name")
                .HasColumnName("name");
            entity.Property(e => e.NonTaxableNature)
                .HasComment("Non taxable nature")
                .HasColumnType("character varying")
                .HasColumnName("non_taxable_nature");
            entity.Property(e => e.ParentId)
                .HasComment("Parent Tax Account")
                .HasColumnName("parent_id");
            entity.Property(e => e.Payability)
                .HasComment("VAT payability")
                .HasColumnType("character varying")
                .HasColumnName("payability");
            entity.Property(e => e.PriceInclude)
                .HasComment("Tax Included in Price")
                .HasColumnName("price_include");
            entity.Property(e => e.PythonApplicable)
                .HasComment("Python Code")
                .HasColumnName("python_applicable");
            entity.Property(e => e.PythonCompute)
                .HasComment("Python Code")
                .HasColumnName("python_compute");
            entity.Property(e => e.PythonComputeInv)
                .HasComment("Python Code (reverse)")
                .HasColumnName("python_compute_inv");
            entity.Property(e => e.RefBaseCodeId)
                .HasComment("Refund Base Code")
                .HasColumnName("ref_base_code_id");
            entity.Property(e => e.RefBaseSign)
                .HasComment("Base Code Sign")
                .HasColumnName("ref_base_sign");
            entity.Property(e => e.RefTaxCodeId)
                .HasComment("Refund Tax Code")
                .HasColumnName("ref_tax_code_id");
            entity.Property(e => e.RefTaxSign)
                .HasComment("Tax Code Sign")
                .HasColumnName("ref_tax_sign");
            entity.Property(e => e.ScmPiIndex)
                .HasComment("Index on PI till")
                .HasColumnName("scm_pi_index");
            entity.Property(e => e.Sequence)
                .HasComment("Sequence")
                .HasColumnName("sequence");
            entity.Property(e => e.TaxCodeId)
                .HasComment("Account Tax Code")
                .HasColumnName("tax_code_id");
            entity.Property(e => e.TaxSign)
                .HasComment("Tax Code Sign")
                .HasColumnName("tax_sign");
            entity.Property(e => e.Type)
                .HasComment("Tax Type")
                .HasColumnType("character varying")
                .HasColumnName("type");
            entity.Property(e => e.TypeTaxUse)
                .HasComment("Tax Application")
                .HasColumnType("character varying")
                .HasColumnName("type_tax_use");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_tax_parent_id_fkey");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_category_pkey");

            entity.ToTable("product_category", tb => tb.HasComment("Product Category"));

            entity.HasIndex(e => e.Code, "product_category_code_index");

            entity.HasIndex(e => e.Code, "product_category_code_uniq").IsUnique();

            entity.HasIndex(e => e.Name, "product_category_name_index");

            entity.HasIndex(e => e.Name, "product_category_name_uniq").IsUnique();

            entity.HasIndex(e => e.ParentId, "product_category_parent_id_index");

            entity.HasIndex(e => e.ParentLeft, "product_category_parent_left_index");

            entity.HasIndex(e => e.ParentRight, "product_category_parent_right_index");

            entity.HasIndex(e => e.SaleType, "product_category_sale_type_index");

            entity.HasIndex(e => e.Sequence, "product_category_sequence_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BusinessCentralCodePrefix)
                .HasComment("Business Central Code Prefix")
                .HasColumnType("character varying")
                .HasColumnName("business_central_code_prefix");
            entity.Property(e => e.Code)
                .HasMaxLength(64)
                .HasComment("Code")
                .HasColumnName("code");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.IsForFees)
                .HasComment("Is for Fees")
                .HasColumnName("is_for_fees");
            entity.Property(e => e.IsForStatistics)
                .HasComment("Is for statistics")
                .HasColumnName("is_for_statistics");
            entity.Property(e => e.IsForValueAssignement)
                .HasComment("Is for value assignement")
                .HasColumnName("is_for_value_assignement");
            entity.Property(e => e.IsNoFood)
                .HasComment("Is No Food")
                .HasColumnName("is_no_food");
            entity.Property(e => e.IsSubFamily)
                .HasComment("Is sub family")
                .HasColumnName("is_sub_family");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasComment("Name")
                .HasColumnName("name");
            entity.Property(e => e.NotPrintableOnFiscal)
                .HasComment("Not Printable on Fiscal")
                .HasColumnName("not_printable_on_fiscal");
            entity.Property(e => e.NxDiscountable)
                .HasComment("Discountable")
                .HasColumnName("nx_discountable");
            entity.Property(e => e.ParentId)
                .HasComment("Parent Category")
                .HasColumnName("parent_id");
            entity.Property(e => e.ParentLeft).HasColumnName("parent_left");
            entity.Property(e => e.ParentRight).HasColumnName("parent_right");
            entity.Property(e => e.PiColor)
                .HasComment("Color")
                .HasColumnName("pi_color");
            entity.Property(e => e.PrintOnSecondaryFiscalPrinter)
                .HasComment("Print On Secondary Fiscal Printer")
                .HasColumnName("print_on_secondary_fiscal_printer");
            entity.Property(e => e.SaleType)
                .HasComment("Sale Type")
                .HasColumnType("character varying")
                .HasColumnName("sale_type");
            entity.Property(e => e.ScmTaxId)
                .HasComment("Tax")
                .HasColumnName("scm_tax_id");
            entity.Property(e => e.Sequence)
                .HasComment("Sequence")
                .HasColumnName("sequence");
            entity.Property(e => e.Type)
                .HasComment("Category Type")
                .HasColumnType("character varying")
                .HasColumnName("type");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_category_parent_id_fkey");
        });

        modelBuilder.Entity<ProductProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_product_pkey");

            entity.ToTable("product_product", tb => tb.HasComment("Product"));

            entity.HasIndex(e => e.DefaultCode, "product_product_default_code_index");

            entity.HasIndex(e => e.DefaultCode, "product_product_default_code_uniq").IsUnique();

            entity.HasIndex(e => e.NameTemplate, "product_product_name_template_index");

            entity.HasIndex(e => e.ProductTmplId, "product_product_product_tmpl_id_index");

            entity.HasIndex(e => e.SaleType, "product_product_sale_type_index");

            entity.HasIndex(e => e.SubType, "product_product_sub_type_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasComment("Active")
                .HasColumnName("active");
            entity.Property(e => e.AggioPerc)
                .HasComment("Aggio Percentage")
                .HasColumnName("aggio_perc");
            entity.Property(e => e.AggioValue)
                .HasComment("Aggio Value")
                .HasColumnName("aggio_value");
            entity.Property(e => e.AgreementScore)
                .HasComment("Agreement Score")
                .HasColumnName("agreement_score");
            entity.Property(e => e.AskPromptPrice)
                .HasComment("Ask for Price")
                .HasColumnName("ask_prompt_price");
            entity.Property(e => e.AskSerialNumber)
                .HasComment("Ask For Serial Number")
                .HasColumnName("ask_serial_number");
            entity.Property(e => e.Color)
                .HasComment("Color Index")
                .HasColumnName("color");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.DefaultCode)
                .HasMaxLength(64)
                .HasComment("Internal Reference")
                .HasColumnName("default_code");
            entity.Property(e => e.DontPrintIfZero)
                .HasComment("Don't print if value is zero")
                .HasColumnName("dont_print_if_zero");
            entity.Property(e => e.Ean13)
                .HasMaxLength(13)
                .HasComment("EAN13 Barcode")
                .HasColumnName("ean13");
            entity.Property(e => e.FixedPricelist)
                .HasComment("Price Not Modifiable")
                .HasColumnName("fixed_pricelist");
            entity.Property(e => e.HaveStockMoves)
                .HasComment("Have Stock Moves")
                .HasColumnName("have_stock_moves");
            entity.Property(e => e.Image)
                .HasComment("Image")
                .HasColumnName("image");
            entity.Property(e => e.ImageFilename)
                .HasMaxLength(50)
                .HasComment("Image Filename")
                .HasColumnName("image_filename");
            entity.Property(e => e.ImageMedium)
                .HasComment("Medium-sized image")
                .HasColumnName("image_medium");
            entity.Property(e => e.ImageSmall)
                .HasComment("Small-sized image")
                .HasColumnName("image_small");
            entity.Property(e => e.ImageTimestamp)
                .HasComment("Image timestamp")
                .HasColumnName("image_timestamp");
            entity.Property(e => e.InPromotion)
                .HasComment("In Promotion")
                .HasColumnName("in_promotion");
            entity.Property(e => e.IsAddition)
                .HasComment("Is Addition")
                .HasColumnName("is_addition");
            entity.Property(e => e.IsForAdults)
                .HasComment("Is for Adults")
                .HasColumnName("is_for_adults");
            entity.Property(e => e.IsForPrimanota)
                .HasComment("Is for Primanota")
                .HasColumnName("is_for_primanota");
            entity.Property(e => e.IsNegative)
                .HasComment("Is Negative")
                .HasColumnName("is_negative");
            entity.Property(e => e.IsNoFood)
                .HasComment("Is No Food")
                .HasColumnName("is_no_food");
            entity.Property(e => e.IsScaleItem)
                .HasComment("Product To Be Weighed")
                .HasColumnName("is_scale_item");
            entity.Property(e => e.IsSellByWeight)
                .HasComment("Product To Sell By Weight")
                .HasColumnName("is_sell_by_weight");
            entity.Property(e => e.IsServiceApplicable)
                .HasComment("Is Service Applicable")
                .HasColumnName("is_service_applicable");
            entity.Property(e => e.IsServiceArticle)
                .HasComment("Is Service Article")
                .HasColumnName("is_service_article");
            entity.Property(e => e.IsServiceVariable)
                .HasComment("Is Service Variable")
                .HasColumnName("is_service_variable");
            entity.Property(e => e.LabelCp)
                .HasComment("Pieces for carton")
                .HasColumnName("label_cp");
            entity.Property(e => e.LabelQty)
                .HasComment("Label Quantity")
                .HasColumnName("label_qty");
            entity.Property(e => e.LabelUm)
                .HasComment("Label UM")
                .HasColumnType("character varying")
                .HasColumnName("label_um");
            entity.Property(e => e.LinkedProductVoucher)
                .HasComment("Linked Product Voucher")
                .HasColumnName("linked_product_voucher");
            entity.Property(e => e.LinkedProductVoucherDays)
                .HasComment("Validity days of the voucher")
                .HasColumnName("linked_product_voucher_days");
            entity.Property(e => e.MandatoryNote)
                .HasComment("Mandatory Note")
                .HasColumnName("mandatory_note");
            entity.Property(e => e.MixMatchGroup)
                .HasMaxLength(5)
                .HasComment("Mix Match Promotion")
                .HasColumnName("mix_match_group");
            entity.Property(e => e.NameTemplate)
                .HasMaxLength(128)
                .HasComment("Template Name")
                .HasColumnName("name_template");
            entity.Property(e => e.NotForPointsAccumulation)
                .HasComment("Not for Points Accumulation")
                .HasColumnName("not_for_points_accumulation");
            entity.Property(e => e.NotManagedInStock)
                .HasComment("Not managed in stock")
                .HasColumnName("not_managed_in_stock");
            entity.Property(e => e.NotPrintableOnFiscal)
                .HasComment("Not Printable on Fiscal")
                .HasColumnName("not_printable_on_fiscal");
            entity.Property(e => e.NxDiscountable)
                .HasComment("Discountable")
                .HasColumnName("nx_discountable");
            entity.Property(e => e.PiSortKitchen)
                .HasComment("Sort Kitchen")
                .HasColumnName("pi_sort_kitchen");
            entity.Property(e => e.PiStatusBlockedPrices)
                .HasComment("Blocked Prices")
                .HasColumnName("pi_status_blocked_prices");
            entity.Property(e => e.PiStatusComment)
                .HasComment("Force comment")
                .HasColumnName("pi_status_comment");
            entity.Property(e => e.PiStatusGroup)
                .HasComment("Article type")
                .HasColumnType("character varying")
                .HasColumnName("pi_status_group");
            entity.Property(e => e.PiStatusMaxPrice)
                .HasComment("Status Max Price")
                .HasColumnType("character varying")
                .HasColumnName("pi_status_max_price");
            entity.Property(e => e.PiStatusMinPrice)
                .HasComment("Status Min price")
                .HasColumnType("character varying")
                .HasColumnName("pi_status_min_price");
            entity.Property(e => e.PiStatusPrice)
                .HasComment("Price mode")
                .HasColumnType("character varying")
                .HasColumnName("pi_status_price");
            entity.Property(e => e.PiStatusService)
                .HasComment("Service included")
                .HasColumnName("pi_status_service");
            entity.Property(e => e.PiStatusType)
                .HasComment("Discountable")
                .HasColumnName("pi_status_type");
            entity.Property(e => e.PluScale)
                .HasComment("Scale PLU")
                .HasColumnType("character varying")
                .HasColumnName("plu_scale");
            entity.Property(e => e.PriceExtra)
                .HasComment("Variant Price Extra")
                .HasColumnName("price_extra");
            entity.Property(e => e.PriceMargin)
                .HasComment("Variant Price Margin")
                .HasColumnName("price_margin");
            entity.Property(e => e.PrintReverse)
                .HasComment("Print Reverse on Kitchen")
                .HasColumnName("print_reverse");
            entity.Property(e => e.PrintVoucher)
                .HasComment("Print Voucher")
                .HasColumnName("print_voucher");
            entity.Property(e => e.ProductNotes)
                .HasComment("Note")
                .HasColumnName("product_notes");
            entity.Property(e => e.ProductTmplId)
                .HasComment("Product Template")
                .HasColumnName("product_tmpl_id");
            entity.Property(e => e.ProductionCenterId)
                .HasComment("Production center")
                .HasColumnName("production_center_id");
            entity.Property(e => e.ReferenceFormula)
                .HasMaxLength(20)
                .HasComment("Article Reference Formula")
                .HasColumnName("reference_formula");
            entity.Property(e => e.ReferencePrice)
                .HasMaxLength(20)
                .HasComment("Article Reference Price")
                .HasColumnName("reference_price");
            entity.Property(e => e.RevaluationDiscountType)
                .HasComment("Revaluation Discount Type")
                .HasColumnType("character varying")
                .HasColumnName("revaluation_discount_type");
            entity.Property(e => e.RevaluationDiscountValue)
                .HasComment("Revaluation Discount Value")
                .HasColumnName("revaluation_discount_value");
            entity.Property(e => e.SaleType)
                .HasComment("Sale Type")
                .HasColumnType("character varying")
                .HasColumnName("sale_type");
            entity.Property(e => e.SinglePrintInKitchen)
                .HasComment("Single Print in Kitchen")
                .HasColumnName("single_print_in_kitchen");
            entity.Property(e => e.StatusValue)
                .HasComment("Item status")
                .HasColumnName("status_value");
            entity.Property(e => e.SubType)
                .HasComment("Article Type ")
                .HasColumnType("character varying")
                .HasColumnName("sub_type");
            entity.Property(e => e.TicAamsCode)
                .HasComment("AAMS Code")
                .HasColumnType("character varying")
                .HasColumnName("tic_aams_code");
            entity.Property(e => e.TicAlias)
                .HasComment("Alias")
                .HasColumnType("character varying")
                .HasColumnName("tic_alias");
            entity.Property(e => e.TicCategory)
                .HasComment("Category")
                .HasColumnType("character varying")
                .HasColumnName("tic_category");
            entity.Property(e => e.TicCode)
                .HasComment("Product Code")
                .HasColumnType("character varying")
                .HasColumnName("tic_code");
            entity.Property(e => e.TicDescription)
                .HasComment("Product Description")
                .HasColumnType("character varying")
                .HasColumnName("tic_description");
            entity.Property(e => e.TicDescriptionType)
                .HasComment("Description Type")
                .HasColumnType("character varying")
                .HasColumnName("tic_description_type");
            entity.Property(e => e.TicEans)
                .HasComment("Eans")
                .HasColumnType("character varying")
                .HasColumnName("tic_eans");
            entity.Property(e => e.TicIsRadiato)
                .HasComment("Is radiated")
                .HasColumnName("tic_is_radiato");
            entity.Property(e => e.TicLastTimeUpdated)
                .HasComment("Last Time Updated")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("tic_last_time_updated");
            entity.Property(e => e.TicMinBuyingKg)
                .HasComment("Minimum purchasable quantity in kg")
                .HasColumnName("tic_min_buying_kg");
            entity.Property(e => e.TicMinBuyingQty)
                .HasComment("Minimum purchasable quantity in pieces")
                .HasColumnName("tic_min_buying_qty");
            entity.Property(e => e.TicPackagingSellingPrice)
                .HasComment("Euro/piece price")
                .HasColumnName("tic_packaging_selling_price");
            entity.Property(e => e.TicVatAmount)
                .HasComment("Vat Amount %")
                .HasColumnName("tic_vat_amount");
            entity.Property(e => e.TicVatCode)
                .HasComment("Vat Code")
                .HasColumnType("character varying")
                .HasColumnName("tic_vat_code");
            entity.Property(e => e.TicVatDescription)
                .HasComment("Vat Description")
                .HasColumnType("character varying")
                .HasColumnName("tic_vat_description");
            entity.Property(e => e.TicWeightSellingPrice)
                .HasComment("Euro/Kg price")
                .HasColumnName("tic_weight_selling_price");
            entity.Property(e => e.TicketDesc)
                .HasMaxLength(20)
                .HasComment("On Ticket description")
                .HasColumnName("ticket_desc");
            entity.Property(e => e.TrackIncoming)
                .HasComment("Track Incoming Lots")
                .HasColumnName("track_incoming");
            entity.Property(e => e.TrackOutgoing)
                .HasComment("Track Outgoing Lots")
                .HasColumnName("track_outgoing");
            entity.Property(e => e.TrackProduction)
                .HasComment("Track Manufacturing Lots")
                .HasColumnName("track_production");
            entity.Property(e => e.Valuation)
                .HasComment("Inventory Valuation")
                .HasColumnType("character varying")
                .HasColumnName("valuation");
            entity.Property(e => e.Variants)
                .HasMaxLength(64)
                .HasComment("Variants")
                .HasColumnName("variants");
            entity.Property(e => e.WinPayment)
                .HasComment("Win Payment")
                .HasColumnName("win_payment");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.LinkedProductVoucherNavigation).WithMany(p => p.InverseLinkedProductVoucherNavigation)
                .HasForeignKey(d => d.LinkedProductVoucher)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_product_linked_product_voucher_fkey");

            entity.HasOne(d => d.ProductTmpl).WithMany(p => p.ProductProducts)
                .HasForeignKey(d => d.ProductTmplId)
                .HasConstraintName("product_product_product_tmpl_id_fkey");
        });

        modelBuilder.Entity<ProductTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_template_pkey");

            entity.ToTable("product_template", tb => tb.HasComment("Product Template"));

            entity.HasIndex(e => e.CompanyId, "product_template_company_id_index");

            entity.HasIndex(e => e.Name, "product_template_name_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategId)
                .HasComment("Category")
                .HasColumnName("categ_id");
            entity.Property(e => e.CompanyId)
                .HasComment("Company")
                .HasColumnName("company_id");
            entity.Property(e => e.CostMethod)
                .HasComment("Costing Method")
                .HasColumnType("character varying")
                .HasColumnName("cost_method");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.Description)
                .HasComment("Description")
                .HasColumnName("description");
            entity.Property(e => e.DescriptionPurchase)
                .HasComment("Purchase Description")
                .HasColumnName("description_purchase");
            entity.Property(e => e.DescriptionSale)
                .HasComment("Sale Description")
                .HasColumnName("description_sale");
            entity.Property(e => e.FiscalCategId)
                .HasComment("Fiscal category")
                .HasColumnName("fiscal_categ_id");
            entity.Property(e => e.ListPrice)
                .HasComment("Sale Price")
                .HasColumnName("list_price");
            entity.Property(e => e.LocCase)
                .HasMaxLength(16)
                .HasComment("Case")
                .HasColumnName("loc_case");
            entity.Property(e => e.LocRack)
                .HasMaxLength(16)
                .HasComment("Rack")
                .HasColumnName("loc_rack");
            entity.Property(e => e.LocRow)
                .HasMaxLength(16)
                .HasComment("Row")
                .HasColumnName("loc_row");
            entity.Property(e => e.MesType)
                .HasComment("Measure Type")
                .HasColumnType("character varying")
                .HasColumnName("mes_type");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasComment("Name")
                .HasColumnName("name");
            entity.Property(e => e.ProcureMethod)
                .HasComment("Procurement Method")
                .HasColumnType("character varying")
                .HasColumnName("procure_method");
            entity.Property(e => e.ProduceDelay)
                .HasComment("Manufacturing Lead Time")
                .HasColumnName("produce_delay");
            entity.Property(e => e.ProductManager)
                .HasComment("Product Manager")
                .HasColumnName("product_manager");
            entity.Property(e => e.PurchaseOk)
                .HasComment("Can be Purchased")
                .HasColumnName("purchase_ok");
            entity.Property(e => e.Rental)
                .HasComment("Can be Rent")
                .HasColumnName("rental");
            entity.Property(e => e.SaleDelay)
                .HasComment("Customer Lead Time")
                .HasColumnName("sale_delay");
            entity.Property(e => e.SaleOk)
                .HasComment("Can be Sold")
                .HasColumnName("sale_ok");
            entity.Property(e => e.StandardPrice)
                .HasComment("Cost")
                .HasColumnName("standard_price");
            entity.Property(e => e.State)
                .HasComment("Status")
                .HasColumnType("character varying")
                .HasColumnName("state");
            entity.Property(e => e.SubfamilyId)
                .HasComment("Sub Family")
                .HasColumnName("subfamily_id");
            entity.Property(e => e.SupplyMethod)
                .HasComment("Supply Method")
                .HasColumnType("character varying")
                .HasColumnName("supply_method");
            entity.Property(e => e.Type)
                .HasComment("Product Type")
                .HasColumnType("character varying")
                .HasColumnName("type");
            entity.Property(e => e.UomId)
                .HasComment("Unit of Measure")
                .HasColumnName("uom_id");
            entity.Property(e => e.UomPoId)
                .HasComment("Purchase Unit of Measure")
                .HasColumnName("uom_po_id");
            entity.Property(e => e.UosCoeff)
                .HasComment("Unit of Measure -> UOS Coeff")
                .HasColumnName("uos_coeff");
            entity.Property(e => e.UosId)
                .HasComment("Unit of Sale")
                .HasColumnName("uos_id");
            entity.Property(e => e.Volume)
                .HasComment("Volume")
                .HasColumnName("volume");
            entity.Property(e => e.Warranty)
                .HasComment("Warranty")
                .HasColumnName("warranty");
            entity.Property(e => e.Weight)
                .HasComment("Gross Weight")
                .HasColumnName("weight");
            entity.Property(e => e.WeightNet)
                .HasComment("Net Weight")
                .HasColumnName("weight_net");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Categ).WithMany(p => p.ProductTemplateCategs)
                .HasForeignKey(d => d.CategId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_template_categ_id_fkey");

            entity.HasOne(d => d.FiscalCateg).WithMany(p => p.ProductTemplateFiscalCategs)
                .HasForeignKey(d => d.FiscalCategId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_template_fiscal_categ_id_fkey");

            entity.HasOne(d => d.Subfamily).WithMany(p => p.ProductTemplateSubfamilies)
                .HasForeignKey(d => d.SubfamilyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_template_subfamily_id_fkey");

            entity.HasOne(d => d.Uom).WithMany(p => p.ProductTemplateUoms)
                .HasForeignKey(d => d.UomId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_template_uom_id_fkey");

            entity.HasOne(d => d.UomPo).WithMany(p => p.ProductTemplateUomPos)
                .HasForeignKey(d => d.UomPoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_template_uom_po_id_fkey");

            entity.HasOne(d => d.Uos).WithMany(p => p.ProductTemplateUos)
                .HasForeignKey(d => d.UosId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_template_uos_id_fkey");
        });

        modelBuilder.Entity<ProductUom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_uom_pkey");

            entity.ToTable("product_uom", tb => tb.HasComment("Product Unit of Measure"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasComment("Active")
                .HasColumnName("active");
            entity.Property(e => e.CategoryId)
                .HasComment("Category")
                .HasColumnName("category_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.Factor)
                .HasComment("Ratio")
                .HasColumnName("factor");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasComment("Unit of Measure")
                .HasColumnName("name");
            entity.Property(e => e.Rounding)
                .HasComment("Rounding Precision")
                .HasColumnName("rounding");
            entity.Property(e => e.UomType)
                .HasComment("Type")
                .HasColumnType("character varying")
                .HasColumnName("uom_type");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");
        });

        modelBuilder.Entity<ResPartner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("res_partner_pkey");

            entity.ToTable("res_partner");

            entity.HasIndex(e => e.CardCode, "res_partner_card_code_index");

            entity.HasIndex(e => e.CardCode, "res_partner_card_code_uniq").IsUnique();

            entity.HasIndex(e => e.Code, "res_partner_code_index");

            entity.HasIndex(e => e.Code, "res_partner_code_uniq").IsUnique();

            entity.HasIndex(e => e.CompanyId, "res_partner_company_id_index");

            entity.HasIndex(e => e.Date, "res_partner_date_index");

            entity.HasIndex(e => e.Name, "res_partner_name_index");

            entity.HasIndex(e => e.ParentId, "res_partner_parent_id_index");

            entity.HasIndex(e => new { e.ReaCode, e.CompanyId }, "res_partner_rea_code_uniq").IsUnique();

            entity.HasIndex(e => e.Ref, "res_partner_ref_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcceptedPrivacyPolicy)
                .HasComment("Accepted privacy policy")
                .HasColumnName("accepted_privacy_policy");
            entity.Property(e => e.AcceptedTermsAndConditions)
                .HasComment("Accepted terms and conditions")
                .HasColumnName("accepted_terms_and_conditions");
            entity.Property(e => e.Active)
                .HasComment("Active")
                .HasColumnName("active");
            entity.Property(e => e.Aggio)
                .HasComment("Aggio Percentage")
                .HasColumnName("aggio");
            entity.Property(e => e.Birthdate)
                .HasMaxLength(64)
                .HasComment("Birthdate")
                .HasColumnName("birthdate");
            entity.Property(e => e.CardCode)
                .HasMaxLength(64)
                .HasColumnName("card_code");
            entity.Property(e => e.CardExpirationDate)
                .HasComment("Card Expiration Date")
                .HasColumnName("card_expiration_date");
            entity.Property(e => e.CardPin)
                .HasMaxLength(20)
                .HasComment("Pin Card")
                .HasColumnName("card_pin");
            entity.Property(e => e.CarriageConditionId)
                .HasComment("Carriage condition")
                .HasColumnName("carriage_condition_id");
            entity.Property(e => e.CashBalance)
                .HasComment("Cash Balance")
                .HasColumnName("cash_balance");
            entity.Property(e => e.City)
                .HasMaxLength(128)
                .HasComment("City")
                .HasColumnName("city");
            entity.Property(e => e.Code)
                .HasMaxLength(64)
                .HasComment("Code")
                .HasColumnName("code");
            entity.Property(e => e.CodiceDestinatario)
                .HasComment("Codice Destinatario")
                .HasColumnType("character varying")
                .HasColumnName("codice_destinatario");
            entity.Property(e => e.Color)
                .HasComment("Color Index")
                .HasColumnName("color");
            entity.Property(e => e.Comment)
                .HasComment("Notes")
                .HasColumnName("comment");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CompletedPersonalData)
                .HasComment("Completed Personal Data")
                .HasColumnName("completed_personal_data");
            entity.Property(e => e.CountryId)
                .HasComment("Country")
                .HasColumnName("country_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.CreditLimit)
                .HasComment("Credit Limit")
                .HasColumnName("credit_limit");
            entity.Property(e => e.CurrentPointsBalance)
                .HasComment("Current Points Balance")
                .HasColumnName("current_points_balance");
            entity.Property(e => e.Customer)
                .HasComment("Customer")
                .HasColumnName("customer");
            entity.Property(e => e.CustomerNote)
                .HasComment("Customer Note")
                .HasColumnName("customer_note");
            entity.Property(e => e.Date)
                .HasComment("Date")
                .HasColumnName("date");
            entity.Property(e => e.DateOfBirth)
                .HasComment("Date Of Birth")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.DebitLimit)
                .HasComment("Payable Limit")
                .HasColumnName("debit_limit");
            entity.Property(e => e.DisplayName)
                .HasComment("Name")
                .HasColumnType("character varying")
                .HasColumnName("display_name");
            entity.Property(e => e.Ean13)
                .HasMaxLength(13)
                .HasComment("EAN13")
                .HasColumnName("ean13");
            entity.Property(e => e.ElectronicInvoiceDataComplete)
                .HasComment("unknown")
                .HasColumnName("electronic_invoice_data_complete");
            entity.Property(e => e.ElectronicInvoiceNoContactUpdate)
                .HasComment("Do not update the contact from Electronic Invoice Details")
                .HasColumnName("electronic_invoice_no_contact_update");
            entity.Property(e => e.ElectronicInvoiceObligedSubject)
                .HasComment("Obliged Subject")
                .HasColumnName("electronic_invoice_obliged_subject");
            entity.Property(e => e.ElectronicInvoiceSubjected)
                .HasComment("Subjected to electronic invoice")
                .HasColumnName("electronic_invoice_subjected");
            entity.Property(e => e.ElectronicInvoiceUseThisAddress)
                .HasComment("Use this e-invoicing data when invoicing to this address")
                .HasColumnName("electronic_invoice_use_this_address");
            entity.Property(e => e.Email)
                .HasMaxLength(240)
                .HasComment("Email")
                .HasColumnName("email");
            entity.Property(e => e.Employee)
                .HasComment("Employee")
                .HasColumnName("employee");
            entity.Property(e => e.EntranceBonusEarned)
                .HasComment("Entrance Bonus Earned")
                .HasColumnName("entrance_bonus_earned");
            entity.Property(e => e.EoriCode)
                .HasMaxLength(20)
                .HasComment("EORI Code")
                .HasColumnName("eori_code");
            entity.Property(e => e.ExternalEmployeeCode)
                .HasComment("External Employee Code")
                .HasColumnType("character varying")
                .HasColumnName("external_employee_code");
            entity.Property(e => e.Fax)
                .HasMaxLength(64)
                .HasComment("Fax")
                .HasColumnName("fax");
            entity.Property(e => e.Firstname)
                .HasComment("Firstname")
                .HasColumnType("character varying")
                .HasColumnName("firstname");
            entity.Property(e => e.Fiscalcode)
                .HasMaxLength(16)
                .HasComment("Fiscal Code")
                .HasColumnName("fiscalcode");
            entity.Property(e => e.Function)
                .HasMaxLength(128)
                .HasComment("Job Position")
                .HasColumnName("function");
            entity.Property(e => e.GiftCardExpirationDate)
                .HasComment("Gift Card Expiration Date")
                .HasColumnName("gift_card_expiration_date");
            entity.Property(e => e.GoodsDescriptionId)
                .HasComment("Description of goods")
                .HasColumnName("goods_description_id");
            entity.Property(e => e.GrandTotalConsumedPointsBalance)
                .HasComment("Total Points Consumed")
                .HasColumnName("grand_total_consumed_points_balance");
            entity.Property(e => e.GrandTotalPointsBalance)
                .HasComment("Total Points Accumulated")
                .HasColumnName("grand_total_points_balance");
            entity.Property(e => e.IgnoreNotDiscountableFlag)
                .HasComment("Ignore Not Discountable Flag")
                .HasColumnName("ignore_not_discountable_flag");
            entity.Property(e => e.Image)
                .HasComment("Image")
                .HasColumnName("image");
            entity.Property(e => e.ImageMedium)
                .HasComment("Medium-sized image")
                .HasColumnName("image_medium");
            entity.Property(e => e.ImageSmall)
                .HasComment("Small-sized image")
                .HasColumnName("image_small");
            entity.Property(e => e.InFiscalDocumentType)
                .HasComment("In Fiscal Document Type")
                .HasColumnName("in_fiscal_document_type");
            entity.Property(e => e.Individual)
                .HasComment("Individual")
                .HasColumnName("individual");
            entity.Property(e => e.InvoiceRequest)
                .HasComment("Invoice Request")
                .HasColumnName("invoice_request");
            entity.Property(e => e.IpaCode)
                .HasMaxLength(128)
                .HasComment("IPA Code")
                .HasColumnName("ipa_code");
            entity.Property(e => e.IsCompany)
                .HasComment("Is a Company")
                .HasColumnName("is_company");
            entity.Property(e => e.IsEmployeeCard)
                .HasComment("Card of Employee")
                .HasColumnName("isEmployeeCard");
            entity.Property(e => e.IsLoyalty)
                .HasComment("Loyalty Enabled")
                .HasColumnName("is_loyalty");
            entity.Property(e => e.IsManual)
                .HasComment("Is Manual")
                .HasColumnName("is_manual");
            entity.Property(e => e.IsMultiuseCard)
                .HasComment("Is Multiuse Card")
                .HasColumnName("is_multiuse_card");
            entity.Property(e => e.IsPa)
                .HasComment("Public administration")
                .HasColumnName("is_pa");
            entity.Property(e => e.IsPrepaidOnDb)
                .HasComment("Is Prepaid On DB")
                .HasColumnName("is_prepaid_on_db");
            entity.Property(e => e.IsTobaccoReseller)
                .HasComment("Is Tobacco Reseller")
                .HasColumnName("is_tobacco_reseller");
            entity.Property(e => e.IsTobaccoSupplier)
                .HasComment("Is Tobacco Supplyer")
                .HasColumnName("is_tobacco_supplier");
            entity.Property(e => e.Lang)
                .HasMaxLength(64)
                .HasColumnName("lang");
            entity.Property(e => e.LastBalancesRectification)
                .HasComment("Last Balances Rectification")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_balances_rectification");
            entity.Property(e => e.LastCardUsage)
                .HasComment("Last Card Usage")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_card_usage");
            entity.Property(e => e.LastPrepaidUsage)
                .HasComment("Last Prepaid Usage")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_prepaid_usage");
            entity.Property(e => e.LastReconciliationDate)
                .HasComment("Latest Full Reconciliation Date")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_reconciliation_date");
            entity.Property(e => e.Lastname)
                .HasComment("Lastname")
                .HasColumnType("character varying")
                .HasColumnName("lastname");
            entity.Property(e => e.LicenseNumber)
                .HasMaxLength(20)
                .HasComment("License Code")
                .HasColumnName("license_number");
            entity.Property(e => e.LotteryCode)
                .HasComment("Lottery Code")
                .HasColumnType("character varying")
                .HasColumnName("lottery_code");
            entity.Property(e => e.Mobile)
                .HasMaxLength(64)
                .HasComment("Mobile")
                .HasColumnName("mobile");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.NotificationEmailSend)
                .HasComment("Receive Messages by Email")
                .HasColumnType("character varying")
                .HasColumnName("notification_email_send");
            entity.Property(e => e.NumRivendita)
                .HasComment("Numero rivendita")
                .HasColumnName("num_rivendita");
            entity.Property(e => e.OnlyPrepaidCard)
                .HasComment("Only Prepaid Card")
                .HasColumnName("only_prepaid_card");
            entity.Property(e => e.OptOut)
                .HasComment("Opt-Out")
                .HasColumnName("opt_out");
            entity.Property(e => e.OutFiscalDocumentType)
                .HasComment("Out Fiscal Document Type")
                .HasColumnName("out_fiscal_document_type");
            entity.Property(e => e.OverridePrepaidPayment)
                .HasComment("Override Prepaid Payment")
                .HasColumnName("override_prepaid_payment");
            entity.Property(e => e.PaPartnerCode)
                .HasMaxLength(20)
                .HasComment("PA Code for partner")
                .HasColumnName("pa_partner_code");
            entity.Property(e => e.ParentId)
                .HasComment("Related Company")
                .HasColumnName("parent_id");
            entity.Property(e => e.PecDestinatario)
                .HasComment("PEC destinatario")
                .HasColumnType("character varying")
                .HasColumnName("pec_destinatario");
            entity.Property(e => e.Phone)
                .HasMaxLength(64)
                .HasComment("Phone")
                .HasColumnName("phone");
            entity.Property(e => e.PosBalance)
                .HasComment("Pos/EFT Balance")
                .HasColumnName("pos_balance");
            entity.Property(e => e.PrepaidCreditAmount)
                .HasComment("Max Prepaid On DB Credit")
                .HasColumnName("prepaid_credit_amount");
            entity.Property(e => e.PrepaidCreditAmountUsed)
                .HasComment("Prepaid On DB Credit Used")
                .HasColumnName("prepaid_credit_amount_used");
            entity.Property(e => e.PrepaidOnDbBalance)
                .HasComment("Prepaid On DB Balance")
                .HasColumnName("prepaid_on_db_balance");
            entity.Property(e => e.PricelistId)
                .HasComment("Pricelist")
                .HasColumnName("pricelist_id");
            entity.Property(e => e.Province)
                .HasComment("Province")
                .HasColumnName("province");
            entity.Property(e => e.ReaCapital)
                .HasComment("Capital")
                .HasColumnName("rea_capital");
            entity.Property(e => e.ReaCode)
                .HasMaxLength(20)
                .HasComment("REA Code")
                .HasColumnName("rea_code");
            entity.Property(e => e.ReaLiquidationState)
                .HasComment("Liquidation State")
                .HasColumnType("character varying")
                .HasColumnName("rea_liquidation_state");
            entity.Property(e => e.ReaMemberType)
                .HasComment("Member Type")
                .HasColumnType("character varying")
                .HasColumnName("rea_member_type");
            entity.Property(e => e.ReaOffice)
                .HasComment("Office Province")
                .HasColumnName("rea_office");
            entity.Property(e => e.RechargeVatRate)
                .HasComment("Recharge Vat Rate")
                .HasColumnName("recharge_vat_rate");
            entity.Property(e => e.Ref)
                .HasMaxLength(64)
                .HasComment("Reference")
                .HasColumnName("ref");
            entity.Property(e => e.Region)
                .HasComment("Region")
                .HasColumnName("region");
            entity.Property(e => e.Register)
                .HasMaxLength(60)
                .HasComment("Professional Register")
                .HasColumnName("register");
            entity.Property(e => e.RegisterCode)
                .HasMaxLength(60)
                .HasComment("Register Code")
                .HasColumnName("register_code");
            entity.Property(e => e.RegisterFiscalpos)
                .HasComment("Register Fiscal Position")
                .HasColumnName("register_fiscalpos");
            entity.Property(e => e.RegisterProvince)
                .HasComment("Register Province")
                .HasColumnName("register_province");
            entity.Property(e => e.RegisterRegdate)
                .HasComment("Register Registration Date")
                .HasColumnName("register_regdate");
            entity.Property(e => e.RevaluationBalance)
                .HasComment("Revaluation Balance")
                .HasColumnName("revaluation_balance");
            entity.Property(e => e.SignupExpiration)
                .HasComment("Signup Expiration")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("signup_expiration");
            entity.Property(e => e.SignupToken)
                .HasComment("Signup Token")
                .HasColumnType("character varying")
                .HasColumnName("signup_token");
            entity.Property(e => e.SignupType)
                .HasComment("Signup Token Type")
                .HasColumnType("character varying")
                .HasColumnName("signup_type");
            entity.Property(e => e.SmartBillActive)
                .HasComment("Smart Bill Active")
                .HasColumnName("smart_bill_active");
            entity.Property(e => e.StateId)
                .HasComment("State")
                .HasColumnName("state_id");
            entity.Property(e => e.Street)
                .HasMaxLength(128)
                .HasComment("Street")
                .HasColumnName("street");
            entity.Property(e => e.Street2)
                .HasMaxLength(128)
                .HasComment("Street2")
                .HasColumnName("street2");
            entity.Property(e => e.Supplier)
                .HasComment("Supplier")
                .HasColumnName("supplier");
            entity.Property(e => e.TicketBalance)
                .HasComment("Ticket Balance")
                .HasColumnName("ticket_balance");
            entity.Property(e => e.Title)
                .HasComment("Title")
                .HasColumnName("title");
            entity.Property(e => e.TransportationReasonId)
                .HasComment("Reason for transportation")
                .HasColumnName("transportation_reason_id");
            entity.Property(e => e.Type)
                .HasComment("Address Type")
                .HasColumnType("character varying")
                .HasColumnName("type");
            entity.Property(e => e.Tz)
                .HasMaxLength(64)
                .HasComment("Timezone")
                .HasColumnName("tz");
            entity.Property(e => e.UseParentAddress)
                .HasComment("Use Company Address")
                .HasColumnName("use_parent_address");
            entity.Property(e => e.UserId)
                .HasComment("Salesperson")
                .HasColumnName("user_id");
            entity.Property(e => e.Vat)
                .HasMaxLength(32)
                .HasComment("TIN")
                .HasColumnName("vat");
            entity.Property(e => e.VatSubjected)
                .HasComment("VAT Legal Statement")
                .HasColumnName("vat_subjected");
            entity.Property(e => e.Website)
                .HasMaxLength(64)
                .HasComment("Website")
                .HasColumnName("website");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            entity.Property(e => e.Zip)
                .HasMaxLength(24)
                .HasComment("Zip")
                .HasColumnName("zip");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_partner_parent_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptAgreement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_agreements_pkey");

            entity.ToTable("scm_receipt_agreements", tb => tb.HasComment("scm.receipt.agreements"));

            entity.HasIndex(e => e.HeaderId, "scm_receipt_agreements_header_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgreementDate)
                .HasMaxLength(15)
                .HasComment("Agreement Date")
                .HasColumnName("agreement_date");
            entity.Property(e => e.AgreementDatetime)
                .HasComment("Agreement Datetime")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("agreement_datetime");
            entity.Property(e => e.AgreementId)
                .HasComment("Agreement")
                .HasColumnName("agreement_id");
            entity.Property(e => e.AgreementTime)
                .HasMaxLength(15)
                .HasComment("Agreement Time")
                .HasColumnName("agreement_time");
            entity.Property(e => e.Amount)
                .HasComment("Agreement Amount")
                .HasColumnName("amount");
            entity.Property(e => e.Badge)
                .HasMaxLength(25)
                .HasComment("Agreement Badge")
                .HasColumnName("badge");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasComment("Agreement Code")
                .HasColumnName("code");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.DiscountAmount)
                .HasComment("Agreement Discount Amount")
                .HasColumnName("discount_amount");
            entity.Property(e => e.DiscountType)
                .HasMaxLength(15)
                .HasComment("Agreement Discount Type")
                .HasColumnName("discount_type");
            entity.Property(e => e.Extra)
                .HasComment("Agreement Extra")
                .HasColumnName("extra");
            entity.Property(e => e.HeaderId)
                .HasComment("Header")
                .HasColumnName("header_id");
            entity.Property(e => e.Qty)
                .HasComment("Agreement Quantity")
                .HasColumnName("qty");
            entity.Property(e => e.Score)
                .HasComment("Agreement Score")
                .HasColumnName("score");
            entity.Property(e => e.Type)
                .HasMaxLength(15)
                .HasComment("Agreement Type")
                .HasColumnName("type");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Header).WithMany(p => p.ScmReceiptAgreements)
                .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_agreements_header_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptAnalyticItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_analytic_items_pkey");

            entity.ToTable("scm_receipt_analytic_items", tb => tb.HasComment("scm.receipt.analytic_items"));

            entity.HasIndex(e => e.HeaderId, "scm_receipt_analytic_items_header_id_index");

            entity.HasIndex(e => e.WaiterId, "scm_receipt_analytic_items_waiter_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasComment("Amount")
                .HasColumnName("amount");
            entity.Property(e => e.CategoryCode)
                .HasComment("Category code")
                .HasColumnType("character varying")
                .HasColumnName("category_code");
            entity.Property(e => e.ConsumedPoints)
                .HasComment("Consumed Points")
                .HasColumnName("consumed_points");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.Description)
                .HasComment("Description")
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.GiftCode)
                .HasComment("Gift code")
                .HasColumnType("character varying")
                .HasColumnName("gift_code");
            entity.Property(e => e.HeaderId)
                .HasComment("Header")
                .HasColumnName("header_id");
            entity.Property(e => e.ItemAppliedPrice)
                .HasComment("Item Real Price")
                .HasColumnName("item_applied_price");
            entity.Property(e => e.ItemDate)
                .HasComment("Date")
                .HasColumnType("character varying")
                .HasColumnName("item_date");
            entity.Property(e => e.ItemDatetime)
                .HasComment("Item Datetime")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("item_datetime");
            entity.Property(e => e.ItemRealDatetime)
                .HasComment("Item Datetime")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("item_real_datetime");
            entity.Property(e => e.ItemTime)
                .HasComment("Time")
                .HasColumnType("character varying")
                .HasColumnName("item_time");
            entity.Property(e => e.MessageText)
                .HasComment("Message text")
                .HasColumnType("character varying")
                .HasColumnName("message_text");
            entity.Property(e => e.ProductCode)
                .HasComment("Product Code")
                .HasColumnType("character varying")
                .HasColumnName("product_code");
            entity.Property(e => e.ProductId)
                .HasComment("Product")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductType)
                .HasComment("Product type")
                .HasColumnType("character varying")
                .HasColumnName("product_type");
            entity.Property(e => e.Qty)
                .HasComment("Quantity")
                .HasColumnName("qty");
            entity.Property(e => e.Reason)
                .HasComment("Reason")
                .HasColumnType("character varying")
                .HasColumnName("reason");
            entity.Property(e => e.Score)
                .HasComment("Item Score")
                .HasColumnName("score");
            entity.Property(e => e.SerialNumber)
                .HasComment("Serial number")
                .HasColumnType("character varying")
                .HasColumnName("serial_number");
            entity.Property(e => e.State)
                .HasComment("State")
                .HasColumnType("character varying")
                .HasColumnName("state");
            entity.Property(e => e.TillCode)
                .HasComment("Till code")
                .HasColumnType("character varying")
                .HasColumnName("till_code");
            entity.Property(e => e.TillId)
                .HasComment("Till")
                .HasColumnName("till_id");
            entity.Property(e => e.UnitPrice)
                .HasComment("Unit Price")
                .HasColumnName("unit_price");
            entity.Property(e => e.WaiterId)
                .HasComment("Waiter")
                .HasColumnName("waiter_id");
            entity.Property(e => e.WaiterUserCode)
                .HasComment("Waiter User code")
                .HasColumnType("character varying")
                .HasColumnName("waiter_user_code");
            entity.Property(e => e.Weight)
                .HasComment("Weight")
                .HasColumnName("weight");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Header).WithMany(p => p.ScmReceiptAnalyticItems)
                .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_analytic_items_header_id_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.ScmReceiptAnalyticItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_analytic_items_product_id_fkey");

            entity.HasOne(d => d.Till).WithMany(p => p.ScmReceiptAnalyticItems)
                .HasForeignKey(d => d.TillId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_analytic_items_till_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptCouponsDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_coupons_detail_pkey");

            entity.ToTable("scm_receipt_coupons_detail", tb => tb.HasComment("scm.receipt.coupons_detail"));

            entity.HasIndex(e => e.HeaderId, "scm_receipt_coupons_detail_header_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CouponCode)
                .HasComment("Coupon Code")
                .HasColumnType("character varying")
                .HasColumnName("coupon_code");
            entity.Property(e => e.CouponQty)
                .HasComment("Coupon Quantity")
                .HasColumnName("coupon_qty");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.HeaderId)
                .HasComment("Header")
                .HasColumnName("header_id");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Header).WithMany(p => p.ScmReceiptCouponsDetails)
                .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_coupons_detail_header_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptDiscountDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_discount_details_pkey");

            entity.ToTable("scm_receipt_discount_details", tb => tb.HasComment("scm.receipt.discount.details"));

            entity.HasIndex(e => e.HeaderId, "scm_receipt_discount_details_header_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accumulator)
                .HasComment("Accumulator")
                .HasColumnName("accumulator");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(5)
                .HasComment("Discount Category Code")
                .HasColumnName("category_code");
            entity.Property(e => e.Coupon)
                .HasComment("Coupon")
                .HasColumnType("character varying")
                .HasColumnName("coupon");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.DiscountCode)
                .HasMaxLength(5)
                .HasComment("Discount Code")
                .HasColumnName("discount_code");
            entity.Property(e => e.DiscountId)
                .HasComment("Discount")
                .HasColumnName("discount_id");
            entity.Property(e => e.HeaderId)
                .HasComment("Header")
                .HasColumnName("header_id");
            entity.Property(e => e.Initiative)
                .HasMaxLength(5)
                .HasComment("Discount Initiative")
                .HasColumnName("initiative");
            entity.Property(e => e.Mechanics)
                .HasMaxLength(5)
                .HasComment("Discount Mechanics")
                .HasColumnName("mechanics");
            entity.Property(e => e.MessageText)
                .HasComment("Text")
                .HasColumnType("character varying")
                .HasColumnName("message_text");
            entity.Property(e => e.Points)
                .HasComment("Points")
                .HasColumnName("points");
            entity.Property(e => e.Qty)
                .HasComment("Quantity")
                .HasColumnName("qty");
            entity.Property(e => e.Threshold)
                .HasComment("Threshold")
                .HasColumnName("threshold");
            entity.Property(e => e.TotalAmount)
                .HasComment("Total amount")
                .HasColumnName("total_amount");
            entity.Property(e => e.TotalRate)
                .HasComment("Total rate")
                .HasColumnName("total_rate");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Header).WithMany(p => p.ScmReceiptDiscountDetails)
                .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_discount_details_header_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptHeader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_headers_pkey");

            entity.ToTable("scm_receipt_headers", tb => tb.HasComment("scm.receipt.headers"));

            entity.HasIndex(e => e.BookkeepingDate, "scm_receipt_headers_bookkeeping_date_index");

            entity.HasIndex(e => e.CompanyId, "scm_receipt_headers_company_id_index");

            entity.HasIndex(e => e.IsOnline, "scm_receipt_headers_is_online_index");

            entity.HasIndex(e => e.PanariaDataFromServer, "scm_receipt_headers_panaria_data_from_server_index");

            entity.HasIndex(e => e.PanariaEmployeeName, "scm_receipt_headers_panaria_employee_name_index");

            entity.HasIndex(e => e.PanariaUserId, "scm_receipt_headers_panaria_user_id_index");

            entity.HasIndex(e => e.PanariaVoucherId, "scm_receipt_headers_panaria_voucher_id_index");

            entity.HasIndex(e => e.ParentTransactionId, "scm_receipt_headers_parent_transaction_id_index");

            entity.HasIndex(e => e.PartnerId, "scm_receipt_headers_partner_id_index");

            entity.HasIndex(e => e.Reason, "scm_receipt_headers_reason_index");

            entity.HasIndex(e => e.ReceiptDate, "scm_receipt_headers_receipt_date_index");

            entity.HasIndex(e => e.ReceiptTime, "scm_receipt_headers_receipt_time_index");

            entity.HasIndex(e => e.TillCode, "scm_receipt_headers_till_code_index");

            entity.HasIndex(e => e.TransactionNumber, "scm_receipt_headers_transaction_number_index");

            entity.HasIndex(e => new { e.ReceiptDate, e.ReceiptTime, e.TransactionNumber, e.ShopCode, e.TillCode }, "scm_receipt_headers_unique_transaction").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountInvoiceId)
                .HasComment("Invoice")
                .HasColumnName("account_invoice_id");
            entity.Property(e => e.AddforReaderId)
                .HasComment("Add-For Reader")
                .HasColumnName("addfor_reader_id");
            entity.Property(e => e.AddforReadingId)
                .HasComment("Add-For Reading ID")
                .HasColumnType("character varying")
                .HasColumnName("addfor_reading_id");
            entity.Property(e => e.AppOrderId)
                .HasComment("App Order ")
                .HasColumnName("app_order_id");
            entity.Property(e => e.BedzzleBillAlias)
                .HasComment("Bedzzle Bill Alias")
                .HasColumnType("character varying")
                .HasColumnName("bedzzle_bill_alias");
            entity.Property(e => e.BedzzleCompanyName)
                .HasComment("Company Name")
                .HasColumnType("character varying")
                .HasColumnName("bedzzle_company_name");
            entity.Property(e => e.BedzzleHotelId)
                .HasComment("Bedzzle Hotel")
                .HasColumnName("bedzzle_hotel_id");
            entity.Property(e => e.BedzzleIsMiscSale)
                .HasComment("Is Misc Sale")
                .HasColumnName("bedzzle_is_misc_sale");
            entity.Property(e => e.BedzzleIsPaid)
                .HasComment("Is Paid")
                .HasColumnName("bedzzle_is_paid");
            entity.Property(e => e.BedzzleReservationName)
                .HasComment("Bedzzle Reservation Name")
                .HasColumnType("character varying")
                .HasColumnName("bedzzle_reservation_name");
            entity.Property(e => e.BedzzleRoomAlias)
                .HasComment("Bedzzle Room Alias")
                .HasColumnType("character varying")
                .HasColumnName("bedzzle_room_alias");
            entity.Property(e => e.Billable)
                .HasComment("Billable")
                .HasColumnName("billable");
            entity.Property(e => e.BookkeepingDate)
                .HasComment("Bookkeeping date")
                .HasColumnName("bookkeeping_date");
            entity.Property(e => e.CancelDate)
                .HasComment("Cancel date")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("cancel_date");
            entity.Property(e => e.CancelUserId)
                .HasComment("Canceled by")
                .HasColumnName("cancel_user_id");
            entity.Property(e => e.Canceled)
                .HasComment("Canceled")
                .HasColumnName("canceled");
            entity.Property(e => e.CashierId)
                .HasComment("Cashier")
                .HasColumnName("cashier_id");
            entity.Property(e => e.CashierUserCode)
                .HasComment("Cashier user code")
                .HasColumnType("character varying")
                .HasColumnName("cashier_user_code");
            entity.Property(e => e.CompanyCurrencyId)
                .HasComment("Company Currency")
                .HasColumnName("company_currency_id");
            entity.Property(e => e.CompanyId)
                .HasComment("Company")
                .HasColumnName("company_id");
            entity.Property(e => e.CoverChargeQty)
                .HasComment("Cover charge quantity")
                .HasColumnName("cover_charge_qty");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.CustomerInvoiceHeader)
                .HasComment("Invoice header")
                .HasColumnName("customer_invoice_header");
            entity.Property(e => e.CustomerNumber)
                .HasComment("Customer number")
                .HasColumnType("character varying")
                .HasColumnName("customer_number");
            entity.Property(e => e.DiscountOnTotalId)
                .HasComment("Discount On Total")
                .HasColumnName("discount_on_total_id");
            entity.Property(e => e.DiscountOnTotalValue)
                .HasComment("Discount On Total Value")
                .HasColumnName("discount_on_total_value");
            entity.Property(e => e.ErgoMovementId)
                .HasComment("Ergo Movement ID")
                .HasColumnName("ergo_movement_id");
            entity.Property(e => e.ExtraOrderId)
                .HasComment("Extra Order ID")
                .HasColumnType("character varying")
                .HasColumnName("extra_order_id");
            entity.Property(e => e.ExtraOrderServiceName)
                .HasComment("Extra Order Service Name")
                .HasColumnType("character varying")
                .HasColumnName("extra_order_service_name");
            entity.Property(e => e.FiscalNumber)
                .HasComment("Fiscal number")
                .HasColumnName("fiscal_number");
            entity.Property(e => e.FiscalPrinterId)
                .HasMaxLength(64)
                .HasComment("Fiscal Printer ID")
                .HasColumnName("fiscal_printer_id");
            entity.Property(e => e.HallCode)
                .HasComment("Hall code")
                .HasColumnType("character varying")
                .HasColumnName("hall_code");
            entity.Property(e => e.Handled)
                .HasComment("Handled")
                .HasColumnName("handled");
            entity.Property(e => e.InvoiceNumber)
                .HasComment("Invoice number")
                .HasColumnType("character varying")
                .HasColumnName("invoice_number");
            entity.Property(e => e.IsManual)
                .HasComment("Is manual")
                .HasColumnName("is_manual");
            entity.Property(e => e.IsOnline)
                .HasComment("Is Online Transaction")
                .HasColumnName("is_online");
            entity.Property(e => e.IsPrintedOnFiscalPrinter)
                .HasComment("Bill is printed On Fiscal Printer")
                .HasColumnName("is_printed_on_fiscal_printer");
            entity.Property(e => e.IsReversal)
                .HasComment("Reversal")
                .HasColumnName("is_reversal");
            entity.Property(e => e.IsWaste)
                .HasComment("Is Waste")
                .HasColumnName("is_waste");
            entity.Property(e => e.LinkedTransactionId)
                .HasComment("Linked transaction")
                .HasColumnName("linked_transaction_id");
            entity.Property(e => e.LotteryCode)
                .HasComment("Lottery Code")
                .HasColumnType("character varying")
                .HasColumnName("lottery_code");
            entity.Property(e => e.Notes)
                .HasComment("Notes")
                .HasColumnName("notes");
            entity.Property(e => e.NumberOfItems)
                .HasComment("Number of items")
                .HasColumnName("number_of_items");
            entity.Property(e => e.OperatorShiftId)
                .HasComment("Operator Shift Id")
                .HasColumnName("operator_shift_id");
            entity.Property(e => e.PanariaDataFromServer)
                .HasComment("Panaria Data From Server")
                .HasColumnName("panaria_data_from_server");
            entity.Property(e => e.PanariaEmployeeName)
                .HasComment("Panaria Employee Name")
                .HasColumnType("character varying")
                .HasColumnName("panaria_employee_name");
            entity.Property(e => e.PanariaUserId)
                .HasComment("Panaria Employee Id")
                .HasColumnType("character varying")
                .HasColumnName("panaria_user_id");
            entity.Property(e => e.PanariaVoucherId)
                .HasComment("Panaria Voucher Id")
                .HasColumnType("character varying")
                .HasColumnName("panaria_voucher_id");
            entity.Property(e => e.ParentTransactionId)
                .HasComment("Parent Transaction")
                .HasColumnName("parent_transaction_id");
            entity.Property(e => e.PartnerAnomaly)
                .HasComment("Partner Anomaly")
                .HasColumnName("partner_anomaly");
            entity.Property(e => e.PartnerId)
                .HasComment("Partner")
                .HasColumnName("partner_id");
            entity.Property(e => e.PickingId)
                .HasComment("Picking")
                .HasColumnName("picking_id");
            entity.Property(e => e.PointsCampaignId)
                .HasComment("Points Campaign")
                .HasColumnName("points_campaign_id");
            entity.Property(e => e.ProgramVersion)
                .HasComment("Program Version")
                .HasColumnType("character varying")
                .HasColumnName("program_version");
            entity.Property(e => e.Provenience)
                .HasComment("Provenience")
                .HasColumnType("character varying")
                .HasColumnName("provenience");
            entity.Property(e => e.Reason)
                .HasComment("Ticket reason")
                .HasColumnType("character varying")
                .HasColumnName("reason");
            entity.Property(e => e.ReceiptDate)
                .HasMaxLength(8)
                .HasComment("Receipt date")
                .HasColumnName("receipt_date");
            entity.Property(e => e.ReceiptDatetime)
                .HasComment("Receipt Datetime")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("receipt_datetime");
            entity.Property(e => e.ReceiptRealDatetime)
                .HasComment("Receipt Datetime")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("receipt_real_datetime");
            entity.Property(e => e.ReceiptTime)
                .HasMaxLength(6)
                .HasComment("Receipt time")
                .HasColumnName("receipt_time");
            entity.Property(e => e.ReferenceReceipt)
                .HasComment("Transaction reference")
                .HasColumnType("character varying")
                .HasColumnName("reference_receipt");
            entity.Property(e => e.ReferenceZreport)
                .HasComment("Z Report reference")
                .HasColumnName("reference_zreport");
            entity.Property(e => e.ReversalTransactionId)
                .HasComment("Reversal transaction")
                .HasColumnName("reversal_transaction_id");
            entity.Property(e => e.ReversedTransactionId)
                .HasComment("Reversed receipt")
                .HasColumnName("reversed_transaction_id");
            entity.Property(e => e.ServiceId)
                .HasComment("Service")
                .HasColumnName("service_id");
            entity.Property(e => e.ServiceTimeSlot)
                .HasComment("Service Time slot")
                .HasColumnType("character varying")
                .HasColumnName("service_time_slot");
            entity.Property(e => e.ShopCode)
                .HasComment("Shop code")
                .HasColumnType("character varying")
                .HasColumnName("shop_code");
            entity.Property(e => e.ShopId)
                .HasComment("Shop")
                .HasColumnName("shop_id");
            entity.Property(e => e.TableCode)
                .HasComment("Table code")
                .HasColumnType("character varying")
                .HasColumnName("table_code");
            entity.Property(e => e.TemporaryBillPrinted)
                .HasComment("Temporary Bill Printed")
                .HasColumnName("temporary_bill_printed");
            entity.Property(e => e.TicketsCount)
                .HasComment("Tickets Count")
                .HasColumnName("tickets_count");
            entity.Property(e => e.TillCode)
                .HasComment("Till code")
                .HasColumnType("character varying")
                .HasColumnName("till_code");
            entity.Property(e => e.TillId)
                .HasComment("Till")
                .HasColumnName("till_id");
            entity.Property(e => e.Total)
                .HasComment("Total")
                .HasColumnName("total");
            entity.Property(e => e.TotalTaxes)
                .HasComment("Total Taxes")
                .HasColumnName("total_taxes");
            entity.Property(e => e.TotalWithoutTaxes)
                .HasComment("Total without taxes")
                .HasColumnName("total_without_taxes");
            entity.Property(e => e.TransactionNumber)
                .HasComment("Transaction number")
                .HasColumnType("character varying")
                .HasColumnName("transaction_number");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            entity.Property(e => e.ZReportNumber)
                .HasComment("Z Report Number")
                .HasColumnName("z_report_number");

            entity.HasOne(d => d.Cashier).WithMany(p => p.ScmReceiptHeaders)
                .HasForeignKey(d => d.CashierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_headers_cashier_id_fkey");

            entity.HasOne(d => d.LinkedTransaction).WithMany(p => p.InverseLinkedTransaction)
                .HasForeignKey(d => d.LinkedTransactionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_headers_linked_transaction_id_fkey");

            entity.HasOne(d => d.ParentTransaction).WithMany(p => p.InverseParentTransaction)
                .HasForeignKey(d => d.ParentTransactionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_headers_parent_transaction_id_fkey");

            entity.HasOne(d => d.Partner).WithMany(p => p.ScmReceiptHeaders)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_headers_partner_id_fkey");

            entity.HasOne(d => d.ReversalTransaction).WithMany(p => p.InverseReversalTransaction)
                .HasForeignKey(d => d.ReversalTransactionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_headers_reversal_transaction_id_fkey");

            entity.HasOne(d => d.ReversedTransaction).WithMany(p => p.InverseReversedTransaction)
                .HasForeignKey(d => d.ReversedTransactionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_headers_reversed_transaction_id_fkey");

            entity.HasOne(d => d.Shop).WithMany(p => p.ScmReceiptHeaders)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_headers_shop_id_fkey");

            entity.HasOne(d => d.Till).WithMany(p => p.ScmReceiptHeaders)
                .HasForeignKey(d => d.TillId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_headers_till_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptInvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_invoice_details_pkey");

            entity.ToTable("scm_receipt_invoice_details", tb => tb.HasComment("scm.receipt.invoice.details"));

            entity.HasIndex(e => e.HeaderId, "scm_receipt_invoice_details_header_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BirthdayDate)
                .HasMaxLength(8)
                .HasComment("Birthday Date")
                .HasColumnName("birthday_date");
            entity.Property(e => e.CompanyCity)
                .HasMaxLength(50)
                .HasComment("Company City")
                .HasColumnName("company_city");
            entity.Property(e => e.CompanyCodiceDestinatario)
                .HasMaxLength(50)
                .HasComment("Company Codice Destinatario")
                .HasColumnName("company_codice_destinatario");
            entity.Property(e => e.CompanyCodsdi)
                .HasComment("Company Cod SDI")
                .HasColumnType("character varying")
                .HasColumnName("company_codsdi");
            entity.Property(e => e.CompanyCountry)
                .HasMaxLength(50)
                .HasComment("Company Country")
                .HasColumnName("company_country");
            entity.Property(e => e.CompanyFiscalCode)
                .HasMaxLength(50)
                .HasComment("Company Fiscal Code")
                .HasColumnName("company_fiscal_code");
            entity.Property(e => e.CompanyIsForInvoice)
                .HasComment("Company Is For invoice")
                .HasColumnName("company_is_for_invoice");
            entity.Property(e => e.CompanyMail)
                .HasMaxLength(50)
                .HasComment("Company Mail")
                .HasColumnName("company_mail");
            entity.Property(e => e.CompanyName)
                .HasComment("Company Name")
                .HasColumnType("character varying")
                .HasColumnName("company_name");
            entity.Property(e => e.CompanyNumber)
                .HasMaxLength(25)
                .HasComment("Company Number")
                .HasColumnName("company_number");
            entity.Property(e => e.CompanyPec)
                .HasComment("Company Pec")
                .HasColumnType("character varying")
                .HasColumnName("company_pec");
            entity.Property(e => e.CompanyPhone)
                .HasMaxLength(50)
                .HasComment("Company Phone")
                .HasColumnName("company_phone");
            entity.Property(e => e.CompanyStreet)
                .HasComment("Company Street")
                .HasColumnType("character varying")
                .HasColumnName("company_street");
            entity.Property(e => e.CompanyVatCode)
                .HasMaxLength(50)
                .HasComment("Company Vat Code")
                .HasColumnName("company_vat_code");
            entity.Property(e => e.CompanyZip)
                .HasMaxLength(50)
                .HasComment("Company Zip")
                .HasColumnName("company_zip");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.ExpirationDate)
                .HasMaxLength(8)
                .HasComment("Card Expiration Date")
                .HasColumnName("expiration_date");
            entity.Property(e => e.HeaderId)
                .HasComment("Header")
                .HasColumnName("header_id");
            entity.Property(e => e.IsPrepaidOnDb)
                .HasComment("Company Is For invoice")
                .HasColumnName("is_prepaid_on_db");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Header).WithMany(p => p.ScmReceiptInvoiceDetails)
                .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_invoice_details_header_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_items_pkey");

            entity.ToTable("scm_receipt_items", tb => tb.HasComment("scm.receipt.items"));

            entity.HasIndex(e => e.HeaderId, "scm_receipt_items_header_id_index");

            entity.HasIndex(e => e.Reason, "scm_receipt_items_reason_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasComment("Amount")
                .HasColumnName("amount");
            entity.Property(e => e.Barcode)
                .HasComment("Barcode")
                .HasColumnType("character varying")
                .HasColumnName("barcode");
            entity.Property(e => e.CategoryCode)
                .HasComment("Category code")
                .HasColumnType("character varying")
                .HasColumnName("category_code");
            entity.Property(e => e.ConsumedPoints)
                .HasComment("Consumed Points")
                .HasColumnName("consumed_points");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.Description)
                .HasComment("Description")
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.DiscountAmount)
                .HasComment("Discount amount")
                .HasColumnName("discount_amount");
            entity.Property(e => e.DiscountFromTotal)
                .HasComment("Discount from total")
                .HasColumnName("discount_from_total");
            entity.Property(e => e.DiscountOnRowId)
                .HasComment("Discount Name")
                .HasColumnName("discount_on_row_id");
            entity.Property(e => e.DiscountRate)
                .HasComment("Discount rate")
                .HasColumnName("discount_rate");
            entity.Property(e => e.Discountable)
                .HasComment("Discountable")
                .HasColumnName("discountable");
            entity.Property(e => e.FatherProduct)
                .HasComment("Father Product")
                .HasColumnType("character varying")
                .HasColumnName("father_product");
            entity.Property(e => e.FatherProductId)
                .HasComment("Father Product")
                .HasColumnName("father_product_id");
            entity.Property(e => e.FiscalAmount)
                .HasComment("Fiscal Amount")
                .HasColumnName("fiscal_amount");
            entity.Property(e => e.FiscalNetAmount)
                .HasComment("Fiscal Net Amount")
                .HasColumnName("fiscal_net_amount");
            entity.Property(e => e.GiftCode)
                .HasComment("Gift code")
                .HasColumnType("character varying")
                .HasColumnName("gift_code");
            entity.Property(e => e.HeaderId)
                .HasComment("Header")
                .HasColumnName("header_id");
            entity.Property(e => e.ItemDate)
                .HasComment("Date")
                .HasColumnType("character varying")
                .HasColumnName("item_date");
            entity.Property(e => e.ItemDatetime)
                .HasComment("Item Datetime")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("item_datetime");
            entity.Property(e => e.ItemInmenuPrice)
                .HasComment("Item In Menu Price")
                .HasColumnName("item_inmenu_price");
            entity.Property(e => e.ItemInmenuPriceFiscalNet)
                .HasComment("Item In Menu Price Fiscal Net")
                .HasColumnName("item_inmenu_price_fiscal_net");
            entity.Property(e => e.ItemMenuPrice)
                .HasComment("Menu Price")
                .HasColumnName("item_menu_price");
            entity.Property(e => e.ItemMenuPriceFiscalNet)
                .HasComment("Menu Price Fiscal Net")
                .HasColumnName("item_menu_price_fiscal_net");
            entity.Property(e => e.ItemNotPrintable)
                .HasComment("Not Printable")
                .HasColumnName("item_not_printable");
            entity.Property(e => e.ItemPromoId)
                .HasComment("Promotion Applied")
                .HasColumnName("item_promo_id");
            entity.Property(e => e.ItemPromoLabel)
                .HasComment("Promotion Label")
                .HasColumnType("character varying")
                .HasColumnName("item_promo_label");
            entity.Property(e => e.ItemRealPrice)
                .HasComment("Item Real Price")
                .HasColumnName("item_real_price");
            entity.Property(e => e.ItemRealPriceFiscalNet)
                .HasComment("Item Real Price Fiscal Net")
                .HasColumnName("item_real_price_fiscal_net");
            entity.Property(e => e.ItemTillId)
                .HasComment("Suspension Till")
                .HasColumnName("item_till_id");
            entity.Property(e => e.ItemTime)
                .HasComment("Time")
                .HasColumnType("character varying")
                .HasColumnName("item_time");
            entity.Property(e => e.ItemWineemotionBarcode)
                .HasComment("Wine Emotion Barcode")
                .HasColumnType("character varying")
                .HasColumnName("item_wineemotion_barcode");
            entity.Property(e => e.MessageText)
                .HasComment("Message text")
                .HasColumnType("character varying")
                .HasColumnName("message_text");
            entity.Property(e => e.MixmatchCode)
                .HasComment("Mixmatch code")
                .HasColumnType("character varying")
                .HasColumnName("mixmatch_code");
            entity.Property(e => e.NetAmount)
                .HasComment("Net Amount")
                .HasColumnName("net_amount");
            entity.Property(e => e.PriceList)
                .HasComment("Item Pricelist")
                .HasColumnType("character varying")
                .HasColumnName("price_list");
            entity.Property(e => e.PriceListId)
                .HasComment("Product Pricelist")
                .HasColumnName("price_list_id");
            entity.Property(e => e.ProductCode)
                .HasComment("Product Code")
                .HasColumnType("character varying")
                .HasColumnName("product_code");
            entity.Property(e => e.ProductId)
                .HasComment("Product")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductType)
                .HasComment("Product type")
                .HasColumnType("character varying")
                .HasColumnName("product_type");
            entity.Property(e => e.Qty)
                .HasComment("Quantity")
                .HasColumnName("qty");
            entity.Property(e => e.Reason)
                .HasComment("Reason")
                .HasColumnType("character varying")
                .HasColumnName("reason");
            entity.Property(e => e.Score)
                .HasComment("Item Score")
                .HasColumnName("score");
            entity.Property(e => e.SerialNumber)
                .HasComment("Serial number")
                .HasColumnType("character varying")
                .HasColumnName("serial_number");
            entity.Property(e => e.State)
                .HasComment("State")
                .HasColumnType("character varying")
                .HasColumnName("state");
            entity.Property(e => e.SuspensionTime)
                .HasMaxLength(8)
                .HasComment("Suspension Time")
                .HasColumnName("suspension_time");
            entity.Property(e => e.UnitPrice)
                .HasComment("Unit Price")
                .HasColumnName("unit_price");
            entity.Property(e => e.VatCode)
                .HasComment("Vat Code")
                .HasColumnType("character varying")
                .HasColumnName("vat_code");
            entity.Property(e => e.VatCodeId)
                .HasComment("Vat Code")
                .HasColumnName("vat_code_id");
            entity.Property(e => e.VatRate)
                .HasComment("Vat Rate")
                .HasColumnName("vat_rate");
            entity.Property(e => e.WaiterId)
                .HasComment("Waiter")
                .HasColumnName("waiter_id");
            entity.Property(e => e.WaiterUserCode)
                .HasComment("Waiter User code")
                .HasColumnType("character varying")
                .HasColumnName("waiter_user_code");
            entity.Property(e => e.Weight).HasColumnName("weight");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.FatherProductNavigation).WithMany(p => p.ScmReceiptItemFatherProductNavigations)
                .HasForeignKey(d => d.FatherProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_items_father_product_id_fkey");

            entity.HasOne(d => d.Header).WithMany(p => p.ScmReceiptItems)
                .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_items_header_id_fkey");

            entity.HasOne(d => d.ItemTill).WithMany(p => p.ScmReceiptItems)
                .HasForeignKey(d => d.ItemTillId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_items_item_till_id_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.ScmReceiptItemProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_items_product_id_fkey");

            entity.HasOne(d => d.VatCodeNavigation).WithMany(p => p.ScmReceiptItems)
                .HasForeignKey(d => d.VatCodeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_items_vat_code_id_fkey");

            entity.HasOne(d => d.Waiter).WithMany(p => p.ScmReceiptItems)
                .HasForeignKey(d => d.WaiterId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_items_waiter_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptItemNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_item_notes_pkey");

            entity.ToTable("scm_receipt_item_notes", tb => tb.HasComment("scm.receipt.item.notes"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasComment("Amount")
                .HasColumnName("amount");
            entity.Property(e => e.Barcode)
                .HasComment("Barcode")
                .HasColumnType("character varying")
                .HasColumnName("barcode");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.ItemId)
                .HasComment("Item")
                .HasColumnName("item_id");
            entity.Property(e => e.Sign)
                .HasComment("Sign")
                .HasColumnType("character varying")
                .HasColumnName("sign");
            entity.Property(e => e.Text)
                .HasComment("Text")
                .HasColumnType("character varying")
                .HasColumnName("text");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Item).WithMany(p => p.ScmReceiptItemNotes)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_item_notes_item_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptItemPromotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_item_promotions_pkey");

            entity.ToTable("scm_receipt_item_promotions", tb => tb.HasComment("scm.receipt.item.promotions"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bonus)
                .HasComment("Promotion Bonus")
                .HasColumnName("bonus");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(5)
                .HasComment("Promotion Category Code")
                .HasColumnName("category_code");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .HasComment("Promotion Code")
                .HasColumnName("code");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.DiscountType)
                .HasMaxLength(6)
                .HasComment("Promotion Discount Type")
                .HasColumnName("discount_type");
            entity.Property(e => e.GroupMixMatch)
                .HasComment("Promotion Group Mixmatch")
                .HasColumnName("group_mix_match");
            entity.Property(e => e.Initiative)
                .HasMaxLength(10)
                .HasComment("Promotion Initiative")
                .HasColumnName("initiative");
            entity.Property(e => e.ItemId)
                .HasComment("Item")
                .HasColumnName("item_id");
            entity.Property(e => e.Points)
                .HasComment("Promotion Points")
                .HasColumnName("points");
            entity.Property(e => e.Qty)
                .HasComment("Promotion Quantity")
                .HasColumnName("qty");
            entity.Property(e => e.QuantityDiscounted)
                .HasComment("Promotion Quantity Discount")
                .HasColumnName("quantity_discounted");
            entity.Property(e => e.Threshold)
                .HasComment("Promotion Threshold")
                .HasColumnName("threshold");
            entity.Property(e => e.ThresholdDiscount)
                .HasComment("Promotion Thresold Discount")
                .HasColumnName("threshold_discount");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Item).WithMany(p => p.ScmReceiptItemPromotions)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_item_promotions_item_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_payments_pkey");

            entity.ToTable("scm_receipt_payments", tb => tb.HasComment("scm.receipt.payments"));

            entity.HasIndex(e => e.HeaderId, "scm_receipt_payments_header_id_index");

            entity.HasIndex(e => e.PaymentDatetime, "scm_receipt_payments_payment_datetime_index");

            entity.HasIndex(e => e.Type, "scm_receipt_payments_type_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasComment("Payment Amount")
                .HasColumnName("amount");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .HasComment("Payment Code")
                .HasColumnName("code");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.Currency)
                .HasMaxLength(5)
                .HasComment("Payment Currency")
                .HasColumnName("currency");
            entity.Property(e => e.HeaderId)
                .HasComment("Header")
                .HasColumnName("header_id");
            entity.Property(e => e.IsRechargeTicket)
                .HasComment("Recharge Ticket")
                .HasColumnName("is_recharge_ticket");
            entity.Property(e => e.PaymentDate)
                .HasMaxLength(8)
                .HasComment("Payment Date")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentDatetime)
                .HasComment("Receipt Datetime")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("payment_datetime");
            entity.Property(e => e.PaymentId)
                .HasComment("Payment")
                .HasColumnName("payment_id");
            entity.Property(e => e.PaymentTime)
                .HasMaxLength(6)
                .HasComment("Payment Time")
                .HasColumnName("payment_time");
            entity.Property(e => e.PaymentTip)
                .HasComment("Payment Tip")
                .HasColumnName("payment_tip");
            entity.Property(e => e.Qty)
                .HasComment("Payment Quantity")
                .HasColumnName("qty");
            entity.Property(e => e.SatispayPaymentId)
                .HasComment("Satispay Payment ID")
                .HasColumnType("character varying")
                .HasColumnName("satispay_payment_id");
            entity.Property(e => e.TicketCode)
                .HasMaxLength(5)
                .HasComment("Payment Ticket Code")
                .HasColumnName("ticket_code");
            entity.Property(e => e.TicketCodeline)
                .HasComment("Ticket Codeline")
                .HasColumnType("character varying")
                .HasColumnName("ticket_codeline");
            entity.Property(e => e.TicketIsDematerialized)
                .HasComment("Ticket is Dematerialized")
                .HasColumnName("ticket_is_dematerialized");
            entity.Property(e => e.Type)
                .HasMaxLength(5)
                .HasComment("Payment Type")
                .HasColumnName("type");
            entity.Property(e => e.UnitValue)
                .HasComment("Payment Unit Value")
                .HasColumnName("unit_value");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Header).WithMany(p => p.ScmReceiptPayments)
                .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_payments_header_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptPaymentDivision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_payment_division_pkey");

            entity.ToTable("scm_receipt_payment_division", tb => tb.HasComment("scm.receipt.payment_division"));

            entity.HasIndex(e => e.HeaderId, "scm_receipt_payment_division_header_id_index");

            entity.HasIndex(e => e.PaymentId, "scm_receipt_payment_division_payment_id_index");

            entity.HasIndex(e => e.ProductId, "scm_receipt_payment_division_product_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.GrossAmountVat)
                .HasComment("Gross Amount Vat")
                .HasColumnName("gross_amount_vat");
            entity.Property(e => e.HeaderId)
                .HasComment("Header")
                .HasColumnName("header_id");
            entity.Property(e => e.NetAmountVat)
                .HasComment("Net Amount Vat")
                .HasColumnName("net_amount_vat");
            entity.Property(e => e.PaymentId)
                .HasComment("Payment")
                .HasColumnName("payment_id");
            entity.Property(e => e.ProductId)
                .HasComment("Product")
                .HasColumnName("product_id");
            entity.Property(e => e.VatAmount)
                .HasComment("Amount Vat")
                .HasColumnName("vat_amount");
            entity.Property(e => e.VatId)
                .HasComment("Vat")
                .HasColumnName("vat_id");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Header).WithMany(p => p.ScmReceiptPaymentDivisions)
                .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_payment_division_header_id_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.ScmReceiptPaymentDivisions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_payment_division_product_id_fkey");

            entity.HasOne(d => d.Vat).WithMany(p => p.ScmReceiptPaymentDivisions)
                .HasForeignKey(d => d.VatId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_payment_division_vat_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptPointCampaignDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_point_campaign_details_pkey");

            entity.ToTable("scm_receipt_point_campaign_details", tb => tb.HasComment("scm.receipt.point.campaign.details"));

            entity.HasIndex(e => e.HeaderId, "scm_receipt_point_campaign_details_header_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CampaignId)
                .HasComment("Points Campaign")
                .HasColumnName("campaign_id");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(25)
                .HasComment("Card Number")
                .HasColumnName("card_number");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.CurrentPointsBalance)
                .HasComment("Current Points Balance")
                .HasColumnName("current_points_balance");
            entity.Property(e => e.ExtraPointsAccumulated)
                .HasComment("Extra Points Accumulated")
                .HasColumnName("extra_points_accumulated");
            entity.Property(e => e.HeaderId)
                .HasComment("Header")
                .HasColumnName("header_id");
            entity.Property(e => e.PointsAccumulated)
                .HasComment("Points Accumulated")
                .HasColumnName("points_accumulated");
            entity.Property(e => e.PointsConsumed)
                .HasComment("Points Consumed")
                .HasColumnName("points_consumed");
            entity.Property(e => e.PreviousPointsBalance)
                .HasComment("Previous Points Balance")
                .HasColumnName("previous_points_balance");
            entity.Property(e => e.TransDate)
                .HasComment("Transaction Datetime")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("trans_date");
            entity.Property(e => e.TransNumber)
                .HasComment("Transaction Number")
                .HasColumnType("character varying")
                .HasColumnName("trans_number");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Header).WithMany(p => p.ScmReceiptPointCampaignDetails)
                .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_point_campaign_details_header_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptPrepaidDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_prepaid_details_pkey");

            entity.ToTable("scm_receipt_prepaid_details", tb => tb.HasComment("scm.receipt.prepaid.details"));

            entity.HasIndex(e => e.HeaderId, "scm_receipt_prepaid_details_header_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmountCash)
                .HasComment("Prepaid Amount Cash")
                .HasColumnName("amount_cash");
            entity.Property(e => e.AmountDischarged)
                .HasComment("Prepaid Amount Discharged")
                .HasColumnName("amount_discharged");
            entity.Property(e => e.AmountRevaluation)
                .HasComment("Prepaid Amount Evaluation")
                .HasColumnName("amount_revaluation");
            entity.Property(e => e.AmountTicket)
                .HasComment("Prepaid Amount Ticket")
                .HasColumnName("amount_ticket");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(25)
                .HasComment("Prepaid Card Number")
                .HasColumnName("card_number");
            entity.Property(e => e.CashCharged)
                .HasComment("Prepaid Cash Charged")
                .HasColumnName("cash_charged");
            entity.Property(e => e.Circuit)
                .HasMaxLength(10)
                .HasComment("Prepaid Circuit")
                .HasColumnName("circuit");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.CurrentTotalAmount)
                .HasComment("Prepaid Current Total Amount")
                .HasColumnName("current_total_amount");
            entity.Property(e => e.ExpirationDate)
                .HasComment("Prepaid Expiration Date")
                .HasColumnName("expiration_date");
            entity.Property(e => e.HeaderId)
                .HasComment("Header")
                .HasColumnName("header_id");
            entity.Property(e => e.PrepaidCreditAmount)
                .HasComment("Prepaid Credit Amount")
                .HasColumnName("prepaid_credit_amount");
            entity.Property(e => e.PrepaidCreditAmountCharged)
                .HasComment("Prepaid Credit Amount Paid Off")
                .HasColumnName("prepaid_credit_amount_charged");
            entity.Property(e => e.PrepaidCreditAmountDischarged)
                .HasComment("Prepaid Credit Amount Used")
                .HasColumnName("prepaid_credit_amount_discharged");
            entity.Property(e => e.PreviousAmountCash)
                .HasComment("Prepaid Previous Amount Cash")
                .HasColumnName("previous_amount_cash");
            entity.Property(e => e.PreviousAmountRevaluation)
                .HasComment("Prepaid Previous Amount Rev.")
                .HasColumnName("previous_amount_revaluation");
            entity.Property(e => e.PreviousAmountTicket)
                .HasComment("Prepaid Previous Amount Ticket")
                .HasColumnName("previous_amount_ticket");
            entity.Property(e => e.RevaluationEarned)
                .HasComment("Prepaid Revaluation Earned")
                .HasColumnName("revaluation_earned");
            entity.Property(e => e.TicketCharged)
                .HasComment("Prepaid Cash ticket")
                .HasColumnName("ticket_charged");
            entity.Property(e => e.TransDate)
                .HasComment("Transaction Datetime")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("trans_date");
            entity.Property(e => e.TransNumber)
                .HasComment("Transaction Number")
                .HasColumnType("character varying")
                .HasColumnName("trans_number");
            entity.Property(e => e.TransactionNumber)
                .HasComment("Prepaid Transaction")
                .HasColumnName("transaction_number");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Header).WithMany(p => p.ScmReceiptPrepaidDetails)
                .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_prepaid_details_header_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptProfitCenter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_profit_centers_pkey");

            entity.ToTable("scm_receipt_profit_centers", tb => tb.HasComment("scm.receipt.profit_centers"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amounts)
                .HasComment("Amount")
                .HasColumnName("amounts");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.HeaderId)
                .HasComment("Header")
                .HasColumnName("header_id");
            entity.Property(e => e.ProfitCenterId)
                .HasComment("Profit Center")
                .HasColumnName("profit_center_id");
            entity.Property(e => e.Qty)
                .HasComment("Quantity")
                .HasColumnName("qty");
            entity.Property(e => e.QtyCovers)
                .HasComment("Covers Quantity")
                .HasColumnName("qty_covers");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.Header).WithMany(p => p.ScmReceiptProfitCenters)
                .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_receipt_profit_centers_header_id_fkey");
        });

        modelBuilder.Entity<ScmReceiptVat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_receipt_vats_pkey");

            entity.ToTable("scm_receipt_vats", tb => tb.HasComment("scm.receipt.vats"));

            entity.HasIndex(e => e.HeaderId, "scm_receipt_vats_header_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountTaxId)
                .HasComment("Tax Code")
                .HasColumnName("account_tax_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.GrossAmount)
                .HasComment("Gross Amount")
                .HasColumnName("gross_amount");
            entity.Property(e => e.HeaderId)
                .HasComment("Header")
                .HasColumnName("header_id");
            entity.Property(e => e.NetAmount)
                .HasComment("Net Amount")
                .HasColumnName("net_amount");
            entity.Property(e => e.VatAmount)
                .HasComment("Tax Amount")
                .HasColumnName("vat_amount");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.AccountTax).WithMany(p => p.ScmReceiptVats)
                .HasForeignKey(d => d.AccountTaxId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_receipt_vats_account_tax_id_fkey");

            entity.HasOne(d => d.Header).WithMany(p => p.ScmReceiptVats)
                .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("scm_receipt_vats_header_id_fkey");
        });

        modelBuilder.Entity<ScmShop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_shops_pkey");

            entity.ToTable("scm_shops", tb => tb.HasComment("scm.shops"));

            entity.HasIndex(e => e.Code, "scm_shops_code_uniq").IsUnique();

            entity.HasIndex(e => e.CompanyId, "scm_shops_company_id_index");

            entity.HasIndex(e => e.DefaultPriceListId, "scm_shops_default_price_list_id_index");

            entity.HasIndex(e => e.HigherPriceListId, "scm_shops_higher_price_list_id_index");

            entity.HasIndex(e => e.LowerPriceListId, "scm_shops_lower_price_list_id_index");

            entity.HasIndex(e => e.Name, "scm_shops_name_uniq").IsUnique();

            entity.HasIndex(e => e.PanariaPartner, "scm_shops_panaria_partner_index");

            entity.HasIndex(e => e.VisibilityId, "scm_shops_visibility_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivationKey)
                .HasMaxLength(50)
                .HasComment("Activation key")
                .HasColumnName("activation_key");
            entity.Property(e => e.Active)
                .HasComment("Active")
                .HasColumnName("active");
            entity.Property(e => e.AdvancedPricelistEscalation)
                .HasComment("Advanced Pricelist Escalation")
                .HasColumnName("advanced_pricelist_escalation");
            entity.Property(e => e.BillHeaderR1)
                .HasMaxLength(40)
                .HasComment("Bill header row 1")
                .HasColumnName("bill_header_r1");
            entity.Property(e => e.BillHeaderR2)
                .HasMaxLength(40)
                .HasComment("Bill header row 2")
                .HasColumnName("bill_header_r2");
            entity.Property(e => e.BillHeaderR3)
                .HasMaxLength(40)
                .HasComment("Bill header row 3")
                .HasColumnName("bill_header_r3");
            entity.Property(e => e.BillHeaderR4)
                .HasMaxLength(40)
                .HasComment("Bill header row 4")
                .HasColumnName("bill_header_r4");
            entity.Property(e => e.BillHeaderR5)
                .HasMaxLength(40)
                .HasComment("Bill header row 5")
                .HasColumnName("bill_header_r5");
            entity.Property(e => e.BillHeaderR6)
                .HasMaxLength(40)
                .HasComment("Bill header row 6")
                .HasColumnName("bill_header_r6");
            entity.Property(e => e.BillHeaderR7)
                .HasMaxLength(40)
                .HasComment("Bill header row 7")
                .HasColumnName("bill_header_r7");
            entity.Property(e => e.BillHeaderR8)
                .HasMaxLength(40)
                .HasComment("Bill header row 8")
                .HasColumnName("bill_header_r8");
            entity.Property(e => e.BookingAppEnabled)
                .HasComment("Enabled for NemPOS Orders")
                .HasColumnName("booking_app_enabled");
            entity.Property(e => e.BookingDeadline)
                .HasComment("Booking End Time Lunch")
                .HasColumnName("booking_deadline");
            entity.Property(e => e.BookingDeadline2)
                .HasComment("Booking End Time Dinner")
                .HasColumnName("booking_deadline2");
            entity.Property(e => e.CardAddCheckdigit)
                .HasComment("Card serial add check digit")
                .HasColumnName("card_add_checkdigit");
            entity.Property(e => e.CardNextNumber)
                .HasComment("Card next progressive number")
                .HasColumnType("character varying")
                .HasColumnName("card_next_number");
            entity.Property(e => e.CardNote)
                .HasComment("Card note")
                .HasColumnName("card_note");
            entity.Property(e => e.CardNoteCopyNumber)
                .HasComment("Card print note copy")
                .HasColumnName("card_note_copy_number");
            entity.Property(e => e.CardPrefix)
                .HasComment("Card Prefix")
                .HasColumnType("character varying")
                .HasColumnName("card_prefix");
            entity.Property(e => e.CardPrintQrcode)
                .HasComment("Card print QR Code")
                .HasColumnName("card_print_qrcode");
            entity.Property(e => e.CardSuffix)
                .HasComment("Card Suffix")
                .HasColumnType("character varying")
                .HasColumnName("card_suffix");
            entity.Property(e => e.ClosingHour)
                .HasMaxLength(5)
                .HasComment("Closing hour")
                .HasColumnName("closing_hour");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasComment("Code")
                .HasColumnName("code");
            entity.Property(e => e.CompanyId)
                .HasComment("Company")
                .HasColumnName("company_id");
            entity.Property(e => e.CompleteMealProduct)
                .HasComment("Complete Meal Product")
                .HasColumnName("complete_meal_product");
            entity.Property(e => e.CourtesyElectronicInvoiceMsg)
                .HasComment("Electronic Invoice Message")
                .HasColumnName("courtesy_electronic_invoice_msg");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.CreditsFilename)
                .HasMaxLength(50)
                .HasComment("Credits filename")
                .HasColumnName("credits_filename");
            entity.Property(e => e.CutOnNext)
                .HasComment("Cut On Next")
                .HasColumnName("cut_on_next");
            entity.Property(e => e.DatabaseVersion)
                .HasMaxLength(50)
                .HasComment("Database Version")
                .HasColumnName("database_version");
            entity.Property(e => e.DefaultCardMode)
                .HasComment("Default Card Mode")
                .HasColumnType("character varying")
                .HasColumnName("default_card_mode");
            entity.Property(e => e.DefaultCoverArticleForTableService)
                .HasComment("Default Cover Article for Table Service")
                .HasColumnName("default_cover_article_for_table_service");
            entity.Property(e => e.DefaultPrepaidTicketRechargeProduct)
                .HasComment("Default Prepaid Ticket Recharge product")
                .HasColumnName("default_prepaid_ticket_recharge_product");
            entity.Property(e => e.DefaultPriceListId)
                .HasComment("Default price list")
                .HasColumnName("default_price_list_id");
            entity.Property(e => e.DefaultRechargeVatRate)
                .HasComment("Default Recharge Vat Rate %")
                .HasColumnName("default_recharge_vat_rate");
            entity.Property(e => e.DeliveryCostThreshold)
                .HasComment("Threshold for free shipping costs")
                .HasColumnName("delivery_cost_threshold");
            entity.Property(e => e.DeliveryInfo)
                .HasComment("Delivery notes")
                .HasColumnName("delivery_info");
            entity.Property(e => e.DeliveryProductId)
                .HasComment("Product for delivery costs")
                .HasColumnName("delivery_product_id");
            entity.Property(e => e.DeliveryProductId2)
                .HasComment("Reduced delivery cost 1")
                .HasColumnName("delivery_product_id_2");
            entity.Property(e => e.DeliveryProductId3)
                .HasComment("Reduced delivery cost 2")
                .HasColumnName("delivery_product_id_3");
            entity.Property(e => e.DiscountOnPickupId)
                .HasComment("Discount on pickup")
                .HasColumnName("discount_on_pickup_id");
            entity.Property(e => e.DrawerDifferenceThreshold1)
                .HasComment("Drawer Difference Threshold #1")
                .HasColumnName("drawer_difference_threshold_1");
            entity.Property(e => e.DropboxBackupEnabled)
                .HasComment("Dropbox Backup Enabled")
                .HasColumnName("dropbox_backup_enabled");
            entity.Property(e => e.DropboxDbBackupRetention)
                .HasComment("Dropbox DB Backup Retention")
                .HasColumnName("dropbox_db_backup_retention");
            entity.Property(e => e.DropboxDbBackupSched)
                .HasMaxLength(4)
                .HasComment("Dropbox DB Backup Scheduled")
                .HasColumnName("dropbox_db_backup_sched");
            entity.Property(e => e.DropboxSaveDbPath)
                .HasMaxLength(50)
                .HasComment("Dropbox DB Save Path")
                .HasColumnName("dropbox_save_db_path");
            entity.Property(e => e.DropboxSaveTransPath)
                .HasMaxLength(50)
                .HasComment("Dropbox Transactions Save Path")
                .HasColumnName("dropbox_save_trans_path");
            entity.Property(e => e.DropboxToken)
                .HasMaxLength(100)
                .HasComment("Dropbox Token")
                .HasColumnName("dropbox_token");
            entity.Property(e => e.ElectronicInvoiceOnlyOnline)
                .HasComment("Electronic Invoice Works Only ONLINE")
                .HasColumnName("electronic_invoice_only_online");
            entity.Property(e => e.EnableDelivery)
                .HasComment("Enable delivery")
                .HasColumnName("enable_delivery");
            entity.Property(e => e.EnableDeliveryInfoButton)
                .HasComment("Enable delivery button info")
                .HasColumnName("enable_delivery_info_button");
            entity.Property(e => e.EnableExpress)
                .HasComment("Express ticket")
                .HasColumnName("enable_express");
            entity.Property(e => e.EnableParking)
                .HasComment("Enable self parking")
                .HasColumnName("enable_parking");
            entity.Property(e => e.EnablePickup)
                .HasComment("Enable pickup")
                .HasColumnName("enable_pickup");
            entity.Property(e => e.EnableSelfOrders)
                .HasComment("Enable self order")
                .HasColumnName("enable_self_orders");
            entity.Property(e => e.ExportPiSwapCategory)
                .HasComment("Swap Category/Sector on Export ")
                .HasColumnName("export_pi_swap_category");
            entity.Property(e => e.ExportPiTemplate)
                .HasComment("Export PI Template")
                .HasColumnName("export_pi_template");
            entity.Property(e => e.ExpressCostThreshold)
                .HasComment("Threshold for free express ticket costs")
                .HasColumnName("express_cost_threshold");
            entity.Property(e => e.ExpressProductId)
                .HasComment("Product for express ticket costs")
                .HasColumnName("express_product_id");
            entity.Property(e => e.ForceImmediateOrder)
                .HasComment("Force Immediate Order")
                .HasColumnName("force_immediate_order");
            entity.Property(e => e.FundManagement)
                .HasComment("Fund management")
                .HasColumnName("fund_management");
            entity.Property(e => e.GiftProductId)
                .HasComment("Gift fee product")
                .HasColumnName("gift_product_id");
            entity.Property(e => e.GroupId)
                .HasComment("Group")
                .HasColumnName("group_id");
            entity.Property(e => e.HelpdeskEmail)
                .HasMaxLength(50)
                .HasComment("Helpdesk Email")
                .HasColumnName("helpdesk_email");
            entity.Property(e => e.HelpdeskPhonenumber)
                .HasMaxLength(50)
                .HasComment("Helpdesk Phone Number")
                .HasColumnName("helpdesk_phonenumber");
            entity.Property(e => e.HigherPriceListId)
                .HasComment("Higher price list")
                .HasColumnName("higher_price_list_id");
            entity.Property(e => e.HqIpAddress)
                .HasMaxLength(16)
                .HasComment("IP main server")
                .HasColumnName("hq_ip_address");
            entity.Property(e => e.Is24h)
                .HasComment("24H Shop")
                .HasColumnName("is_24h");
            entity.Property(e => e.KitchenTemplateId)
                .HasComment("Kitchen Template")
                .HasColumnName("kitchen_template_id");
            entity.Property(e => e.License)
                .HasComment("License")
                .HasColumnName("license");
            entity.Property(e => e.LowerPriceListId)
                .HasComment("Lower price list")
                .HasColumnName("lower_price_list_id");
            entity.Property(e => e.ManageItemForOperator)
                .HasComment("Manage Bill Items For Operator")
                .HasColumnName("manage_item_for_operator");
            entity.Property(e => e.ManagePaymentDivision)
                .HasComment("Manage Transaction Payments division")
                .HasColumnName("manage_payment_division");
            entity.Property(e => e.ManageRealTimeStock)
                .HasComment("Manage Real Time Product Stocks")
                .HasColumnName("manage_real_time_stock");
            entity.Property(e => e.ManagerSafeId)
                .HasComment("Manager Safes")
                .HasColumnName("manager_safe_id");
            entity.Property(e => e.MaxOrderAmount)
                .HasComment("Max order amount")
                .HasColumnName("max_order_amount");
            entity.Property(e => e.MaxPaymentAmount)
                .HasComment("Maximum amount for payments")
                .HasColumnName("max_payment_amount");
            entity.Property(e => e.MaxRecharge)
                .HasComment("Maximum recharge on prepaid")
                .HasColumnName("max_recharge");
            entity.Property(e => e.MaxSaleByDept)
                .HasComment("Maximum price for sales by department")
                .HasColumnName("max_sale_by_dept");
            entity.Property(e => e.MinAmountExpress)
                .HasComment("Min order amount for express orders")
                .HasColumnName("min_amount_express");
            entity.Property(e => e.MinAmountTable)
                .HasComment("Min order amount for self orders")
                .HasColumnName("min_amount_table");
            entity.Property(e => e.MinOrderAmount)
                .HasComment("Min order amount")
                .HasColumnName("min_order_amount");
            entity.Property(e => e.MinOrderAmountTakeaway)
                .HasComment("Min order amount takeaway")
                .HasColumnName("min_order_amount_takeaway");
            entity.Property(e => e.MonouseCardPayLessEqualVat)
                .HasComment("Pays products with VAT less than or equal to the monouse cards rate VAT")
                .HasColumnName("monouse_card_pay_less_equal_vat");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Name")
                .HasColumnName("name");
            entity.Property(e => e.NemposDashboardEnabled)
                .HasComment("Enable NemPOS dashboard")
                .HasColumnName("nempos_dashboard_enabled");
            entity.Property(e => e.NemposDashboardStatus)
                .HasComment("NemPOS dashboard synchronization status")
                .HasColumnType("character varying")
                .HasColumnName("nempos_dashboard_status");
            entity.Property(e => e.NewProductionCentersMode)
                .HasComment("New Production Centers Mode")
                .HasColumnName("new_production_centers_mode");
            entity.Property(e => e.NewsFilename)
                .HasMaxLength(50)
                .HasComment("News Filename")
                .HasColumnName("news_filename");
            entity.Property(e => e.Notes)
                .HasComment("Notes")
                .HasColumnName("notes");
            entity.Property(e => e.NumRivendita)
                .HasComment("Numero rivendita")
                .HasColumnName("num_rivendita");
            entity.Property(e => e.OpenapiEnabled)
                .HasComment("Enabled")
                .HasColumnName("openapi_enabled");
            entity.Property(e => e.OpenapiPassword)
                .HasComment("OpenApi Password")
                .HasColumnType("character varying")
                .HasColumnName("openapi_password");
            entity.Property(e => e.OpenapiSandbox)
                .HasComment("Use Sandbox")
                .HasColumnName("openapi_sandbox");
            entity.Property(e => e.OpenapiUsername)
                .HasComment("OpenApi Username")
                .HasColumnType("character varying")
                .HasColumnName("openapi_username");
            entity.Property(e => e.OpeningHour)
                .HasMaxLength(5)
                .HasComment("Opening hour")
                .HasColumnName("opening_hour");
            entity.Property(e => e.PanariaEnabled)
                .HasComment("Abilitato")
                .HasColumnName("panaria_enabled");
            entity.Property(e => e.PanariaIsTest)
                .HasComment("Test")
                .HasColumnName("panaria_is_test");
            entity.Property(e => e.PanariaPartner)
                .HasComment("Cliente Panaria")
                .HasColumnName("panaria_partner");
            entity.Property(e => e.PanariaRestaurantId)
                .HasComment("ID Ristorante")
                .HasColumnName("panaria_restaurant_id");
            entity.Property(e => e.PanariaShopToken)
                .HasComment("Token Negozio Panaria")
                .HasColumnType("character varying")
                .HasColumnName("panaria_shop_token");
            entity.Property(e => e.PartnerId)
                .HasComment("Linked partner")
                .HasColumnName("partner_id");
            entity.Property(e => e.PiMenuId)
                .HasComment("Default PI Menu")
                .HasColumnName("pi_menu_id");
            entity.Property(e => e.PiSetmenuSystem)
                .HasComment("Manage SetMenu")
                .HasColumnName("pi_setmenu_system");
            entity.Property(e => e.PiWindowSystem)
                .HasComment("Manage Windows")
                .HasColumnName("pi_window_system");
            entity.Property(e => e.PickUpCostThreshold)
                .HasComment("Threshold for free pickup costs")
                .HasColumnName("pick_up_cost_threshold");
            entity.Property(e => e.PikupProductId)
                .HasComment("Product for pickup costs")
                .HasColumnName("pikup_product_id");
            entity.Property(e => e.PrepaidBillingUnified)
                .HasComment("Prepaid Billing Unified")
                .HasColumnName("prepaid_billing_unified");
            entity.Property(e => e.PrepaidDischargeOnNotFiscal)
                .HasComment("Prepaid Discharge On Not Fiscal")
                .HasColumnName("prepaid_discharge_on_not_fiscal");
            entity.Property(e => e.PrepaidManagement)
                .HasComment("Prepaid Management")
                .HasColumnName("prepaid_management");
            entity.Property(e => e.PrepaidOnDbEnabled)
                .HasComment("Prepaid on DB")
                .HasColumnName("prepaid_on_db_enabled");
            entity.Property(e => e.PrepaidOnDbOfflineMode)
                .HasComment("Prepaid on DB OffLine Mode")
                .HasColumnType("character varying")
                .HasColumnName("prepaid_on_db_offline_mode");
            entity.Property(e => e.PrepaidRevaluationAsScontoAPagare)
                .HasComment("Prepaid Revaluation As Sconto a Pagare")
                .HasColumnName("prepaid_revaluation_as_sconto_a_pagare");
            entity.Property(e => e.PrepaidRevaluationPayment)
                .HasComment("Revaluation Payment")
                .HasColumnName("prepaid_revaluation_payment");
            entity.Property(e => e.PrepaidTill)
                .HasComment("Till for e-wallet recharges")
                .HasColumnName("prepaid_till");
            entity.Property(e => e.PrepaidUser)
                .HasComment("POS user for e-wallet recharges")
                .HasColumnName("prepaid_user");
            entity.Property(e => e.PrintDifferenceDetailsOnWithdrawal)
                .HasComment("Print Difference Details on Withdrawal")
                .HasColumnName("print_difference_details_on_withdrawal");
            entity.Property(e => e.RechargeBonusItem)
                .HasComment("Recharge Bouns Item for Gift Card")
                .HasColumnName("recharge_bonus_item");
            entity.Property(e => e.SatispayAuthorizationCode)
                .HasComment("Authorization Code")
                .HasColumnType("character varying")
                .HasColumnName("satispay_authorization_code");
            entity.Property(e => e.SatispayCurrency)
                .HasComment("Currency")
                .HasColumnType("character varying")
                .HasColumnName("satispay_currency");
            entity.Property(e => e.SatispayEnabled)
                .HasComment("Satispay Enabled")
                .HasColumnName("satispay_enabled");
            entity.Property(e => e.SatispayIsStaging)
                .HasComment("Is Staging")
                .HasColumnName("satispay_is_staging");
            entity.Property(e => e.SatispayKeyId)
                .HasComment("Key ID")
                .HasColumnName("satispay_key_id");
            entity.Property(e => e.SatispayPaymentId)
                .HasComment("Payment to Use")
                .HasColumnName("satispay_payment_id");
            entity.Property(e => e.SatispayPrintBill)
                .HasComment("Print Bill")
                .HasColumnName("satispay_print_bill");
            entity.Property(e => e.SatispayPrivateKeyFile)
                .HasComment("Private Key File")
                .HasColumnName("satispay_private_key_file");
            entity.Property(e => e.SatispayPrivateKeyFilepath)
                .HasComment("Private Key File Name")
                .HasColumnType("character varying")
                .HasColumnName("satispay_private_key_filepath");
            entity.Property(e => e.ServiceManagement)
                .HasComment("Service Management")
                .HasColumnType("character varying")
                .HasColumnName("service_management");
            entity.Property(e => e.ServingsEnabled)
                .HasComment("Servings Enabled")
                .HasColumnName("servings_enabled");
            entity.Property(e => e.ServingsPrintMode)
                .HasComment("Servings Print Mode")
                .HasColumnType("character varying")
                .HasColumnName("servings_print_mode");
            entity.Property(e => e.ShopImg)
                .HasComment("Shop Image")
                .HasColumnName("shop_img");
            entity.Property(e => e.ShopImgMedium)
                .HasComment("Shop image")
                .HasColumnName("shop_img_medium");
            entity.Property(e => e.ShopImgTimestamp)
                .HasComment("Image timestamp")
                .HasColumnName("shop_img_timestamp");
            entity.Property(e => e.ShopIpAddress)
                .HasMaxLength(16)
                .HasComment("IP local server")
                .HasColumnName("shop_ip_address");
            entity.Property(e => e.ShowCommentsOnTheReceipt)
                .HasComment("Show Comments On The Receipt")
                .HasColumnName("show_comments_on_the_receipt");
            entity.Property(e => e.ShowDashboardOnTillClosure)
                .HasComment("Show Dashboard on Till Closure")
                .HasColumnName("show_dashboard_on_till_closure");
            entity.Property(e => e.SimsolAccountApiKey)
                .HasComment("Account API Key")
                .HasColumnType("character varying")
                .HasColumnName("simsol_account_api_key");
            entity.Property(e => e.SimsolAccountId)
                .HasComment("Account ID")
                .HasColumnType("character varying")
                .HasColumnName("simsol_account_id");
            entity.Property(e => e.SimsolApiUrl)
                .HasComment("API Url")
                .HasColumnType("character varying")
                .HasColumnName("simsol_api_url");
            entity.Property(e => e.SmsSupport)
                .HasMaxLength(50)
                .HasComment("SMS Support")
                .HasColumnName("sms_support");
            entity.Property(e => e.StatusInterval)
                .HasComment("Status Requests Interval")
                .HasColumnName("status_interval");
            entity.Property(e => e.StockWarehouseId)
                .HasComment("Stock Warehouse")
                .HasColumnName("stock_warehouse_id");
            entity.Property(e => e.Supervisor)
                .HasMaxLength(40)
                .HasComment("Supervisor")
                .HasColumnName("supervisor");
            entity.Property(e => e.SupervisorPassword)
                .HasMaxLength(50)
                .HasComment("Supervisor Password")
                .HasColumnName("supervisor_password");
            entity.Property(e => e.SupportContact)
                .HasMaxLength(50)
                .HasComment("Support Contact")
                .HasColumnName("support_contact");
            entity.Property(e => e.SupportMail)
                .HasMaxLength(50)
                .HasComment("Support Mail")
                .HasColumnName("support_mail");
            entity.Property(e => e.SupportPhone)
                .HasMaxLength(50)
                .HasComment("Support Phone")
                .HasColumnName("support_phone");
            entity.Property(e => e.SuspensionLabel)
                .HasComment("Suspension Label")
                .HasColumnType("character varying")
                .HasColumnName("suspension_label");
            entity.Property(e => e.TableCostThreshold)
                .HasComment("Threshold for free table order costs")
                .HasColumnName("table_cost_threshold");
            entity.Property(e => e.TableCoverProductId)
                .HasComment("Cover product for self order")
                .HasColumnName("table_cover_product_id");
            entity.Property(e => e.TableReservationApiKey)
                .HasComment("Reservations API key")
                .HasColumnType("character varying")
                .HasColumnName("table_reservation_api_key");
            entity.Property(e => e.TableReservationServerUrl)
                .HasComment("Reservations server URL")
                .HasColumnType("character varying")
                .HasColumnName("table_reservation_server_url");
            entity.Property(e => e.TableReservationSystem)
                .HasComment("Reservations System")
                .HasColumnType("character varying")
                .HasColumnName("table_reservation_system");
            entity.Property(e => e.TableServiceManagement)
                .HasComment("Table Service Management")
                .HasColumnName("table_service_management");
            entity.Property(e => e.TaxId)
                .HasComment("Tax")
                .HasColumnName("tax_id");
            entity.Property(e => e.TicClientId)
                .HasComment("Tabacchi in Cloud Client ID")
                .HasColumnType("character varying")
                .HasColumnName("tic_client_id");
            entity.Property(e => e.TimeFromLastSuspension)
                .HasComment("Time From Last Suspension")
                .HasColumnName("time_from_last_suspension");
            entity.Property(e => e.UpdaterServer)
                .HasMaxLength(50)
                .HasComment("Updater Server")
                .HasColumnName("updater_server");
            entity.Property(e => e.UpdaterServerPass)
                .HasMaxLength(50)
                .HasComment("Updater Server Pass")
                .HasColumnName("updater_server_pass");
            entity.Property(e => e.UpdaterServerUser)
                .HasMaxLength(50)
                .HasComment("Updater Server User")
                .HasColumnName("updater_server_user");
            entity.Property(e => e.UrlFacebook)
                .HasComment("URL to Facebook profile")
                .HasColumnType("character varying")
                .HasColumnName("url_facebook");
            entity.Property(e => e.UrlInstagram)
                .HasComment("URL to Instagram profile")
                .HasColumnType("character varying")
                .HasColumnName("url_instagram");
            entity.Property(e => e.UrlLinkedin)
                .HasComment("URL to Linkedin profile")
                .HasColumnType("character varying")
                .HasColumnName("url_linkedin");
            entity.Property(e => e.UrlPinterest)
                .HasComment("URL to Pinterest profile")
                .HasColumnType("character varying")
                .HasColumnName("url_pinterest");
            entity.Property(e => e.UrlPrivacy)
                .HasComment("URL for privacy policy")
                .HasColumnType("character varying")
                .HasColumnName("url_privacy");
            entity.Property(e => e.UrlTermsConditions)
                .HasComment("URL for terms and conditions")
                .HasColumnType("character varying")
                .HasColumnName("url_terms_conditions");
            entity.Property(e => e.UrlTiktok)
                .HasComment("URL to Tiktok profile")
                .HasColumnType("character varying")
                .HasColumnName("url_tiktok");
            entity.Property(e => e.UrlYoutube)
                .HasComment("URL to Youtube channel")
                .HasColumnType("character varying")
                .HasColumnName("url_youtube");
            entity.Property(e => e.UseDefaultRulesNewCard)
                .HasComment("Use Default Rules")
                .HasColumnName("use_default_rules_new_card");
            entity.Property(e => e.UseMenusNewGui)
                .HasComment("Use Menus New Gui")
                .HasColumnName("use_menus_new_gui");
            entity.Property(e => e.Virtual)
                .HasComment("Virtual license")
                .HasColumnName("virtual");
            entity.Property(e => e.VisibilityId)
                .HasComment("Visibility")
                .HasColumnName("visibility_id");
            entity.Property(e => e.WithdrawalMandatory)
                .HasComment("Withdrawal Mandatory")
                .HasColumnName("withdrawal_mandatory");
            entity.Property(e => e.WithdrawalSafeId)
                .HasComment("Safes For Withdrawals")
                .HasColumnName("withdrawal_safe_id");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");

            entity.HasOne(d => d.CompleteMealProductNavigation).WithMany(p => p.ScmShopCompleteMealProductNavigations)
                .HasForeignKey(d => d.CompleteMealProduct)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_complete_meal_product_fkey");

            entity.HasOne(d => d.DefaultCoverArticleForTableServiceNavigation).WithMany(p => p.ScmShopDefaultCoverArticleForTableServiceNavigations)
                .HasForeignKey(d => d.DefaultCoverArticleForTableService)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_default_cover_article_for_table_service_fkey");

            entity.HasOne(d => d.DefaultPrepaidTicketRechargeProductNavigation).WithMany(p => p.ScmShopDefaultPrepaidTicketRechargeProductNavigations)
                .HasForeignKey(d => d.DefaultPrepaidTicketRechargeProduct)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_default_prepaid_ticket_recharge_product_fkey");

            entity.HasOne(d => d.DeliveryProduct).WithMany(p => p.ScmShopDeliveryProducts)
                .HasForeignKey(d => d.DeliveryProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_delivery_product_id_fkey");

            entity.HasOne(d => d.DeliveryProductId2Navigation).WithMany(p => p.ScmShopDeliveryProductId2Navigations)
                .HasForeignKey(d => d.DeliveryProductId2)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_delivery_product_id_2_fkey");

            entity.HasOne(d => d.DeliveryProductId3Navigation).WithMany(p => p.ScmShopDeliveryProductId3Navigations)
                .HasForeignKey(d => d.DeliveryProductId3)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_delivery_product_id_3_fkey");

            entity.HasOne(d => d.ExpressProduct).WithMany(p => p.ScmShopExpressProducts)
                .HasForeignKey(d => d.ExpressProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_express_product_id_fkey");

            entity.HasOne(d => d.GiftProduct).WithMany(p => p.ScmShopGiftProducts)
                .HasForeignKey(d => d.GiftProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_gift_product_id_fkey");

            entity.HasOne(d => d.PanariaPartnerNavigation).WithMany(p => p.ScmShopPanariaPartnerNavigations)
                .HasForeignKey(d => d.PanariaPartner)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scm_shops_panaria_partner_fkey");

            entity.HasOne(d => d.Partner).WithMany(p => p.ScmShopPartners)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_partner_id_fkey");

            entity.HasOne(d => d.PikupProduct).WithMany(p => p.ScmShopPikupProducts)
                .HasForeignKey(d => d.PikupProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_pikup_product_id_fkey");

            entity.HasOne(d => d.PrepaidTillNavigation).WithMany(p => p.ScmShops)
                .HasForeignKey(d => d.PrepaidTill)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_prepaid_till_fkey");

            entity.HasOne(d => d.PrepaidUserNavigation).WithMany(p => p.ScmShops)
                .HasForeignKey(d => d.PrepaidUser)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_prepaid_user_fkey");

            entity.HasOne(d => d.RechargeBonusItemNavigation).WithMany(p => p.ScmShopRechargeBonusItemNavigations)
                .HasForeignKey(d => d.RechargeBonusItem)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_recharge_bonus_item_fkey");

            entity.HasOne(d => d.TableCoverProduct).WithMany(p => p.ScmShopTableCoverProducts)
                .HasForeignKey(d => d.TableCoverProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_table_cover_product_id_fkey");

            entity.HasOne(d => d.Tax).WithMany(p => p.ScmShops)
                .HasForeignKey(d => d.TaxId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_shops_tax_id_fkey");
        });

        modelBuilder.Entity<ScmTill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_tills_pkey");

            entity.ToTable("scm_tills", tb => tb.HasComment("scm.tills"));

            entity.HasIndex(e => e.DefaultPriceListId, "scm_tills_default_price_list_id_index");

            entity.HasIndex(e => e.ErgoPricelist, "scm_tills_ergo_pricelist_index");

            entity.HasIndex(e => e.HallId, "scm_tills_hall_id_index");

            entity.HasIndex(e => e.HigherPriceListId, "scm_tills_higher_price_list_id_index");

            entity.HasIndex(e => e.LowerPriceListId, "scm_tills_lower_price_list_id_index");

            entity.HasIndex(e => e.Prepaidv2ErgoPricelist, "scm_tills_prepaidv2_ergo_pricelist_index");

            entity.HasIndex(e => e.ShopId, "scm_tills_shop_id_index");

            entity.HasIndex(e => e.TillGroupId, "scm_tills_till_group_id_index");

            entity.HasIndex(e => e.TillTypeId, "scm_tills_till_type_id_index");

            entity.HasIndex(e => new { e.ShopId, e.Code }, "scm_tills_tills_code_uniq").IsUnique();

            entity.HasIndex(e => e.VisibilityId, "scm_tills_visibility_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasComment("Enabled")
                .HasColumnName("active");
            entity.Property(e => e.AddforBaseUrl)
                .HasMaxLength(128)
                .HasComment("Base Url")
                .HasColumnName("addfor_base_url");
            entity.Property(e => e.AddforDevicesShowBillsWindow)
                .HasComment("Show Bill Windows")
                .HasColumnName("addfor_devices_show_bills_window");
            entity.Property(e => e.AddforEnabled)
                .HasComment("Enabled")
                .HasColumnName("addfor_enabled");
            entity.Property(e => e.AddforPassword)
                .HasMaxLength(64)
                .HasComment("Password")
                .HasColumnName("addfor_password");
            entity.Property(e => e.AddforUser)
                .HasMaxLength(64)
                .HasComment("User")
                .HasColumnName("addfor_user");
            entity.Property(e => e.AfterLoginPage)
                .HasComment("After Login Page")
                .HasColumnName("after_login_page");
            entity.Property(e => e.ArgenteaAutomaticBpeVoid)
                .HasComment("Automatic Bpe Void in voiding bill")
                .HasColumnName("argentea_automatic_bpe_void");
            entity.Property(e => e.ArgenteaAutomaticDematVoid)
                .HasComment("Automatic Demat Void in voiding bill")
                .HasColumnName("argentea_automatic_demat_void");
            entity.Property(e => e.ArgenteaEnabled)
                .HasComment("Active")
                .HasColumnName("argentea_enabled");
            entity.Property(e => e.ArgenteaPayVoidPlus)
                .HasComment("Use Payment and Void PLUS")
                .HasColumnName("argentea_pay_void_plus");
            entity.Property(e => e.ArgenteaPosIp)
                .HasComment("Pos Ip Address")
                .HasColumnType("character varying")
                .HasColumnName("argentea_pos_ip");
            entity.Property(e => e.ArgenteaPosModel)
                .HasComment("Argentea Pos Model")
                .HasColumnType("character varying")
                .HasColumnName("argentea_pos_model");
            entity.Property(e => e.ArgenteaPosPort)
                .HasComment("Pos Port Number")
                .HasColumnName("argentea_pos_port");
            entity.Property(e => e.ArgenteaPrinterOnBoard)
                .HasComment("Printer On Board")
                .HasColumnName("argentea_printer_on_board");
            entity.Property(e => e.ArgenteaRupp)
                .HasComment("RUPP Code")
                .HasColumnType("character varying")
                .HasColumnName("argentea_rupp");
            entity.Property(e => e.ArgenteaTrackCodePlus)
                .HasComment("Tracking Code for PLUS Methods")
                .HasColumnType("character varying")
                .HasColumnName("argentea_track_code_plus");
            entity.Property(e => e.ArgenteaUseBpe)
                .HasComment("Use BPE")
                .HasColumnName("argentea_use_bpe");
            entity.Property(e => e.ArgenteaUseDemat)
                .HasComment("Use Demat")
                .HasColumnName("argentea_use_demat");
            entity.Property(e => e.ArticlesDetailEnabled)
                .HasComment("Print Articles Detail on Fiscal Closure")
                .HasColumnName("articles_detail_enabled");
            entity.Property(e => e.ArticlesDetailShowAll)
                .HasComment("Show All")
                .HasColumnName("articles_detail_show_all");
            entity.Property(e => e.ArticlesDetailShowOperator)
                .HasComment("Show Operators Detail")
                .HasColumnName("articles_detail_show_operator");
            entity.Property(e => e.ArticlesDetailShowProduct)
                .HasComment("Show Products Detail")
                .HasColumnName("articles_detail_show_product");
            entity.Property(e => e.AskCovers)
                .HasComment("Ask Covers")
                .HasColumnName("ask_covers");
            entity.Property(e => e.AskCustomerName)
                .HasComment("Ask Customer Name")
                .HasColumnName("ask_customer_name");
            entity.Property(e => e.AskPrintNonFiscalBill)
                .HasComment("Ask Print Non Fiscal Bill")
                .HasColumnName("ask_print_non_fiscal_bill");
            entity.Property(e => e.AttendanceDisabled)
                .HasComment("Attendance Disabled")
                .HasColumnName("attendance_disabled");
            entity.Property(e => e.AttendanceMode)
                .HasComment("Attendance Mode")
                .HasColumnType("character varying")
                .HasColumnName("attendance_mode");
            entity.Property(e => e.AutoZReportAt)
                .HasMaxLength(5)
                .HasComment("Auto ZReport At")
                .HasColumnName("auto_z_report_at");
            entity.Property(e => e.AutoZReportEnabled)
                .HasComment("Auto ZReport Enabled")
                .HasColumnName("auto_z_report_enabled");
            entity.Property(e => e.BackToLoginCode)
                .HasComment("Back To Login Code")
                .HasColumnType("character varying")
                .HasColumnName("back_to_login_code");
            entity.Property(e => e.BackupNotfiscalDeviceId)
                .HasComment("Backup Not Fiscal Device")
                .HasColumnName("backup_notfiscal_device_id");
            entity.Property(e => e.BedzzleActive)
                .HasComment("Active")
                .HasColumnName("bedzzle_active");
            entity.Property(e => e.BedzzleHost)
                .HasComment("Bedzzle Host")
                .HasColumnType("character varying")
                .HasColumnName("bedzzle_host");
            entity.Property(e => e.BedzzlePassword)
                .HasComment("Bedzzle Password")
                .HasColumnType("character varying")
                .HasColumnName("bedzzle_password");
            entity.Property(e => e.BedzzlePaymentId)
                .HasComment("Room Transfer Payment")
                .HasColumnName("bedzzle_payment_id");
            entity.Property(e => e.BedzzlePort)
                .HasComment("Bedzzle Host Port")
                .HasColumnName("bedzzle_port");
            entity.Property(e => e.BedzzleUsername)
                .HasComment("Bedzzle Username")
                .HasColumnType("character varying")
                .HasColumnName("bedzzle_username");
            entity.Property(e => e.BillFooter)
                .HasComment("Bill footer")
                .HasColumnName("bill_footer");
            entity.Property(e => e.BillHeader)
                .HasComment("Bill header")
                .HasColumnName("bill_header");
            entity.Property(e => e.BlockShiftIfAlreadyClosed)
                .HasComment("Block Shift If Already Closed")
                .HasColumnName("block_shift_if_already_closed");
            entity.Property(e => e.BusinessCentralCode)
                .HasComment("Business Central Code")
                .HasColumnType("character varying")
                .HasColumnName("business_central_code");
            entity.Property(e => e.CashDrawerName)
                .HasMaxLength(20)
                .HasComment("Cash drawer name")
                .HasColumnName("cash_drawer_name");
            entity.Property(e => e.CentralizedInvoiceNumber)
                .HasComment("Centralized Invoice Number")
                .HasColumnName("centralized_invoice_number");
            entity.Property(e => e.CodCdc)
                .HasComment("CDC Code")
                .HasColumnName("cod_cdc");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasComment("Code")
                .HasColumnName("code");
            entity.Property(e => e.CompanyId)
                .HasComment("Company")
                .HasColumnName("company_id");
            entity.Property(e => e.Country)
                .HasComment("Country")
                .HasColumnType("character varying")
                .HasColumnName("country");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.CustomerDisplayPort)
                .HasMaxLength(20)
                .HasComment("Customer display port")
                .HasColumnName("customer_display_port");
            entity.Property(e => e.DefaultNotfiscalDeviceId)
                .HasComment("Default Not Fiscal Device")
                .HasColumnName("default_notfiscal_device_id");
            entity.Property(e => e.DefaultPettyCashOperator)
                .HasComment("Default Petty Cash Operator")
                .HasColumnName("default_petty_cash_operator");
            entity.Property(e => e.DefaultPriceListId)
                .HasComment("Default price list")
                .HasColumnName("default_price_list_id");
            entity.Property(e => e.DefaultSharedPrinterQueue)
                .HasComment("Default Shared Printer Queue")
                .HasColumnName("default_shared_printer_queue");
            entity.Property(e => e.DenyNotCollectedPaymentsNotFiscal)
                .HasComment("Deny Not Collected Payments")
                .HasColumnName("deny_not_collected_payments_not_fiscal");
            entity.Property(e => e.DenyPayments)
                .HasComment("Deny Payments")
                .HasColumnName("deny_payments");
            entity.Property(e => e.Dfw06StdDeviceParameters)
                .HasMaxLength(50)
                .HasComment("DFW06 STD Device Parameters")
                .HasColumnName("dfw06STD_device_parameters");
            entity.Property(e => e.Dfw06StdDevicePort)
                .HasMaxLength(40)
                .HasComment("DFW06 STD Device Port")
                .HasColumnName("dfw06STD_device_port");
            entity.Property(e => e.Dfw06StdDeviceType)
                .HasMaxLength(16)
                .HasComment("DFW06 STD Device Type")
                .HasColumnName("dfw06STD_device_type");
            entity.Property(e => e.Dfw06StdPortType)
                .HasMaxLength(16)
                .HasComment("DFW06 STD Port Type")
                .HasColumnName("dfw06STD_port_type");
            entity.Property(e => e.DisplayCustomerClosedR1)
                .HasMaxLength(20)
                .HasComment("Till closed (customer) - Row1")
                .HasColumnName("display_customer_closed_r1");
            entity.Property(e => e.DisplayCustomerClosedR2)
                .HasMaxLength(20)
                .HasComment("Till closed (customer) - Row2")
                .HasColumnName("display_customer_closed_r2");
            entity.Property(e => e.DisplayCustomerOpenR1)
                .HasMaxLength(20)
                .HasComment("Till opened (customer) - Row1")
                .HasColumnName("display_customer_open_r1");
            entity.Property(e => e.DisplayCustomerOpenR2)
                .HasMaxLength(20)
                .HasComment("Till opened (customer) - Row2")
                .HasColumnName("display_customer_open_r2");
            entity.Property(e => e.DisplayOperatorOpenR1)
                .HasMaxLength(20)
                .HasComment("Till opened (operator) - Row1")
                .HasColumnName("display_operator_open_r1");
            entity.Property(e => e.DisplayOperatorOpenR2)
                .HasMaxLength(20)
                .HasComment("Till opened (operator) - Row2")
                .HasColumnName("display_operator_open_r2");
            entity.Property(e => e.DrawerOnNonFiscalPrinter)
                .HasComment("Drawer On Non Fiscal Printer")
                .HasColumnName("drawer_on_non_fiscal_printer");
            entity.Property(e => e.EanCoperto)
                .HasComment("Ean Coperto")
                .HasColumnName("ean_coperto");
            entity.Property(e => e.ElectronicDrawerId)
                .HasComment("Electronic Drawer")
                .HasColumnName("electronic_drawer_id");
            entity.Property(e => e.Enabled)
                .HasComment("Enabled")
                .HasColumnName("enabled");
            entity.Property(e => e.ErgoDefaultTaxPerc)
                .HasComment("Ergo default Tax Perc.")
                .HasColumnName("ergo_default_tax_perc");
            entity.Property(e => e.ErgoPricelist)
                .HasComment("Ergo price list")
                .HasColumnName("ergo_pricelist");
            entity.Property(e => e.EscposLinedisplayPort)
                .HasMaxLength(40)
                .HasComment("ESC/POS Line Display Port")
                .HasColumnName("escpos_linedisplay_port");
            entity.Property(e => e.EscposLinedisplayPortParameters)
                .HasMaxLength(50)
                .HasComment("ESC/POS Line Display Port Parameters")
                .HasColumnName("escpos_linedisplay_port_parameters");
            entity.Property(e => e.FixedTablesDb)
                .HasComment("Keep Fixed Tables DB")
                .HasColumnName("fixed_tables_db");
            entity.Property(e => e.FontIncrement)
                .HasComment("Font Increment")
                .HasColumnType("character varying")
                .HasColumnName("font_increment");
            entity.Property(e => e.ForcePriceList)
                .HasComment("Force price list")
                .HasColumnName("force_price_list");
            entity.Property(e => e.FusionPrinterDrawer)
                .HasComment("Fusion Printer Drawer")
                .HasColumnName("fusion_printer_drawer");
            entity.Property(e => e.GenerateSuspensionOnCloseBill)
                .HasComment("Generates Suspension on Receipt Closing")
                .HasColumnName("generate_suspension_on_close_bill");
            entity.Property(e => e.HallId)
                .HasComment("Default Hall")
                .HasColumnName("hall_id");
            entity.Property(e => e.HandHeldScannerDriver)
                .HasComment("Hand scanner driver")
                .HasColumnType("character varying")
                .HasColumnName("hand_held_scanner_driver");
            entity.Property(e => e.HandHeldScannerName)
                .HasMaxLength(20)
                .HasComment("Hand scanner name")
                .HasColumnName("hand_held_scanner_name");
            entity.Property(e => e.HigherPriceListId)
                .HasComment("Higher price list")
                .HasColumnName("higher_price_list_id");
            entity.Property(e => e.IButtonComBaudRate)
                .HasComment("Baud Rate")
                .HasColumnType("character varying")
                .HasColumnName("iButton_com_baud_rate");
            entity.Property(e => e.IButtonComDatabits)
                .HasComment("DataBits")
                .HasColumnType("character varying")
                .HasColumnName("iButton_com_databits");
            entity.Property(e => e.IButtonComParity)
                .HasComment("Parity")
                .HasColumnType("character varying")
                .HasColumnName("iButton_com_parity");
            entity.Property(e => e.IButtonComPort)
                .HasMaxLength(64)
                .HasComment("COM Port Name")
                .HasColumnName("iButton_com_port");
            entity.Property(e => e.IButtonComStopbits)
                .HasComment("StopBits")
                .HasColumnType("character varying")
                .HasColumnName("iButton_com_stopbits");
            entity.Property(e => e.IButtonEnabled)
                .HasComment("Enabled")
                .HasColumnName("iButton_enabled");
            entity.Property(e => e.InactivityTimeout)
                .HasComment("Inactivity timeout")
                .HasColumnName("inactivity_timeout");
            entity.Property(e => e.Ingenico17BillFooter)
                .HasComment("Bill Footer")
                .HasColumnName("ingenico_17_bill_footer");
            entity.Property(e => e.Ingenico17EthPort)
                .HasComment("Ethernet Port Number")
                .HasColumnName("ingenico_17_eth_port");
            entity.Property(e => e.Ingenico17IpAddress)
                .HasComment("Ip Address")
                .HasColumnType("character varying")
                .HasColumnName("ingenico_17_ip_address");
            entity.Property(e => e.Ingenico17Mode)
                .HasComment("Connection Mode")
                .HasColumnType("character varying")
                .HasColumnName("ingenico_17_mode");
            entity.Property(e => e.Ingenico17PosCode)
                .HasComment("POS Code")
                .HasColumnType("character varying")
                .HasColumnName("ingenico_17_pos_code");
            entity.Property(e => e.Ingenico17PrinterOnBoard)
                .HasComment("Printer On Board")
                .HasColumnName("ingenico_17_printer_on_board");
            entity.Property(e => e.Ingenico17ReverseMode)
                .HasComment("Reverse Mode")
                .HasColumnType("character varying")
                .HasColumnName("ingenico_17_reverse_mode");
            entity.Property(e => e.Ingenico17SerConf)
                .HasComment("Serial Port Configuration")
                .HasColumnType("character varying")
                .HasColumnName("ingenico_17_ser_conf");
            entity.Property(e => e.Ingenico17SerPort)
                .HasComment("Serial Port Name")
                .HasColumnType("character varying")
                .HasColumnName("ingenico_17_ser_port");
            entity.Property(e => e.Ingenico17TillCode)
                .HasComment("TILL Code")
                .HasColumnType("character varying")
                .HasColumnName("ingenico_17_till_code");
            entity.Property(e => e.InvoiceCopiesNumber)
                .HasComment("Invoice Copies Number")
                .HasColumnName("invoice_copies_number");
            entity.Property(e => e.InvoiceNumberPrefix)
                .HasMaxLength(50)
                .HasComment("Invoice Number Prefix")
                .HasColumnName("invoice_number_prefix");
            entity.Property(e => e.InvoicePrintMode)
                .HasComment("Invoice Print Mode")
                .HasColumnType("character varying")
                .HasColumnName("invoice_print_mode");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(15)
                .HasComment("IP address")
                .HasColumnName("ip_address");
            entity.Property(e => e.IsErgo)
                .HasComment("Is Ergo")
                .HasColumnName("is_ergo");
            entity.Property(e => e.IsRt)
                .HasComment("Is RT")
                .HasColumnName("is_rt");
            entity.Property(e => e.JposDisplayName)
                .HasMaxLength(20)
                .HasComment("Display name")
                .HasColumnName("jpos_display_name");
            entity.Property(e => e.ListinoBase)
                .HasMaxLength(3)
                .HasComment("Base Pricelist")
                .HasColumnName("listino_base");
            entity.Property(e => e.LogoutClosingTransaction)
                .HasComment("Logout in Closing Transaction")
                .HasColumnName("logout_closing_transaction");
            entity.Property(e => e.LogoutMode)
                .HasComment("Logout Mode")
                .HasColumnType("character varying")
                .HasColumnName("logout_mode");
            entity.Property(e => e.LogoutTimeout)
                .HasComment("Logout timeout")
                .HasColumnName("logout_timeout");
            entity.Property(e => e.LowerPriceListId)
                .HasComment("Lower price list")
                .HasColumnName("lower_price_list_id");
            entity.Property(e => e.MacAddress)
                .HasMaxLength(20)
                .HasComment("MAC address")
                .HasColumnName("mac_address");
            entity.Property(e => e.ManageFiscal)
                .HasComment("Manage Fiscal on Non Fiscal Printer")
                .HasColumnName("manage_fiscal");
            entity.Property(e => e.MaxOrderNumber)
                .HasComment("Max Order Num")
                .HasColumnName("max_order_number");
            entity.Property(e => e.MercuryGatewayId)
                .HasComment("Mercury Gateway")
                .HasColumnName("mercury_gateway_id");
            entity.Property(e => e.MercuryGatewayPort)
                .HasComment("Port Number")
                .HasColumnName("mercury_gateway_port");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Name")
                .HasColumnName("name");
            entity.Property(e => e.NemposfeEndMaintenance)
                .HasComment("NemPos FE Maintenance Due Date")
                .HasColumnName("nemposfe_end_maintenance");
            entity.Property(e => e.NemposfeLicenseForTest)
                .HasComment("NemPos FE License For Test")
                .HasColumnName("nemposfe_license_for_test");
            entity.Property(e => e.NemposfeLicenseVirtual)
                .HasComment("NemPos FE License Virtual")
                .HasColumnName("nemposfe_license_virtual");
            entity.Property(e => e.NemposfeMaintenanceDelayFactor)
                .HasComment("Maintenance Delay Factor")
                .HasColumnName("nemposfe_maintenance_delay_factor");
            entity.Property(e => e.NemposfeMaintenanceExpirationToleranceDays)
                .HasComment("Maintenance Expiration Tolerance Days")
                .HasColumnName("nemposfe_maintenance_expiration_tolerance_days");
            entity.Property(e => e.NotFiscalBillCopies)
                .HasComment("Not Fiscal Bill Copies")
                .HasColumnName("not_fiscal_bill_copies");
            entity.Property(e => e.Notes)
                .HasComment("Notes")
                .HasColumnName("notes");
            entity.Property(e => e.NotfiscalProductMode)
                .HasComment("Not Fiscal Products Mode")
                .HasColumnType("character varying")
                .HasColumnName("notfiscal_product_mode");
            entity.Property(e => e.NumbersPanelBottom)
                .HasComment("Numbers Panel in the bottom")
                .HasColumnName("numbers_panel_bottom");
            entity.Property(e => e.OperatorDisplayPort)
                .HasMaxLength(20)
                .HasComment("Operator display port")
                .HasColumnName("operator_display_port");
            entity.Property(e => e.OrderNumberBig)
                .HasComment("Order Number Big")
                .HasColumnName("order_number_big");
            entity.Property(e => e.PayOutOnMercuryError)
                .HasMaxLength(50)
                .HasComment("Pay Out On Mercury Error")
                .HasColumnName("pay_out_on_mercury_error");
            entity.Property(e => e.PiHandyKeybTemplate)
                .HasComment("PI Spin Pad Key Template")
                .HasColumnName("pi_handy_keyb_template");
            entity.Property(e => e.PiMenuId)
                .HasComment("Default PI Menu")
                .HasColumnName("pi_menu_id");
            entity.Property(e => e.PreferredSafeId)
                .HasComment("Preferred Safe")
                .HasColumnName("preferred_safe_id");
            entity.Property(e => e.PrepaidDeviceParameters)
                .HasMaxLength(50)
                .HasComment("Prepaid Device Parameters")
                .HasColumnName("prepaid_device_parameters");
            entity.Property(e => e.PrepaidDevicePort)
                .HasMaxLength(40)
                .HasComment("Prepaid Device Port")
                .HasColumnName("prepaid_device_port");
            entity.Property(e => e.PrepaidDevicePortType)
                .HasMaxLength(16)
                .HasComment("Prepaid Device Port Type")
                .HasColumnName("prepaid_device_port_type");
            entity.Property(e => e.PrepaidDeviceType)
                .HasMaxLength(16)
                .HasComment("Prepaid Device Type")
                .HasColumnName("prepaid_device_type");
            entity.Property(e => e.PrepaidRfidEnabled)
                .HasComment("RFID Enabled")
                .HasColumnName("prepaid_rfid_enabled");
            entity.Property(e => e.Prepaidv2AuthorizationToken)
                .HasComment("Authorization Token")
                .HasColumnType("character varying")
                .HasColumnName("prepaidv2_authorization_token");
            entity.Property(e => e.Prepaidv2Enabled)
                .HasComment("Enabled")
                .HasColumnName("prepaidv2_enabled");
            entity.Property(e => e.Prepaidv2Ergo)
                .HasComment("Enabled")
                .HasColumnName("prepaidv2_ergo");
            entity.Property(e => e.Prepaidv2ErgoDefaultTaxPerc)
                .HasComment("Ergo default Tax Perc.")
                .HasColumnName("prepaidv2_ergo_default_tax_perc");
            entity.Property(e => e.Prepaidv2ErgoPayment)
                .HasComment("Payment")
                .HasColumnName("prepaidv2_ergo_payment");
            entity.Property(e => e.Prepaidv2ErgoPricelist)
                .HasComment("Ergo price list")
                .HasColumnName("prepaidv2_ergo_pricelist");
            entity.Property(e => e.Prepaidv2ErgoShopCode)
                .HasComment("Ergo Shop Code")
                .HasColumnType("character varying")
                .HasColumnName("prepaidv2_ergo_shop_code");
            entity.Property(e => e.Prepaidv2ErgoTillCode)
                .HasComment("Ergo Till Code")
                .HasColumnType("character varying")
                .HasColumnName("prepaidv2_ergo_till_code");
            entity.Property(e => e.Prepaidv2SendTransactionsImmediately)
                .HasComment("Send Transactions Immediately")
                .HasColumnName("prepaidv2_send_transactions_immediately");
            entity.Property(e => e.Prepaidv2ServerUrl)
                .HasComment("Server Url")
                .HasColumnType("character varying")
                .HasColumnName("prepaidv2_server_url");
            entity.Property(e => e.PrimaryFiscalPrinter)
                .HasComment("Primary Fiscal Printer")
                .HasColumnName("primary_fiscal_printer");
            entity.Property(e => e.PrintOnProductionCenters)
                .HasComment("Print on Production Centers")
                .HasColumnName("print_on_production_centers");
            entity.Property(e => e.PrintOnlyTableSelected)
                .HasComment("Print only when Table is Selected")
                .HasColumnName("print_only_table_selected");
            entity.Property(e => e.PrintPettycashMovementReportBeforeZ)
                .HasComment("Print Petty Cash Report Before Z")
                .HasColumnName("print_pettycash_movement_report_before_z");
            entity.Property(e => e.PrintReportBeforeZ)
                .HasComment("Print Report Before Z")
                .HasColumnName("print_report_before_z");
            entity.Property(e => e.PrintTemporaryBillAfterBillClosing)
                .HasComment("Print Temporary Bill after Bill Closing")
                .HasColumnName("print_temporary_bill_after_bill_closing");
            entity.Property(e => e.PrintTemporaryBillOnFiscalPrinter)
                .HasComment("Print Temporary Bill on Fiscal Printer")
                .HasColumnName("print_temporary_bill_on_fiscal_printer");
            entity.Property(e => e.PrintVatDetails)
                .HasComment("Print Vat Details")
                .HasColumnName("print_vat_details");
            entity.Property(e => e.PrintWasteOnFiscalPrinter)
                .HasComment("Print Waste on Fiscal Printer")
                .HasColumnName("print_waste_on_fiscal_printer");
            entity.Property(e => e.ProductsBackgroundColor)
                .HasComment("Products Background Color")
                .HasColumnType("character varying")
                .HasColumnName("products_background_color");
            entity.Property(e => e.QrcodePrefixBlockKeys)
                .HasComment("Qr-Code Prefix Block Keys")
                .HasColumnType("character varying")
                .HasColumnName("qrcode_prefix_block_keys");
            entity.Property(e => e.QrcodeTypeOnFooter)
                .HasComment("QR Code on Footer")
                .HasColumnType("character varying")
                .HasColumnName("qrcode_type_on_footer");
            entity.Property(e => e.ReceiptPrinterDriver)
                .HasComment("Receipt printer driver")
                .HasColumnType("character varying")
                .HasColumnName("receipt_printer_driver");
            entity.Property(e => e.ReceiptPrinterName)
                .HasMaxLength(20)
                .HasComment("Receipt printer name")
                .HasColumnName("receipt_printer_name");
            entity.Property(e => e.ReceiptPrinterPort)
                .HasMaxLength(20)
                .HasComment("Receipt printer port")
                .HasColumnName("receipt_printer_port");
            entity.Property(e => e.ReceiptPrinterType)
                .HasComment("Receipt printer type")
                .HasColumnType("character varying")
                .HasColumnName("receipt_printer_type");
            entity.Property(e => e.ReqSupervisorForFiscalClosure)
                .HasComment("Request Supervisor for Fiscal closure")
                .HasColumnName("req_supervisor_for_fiscal_closure");
            entity.Property(e => e.ResetBillCounterOnZReport)
                .HasComment("Reset Bill Counter on ZReport")
                .HasColumnName("reset_bill_counter_on_z_report");
            entity.Property(e => e.RestPort)
                .HasComment("Internal Rest port")
                .HasColumnName("rest_port");
            entity.Property(e => e.RoundingByFiscalPrinter)
                .HasComment("Rounding By Fiscal Printer")
                .HasColumnName("rounding_by_fiscal_printer");
            entity.Property(e => e.RoundingMode)
                .HasMaxLength(50)
                .HasComment("Rounding Mode")
                .HasColumnName("rounding_mode");
            entity.Property(e => e.RoundingProduct)
                .HasComment("Rounding Product")
                .HasColumnName("rounding_product");
            entity.Property(e => e.RoundingValue)
                .HasMaxLength(50)
                .HasComment("Rounding Value")
                .HasColumnName("rounding_value");
            entity.Property(e => e.SecondaryFiscalPrinter)
                .HasComment("Secondary Fiscal Printer")
                .HasColumnName("secondary_fiscal_printer");
            entity.Property(e => e.SecondaryFiscalPrinterDrawerName)
                .HasMaxLength(60)
                .HasComment("Secondary Fiscal Printer Drawer Name")
                .HasColumnName("secondary_fiscal_printer_drawer_name");
            entity.Property(e => e.SecondaryFiscalPrinterEnabled)
                .HasComment("Secondary Fiscal Printer Enabled")
                .HasColumnName("secondary_fiscal_printer_enabled");
            entity.Property(e => e.SecondaryFiscalPrinterIsRt)
                .HasComment("Secondary Fiscal Printer Is RT")
                .HasColumnName("secondary_fiscal_printer_is_rt");
            entity.Property(e => e.SecondaryFiscalPrinterLineDisplayName)
                .HasMaxLength(60)
                .HasComment("Secondary Fiscal Printer Line Display Name")
                .HasColumnName("secondary_fiscal_printer_line_display_name");
            entity.Property(e => e.SecondaryFiscalPrinterModel)
                .HasMaxLength(50)
                .HasComment("Secondary Fiscal Printer Model")
                .HasColumnName("secondary_fiscal_printer_model");
            entity.Property(e => e.SecondaryFiscalPrinterName)
                .HasMaxLength(60)
                .HasComment("Secondary Fiscal Printer Name")
                .HasColumnName("secondary_fiscal_printer_name");
            entity.Property(e => e.SelectLastTablesHall)
                .HasComment("Select Last Tabels Hall")
                .HasColumnName("select_last_tables_hall");
            entity.Property(e => e.ServiceProduct)
                .HasComment("Service Product")
                .HasColumnName("service_product");
            entity.Property(e => e.SharedPrinterQueueEnabled)
                .HasComment("Shared Printer Queue Enabled")
                .HasColumnName("shared_printer_queue_enabled");
            entity.Property(e => e.ShopId)
                .HasComment("Shop")
                .HasColumnName("shop_id");
            entity.Property(e => e.ShowDefaultHall)
                .HasComment("Show Default Hall On New Bill")
                .HasColumnName("show_default_hall");
            entity.Property(e => e.ShowPriceOnButtons)
                .HasComment("Show Price on Buttons")
                .HasColumnName("show_price_on_buttons");
            entity.Property(e => e.ShowsSharedPrinterDashboardAtLogin)
                .HasComment("Shows Dashboard At Login")
                .HasColumnName("shows_shared_printer_dashboard_at_login");
            entity.Property(e => e.SimsolEnabled)
                .HasComment("Simsol Enabled")
                .HasColumnName("simsol_enabled");
            entity.Property(e => e.SimsolUserApiKey)
                .HasComment("User API Key")
                .HasColumnType("character varying")
                .HasColumnName("simsol_user_api_key");
            entity.Property(e => e.SimsolUserId)
                .HasComment("User ID")
                .HasColumnType("character varying")
                .HasColumnName("simsol_user_id");
            entity.Property(e => e.StartPageNumber)
                .HasComment("Start Page Number")
                .HasColumnName("start_page_number");
            entity.Property(e => e.StockLocationId)
                .HasComment("Stock location")
                .HasColumnName("stock_location_id");
            entity.Property(e => e.TableRefreshTimeout)
                .HasComment("Table refresh timeout")
                .HasColumnName("table_refresh_timeout");
            entity.Property(e => e.TillCostCenterId)
                .HasComment("Cost Center")
                .HasColumnName("till_cost_center_id");
            entity.Property(e => e.TillGroupId)
                .HasComment("Till Group")
                .HasColumnName("till_group_id");
            entity.Property(e => e.TillModel)
                .HasComment("Till model")
                .HasColumnType("character varying")
                .HasColumnName("till_model");
            entity.Property(e => e.TillTypeId)
                .HasComment("Till type")
                .HasColumnName("till_type_id");
            entity.Property(e => e.TillsReceiptPrinterModel)
                .HasMaxLength(50)
                .HasComment("Printer Model Receipt")
                .HasColumnName("tills_receipt_printer_model");
            entity.Property(e => e.TotalTimeout)
                .HasComment("Total timeout")
                .HasColumnName("total_timeout");
            entity.Property(e => e.UseSharedPrinterQueue)
                .HasComment("Use Shared Printer Queue")
                .HasColumnName("use_shared_printer_queue");
            entity.Property(e => e.UserAutologin)
                .HasComment("User Auto Login")
                .HasColumnName("user_autologin");
            entity.Property(e => e.VerticalLayout)
                .HasComment("Vertical Layout")
                .HasColumnName("vertical_layout");
            entity.Property(e => e.ViewInWindowFrame)
                .HasComment("View in window frame")
                .HasColumnName("view_in_window_frame");
            entity.Property(e => e.VisibilityId)
                .HasComment("Visibility criteria")
                .HasColumnName("visibility_id");
            entity.Property(e => e.VoidItem)
                .HasComment("Void item")
                .HasColumnName("void_item");
            entity.Property(e => e.VoidLast)
                .HasComment("Void last")
                .HasColumnName("void_last");
            entity.Property(e => e.VoidSuspendedItem)
                .HasComment("Void Suspended Item")
                .HasColumnName("void_suspended_item");
            entity.Property(e => e.VoidSuspendedTransaction)
                .HasComment("Void Suspended Transaction")
                .HasColumnName("void_suspended_transaction");
            entity.Property(e => e.VoidTransaction)
                .HasComment("Void transaction")
                .HasColumnName("void_transaction");
            entity.Property(e => e.WaitElectronicInvoiceResult)
                .HasComment("Wait Electronic Invoice Result")
                .HasColumnName("wait_electronic_invoice_result");
            entity.Property(e => e.WindowFrameX)
                .HasComment("Windows size x")
                .HasColumnName("window_frame_x");
            entity.Property(e => e.WindowFrameY)
                .HasComment("Windows size y")
                .HasColumnName("window_frame_y");
            entity.Property(e => e.WineemotionBarcodeEnabled)
                .HasComment("Barcode Enabled")
                .HasColumnName("wineemotion_barcode_enabled");
            entity.Property(e => e.WineemotionBarcodeType)
                .HasComment("Barcode Type")
                .HasColumnType("character varying")
                .HasColumnName("wineemotion_barcode_type");
            entity.Property(e => e.WineemotionPassphrase)
                .HasComment("Passphrase")
                .HasColumnType("character varying")
                .HasColumnName("wineemotion_passphrase");
            entity.Property(e => e.WineemotionPrintOn)
                .HasComment("Print On")
                .HasColumnType("character varying")
                .HasColumnName("wineemotion_print_on");
            entity.Property(e => e.WineemotionPrintOnSeparatedBill)
                .HasComment("Print on Separated Bill")
                .HasColumnName("wineemotion_print_on_separated_bill");
            entity.Property(e => e.WineemotionTotemNumber)
                .HasComment("Totem Number")
                .HasColumnName("wineemotion_totem_number");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            entity.Property(e => e.YearPosition)
                .HasComment("Year Position")
                .HasColumnType("character varying")
                .HasColumnName("year_position");

            entity.HasOne(d => d.DefaultPettyCashOperatorNavigation).WithMany(p => p.ScmTillDefaultPettyCashOperatorNavigations)
                .HasForeignKey(d => d.DefaultPettyCashOperator)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_tills_default_petty_cash_operator_fkey");

            entity.HasOne(d => d.DefaultSharedPrinterQueueNavigation).WithMany(p => p.InverseDefaultSharedPrinterQueueNavigation)
                .HasForeignKey(d => d.DefaultSharedPrinterQueue)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_tills_default_shared_printer_queue_fkey");

            entity.HasOne(d => d.EanCopertoNavigation).WithMany(p => p.ScmTillEanCopertoNavigations)
                .HasForeignKey(d => d.EanCoperto)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_tills_ean_coperto_fkey");

            entity.HasOne(d => d.MercuryGateway).WithMany(p => p.InverseMercuryGateway)
                .HasForeignKey(d => d.MercuryGatewayId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_tills_mercury_gateway_id_fkey");

            entity.HasOne(d => d.RoundingProductNavigation).WithMany(p => p.ScmTillRoundingProductNavigations)
                .HasForeignKey(d => d.RoundingProduct)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_tills_rounding_product_fkey");

            entity.HasOne(d => d.ServiceProductNavigation).WithMany(p => p.ScmTillServiceProductNavigations)
                .HasForeignKey(d => d.ServiceProduct)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_tills_service_product_fkey");

            entity.HasOne(d => d.Shop).WithMany(p => p.ScmTills)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_tills_shop_id_fkey");

            entity.HasOne(d => d.UserAutologinNavigation).WithMany(p => p.ScmTillUserAutologinNavigations)
                .HasForeignKey(d => d.UserAutologin)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("scm_tills_user_autologin_fkey");
        });

        modelBuilder.Entity<ScmUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scm_users_pkey");

            entity.ToTable("scm_users", tb => tb.HasComment("scm.users"));

            entity.HasIndex(e => e.Code, "scm_users_code_uniq").IsUnique();

            entity.HasIndex(e => e.CompanyId, "scm_users_company_id_index");

            entity.HasIndex(e => e.PriceListId, "scm_users_price_list_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasComment("Code")
                .HasColumnName("code");
            entity.Property(e => e.CompanyId)
                .HasComment("Company")
                .HasColumnName("company_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.Enabled)
                .HasComment("Enabled")
                .HasColumnName("enabled");
            entity.Property(e => e.HrEmployeeId)
                .HasComment("Employee")
                .HasColumnName("hr_employee_id");
            entity.Property(e => e.IsTillOperator)
                .HasComment("Till operator")
                .HasColumnName("is_till_operator");
            entity.Property(e => e.ListOnLeft)
                .HasComment("List on Left part of Screen")
                .HasColumnName("list_on_left");
            entity.Property(e => e.ManualCash)
                .HasComment("Set Manual Cash on Payment")
                .HasColumnName("manual_cash");
            entity.Property(e => e.ManualClosePayment)
                .HasComment("Set Manual Close on Payment")
                .HasColumnName("manual_close_payment");
            entity.Property(e => e.ModifyProductBarcodes)
                .HasComment("Modify Product Barcodes")
                .HasColumnName("modify_product_barcodes");
            entity.Property(e => e.ModifyProductDescription)
                .HasComment("Modify Product Description")
                .HasColumnName("modify_product_description");
            entity.Property(e => e.ModifyProductPrices)
                .HasComment("Modify Product Prices")
                .HasColumnName("modify_product_prices");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Name")
                .HasColumnName("name");
            entity.Property(e => e.OperatorCardNum)
                .HasMaxLength(30)
                .HasComment("Operator Card Number")
                .HasColumnName("operator_card_num");
            entity.Property(e => e.OverrideCashlogy)
                .HasComment("Override Enabled")
                .HasColumnName("override_cashlogy");
            entity.Property(e => e.Passcode)
                .HasMaxLength(10)
                .HasComment("Passcode")
                .HasColumnName("passcode");
            entity.Property(e => e.PriceListId)
                .HasComment("Change Price List")
                .HasColumnName("price_list_id");
            entity.Property(e => e.SecurityLevel)
                .HasComment("Security Level")
                .HasColumnType("character varying")
                .HasColumnName("security_level");
            entity.Property(e => e.SimsolUserApiKey)
                .HasComment("User API Key")
                .HasColumnType("character varying")
                .HasColumnName("simsol_user_api_key");
            entity.Property(e => e.SimsolUserId)
                .HasComment("User ID")
                .HasColumnType("character varying")
                .HasColumnName("simsol_user_id");
            entity.Property(e => e.StartPageNumber)
                .HasComment("Start Page Number")
                .HasColumnName("start_page_number");
            entity.Property(e => e.WriteDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.WriteUid).HasColumnName("write_uid");
        });
        modelBuilder.HasSequence("base_cache_signaling");
        modelBuilder.HasSequence("base_registry_signaling");
        modelBuilder.HasSequence("ir_sequence_001");
        modelBuilder.HasSequence("ir_sequence_002");
        modelBuilder.HasSequence("ir_sequence_003");
        modelBuilder.HasSequence("ir_sequence_004");
        modelBuilder.HasSequence("ir_sequence_005");
        modelBuilder.HasSequence("ir_sequence_006");
        modelBuilder.HasSequence("ir_sequence_007");
        modelBuilder.HasSequence("ir_sequence_008");
        modelBuilder.HasSequence("ir_sequence_009");
        modelBuilder.HasSequence("ir_sequence_010");
        modelBuilder.HasSequence("ir_sequence_011");
        modelBuilder.HasSequence("ir_sequence_012");
        modelBuilder.HasSequence("ir_sequence_013");
        modelBuilder.HasSequence("ir_sequence_014");
        modelBuilder.HasSequence("ir_sequence_015");
        modelBuilder.HasSequence("ir_sequence_016");
        modelBuilder.HasSequence("ir_sequence_017");
        modelBuilder.HasSequence("ir_sequence_018");
        modelBuilder.HasSequence("ir_sequence_019");
        modelBuilder.HasSequence("ir_sequence_020");
        modelBuilder.HasSequence("ir_sequence_021");
        modelBuilder.HasSequence("ir_sequence_022");
        modelBuilder.HasSequence("ir_sequence_023");
        modelBuilder.HasSequence("ir_sequence_024");
        modelBuilder.HasSequence("ir_sequence_025");
        modelBuilder.HasSequence("ir_sequence_026");
        modelBuilder.HasSequence("ir_sequence_027");
        modelBuilder.HasSequence("ir_sequence_028");
        modelBuilder.HasSequence("ir_sequence_029");
        modelBuilder.HasSequence("ir_sequence_030");
        modelBuilder.HasSequence("ir_sequence_047");
        modelBuilder.HasSequence("ir_sequence_048");
        modelBuilder.HasSequence("ir_sequence_049");
        modelBuilder.HasSequence("ir_sequence_052");
        modelBuilder.HasSequence("ir_sequence_053");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
