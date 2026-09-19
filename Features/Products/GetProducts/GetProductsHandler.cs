using System.Text.Json;

namespace FakeStoreMimic.Features.Products.GetProducts;

public class GetProductsHandler
{
    private const string FilePath = "products.json";

    public async Task<IEnumerable<GetProductsResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
        if (!File.Exists(FilePath))
        {
            return Enumerable.Empty<GetProductsResponse>();
        }

        var jsonText = await File.ReadAllTextAsync(FilePath, cancellationToken);
        
        var products = JsonSerializer.Deserialize<List<GetProductsResponse>>(jsonText);

        return products ?? Enumerable.Empty<GetProductsResponse>();
    }
}
