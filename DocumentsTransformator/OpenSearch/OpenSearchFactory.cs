// OpenSearchFactory.cs
using OpenSearch.Client;
using OpenSearch.Net;
using System.Text.RegularExpressions;

public static partial class OpenSearchFactory
{
    private static string ToSnakeCase(string s) =>
        ToSnakeCaseRegex().Replace(s, "$1_$2").ToLower();

    public static IOpenSearchClient Create(string uri, string? user = "admin", string? pwd = null, string? defaultIndex = null)
    {
        var settings = new ConnectionSettings(new Uri(uri))
            .DefaultFieldNameInferrer(ToSnakeCase)
            .DisableDirectStreaming();

        if (uri.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            settings = settings.ServerCertificateValidationCallback(CertificateValidations.AllowAll);
        }

        if (!string.IsNullOrWhiteSpace(defaultIndex))
            settings = settings.DefaultIndex(defaultIndex);

        if (!string.IsNullOrEmpty(user))
            settings = settings.BasicAuthentication(user!, pwd!);

        return new OpenSearchClient(settings);
    }

    [GeneratedRegex("([a-z0-9])([A-Z])")]
    private static partial Regex ToSnakeCaseRegex();
}
