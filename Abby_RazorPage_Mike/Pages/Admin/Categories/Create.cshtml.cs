using Abby.Models;
using Abby.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Abby_RazorPage_Mike.Pages.Admin.Categories
{
    //The [BindProperties] attribute can be used on a PageModel class to
    //apply model binding to all public properties of the class.
    [BindProperties]
    public class CreateModel : PageModel
    {
        public Category Category { get; set; }
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        // Notice, the coming Category object is not used as a parameter
        // But as a public property of this Model
        // What if we have serveral public properties, how to do model binding
        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}