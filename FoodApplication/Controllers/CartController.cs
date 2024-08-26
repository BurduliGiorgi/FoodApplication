using FoodApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodApplication.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult SaveCart(Cart cart)
        {
            return Ok();
        }
    }
}
