using DocumentsTransformator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenSearch.Client;

namespace DocumentsTransformator.Service;

public class InvoiceIngestionService(AppDbContext db, IOpenSearchClient os, IConfiguration cfg)
{
    private readonly AppDbContext _db = db;
    private readonly IOpenSearchClient _os = os;
    private readonly string _index = cfg["OpenSearch:Index"] ?? "invoices";
    private readonly int _batchSize = int.TryParse(cfg["BatchSize"], out var b) ? b : 2000;
    
    
}