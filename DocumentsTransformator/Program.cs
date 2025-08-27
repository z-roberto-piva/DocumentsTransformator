using DocumentsTransformator.Data;
using DocumentsTransformator.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(cfg =>
    {
        cfg.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        cfg.AddEnvironmentVariables();
    })
    .ConfigureServices((ctx, services) =>
    {
        var cs = ctx.Configuration.GetConnectionString("Postgres")!;
        services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(cs));

        var osUri = ctx.Configuration["OpenSearch:Uri"]!;
        var osUser = ctx.Configuration["OpenSearch:User"];
        var osPass = ctx.Configuration["OpenSearch:Pass"];
        var osIndex = ctx.Configuration["OpenSearch:Index"];

        services.AddSingleton(OpenSearchFactory.Create(osUri, osUser, osPass, osIndex));
        services.AddTransient<InvoiceIngestionService>();
    });

using var host = builder.Build();
using var scope = host.Services.CreateScope();
var svc = scope.ServiceProvider.GetRequiredService<InvoiceIngestionService>();

try
{
    await svc.RunAsync();
    Console.WriteLine("Indicizzazione completata.");
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex.ToString());
    Environment.ExitCode = 1;
}
