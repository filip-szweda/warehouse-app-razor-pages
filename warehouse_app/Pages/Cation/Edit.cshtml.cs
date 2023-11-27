using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.Cation
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public EditModel(warehouse_app.Data.ApplicationDbContext context)
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

            var cation =  await _context.Cation.FirstOrDefaultAsync(m => m.Id == id);
            if (cation == null)
            {
                return NotFound();
            }
            Cation = cation;
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

            _context.Attach(Cation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CationExists(Cation.Id))
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

        private bool CationExists(int id)
        {
          return (_context.Cation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
