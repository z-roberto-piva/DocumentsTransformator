# Read Me

## Istruzione per lo scaffold delle tabelle

--use-database-names --no-onconfiguring

```bash

dotnet ef dbcontext scaffold "Host=localhost;Username=zmenu;Password=sviluppo;Database=anondb_dev" Npgsql.EntityFrameworkCore.PostgreSQL --project DocumentsTransformator --output-dir Entities --context AppDbContext --context-dir Data --namespace DocumentsTransformator.Entities --context-namespace DocumentsTransformator.Data --table scm_receipt_agreements --table scm_receipt_analytic_items --table scm_receipt_coupons_detail --table scm_receipt_discount_details --table scm_receipt_headers --table scm_receipt_invoice_details --table scm_receipt_item_notes --table scm_receipt_item_promotions --table scm_receipt_items --table scm_receipt_payment_division --table scm_receipt_payments --table scm_receipt_point_campaign_details --table scm_receipt_prepaid_details --table scm_receipt_profit_centers --table scm_receipt_vats --table scm_shops --table scm_tills --table scm_users --table product_product --table product_template --table product_category --table product_uom --table account_tax --force

```
