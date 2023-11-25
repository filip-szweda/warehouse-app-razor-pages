using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.Ion
{
    public class DeleteModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public DeleteModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public warehouse_app.Data.Ion Ion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ions == null)
            {
                return NotFound();
            }

            var ion = await _context.Ions.FirstOrDefaultAsync(m => m.Id == id);

            if (ion == null)
            {
                return NotFound();
            }
            else 
            {
                Ion = ion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ions == null)
            {
                return NotFound();
            }
            var ion = await _context.Ions.FindAsync(id);

            if (ion != null)
            {
                Ion = ion;
                _context.Ions.Remove(Ion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
