// Servizio che legge i dati dal file di log .\BusinessCoach\ExampleData\2025-08-21.log
// estrae i payload JSON e li salva nel database e in OpenSearch

using System.Text.Json;
using System.Text.RegularExpressions;
using DocumentsTransformator.Dtos.BusinessCoach;
using Microsoft.Extensions.Configuration;
using OpenSearch.Client;

namespace DocumentsTransformator.Services;

public partial class BusinessCoachLogIngestionService(IOpenSearchClient os, IConfiguration cfg)
{
    // Inizializzo delle variabili di configurazione
    private readonly IOpenSearchClient _os = os;
    private readonly string _logFilePath = cfg["BusinessCoach:LogFilePath"] ?? throw new ArgumentNullException("BusinessCoach:LogFilePath non configurato");
    private readonly string _index = cfg["BusinessCoach:IndexName"] ?? throw new ArgumentNullException("BusinessCoach:Index non configurato");
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        // I payload sono in camelCase; questa opzione rende il matching case-insensitive
        PropertyNameCaseInsensitive = true
    };


    // Metodo RunAsync del servizio
    public async Task RunAsync(CancellationToken ct = default)
    {
        DateTime startingTime = DateTime.Now;
        Console.WriteLine($"[Index BusinessCoach from log] Inizio indicizzazione dei documenti: {startingTime}");
        await EnsureIndexAsync(ct);

        Console.WriteLine($"[Index BusinessCoach from log] Inizio lettura del file di log: {_logFilePath}");
        DateTime readLogStartTime = DateTime.Now;
        var payloads = ExtractPayloadsFromLog();
        DateTime readLogEndTime = DateTime.Now;
        Console.WriteLine($"[Index BusinessCoach from log] Estratti {payloads.Count} payloads dal file di log. In {readLogEndTime - readLogStartTime} secondi.");

        if (payloads.Count > 0)
        {
            var bulkResponse = await _os.BulkAsync(b => b
                .Index(_index)
                .IndexMany(payloads), ct);

            if (bulkResponse.Errors)
            {
                foreach (var item in bulkResponse.ItemsWithErrors)
                {
                    Console.WriteLine($"Errore indicizzazione documento ID {item.Id}: {item.Error.Reason}");
                }
            }
            else
            {
                Console.WriteLine($"[Index BusinessCoach from log] Indicizzati {payloads.Count} documenti in OpenSearch. In {DateTime.Now - readLogEndTime} secondi.");
            }
        }
        DateTime endingTime = DateTime.Now;
        Console.WriteLine($"[Index BusinessCoach from log] Fine indicizzazione dei documenti: {endingTime}, durata: {endingTime - startingTime}");
    }

    // Metodo che estrai i payload JSON dal file di log
    public List<BusinessCoachDocumentDto> ExtractPayloadsFromLog()
    {
        if (!File.Exists(_logFilePath))
            throw new FileNotFoundException($"File di log non trovato: {_logFilePath}");

        string fileContent = File.ReadAllText(_logFilePath);
        var matches = BusinessCoachDocumentRegex().Matches(fileContent);
        var payloads = new List<BusinessCoachDocumentDto>();
        int recordSkipped = 0;
        int recordAdded = 0;
        int recordProcessed = 0;
        int recordError = 0;
        foreach (Match match in matches)
        {
            if (match.Groups.Count > 1)
                recordProcessed++;
            {
                string jsonPayload = match.Groups[1].Value;
                // Ignoro i payload che non contengono il campo "serviceType"
                if (!jsonPayload.Contains("\"serviceType\""))
                {
                    // Console.WriteLine("Payload ignorato perché non contiene il campo 'serviceType'.");
                    recordSkipped++;
                    continue;
                }
                try
                {
                    var dto = JsonSerializer.Deserialize<BusinessCoachDocumentDto>(jsonPayload, _jsonOptions);
                    if (dto != null)
                        payloads.Add(dto);
                    recordAdded++;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Errore deserializzazione JSON: {ex.Message}");
                    recordError++;
                }
            }
        }
        Console.WriteLine($"Totale record saltati (mancanza campo 'serviceType'): {recordSkipped}");
        Console.WriteLine($"Totale record processati: {recordProcessed}");
        Console.WriteLine($"Totale record aggiunti: {recordAdded}");
        Console.WriteLine($"Totale record con errore di deserializzazione: {recordError}");
        return payloads;       
    }

    // Metodo che inizializza l'indice in OpenSearch se necessario
    private async Task EnsureIndexAsync(CancellationToken ct)
    {
        var exists = await _os.Indices.ExistsAsync(_index, ct: ct);
        if (exists.Exists) return;

        var create = await _os.Indices.CreateAsync(_index, c => c
            .Map<BusinessCoachDocumentDto>(m => m
                .AutoMap()
                .Properties(ps => ps
                    .Nested<RoomDto>(n => n.Name(p => p.Room).AutoMap())
                    .Nested<OperatorDto>(n => n.Name(p => p.Operator).AutoMap())
                    .Nested<DocumentTypeDto>(n => n.Name(p => p.DocumentType).AutoMap())
                    .Nested<ShiftDto>(n => n.Name(p => p.Shift).AutoMap())
                    .Nested<CashDeskDto>(n => n.Name(p => p.CashDesk).AutoMap())
                    .Nested<DetailDto>(n => n.Name(p => p.Details).AutoMap())
                    .Nested<PaymentDetailDto>(n => n.Name(p => p.PaymentDetails).AutoMap())
                )
            ), ct);

        if (!create.IsValid)
            throw new InvalidOperationException($"Creazione indice '{_index}' fallita: {create.DebugInformation}");
    }

    [GeneratedRegex(@"DoSendMessage Payload:\s*(\{.*\})")]
    private static partial Regex BusinessCoachDocumentRegex();

}
