using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.WaterType
{
    public class DeleteModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public DeleteModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public warehouse_app.Data.WaterType WaterType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.WaterTypes == null)
            {
                return NotFound();
            }

            var watertype = await _context.WaterTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (watertype == null)
            {
                return NotFound();
            }
            else 
            {
                WaterType = watertype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.WaterTypes == null)
            {
                return NotFound();
            }
            var watertype = await _context.WaterTypes.FindAsync(id);

            if (watertype != null)
            {
                WaterType = watertype;
                _context.WaterTypes.Remove(WaterType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
