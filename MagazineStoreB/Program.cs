using FluentValidation.AspNetCore;
using FluentValidation;
using Mapster;
using MagazineStoreB.BL;
using MagazineStoreB.DL;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using MagazineStoreB.Controllers;
using MagazineStoreB.HealthChecks;
using MagazineStoreB.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console(theme:
        AnsiConsoleTheme.Code)
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services
    .AddConfigurations(builder.Configuration)
    .AddDataDependencies()
    .AddBusinessDependencies()
    .AddBackgroundServices();

builder.Services.AddMapster();

builder.Services.AddValidatorsFromAssemblyContaining<TestRequest>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

//builder.Services.AddHealthChecks();

builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("Sample");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/healthz");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// async Method -
// ? 1 ?????? ????????? ?? ????? ???????????????.
// ????? ????????? ??????
// 3 ??????????
// GetDataFromNetwork, GetDataFromDatabase,
// GetDataFromFile
// ??????????? 