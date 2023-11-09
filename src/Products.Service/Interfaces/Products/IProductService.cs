using Products.Domain.Entities.Products;
using Products.Service.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Interfaces.Products
{
    public interface IProductService
    {

        public Task<bool> CreateAsync(ProductDto dto);
        public Task<bool> Update(Guid productId,ProductDto dto);
        public Task<IList<Product>> OrderByName();
        public Task<IList<Product>> OrderByDesendingName();

        public Task<IList<Product>> OrderByType();
        public Task<IList<Product>> OrderByDesendingType();

        public Task<IList<Product>> GetAllAsync();
        public Task<IList<Product>> SearchAsync(string searchTerm);
        public Task<Product> GetAsync();
        public Task<bool> DeleteAsync(Guid productId);
    }
}
