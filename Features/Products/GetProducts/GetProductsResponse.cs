using System.Text.Json.Serialization;

namespace FakeStoreMimic.Features.Products.GetProducts;

public record GetProductsResponse(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("price")] decimal Price,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("category")] string Category,
    [property: JsonPropertyName("image")] string Image,
    [property: JsonPropertyName("rating")] ProductRating Rating
);

public record ProductRating(
    [property: JsonPropertyName("rate")] double Rate,
    [property: JsonPropertyName("count")] int Count
);
