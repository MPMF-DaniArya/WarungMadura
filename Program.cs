using WarungMadura.Data;
using WarungMadura.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ProdukDb>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<WarungMadura.Services.IProductService, WarungMadura.Services.ProductService>();

var app = builder.Build();

app.MapProductEndpoints();

app.Run();