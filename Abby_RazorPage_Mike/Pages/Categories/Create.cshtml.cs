using Abby_RazorPage_Mike.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_RazorPage_Mike.Pages.Categories
{
    public class CreateModel : PageModel
    {
        public Category Category { get; set; }
        public void OnGet()
        {

        }
    }
}
