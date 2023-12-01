using backend.api.Models;
using backend.api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
var connection = Environment.GetEnvironmentVariable("DB_CONNECTIONSTRING");

builder.Services.AddDbContext<PoapCentralDbContext>(options =>
           options.UseNpgsql(connection));

builder.Services.AddHealthChecks();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PoapCentralDbContext>();
    context.Init().Wait();
}
app.MapHealthChecks("/healthz");

app.MapGet("/testdb", async (PoapCentralDbContext context) =>
{
    var canConnect = await context.Database.CanConnectAsync();
    return Results.Ok(new { CanConnect = canConnect });
});

app.MapGet("/", () => "Welcome to POAP Central");

app.MapGet("/event/{id}", (string id) =>
{
    var poapEvent = new Event
    {
        Id = id,
        Title = "POAP Central Test Event",
        Description = "POAP Central has made a great POAP.",
        ImageUrl = "https://example.com/poap.png",
        RequiredPoaps = new List<Poap>
        {
            new Poap
            {
                Id = "1A1",
                Url = "https://example.com/poap/111",
                Status = Status.SUCCESS
            }
        }
    };
    return Results.Ok(poapEvent);
});

app.MapGet("/poap", () =>
{
    var poap = new Poap
    {
        Id = "5B5",
        Url = "https://example.com/poap",
        Status = Status.SUCCESS
    };
    return Results.Ok(poap);
});

//  Example body:
//{
//     "Id": "123",
//     "Url": "https://example.com/poap",
//     "Status": "SUCCESS"
// }
app.MapPost("/poap", async (Poap poap, PoapCentralDbContext context) =>
{
    var validationResult = ValidatePoap(poap);
    if (validationResult != Results.Ok())
    {
        return validationResult;
    }
    context.Poaps.Add(poap);
    await context.SaveChangesAsync();

    return Results.Created($"/poap/{poap.Id}", poap);
});

app.Run();

IResult ValidatePoap(Poap poap)
{
    if (string.IsNullOrWhiteSpace(poap.Id))
    {
        return Results.BadRequest("Id is required.");
    }

    if (string.IsNullOrWhiteSpace(poap.Url) || !Uri.IsWellFormedUriString(poap.Url, UriKind.Absolute))
    {
        return Results.BadRequest("A valid Url is required.");
    }

    if (string.IsNullOrWhiteSpace(poap.Status))
    {
        return Results.BadRequest("Status is required.");
    }

    return Results.Ok();
}
