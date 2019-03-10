using AutoMapper;
using SupermarketApiRest.Domain.Models;
using SupermarketApiRest.Resources;

namespace SupermarketApiRest.Mapping
{
    public class MapToResourceProfile: Profile
    {
        public MapToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
        }
    }
}