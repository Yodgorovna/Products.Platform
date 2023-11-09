using Products.DataAccess.Interfaces.Common;
using Products.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Products.DataAccess.Interfaces.Products
{
    public interface IProduct : IGenericRepository<Product>
    {
        public IQueryable<Product> OrderBy(Expression<Func<Product, bool>> expression);
        public IQueryable<Product> OrderByDesending(Expression<Func<Product, bool>> expression);
    }
}
