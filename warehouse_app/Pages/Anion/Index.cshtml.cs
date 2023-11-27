using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.Anion
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public IndexModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<warehouse_lib.Model.Anion> Anion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Anion != null)
            {
                Anion = await _context.Anion
                .Include(a => a.AnionWater).ToListAsync();
            }
        }
    }
}
