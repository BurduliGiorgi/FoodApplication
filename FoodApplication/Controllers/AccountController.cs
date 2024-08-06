using Microsoft.AspNetCore.Mvc;

namespace FoodApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
