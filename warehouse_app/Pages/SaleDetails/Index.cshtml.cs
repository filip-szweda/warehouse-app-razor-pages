using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.SaleDetails
{
    public class IndexModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public IndexModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<warehouse_lib.Model.SaleDetails> SaleDetails { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SaleDetails != null)
            {
                SaleDetails = await _context.SaleDetails
                .Include(s => s.Sale)
                .Include(s => s.Water).ToListAsync();
            }
        }
    }
}
