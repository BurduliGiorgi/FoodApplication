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
        public IActionResult Search([FromQuery] string recipe)
        {
            ViewBag.Recipe = recipe;
            return View();
        }

        public IActionResult Order([FromQuery] string id) 
        { 
            ViewBag.id = id;
            return View();
        
        
        
        }
        [HttpPost]
        public IActionResult ShowOrder(OrderRecipeDetails orderRecipeDetails)
        {
            Random random = new Random();
            ViewBag.Price = Math.Round(random.Next(150,500)/5.0)*5;
            return PartialView("_ShowOrder", orderRecipeDetails);
        }
    }
}
