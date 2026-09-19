using FakeStoreMimic.Features.Products.GetProducts;
//using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);


// 1. Configure CORS based on the running environment
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVue", policy =>
    {
        if (builder.Environment.IsDevelopment())
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        }
        else
        {
            // Replace with your actual Vue production URL on Azure
            policy.WithOrigins("https://azurewebsites.net")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        }
    });
});

// Register feature logic
builder.Services.AddScoped<GetProductsHandler>();

var app = builder.Build();

app.UseCors("AllowVue");

// Map feature routing
app.MapGetProducts();

//app.Urls.Add("http://localhost:5109");

app.Run();
