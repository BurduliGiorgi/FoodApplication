using FoodApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodApplication.ContextDBConfing
{
    public class FoodApplicationDBContext:IdentityDbContext<ApplicationUser>
    {
        public FoodApplicationDBContext(DbContextOptions<FoodApplicationDBContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Cart> Carts { get; set; }
    }
}
