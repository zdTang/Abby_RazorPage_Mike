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
            // will not pass Model to Razer from here.
            // will use Client side render.
            // the browser will call Web API to pull MenuItem
        }
    }


}
