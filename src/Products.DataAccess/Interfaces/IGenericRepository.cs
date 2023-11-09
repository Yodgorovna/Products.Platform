using Products.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Products.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        public Task<TEntity?> LastOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        public IQueryable<TEntity>OrderBy(Expression<Func<TEntity, string>> expression);
        public IQueryable<TEntity> OrderByDesending(Expression<Func<TEntity, string>> expression);
    }
}
