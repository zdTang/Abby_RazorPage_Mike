using Abby.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Abby_RazorPage_Mike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemTwoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        //public IEnumerable<MenuItem>? MenuItem { get; set; } // we will not use it as model any more, so comment it
        public MenuItemTwoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var menuItemList = _unitOfWork.MenuItem.GetAll();
            return Ok(new { data = menuItemList });
        }
    }
}
