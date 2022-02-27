using System;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace FavoriteFoodApi.Configurations
{
    public static class RedisConfig
    {
        private static ConnectionMultiplexer CreateConnectionMultiplexer()
        {
            var redisPort = Environment.GetEnvironmentVariable("FavoriteFoodApiRedisPort");
            var redisHost = Environment.GetEnvironmentVariable("FavoriteFoodApiRedisHost");
            var connectionString = $"{redisHost}:{redisPort},abortConnect=false";
            return ConnectionMultiplexer.Connect(connectionString);
        }

        public static void AddRedisService(this IServiceCollection services)
        {
            var redis = CreateConnectionMultiplexer();
            services.AddSingleton(redis.GetDatabase());
        }
    }
}