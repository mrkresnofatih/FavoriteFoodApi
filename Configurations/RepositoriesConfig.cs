using FavoriteFoodApi.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FavoriteFoodApi.Configurations
{
    public static class RepositoriesConfig
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<FoodRepository>();
        }
    }
}