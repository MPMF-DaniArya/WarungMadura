using WarungMadura.DTOs;
using WarungMadura.Data;
using WarungMadura.Models;
using Microsoft.EntityFrameworkCore;

namespace WarungMadura.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/product", async (ProdukDb db) =>
        {
            return await db.Produks.ToListAsync();
        });

        app.mapPost("/product", async (ProductDb db, createProductDTO request) =>
        {
            if(string.IsNullOrWhiteSpace(request.ProductName))
            {
                return Results.BadRequest("Nama product tidak boleh kosong!");
            }

            if (request.Price < 0)
            {
                return Results.BadRequest("Harga product tidak boleh minus");
            }

            var productBaru = new Produk
            {
                // ProductName = request.ProductName
                // price
            };
        });
    }
}
