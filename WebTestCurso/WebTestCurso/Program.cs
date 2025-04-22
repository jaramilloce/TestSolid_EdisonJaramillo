using WebTestCurso.Services.Implementacion;
using WebTestCurso.Services.Interfaces;
using WebTestCurso.Services.Singleton;
using Serilog;
using WebTestCurso.Repository;
using WebTestCurso.Services.Implementacion.ValidacionesStrategy;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(@"c:\Logs\app.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IDataBankProdubanco, DataBankProdubanco>();
builder.Services.AddScoped<IDataBankSolidario, DataBankSolidario>();

builder.Services.AddScoped<IDataBank, DataBanks>();

builder.Services.AddScoped<IValidacionesVarias, ValidacionPagoPrestamo>();
builder.Services.AddScoped<IRepoBankRepository, RepoBankRepository>();
builder.Services.AddScoped<IDataBankPrestamo, DataBanksPrestamos>();

builder.Services.AddSingleton<DataUnifyOptionBank>();

//manejo de log para el Api
builder.Host.UseSerilog();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Aplicación iniciada con Serilog");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "API V2");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
