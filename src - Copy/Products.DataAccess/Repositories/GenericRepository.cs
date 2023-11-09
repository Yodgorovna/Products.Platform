using Microsoft.EntityFrameworkCore;
using Products.DataAccess.DbContexts;
using Products.DataAccess.Interfaces;
using System.Linq.Expressions;

namespace Products.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : Repository<TEntity>, IGenericRepository<TEntity>
        where TEntity : class
    {
        public GenericRepository(AppDbContext appDb) : base(appDb)
        { }
        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
            => await _dbSet.FirstOrDefaultAsync(expression);

        public async Task<TEntity?> LastOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
            => await _dbSet.LastOrDefaultAsync(expression);

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
           => _dbSet.Where(expression);
    }
}
