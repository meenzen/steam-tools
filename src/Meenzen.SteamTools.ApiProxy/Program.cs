using AspNetCore.Proxy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(logging => logging.AddSimpleConsole(options => options.SingleLine = true));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});
builder.Services.AddProxies();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.UseCors();
app.RunProxy(proxy => proxy.UseHttp("https://api.steampowered.com"));

await app.RunAsync();
