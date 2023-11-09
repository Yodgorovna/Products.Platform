using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Products.DataAccess.Interfaces;
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

        public async Task<IList<Product>> OrderByDesendingName()
        {
            return await _dbRepos.Product.OrderByDesending(p => p.Name).ToListAsync();
        }

        public async Task<IList<Product>> OrderByName()
        {
            return await _dbRepos.Product.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<IList<Product>> OrderByDesendingType()
        {
            return await _dbRepos.Product.OrderByDesending(p => p.Type).ToListAsync();
        }

        public async Task<IList<Product>> OrderByType()
        {
            return await _dbRepos.Product.OrderBy(p => p.Type).ToListAsync();
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
            product.Updated_At = TimeHelper.GetDateTime();

            await _dbRepos.Product.Update(productId, product);
            var a = _dbRepos.SaveChanges();

            return a > 0;
        }

        public async Task<IList<Product>> OrderByBrand()
        {
            return await _dbRepos.Product.OrderBy(p => p.Brand).ToListAsync();
        }

        public async Task<IList<Product>> OrderByDesendingBrand()
        {
            return await _dbRepos.Product.OrderByDesending(p => p.Brand).ToListAsync();
        }

        public async Task<IList<Product>> OrderById()
        {
            return await _dbRepos.Product.OrderBy(p => p.Id.ToString()).ToListAsync();
        }

        public async Task<IList<Product>> OrderByDesendingId()
        {
            return await _dbRepos.Product.OrderByDesending(p => p.Id.ToString()).ToListAsync();
        }

        public async Task<IList<Product>> OrderByPrice()
        {
            return await _dbRepos.Product.OrderBy(p => p.Price.ToString()).ToListAsync();
        }

        public async Task<IList<Product>> OrderByDesendingPrice()
        {
            return await _dbRepos.Product.OrderByDesending(p => p.Price.ToString()).ToListAsync();
        }

        public async Task<IList<Product>> OrderByCreatedAt()
        {
            return await _dbRepos.Product.OrderByDate(p => p.Created_At).ToListAsync();
        }

        public async Task<IList<Product>> OrderByDesendingCreatedAt()
        {
            return await _dbRepos.Product.OrderByDesendingDate(p => p.Created_At).ToListAsync();
        }

        public async Task<IList<Product>> OrderByUpdatedAt()
        {
            return await _dbRepos.Product.OrderByDesendingDate(p => p.Created_At).ToListAsync();
        }

        public async Task<IList<Product>> OrderByDesendingUpdatedAt()
        {
            return await _dbRepos.Product.OrderByDesendingDate(p => p.Updated_At).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid getbyid)
        {
           return  _dbRepos.Product.GetByIdAsync(getbyid);
        }
    }
}
