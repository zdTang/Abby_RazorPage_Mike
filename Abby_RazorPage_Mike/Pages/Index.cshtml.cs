using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_RazorPage_Mike.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            // At first, the empty OnGet() points to the default Main page (the index.cshtml of the Pages folder), but we want it to point to our desired page
            return RedirectToPage("Customer/Home/Index");
        }
    }
}