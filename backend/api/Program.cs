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
// var connection = Configuration.GetConnectionString("DefaultConnection");
var connection = "Host=db;Port=5432;Database=postgres;Username=postgres;Password=poapcentral;";
builder.Services.AddDbContext<PoapCentralDbContext>(options =>
           options.UseNpgsql(connection));

builder.Services.AddHealthChecks();
var app = builder.Build();

app.MapHealthChecks("/healthz");

app.MapGet("/testdb", async ([FromServices] PoapCentralDbContext db) =>
{
    var canConnect = await db.Database.CanConnectAsync();
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

app.Run();
