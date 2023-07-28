using Abby_RazorPage_Mike.Data;
using Abby_RazorPage_Mike.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_RazorPage_Mike.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category? Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Category = _db.Category.Find(id);
            _db.Category.Remove(Category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
