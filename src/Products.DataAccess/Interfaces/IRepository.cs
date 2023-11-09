using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.DataAccess.Interfaces
{
    public interface IRepository<TEntity>  where TEntity : class
    {
        public IQueryable<TEntity> GetAll();
        public Task<long> CountAsync();
        public Task Add(TEntity entity);
        public Task Update(Guid id, TEntity entity);
        public Task Delete(Guid id);
        public TEntity GetByIdAsync(Guid id);
    }
}
