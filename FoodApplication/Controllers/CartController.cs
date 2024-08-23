using Microsoft.AspNetCore.Mvc;

namespace FoodApplication.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
