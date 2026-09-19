

namespace FakeStoreMimic.Features.Products.GetProducts;

public static class GetProductsEndpoint
{
    public static IEndpointRouteBuilder MapGetProducts(this IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (GetProductsHandler handler, CancellationToken cancellationToken) =>
        {
            var products = await handler.HandleAsync(cancellationToken);
            return Results.Ok(products);
        })
        .WithName("GetProducts");
        //.WithOpenApi();

        return app;
    }
}

