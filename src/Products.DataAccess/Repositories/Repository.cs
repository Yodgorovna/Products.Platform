﻿using Microsoft.EntityFrameworkCore;
using Products.DataAccess.DbContexts;
using Products.DataAccess.Interfaces;

namespace Products.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DbSet<TEntity> _dbSet;

        public Repository(AppDbContext appDb)
        {
            this._dbSet = appDb.Set<TEntity>();
        }

        public async Task Add(TEntity entity) =>  this._dbSet.Add(entity);

        public async Task<long> CountAsync() => await _dbSet.CountAsync();

        public async Task Delete(Guid id)
        {
            TEntity entity = this._dbSet.Find(id)!;
            if (entity != null)
            {
                this._dbSet.Remove(entity);
            }
        }

        public IQueryable<TEntity> GetAll() => _dbSet;

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            TEntity entity = this._dbSet.Find(id)!;
            if (entity != null)
            {
                return  entity;
            }
            return null;

        }

        public async Task Update(Guid id, TEntity entity)
        {
            var res = this._dbSet.Find(id);
            if (res != null) 
                this._dbSet.Update(entity);
        }
    }
}
