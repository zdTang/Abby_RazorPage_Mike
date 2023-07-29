using Abby.Models;
using Microsoft.EntityFrameworkCore;

namespace Abby_RazorPage_Mike.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
    }
}
