using AutoMapper;
using SupermarketApiRest.Domain.Models;
using SupermarketApiRest.Resources;

namespace SupermarketApiRest.Mapping
{
    public class ResourceToModelProfile: Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
        }
    }
}