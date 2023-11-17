using backend.api.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/healthz");

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
