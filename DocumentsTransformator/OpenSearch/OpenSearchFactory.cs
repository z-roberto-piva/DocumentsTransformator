// OpenSearchFactory.cs
using OpenSearch.Client;
using OpenSearch.Net;
using System.Text.RegularExpressions;

namespace DocumentsTransformator.OpenSearch;
public static partial class OpenSearchFactory
{
    static string ToSnakeCase(string name) =>
            ToSnakeRegex().Replace(name, "$1_$2").ToLower();

    public static IOpenSearchClient Create(string uri = "https://localhost:9200", string? user = "admin", string? pwd = "SecureP@ssword1", string? defaultIndex = null)
    {
        var pool = new SingleNodeConnectionPool(new Uri(uri));
        var connectionSettings = new ConnectionSettings(pool)
            .ServerCertificateValidationCallback(CertificateValidations.AllowAll)
            .DefaultFieldNameInferrer(ToSnakeCase)
            .BasicAuthentication(user, pwd);
        if (!string.IsNullOrWhiteSpace(defaultIndex))
            connectionSettings = connectionSettings.DefaultIndex(defaultIndex);
        return new OpenSearchClient(connectionSettings);
    }

    [GeneratedRegex("([a-z0-9])([A-Z])")]
    private static partial Regex ToSnakeRegex();
}
