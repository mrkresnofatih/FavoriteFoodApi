using Microsoft.Extensions.DependencyInjection;
using shortid;
using shortid.Configuration;

namespace FavoriteFoodApi.Configurations
{
    public static class ShortIdConfig
    {
        public static void AddShortIdService(this IServiceCollection services)
        {
            services.AddSingleton<ShortIdGenerator>();
        }
    }

    public class ShortIdGenerator
    {
        private readonly GenerationOptions _generationOptions;

        public ShortIdGenerator()
        {
            _generationOptions = new GenerationOptions
            {
                UseNumbers = true,
                UseSpecialCharacters = false,
                Length = 16
            };
        }

        public string GenerateNewShortId()
        {
            return ShortId.Generate(_generationOptions);
        }
    }
}