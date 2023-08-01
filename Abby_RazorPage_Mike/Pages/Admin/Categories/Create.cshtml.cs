using Abby.Models;
using Abby.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.DataAccess.Repository.IRepository;
using Abby.DataAccess.Repository;

namespace Abby_RazorPage_Mike.Pages.Admin.Categories
{
    //The [BindProperties] attribute can be used on a PageModel class to
    //apply model binding to all public properties of the class.
    [BindProperties]
    public class CreateModel : PageModel
    {
        public Category Category { get; set; }
        //private readonly ApplicationDbContext _db;                     // No repository pattern
        //private readonly ICategoryRepository _categoriesRepository;    // Repository pattern
        private readonly IUnitOfWork _unitOfWork;                        // UnitOfWork pattern
        public CreateModel(/*ICategoryRepository categoryRepository*/IUnitOfWork unitOfWork)
        {
            //_categoriesRepository = categoryRepository;
            _unitOfWork = unitOfWork;
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
                //await _db.Category.AddAsync(Category);
                //await _db.SaveChangesAsync();
                //_categoriesRepository.Add(Category); // Using Repository let use decouple with DAL
                //_categoriesRepository.Save();        // Repository pattern
                _unitOfWork.Category.Add(Category);    // UnitOfWork pattern
                _unitOfWork.Save();                    // UnitOfWork pattern


                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
