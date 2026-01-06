using WarungMadura.DTOs;
using WarungMadura.Services;

namespace WarungMadura.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/product", async (IProductService service) =>
        {
            return await service.GetAllProductAsync();
        });

        app.MapPost("/product", async (IProductService service, CreateProductDto request) =>
        {
            if (string.IsNullOrWhiteSpace(request.ProductName))
            {
                return Results.BadRequest("Nama product tidak boleh kosong!");
            }

            if (request.Price < 0)
            {
                return Results.BadRequest("Harga product tidak boleh minus");
            }

            if (request.Stock < 0)
            {
                return Results.BadRequest("Stock Produk tidak boleh minus");
            }

            var result = await service.CreateProductAsync(request);

            if (result is null)
            {
                return Results.Conflict($"Kopi dengan nama '{request.ProductName}' sudah ada!");
            }

            return Results.Ok(result);
        });
    }
}
