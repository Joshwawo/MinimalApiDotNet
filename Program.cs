//WebApplication builder = WebApplication.CreateBuilder(args);
//WebApplication app = builder.Build();

//app.MapGet("/", () => "Hello World!");


//app.Run();

using MinimalApi2.Models;
using MinimalApi2.Routes;

internal class Program
{
    private static void Main(string[] args)

    {
        WebApplication app = WebApplication.Create(args);

        app.Logger.LogWarning("Test message");
        app.MapGet("/", () => "Hola mundes");
        app.MapGet("/names", () => app.Configuration["Data:Name"]);
        app.MapGet("/me/{name}", (string name) => $"Hola, {name}!");
        app.MapPost("/dev", (Programador programador) =>
            {
                programador.Id = Guid.NewGuid().ToString();
                app.Logger.LogInformation($"{programador.Id}, {programador.Name}");
                return Results.StatusCode(200);
            }
            );
        Routes.Routess(app);

        app.Run(app.Configuration["Data:Url"]);
    }
}