using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.Water
{
    public class IndexModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public IndexModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<warehouse_app.Data.Water> Water { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Waters != null)
            {
                Water = await _context.Waters
                .Include(w => w.Packaging)
                .Include(w => w.Producer)
                .Include(w => w.Type).ToListAsync();
            }
        }
    }
}
