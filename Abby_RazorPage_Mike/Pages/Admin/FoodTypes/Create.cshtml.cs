using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_RazorPage_Mike.Pages.Admin.FoodTypes
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext? _context;
        [BindProperty]
        public FoodType FoodType { get; set; } //This property will be bind as Model
        public CreateModel(ApplicationDbContext? context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            // server-side validation
            if (ModelState.IsValid)
            {
                if (_context != null && FoodType != null)
                {
                    await _context.FoodType.AddAsync(FoodType);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "FoodType created successfully";
                    return RedirectToPage("Index");
                }
            }
            return Page();
        }
    }
}
