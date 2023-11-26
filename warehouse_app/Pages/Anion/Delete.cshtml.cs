using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.Anion
{
    public class DeleteModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public DeleteModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public warehouse_lib.Model.Anion Anion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Anion == null)
            {
                return NotFound();
            }

            var anion = await _context.Anion.FirstOrDefaultAsync(m => m.Id == id);

            if (anion == null)
            {
                return NotFound();
            }
            else 
            {
                Anion = anion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Anion == null)
            {
                return NotFound();
            }
            var anion = await _context.Anion.FindAsync(id);

            if (anion != null)
            {
                Anion = anion;
                _context.Anion.Remove(Anion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
