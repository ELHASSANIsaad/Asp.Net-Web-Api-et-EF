using AutoMapper;
using Castle.Core.Resource;
using Shared.Dto;
using Shared.Model;

namespace FormationApi
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<RestaurantDto, Restaurant>();
            CreateMap<CuisineDto, Cuisine>();
            CreateMap<ContactDto, Contact>();
        }
    }
}
