using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_RazorPage_Mike.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext? _db;
        public IEnumerable<FoodType>? FoodTypes { get; set; }
        public IndexModel(ApplicationDbContext? db)
        {
            _db = db;
        }

        public void OnGet()
        {
            if (_db != null)
                FoodTypes = _db.FoodType;
        }
    }
}
