using System.Text.Json;

namespace MinimalApi2.Routes
{
    public class Routes
    {
        public static void Routess (WebApplication app)
        {
            app.MapGet("/ping", () => "pong");

            app.MapPost("/customjson", (dynamic json) =>
            {
                Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                string value1 = dict["value1"];
                string value2 = dict["value2"];
                return Results.Ok($"vals: {value1} - {value2}");


            }
            );
        }
    }
}
