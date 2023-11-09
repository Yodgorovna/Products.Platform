﻿using Products.DataAccess.DbContexts;
using Products.DataAccess.Interfaces.Products;
using Products.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Products.DataAccess.Repositories.Products
{
    public class ProductRepository : GenericRepository<Product>, IProduct
    {
        public ProductRepository(AppDbContext appDb) : base(appDb)
        { }

        public IQueryable<Product> OrderBy(Expression<Func<Product, bool>> expression)
            =>  _dbSet.OrderBy(expression);
        
        public IQueryable<Product> OrderByDesending(Expression<Func<Product, bool>> expression) 
            => _dbSet.OrderByDescending(expression);
    }
}
