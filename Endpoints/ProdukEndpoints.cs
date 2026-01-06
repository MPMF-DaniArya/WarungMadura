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

        app.MapPost("/product", async (ProdukDb db, createProductDTO request) =>
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

            var productBaru = new Produk
            {
                ProductName = request.ProductName,
                Price = request.Price,
                Stock = request.Stock
            };

            try
            {
                db.Produks.Add(productBaru);
                await db.SaveChangesAsync();
                return Results.Ok(productBaru);
            }
            catch (DbUpdateException)
            {
                return Results.Conflict($"Produk dengan nama '{request.ProductName}' sudah ada!");
            }

        });
    }
}
