using FoodApplication.Models;
using System.Security.Claims;

namespace FoodApplication.Repository
{
    public interface IData
    {
        Task<ApplicationUser> GetUser(ClaimsPrincipal claims);
    }
}
