using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.Ion
{
    public class EditModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public EditModel(warehouse_app.Data.ApplicationDbContext context)
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

            var ion =  await _context.Ions.FirstOrDefaultAsync(m => m.Id == id);
            if (ion == null)
            {
                return NotFound();
            }
            Ion = ion;
           ViewData["AnionWaterId"] = new SelectList(_context.Waters, "Id", "Name");
           ViewData["CationWaterId"] = new SelectList(_context.Waters, "Id", "Name");
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

            _context.Attach(Ion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IonExists(Ion.Id))
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

        private bool IonExists(int id)
        {
          return (_context.Ions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
