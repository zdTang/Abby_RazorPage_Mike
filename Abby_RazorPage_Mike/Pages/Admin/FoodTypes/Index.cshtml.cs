using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_RazorPage_Mike.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        //private readonly AbbyDbContext? _db;
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<FoodType>? FoodTypes { get; set; }
        public IndexModel(/*AbbyDbContext? db*/ IUnitOfWork unitOfWork)
        {
            // _db = db;
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            //if (_db != null)
            // FoodTypes = _db.FoodType;
            FoodTypes = _unitOfWork.FoodType.GetAll();
        }
    }
}
