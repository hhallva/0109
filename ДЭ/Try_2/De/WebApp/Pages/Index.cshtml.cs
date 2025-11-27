using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public string? UserRole { get; set; }
        public string? UserName { get; set; }

        public IActionResult OnGet()
        {
            UserRole = HttpContext.Session.GetString("UserRole");

            if(string.IsNullOrEmpty(UserRole))
                return RedirectToPage("./Login");

            UserName = HttpContext.Session.GetString("UserName");
            return Page();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("./Login");
        }
    }
}
