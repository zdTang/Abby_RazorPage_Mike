using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_RazorPage_Mike.Pages.Admin.FoodTypes
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext? _context;
        [BindProperty]
        public FoodType? FoodType { get; set; }
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            if (id != 0 && _context != null)
            {
                FoodType = await _context.FoodType.FindAsync(id);
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (_context != null && FoodType != null)
            {
                _context.FoodType.Remove(FoodType);
                await _context.SaveChangesAsync();
                TempData["success"] = "FoodType updated successfully";
                return RedirectToPage("Index");
            }
            TempData["error"] = "Cannot delete item due to error!";
            return Page();
        }



    }
}
