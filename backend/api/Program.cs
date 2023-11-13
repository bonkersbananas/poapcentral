using backend.api.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/healthz");

app.MapGet("/", () => "Welcome to POAP Central");

app.MapGet("/poap", () =>
{
    var poap = new Poap
    {
        Id = 555,
        Url = "https://example.com/poap",
        Status = Status.SUCCESS
    };
    return Results.Ok(poap);
});




app.Run();
