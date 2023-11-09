using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities.Products;

namespace Products.DataAccess.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }

        DbSet<Product> Product { get; set; }
    }
}
