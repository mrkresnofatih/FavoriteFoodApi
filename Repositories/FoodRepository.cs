using System;
using AutoMapper;
using FavoriteFoodApi.Configurations;
using FavoriteFoodApi.Constants.CustomExceptions;
using FavoriteFoodApi.Models;
using FavoriteFoodApi.Templates;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace FavoriteFoodApi.Repositories
{
    public class FoodRepository : RedisTemplate<Food>
    {
        public FoodRepository(IDatabase redisDb, 
            IMapper mapper, 
            ILogger<FoodRepository> logger,
            ShortIdGenerator shortIdGenerator) : base(redisDb)
        {
            _shortIdGenerator = shortIdGenerator;
            _mapper = mapper;
            _logger = logger;
        }

        private readonly IMapper _mapper;
        private readonly ILogger<FoodRepository> _logger;
        private readonly ShortIdGenerator _shortIdGenerator;

        public Food SaveOne(FoodCreateUpdateDto foodCreateUpdateDto)
        {
            var newId = _shortIdGenerator.GenerateNewShortId();
            var newFood = _mapper.Map<Food>(foodCreateUpdateDto);
            newFood.Id = newId;
            SaveById(newId, newFood);
            return newFood;
        }

        public Food GetOne(string foodId)
        {
            var foundFood = GetById(foodId);
            if (foundFood == null)
            {
                _logger.LogInformation($"Food by {foodId} not found! Will throw error!");
                throw new BadRequestException();
            }
            return foundFood;
        }

        public string DeleteOne(string foodId)
        {
            GetOne(foodId);
            DeleteById(foodId);
            return foodId;
        }

        protected override string GetPrefix()
        {
            return "sCtXLr8B9XmgwSKAEhx4pLNAqZVDQT1WVQc8eRFG";
        }

        protected override TimeSpan GetLifeTime()
        {
            return TimeSpan.FromDays(1);
        }
    }
}