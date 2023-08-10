using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_RazorPage_Mike.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        //private readonly AbbyDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public Category Category { get; set; }

        public DeleteModel(/*AbbyDbContext db*/ IUnitOfWork unitOfWork)
        {
            //_db = db;
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            // Category = _db.Category.Find(id);
            Category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id); // this approach is more powerful !
            //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
            //Category = _db.Category.SingleOrDefault(u=>u.Id==id);
            //Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            //var categoryFromDb = _db.Category.Find(Category.Id);
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Category.Id);
            if (categoryFromDb != null)
            {
                //_db.Category.Remove(categoryFromDb);
                //await _db.SaveChangesAsync();
                _unitOfWork.Category.Remove(categoryFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }

}