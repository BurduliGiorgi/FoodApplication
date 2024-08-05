using System.ComponentModel.DataAnnotations;

namespace FoodApplication.Models
{
    public class LoginViewModel
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
