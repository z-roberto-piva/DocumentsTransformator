
// L'applicazione deve leggere i dati dalle tabelle relative ai documenti di vendita presenti nel database postgres sorgente e scrivere i dati 
// nella nuova tabella di test presente nel database postgres di destinazione.
// L'applicazione deve usare entity framework per leggere i dati dal database sorgente e scrivere i dati nel database di destinazione.
// I dati delle tabelle di dettaglio verranno normalizzati, trasformati in JSON e scritti in una colonna di tipo JSONB della tabella di test.
// La tabella di test avrà le stesse tabelle della tabella delle testate di origine, ma alcuni campi verranno normalizzati e poi verranno aggiunti i campi JSONB relativi ai dettagli.
// L'applicazione deve poter gestire i parametri in in ingresso come codice negozio, data di inizio e fine, per filtrare i documenti da leggere e scrivere.
// I parametri di connessione ai database di origine e destinazione devono essere letti da un file di configurazione, ma alcuni di essi possono essere passati come parametri in ingresso all'applicazione oppure letti da secret manager.

using System.Text.RegularExpressions;
using DocumentsTransformator.Entities;
using OpenSearch.Client;
using OpenSearch.Net;

static string ToSnakeCase(string name) =>
            Regex.Replace(name, "([a-z0-9])([A-Z])", "$1_$2").ToLower();

var pool = new SingleNodeConnectionPool(new Uri("https://localhost:9200"));
var connectionSettings = new ConnectionSettings(pool)
    .ServerCertificateValidationCallback(CertificateValidations.AllowAll)
    .DefaultIndex("students")
    .DefaultFieldNameInferrer(ToSnakeCase)
    .BasicAuthentication("admin", "SecureP@ssword1");
var client = new OpenSearchClient(connectionSettings);

var student = new Student { 
    Id = 1, 
    Name = "Paulo Santos", 
    Gpa = 3.95, 
    GradYear = 2021 
};

client.IndexDocument(student);
var response = client.Get<Student>(1);
Console.WriteLine($"Student: {response.Source?.Name} - GPA: {response.Source?.Gpa}");


var countResponse = client.Count<Student>(c => c.Query(q => q.MatchAll()));

Console.WriteLine($"Total students: {countResponse.Count}");
