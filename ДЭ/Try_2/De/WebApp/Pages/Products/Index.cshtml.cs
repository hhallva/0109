using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Context;

namespace WebApp.Pages.Products
{
    public class IndexModel(AppDbContext context) : PageModel
    {
        private readonly AppDbContext _context = context;

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Supplier).ToListAsync();
        }
    }
}
