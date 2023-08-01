using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Abby_RazorPage_Mike.Pages.Admin.FoodTypes
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public FoodType? FoodType { get; set; }
        //private readonly ApplicationDbContext? _context;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateModel(/*ApplicationDbContext? context*/ IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            //if (id != 0 && _context != null)
            //{
            //    FoodType = await _context.FoodType.FindAsync(id);
            //}
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
            return Page();
        }
        //public async Task<IActionResult> OnPost()
        public IActionResult OnPost()
        {

            //if (_context != null && ModelState.IsValid && FoodType != null)
            //{
            //    _context.FoodType.Update(FoodType);
            //    await _context.SaveChangesAsync();
            //    TempData["success"] = "FoodType updated successfully";
            //    return RedirectToPage("Index");
            //}
            if (ModelState.IsValid && FoodType != null)
            {
                _unitOfWork.FoodType.Update(FoodType);
                _unitOfWork.Save();
                TempData["success"] = "FoodType updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
