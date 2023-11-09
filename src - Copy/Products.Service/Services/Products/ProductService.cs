using Microsoft.EntityFrameworkCore;
using Products.DataAccess.Interfaces;
using AutoMapper;
using Products.Domain.Entities.Products;
using Products.Service.Dtos.Products;
using Products.Service.Helper;
using Products.Service.Interfaces.Products;


namespace Products.Service.Services.Products
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _dbRepos;
        private IMapper _mapper;

        public ProductService(IUnitOfWork unitOf, IMapper mapper)
        {
            this._dbRepos = unitOf ?? throw new ArgumentNullException(nameof(unitOf));
            _mapper = mapper;
        }
        public async Task<bool> CreateAsync(ProductDto dto)
        {
            //Product product = new Product
            //{
            //    Brand = dto.Brand,
            //    Name = dto.Name,
            //    Price = dto.Price,
            //    Type = dto.Type,

            //};

            Product product = _mapper.Map<Product>(dto);
            product.Created_At = TimeHelper.GetDateTime();
            product.Updated_At = TimeHelper.GetDateTime();

            await _dbRepos.Product.Add(product);
            var a = _dbRepos.SaveChanges();

            return a > 0;
        }

        public async Task<bool> DeleteAsync(Guid productId)
        {
            await _dbRepos.Product.Delete(productId);
            var res = _dbRepos.SaveChanges();

            return res > 0;
        }

        public Task<IList<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> OrderByDesendingName()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> OrderByName()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Product>> SearchAsync(string searchTerm)
        {
            var results = await _dbRepos.Product
    .Where(p =>
        EF.Functions.Like(p.Id.ToString(), $"%{searchTerm}%") ||
        EF.Functions.Like(p.Name, $"%{searchTerm}%") ||
        EF.Functions.Like(p.Type, $"%{searchTerm}%") ||
        EF.Functions.Like(p.Price.ToString(), $"%{searchTerm}%") ||
        EF.Functions.Like(p.Brand, $"%{searchTerm}%") ||
        (p.Created_At != null && EF.Functions.Like(p.Created_At.ToString(), $"%{searchTerm}%")) ||
        (p.Updated_At != null && EF.Functions.Like(p.Updated_At.ToString(), $"%{searchTerm}%")))
    .ToListAsync();

            return results;
        }

        public async Task<bool> Update(Guid productId, ProductDto dto)
        {
            Product product = _mapper.Map<Product>(dto);
            product.Created_At = TimeHelper.GetDateTime();
            product.Updated_At = TimeHelper.GetDateTime();

            await _dbRepos.Product.Add(product);

            await _dbRepos.Product.Update(productId, product);
            var a = _dbRepos.SaveChanges();

            return a > 0;
        }
    }
}
