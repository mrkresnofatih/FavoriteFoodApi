using AutoMapper;
using FavoriteFoodApi.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FavoriteFoodApi.Configurations
{
    public static class AutomapperConfig
    {
        private static IMapper CreateIMapper()
        {
            var mapperProfile = new MapperConfiguration(mp =>
            {
                mp.AddProfile(new AutomapperProfile());
            });
            return mapperProfile.CreateMapper();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(CreateIMapper());
        }
    }

    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Food, FoodCreateUpdateDto>().ReverseMap();
        }
    }
}