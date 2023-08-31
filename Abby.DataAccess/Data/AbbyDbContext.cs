using Abby.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Abby.DataAccess.Data
{
    public class AbbyDbContext : IdentityDbContext
    {
        public AbbyDbContext(DbContextOptions<AbbyDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; } // This table derived IdentityUser class
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
    }
}
