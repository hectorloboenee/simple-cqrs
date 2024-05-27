using Microsoft.AspNetCore.Builder;
using Simple.Cqrs.Application.Extensions;
using Simple.Cqrs.Common.infrastructure.Extensions;
using Simple.Cqrs.Domain;

DotNetEnv.Env.Load();

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var builder = WebApplication.CreateBuilder(args);
builder.AddServer(configuration);

var webApp = builder.Build();

var app = webApp.UseServer(args);

app.Run();


