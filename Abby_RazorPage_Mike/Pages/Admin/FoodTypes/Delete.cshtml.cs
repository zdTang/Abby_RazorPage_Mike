using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Abby_RazorPage_Mike.Pages.Admin.FoodTypes
{
    public class DeleteModel : PageModel
    {
        //private readonly AbbyDbContext? _context;
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public FoodType? FoodType { get; set; }
        public DeleteModel(/*AbbyDbContext context*/ IUnitOfWork unitOfWork)
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
            if (id != 0)
            {
                //FoodType = await _context.FoodType.FindAsync(id);
                FoodType = _unitOfWork.FoodType.GetFirstOrDefault(x => x.Id == id);
            }
            return Page();
        }

        //public async Task<IActionResult> OnPost()
        public IActionResult OnPost()
        {
            //if (_context != null && FoodType != null)
            //{
            //    _context.FoodType.Remove(FoodType);
            //    await _context.SaveChangesAsync();
            //    TempData["success"] = "FoodType updated successfully";
            //    return RedirectToPage("Index");
            //}

            if (FoodType != null)
            {
                _unitOfWork.FoodType.Remove(FoodType);
                _unitOfWork.Save();
                TempData["success"] = "FoodType updated successfully";
                return RedirectToPage("Index");
            }
            TempData["error"] = "Cannot delete item due to error!";
            return Page();
        }



    }
}
