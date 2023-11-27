using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.Cation
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public DeleteModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public warehouse_lib.Model.Cation Cation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cation == null)
            {
                return NotFound();
            }

            var cation = await _context.Cation.FirstOrDefaultAsync(m => m.Id == id);

            if (cation == null)
            {
                return NotFound();
            }
            else 
            {
                Cation = cation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cation == null)
            {
                return NotFound();
            }
            var cation = await _context.Cation.FindAsync(id);

            if (cation != null)
            {
                Cation = cation;
                _context.Cation.Remove(Cation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
