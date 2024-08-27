using FoodApplication.ContextDBConfing;
using FoodApplication.Models;
using FoodApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodApplication.Controllers
{
    public class CartController : Controller
    {
        private readonly IData data;
        private readonly FoodApplicationDBContext context;

        public CartController(IData data,FoodApplicationDBContext context)
        {
            this.data = data;
            this.context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> SaveCart(Cart cart)
        {
            var user = await data.GetUser(HttpContext.User);
            cart.UserId = user?.Id;
            if (ModelState.IsValid)
            {
                context.Carts.Add(cart);
                context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAddedCarts()
        {
            var user = await data.GetUser(HttpContext.User);
            var carts = context.Carts.Where(c => c.UserId == user.Id).Select(c => c.RecipeId).ToList();
            return Ok(carts);
        }

        [HttpPost]
        public IActionResult RemoveCartFromList(string Id)
        {
            if(!string.IsNullOrEmpty(Id))
            {

                var cart = context.Carts.Where(c => c.RecipeId == Id).FirstOrDefault();
                if (cart != null)
                {
                    context.Carts.Remove(cart);
                    context.SaveChanges();
                    return Ok();
                }
            }
            return BadRequest();
        }



        [HttpGet]
        public async Task<IActionResult> GetCartList()
        {
            var user = await data.GetUser(HttpContext.User);
            var cartList = context.Carts.Where(c => c.UserId == user.Id).ToList();
            return View();
        }
    }
}
