using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_RazorPage_Mike.Pages.Admin.FoodTypes
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public FoodType? FoodType { get; set; }
        private readonly ApplicationDbContext? _context;
        public UpdateModel(ApplicationDbContext? context)
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
            if (_context != null && ModelState.IsValid && FoodType != null)
            {
                _context.FoodType.Update(FoodType);
                await _context.SaveChangesAsync();
                TempData["success"] = "FoodType updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
