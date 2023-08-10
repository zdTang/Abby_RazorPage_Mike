using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_RazorPage_Mike.Pages.Admin.Categories
{
    //The [BindProperties] attribute can be used on a PageModel class to
    //apply model binding to all public properties of the class.
    [BindProperties]
    public class EditModel : PageModel
    {
        public Category? Category { get; set; }    // This is Model, the Razor content Page will use it to retrieve data
        //private readonly AbbyDbContext _db; // No pattern
        private readonly IUnitOfWork _unitOfWork;    // UnitOfWork Pattern
        public EditModel(/*AbbyDbContext db*/IUnitOfWork unitOfWork)
        {
            //_db = db;                  // No pattern, access DbContext directly
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            // Here we can get the Id of the Category which need to be edited.
            // we will use this id to retrieve data from database and send to front end.
            // Category = _db.Category.Find(id);
            Category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
            //Category = _db.Category.SingleOrDefault(u=>u.Id==id);
            //Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
        }
        // Notice, the coming Category object is not used as a parameter
        // But as a public property of this Model
        // What if we have serveral public properties, how to do model binding
        public IActionResult OnPost()
        {
            if (Category?.Name == Category?.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                // _db.Category.Update(Category);
                // await _db.SaveChangesAsync();
                _unitOfWork.Category.Update(Category!);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
