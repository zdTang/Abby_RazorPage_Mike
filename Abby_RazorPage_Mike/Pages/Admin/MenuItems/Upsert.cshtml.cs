using Abby.Models;
using Abby.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.DataAccess.Repository.IRepository;
using Abby.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public MenuItem MenuItem { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }    // Used for UI to draw dropdown list 
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }    // Used for UI to draw dropdown list
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;           // Provide information about Hosting Environment
        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            MenuItem = new MenuItem();
            _hostEnvironment = hostEnvironment;
        }
        public void OnGet()
        {
            // Using projecting -- Select
            CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            FoodTypeList = _unitOfWork.FoodType.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
        }
        public IActionResult OnPost()
        {
            //if (ModelState.IsValid)
            //{
            //    _unitOfWork.MenuItem.Add(MenuItem);    // UnitOfWork pattern
            //    _unitOfWork.Save();                    // UnitOfWork pattern
            //    TempData["success"] = "MenuItem created successfully";
            //    return RedirectToPage("Index");
            //}
            //return Page();
            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;                         // File collection send with the request
            if (MenuItem.Id == 0)
            {
                // == Create a new MenuItem ==

                var fileName_new = Guid.NewGuid().ToString();                    // Create a global unique identifier
                var uploadPath = Path.Combine(webRootPath, @"images\menuItems");
                var uploadFileExtension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploadPath, fileName_new + uploadFileExtension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                MenuItem.Image = @"\images\menuItems\" + fileName_new + uploadFileExtension;
                _unitOfWork.MenuItem.Add(MenuItem);
                _unitOfWork.Save();
            }
            else
            {
                // == Edit an existed MenuItem ==
            }
            return RedirectToPage("Index");
        }
    }
}