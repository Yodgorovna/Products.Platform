using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Products.DataAccess.DbContexts;
using Products.DataAccess.Interfaces;
using Products.DataAccess.Repositories;
using Products.Service.Interfaces;
using Products.Service.Interfaces.Products;
using Products.Service.Services;
using Products.Service.Services.Products;

namespace Products.WebApi.Configurations.LayerConfigurations
{
    public static class DataAccessConfigurations
    {
        public static void ConfigureDataAccess(this WebApplicationBuilder builder1)
        {
            string connection = builder1.Configuration.GetConnectionString("DatabaseConnectionString")!;
            builder1.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connection));

            builder1.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder1.Services.AddScoped<IProductService, ProductService>();
            builder1.Services.AddScoped<IPagination, Pagination>();
        }
    }
}
