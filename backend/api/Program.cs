using backend.api.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/poap", () =>
{
    var poap = new Poap
    {
        Url = "https://example.com/poap",
        Message = "Success!",
        Id = 555,
        IsDistributed = true
    };
    return Results.Ok(poap);
});

app.Run();
