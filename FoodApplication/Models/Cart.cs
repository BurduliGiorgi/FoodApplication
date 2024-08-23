using System.ComponentModel.DataAnnotations;

namespace FoodApplication.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Image_url { get; set; }
        [Required]
        public string? Publisher { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? UserId { get; set; }

    }
}
