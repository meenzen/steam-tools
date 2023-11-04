using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Meenzen.SteamTools.Components;
using Meenzen.SteamTools.Services;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices(configuration =>
{
    configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
    configuration.SnackbarConfiguration.PreventDuplicates = true;
    configuration.SnackbarConfiguration.SnackbarVariant = Variant.Outlined;
    configuration.SnackbarConfiguration.ShowCloseIcon = false;
});

Uri proxyUri = new Uri(builder.HostEnvironment.BaseAddress + "api/proxy/");
if (builder.HostEnvironment.IsDevelopment())
{
#pragma warning disable S1075
    proxyUri = new Uri("http://localhost:5115");
#pragma warning restore S1075
}

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = proxyUri });
builder.Services.AddScoped<SteamApi>();

await builder.Build().RunAsync();
