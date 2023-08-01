using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Abby_RazorPage_Mike.Pages.Admin.FoodTypes
{
    public class CreateModel : PageModel
    {
        //private readonly ApplicationDbContext? _context;
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public FoodType FoodType { get; set; } //This property will be bind as Model
        public CreateModel(/*ApplicationDbContext? context*/ IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // server-side validation
            if (ModelState.IsValid)
            {
                //if (_context != null && FoodType != null)
                //{
                //    await _context.FoodType.AddAsync(FoodType);
                //    await _context.SaveChangesAsync();
                //    TempData["success"] = "FoodType created successfully";
                //    return RedirectToPage("Index");
                //}

                _unitOfWork.FoodType.Add(FoodType);
                _unitOfWork.Save();
                TempData["success"] = "FoodType created successfully";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
