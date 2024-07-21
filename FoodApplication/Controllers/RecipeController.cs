using FoodApplication.Models;
using Microsoft.AspNetCore.Mvc;
using FoodApplication.Models;

namespace FoodApplication.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetRecipeCard([FromBody] List<Recipe> recipes)
        {
            return PartialView("_RecipeCard", recipes);
        }
    }
}
