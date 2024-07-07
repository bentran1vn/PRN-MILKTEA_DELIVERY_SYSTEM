using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    [Authorize]
    public class AdminHomeModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
