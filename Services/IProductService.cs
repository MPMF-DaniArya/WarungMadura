using WarungMadura.DTOs;
using WarungMadura.Models;

namespace WarungMadura.Services;

public interface IProductService
{
    Task<List<Produk>> GetAllProductAsync();
    Task<Produk> CreateProductAsync(CreateProductDto k);
}