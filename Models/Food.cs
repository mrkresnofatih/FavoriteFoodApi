using System.ComponentModel.DataAnnotations;

namespace FavoriteFoodApi.Models
{
    public class Food
    {
        public string Id { get; set; }
        public string FoodName { get; set; }
        public int Calories { get; set; }
        public bool IsSnack { get; set; }
    }

    public class FoodCreateUpdateDto
    {
        [Required]
        [StringLength(20)]
        public string FoodName { get; set; }
        
        [Required]
        [Range(50, 1000)]
        public int Calories { get; set; }
        
        [Required]
        public bool IsSnack { get; set; }
    }
}