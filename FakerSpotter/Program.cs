using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace FakerSpotter;

public class Program
{

    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddBlazorise(options => { options.Immediate = true; }).AddBootstrapProviders().AddFontAwesomeIcons();
        builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddScoped(_ => new Random());
        await builder.Build().RunAsync();
    }

}