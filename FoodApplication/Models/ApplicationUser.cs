using Microsoft.AspNetCore.Identity;

namespace FoodApplication.Models
{
    public class ApplicationUser:IdentityUser
    {


        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
