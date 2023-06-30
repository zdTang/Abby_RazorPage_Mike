using Abby_RazorPage_Mike.Data;
using Abby_RazorPage_Mike.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_RazorPage_Mike.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Categories = _db.Category;
        }
    }
}