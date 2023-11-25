using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.WaterType
{
    public class EditModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public EditModel(warehouse_app.Data.ApplicationDbContext context)
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

            var watertype =  await _context.WaterTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (watertype == null)
            {
                return NotFound();
            }
            WaterType = watertype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WaterType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterTypeExists(WaterType.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WaterTypeExists(int id)
        {
          return (_context.WaterTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
