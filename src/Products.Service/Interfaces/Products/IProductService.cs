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

        public Task<IList<Product>> OrderByBrand();
        public Task<IList<Product>> OrderByDesendingBrand();

        public Task<IList<Product>> OrderById();
        public Task<IList<Product>> OrderByDesendingId();

        public Task<IList<Product>> OrderByPrice();
        public Task<IList<Product>> OrderByDesendingPrice();

        public Task<IList<Product>> OrderByCreatedAt();
        public Task<IList<Product>> OrderByDesendingCreatedAt();

        public Task<IList<Product>> OrderByUpdatedAt();
        public Task<IList<Product>> OrderByDesendingUpdatedAt();

        public Task<IList<Product>> GetAllAsync();
        public Task<IList<Product>> SearchAsync(string searchTerm);
        public Task<Product?> GetByIdAsync(Guid getbyid);
        public Task<bool> DeleteAsync(Guid productId);
    }
}
