using WarungMadura.DTOs;
using WarungMadura.Data;
using WarungMadura.Models;
using Microsoft.EntityFrameworkCore;

namespace WarungMadura.Services;

public class ProductService : IProductService
{
    private readonly ProdukDb _db;

    public ProductService(ProdukDb db)
    {
        _db = db;
    }

    public async Task<List<Produk>> GetAllProductAsync()
    {
        return await _db.Produks.ToListAsync();
    }

    public async Task<Produk?> CreateProductAsync(CreateProductDto request)
    {
        var productBaru = new Produk
        {
            ProductName = request.ProductName,
            Price = request.Price,
            Stock = request.Stock
        };

        try
        {
            _db.Produks.Add(productBaru);
            await _db.SaveChangesAsync();
            return productBaru;
        }
        catch (DbUpdateException)
        {
            return null;
        }

    }
}