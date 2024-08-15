using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.X509Certificates;

namespace FoodApplication.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Name { get; set; }  

        public string? Address {  get; set; }   
    }
}
