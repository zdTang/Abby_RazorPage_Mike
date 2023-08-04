using Abby.Models;
using Abby.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.DataAccess.Repository.IRepository;
using Abby.DataAccess.Repository;

namespace Abby_RazorPage_Mike.Pages.Admin.MenuItems
{
    //The [BindProperties] attribute can be used on a PageModel class to
    //apply model binding to all public properties of the class.
    [BindProperties]
    public class UpsertModel : PageModel
    {
        // if we don't instantiate a new object, this menuItem will be Null
        // and we cannot check its Id at all.
        // for an new object, all its properties are null, but as the Id is integer,
        // it will be parse as 0.
        public MenuItem menuItem { get; set; } = new MenuItem();
        private readonly IUnitOfWork _unitOfWork;                        // UnitOfWork pattern
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MenuItem.Add(menuItem!);    // UnitOfWork pattern
                _unitOfWork.Save();                    // UnitOfWork pattern
                TempData["success"] = "MenuItem created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
