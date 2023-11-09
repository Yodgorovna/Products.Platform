using AutoMapper;
using Products.Domain.Entities.Products;
using Products.Service.Dtos.Products;
using AutoMapper;

namespace Products.Service.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
