using Microsoft.EntityFrameworkCore;
using WarungMadura.Models;

namespace WarungMadura.Data;
public class ProdukDb : DbContext
{
    public ProdukDb(DbContextOptions<ProdukDb> options) : base(options) { }

    public DbSet<Produk> Produks => Set<Produk>();
}