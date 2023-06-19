using Abby_RazorPage_Mike.Model;
using Microsoft.EntityFrameworkCore;

namespace Abby_RazorPage_Mike.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
    }
}
