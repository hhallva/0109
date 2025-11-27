using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Login);

            if (user is not null && user.Password == User.Password)
            {
                HttpContext.Session.SetString("UserRole", user.Role);
                HttpContext.Session.SetString("UserName", user.FullName);
                //return RedirectToPage("../Index");
            }

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostGuest()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("UserRole", "Гость");
            return RedirectToPage("./Index");
        }

       
    }
}
