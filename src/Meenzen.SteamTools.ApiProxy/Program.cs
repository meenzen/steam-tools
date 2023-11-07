using AspNetCore.Proxy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(logging => logging.AddSimpleConsole(options => options.SingleLine = true));
builder
    .Services
    .AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });
    });
builder.Services.AddProxies();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors();
app.RunProxy(proxy => proxy.UseHttp("https://api.steampowered.com"));

app.Run();
