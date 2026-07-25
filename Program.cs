using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Enable CORS for your local Vue development server
builder.Services.AddCors(options => {
    options.AddPolicy("AllowVue", policy => {
        policy.WithOrigins("http://localhost:5173", "http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowVue");

// Reads your validated products.json file dynamically
app.MapGet("/products", async () =>
{
    var jsonText = await File.ReadAllTextAsync("products.json");
    var products = JsonSerializer.Deserialize<JsonElement>(jsonText);
    return Results.Ok(products);
});

//app.Urls.Add("http://localhost:5109");

app.Run();
