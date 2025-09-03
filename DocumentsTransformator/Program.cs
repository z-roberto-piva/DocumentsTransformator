using DocumentsTransformator.Data;
using DocumentsTransformator.Services;
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
        var cs = ctx.Configuration["Database:ConnectionString"];
        services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(cs));

        var osUri = ctx.Configuration["OpenSearch:Uri"]!;
        var osUser = ctx.Configuration["OpenSearch:User"];
        var osPass = ctx.Configuration["OpenSearch:Password"];
        var osIndex = ctx.Configuration["OpenSearch:Index"];

        services.AddSingleton(OpenSearchFactory.Create(osUri, osUser, osPass, osIndex));
        services.AddTransient<InvoiceIngestionService>();
        services.AddTransient<BusinessCoachLogIngestionService>();
    });

using var host = builder.Build();
using var scope = host.Services.CreateScope();
var InvoiceSvc = scope.ServiceProvider.GetRequiredService<InvoiceIngestionService>();
var BusinessCoachSvc = scope.ServiceProvider.GetRequiredService<BusinessCoachLogIngestionService>();

try
{
    // await InvoiceSvc.RunAsync();
    await BusinessCoachSvc.RunAsync();
    Console.WriteLine("Indicizzazione tipo 1 completata.");
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex.ToString());
    Environment.ExitCode = 1;
}
