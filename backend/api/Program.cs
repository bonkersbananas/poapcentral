using backend.api.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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
