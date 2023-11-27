using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.Water
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
      public warehouse_lib.Model.Water Water { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Waters == null)
            {
                return NotFound();
            }

            var water = await _context.Waters.FirstOrDefaultAsync(m => m.Id == id);

            if (water == null)
            {
                return NotFound();
            }
            else 
            {
                Water = water;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Waters == null)
            {
                return NotFound();
            }
            var water = await _context.Waters.FindAsync(id);

            if (water != null)
            {
                Water = water;
                _context.Waters.Remove(Water);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
