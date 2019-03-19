using AutoMapper;
using SupermarketApiRest.Domain.Models;
using SupermarketApiRest.Extensions;
using SupermarketApiRest.Resources;

namespace SupermarketApiRest.Mapping
{
    public class MapToResourceProfile : Profile
    {
        public MapToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>().ForMember(src => src.UnitOfMeasurement, opt =>
                opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}