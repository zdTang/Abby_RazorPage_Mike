using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_RazorPage_Mike.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        //private readonly ApplicationDbContext _db;
        // The benefit of using Repository is seperation of concerns.
        // We will not deal with DAL by accessing dbContext directly and repeatedly.
        // All necessary operations with dbContext are wrapped and recreated in the Repository
        // For PageModel, what it need do is just Inject the Repository and use the relevant method.
        // PageModel will not access dbContext any more.
        public IEnumerable<Category> Categories { get; set; }
        private readonly ICategoryRepository _categoriesRepository;
        public IndexModel(ICategoryRepository categoryRepository)
        {
            _categoriesRepository = categoryRepository;
        }
        public void OnGet()
        {
            //Categories = _db.Category;
            Categories = _categoriesRepository.GetAll();
        }
    }
}
