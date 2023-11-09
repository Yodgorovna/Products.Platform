using Products.DataAccess.DbContexts;
using Products.DataAccess.Interfaces;
using Products.DataAccess.Interfaces.Products;
using Products.DataAccess.Repositories.Products;

namespace Products.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AppDbContext _dbSet;

        public IProduct Product { get; }
        public UnitOfWork(AppDbContext app)
        {
            this._dbSet = app;
            this.Product = new ProductRepository(app);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources (if any)
                _dbSet.Dispose();
            }
            // Dispose unmanaged resources (if any)
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }


        public int SaveChanges()
        {
            return this._dbSet.SaveChanges();
        }
    }
}
