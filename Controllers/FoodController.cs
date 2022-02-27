using FavoriteFoodApi.Models;
using FavoriteFoodApi.Repositories;
using FavoriteFoodApi.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FavoriteFoodApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FoodController : ControllerBase
    {
        public FoodController(FoodRepository foodRepository, ILogger<FoodController> logger)
        {
            _foodRepository = foodRepository;
            _logger = logger;
        }

        private readonly FoodRepository _foodRepository;
        private readonly ILogger<FoodController> _logger;

        [HttpPost]
        public ResponsePayload<Food> SaveOne([FromBody] FoodCreateUpdateDto foodCreateUpdateDto)
        {
            _logger.LogInformation("API: SAVE-ONE");
            var res = _foodRepository.SaveOne(foodCreateUpdateDto);
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpGet("{foodId}")]
        public ResponsePayload<Food> GetOne(string foodId)
        {
            _logger.LogInformation("API: GET-ONE");
            var res = _foodRepository.GetOne(foodId);
            return ResponseHandler.WrapSuccess(res);
        }

        [HttpDelete("{foodId}")]
        public ResponsePayload<string> DeleteOne(string foodId)
        {
            _logger.LogInformation("API: DELETE-ONE");
            var res = _foodRepository.DeleteOne(foodId);
            return ResponseHandler.WrapSuccess(res);
        }
    }
}