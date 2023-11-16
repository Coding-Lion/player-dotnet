var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/", (System.Text.Json.JsonElement body) =>
    Results.Json(Strategy.Decide(Newtonsoft.Json.JsonConvert.DeserializeObject<Table>(body.ToString())) ));

app.MapGet("/", () => "Player C#/.net");


app.Run();