using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Pages
{
    public class LoginModel(AppDbContext context) : PageModel
    {
        private readonly AppDbContext _context = context;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public new User User { get; set; } = default!;

        public async Task<IActionResult> OnPostLoginAsync()
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == User.Login);

            if (user is not null && user.Password == User.Password)
            {

            }

            return RedirectToPage("./Products");
        }
    }
}
