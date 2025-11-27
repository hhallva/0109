using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Pages
{
    public class IndexModel(AppDbContext context) : PageModel
    {
        private readonly AppDbContext _context = context;

        public string? UserRole { get; set; }
        public string? UserName { get; set; }
        public IList<Product> Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            UserRole = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(UserRole))
                return RedirectToPage("./Login");

            UserName = HttpContext.Session.GetString("UserName");

            Product = await _context.Products
               .Include(p => p.Manufacturer)
               .Include(p => p.Supplier).ToListAsync();
            return Page();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("./Login");
        }
    }
}
