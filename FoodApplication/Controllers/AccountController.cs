using Microsoft.AspNetCore.Mvc;

namespace FoodApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
