using Blazored.LocalStorage;
using Meenzen.SteamTools;
using Meenzen.SteamTools.Components;
using Meenzen.SteamTools.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder
    .Services
    .AddMudServices(configuration =>
    {
        configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
        configuration.SnackbarConfiguration.PreventDuplicates = true;
        configuration.SnackbarConfiguration.SnackbarVariant = Variant.Outlined;
        configuration.SnackbarConfiguration.ShowCloseIcon = false;
    });

builder
    .Services
    .Configure<SteamToolsOptions>(options =>
    {
        options.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);

        if (builder.HostEnvironment.IsDevelopment())
        {
            options.ProxyUri = new Uri("http://localhost:5115");
        }
        else
        {
            options.ProxyUri = new Uri(builder.HostEnvironment.BaseAddress + "api/proxy/");
        }
    });

var options = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<SteamToolsOptions>>();

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = options.Value.ProxyUri });
builder.Services.AddScoped<SteamApi>();

await builder.Build().RunAsync();
