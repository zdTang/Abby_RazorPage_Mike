using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abby_RazorPage_Mike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //public IEnumerable<MenuItem>? MenuItem { get; set; } // we will not use it as model any more, so comment it
        public MenuItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var menuItemList = _unitOfWork.MenuItem.GetAll();
            return Json(new { data = menuItemList });
        }
    }
}
