using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_RazorPage_Mike.Pages.Admin.MenuItems
{
    public class IndexModel : PageModel
    {

        private readonly IUnitOfWork? _unitOfWork;
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            MenuItems = _unitOfWork.MenuItem.GetAll();
        }
    }


}
