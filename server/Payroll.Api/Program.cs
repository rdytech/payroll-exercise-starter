using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Payroll.Api;
using Payroll.Api.Data;
using Payroll.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PayrollDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Payroll")));

builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddProblemDetails(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.CustomizeProblemDetails = DevelopmentErrors.AddExceptionDetail;
    }
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    SeedData.Initialise(scope.ServiceProvider.GetRequiredService<PayrollDbContext>());
}

app.UseExceptionHandler();

app.MapGet("/api/health", () => Results.Ok(new { status = "ok" }));
app.MapEmployeeEndpoints();

app.Run();

// Lets the test project start the API in memory with WebApplicationFactory<Program>.
public partial class Program;
