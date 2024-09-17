using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using WebTask;
using WebTask.Utils;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
try
{
    var configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();

    var appSettings = configuration.Get<AppSettings>();

    builder.Services.AddSingleton(appSettings);
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(appSettings.BaseAddress) });

    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    await builder.Build().RunAsync();
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error loading configuration: {ex.Message}");
    throw;
}
