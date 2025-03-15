using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddSingleton<IAdRepository, AdRepository>();

builder.Services.AddSingleton<AdService>();

builder.Services.AddControllers();

builder.Services.AddControllers().AddApplicationPart(typeof(Program).Assembly);

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run("http://*:8080");