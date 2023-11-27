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

namespace warehouse_app.Pages.SaleDetails
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
        public warehouse_lib.Model.SaleDetails SaleDetails { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SaleDetails == null)
            {
                return NotFound();
            }

            var saledetails =  await _context.SaleDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (saledetails == null)
            {
                return NotFound();
            }
            SaleDetails = saledetails;
           ViewData["SaleId"] = new SelectList(_context.Sales, "Id", "Id");
           ViewData["WaterId"] = new SelectList(_context.Waters, "Id", "Name");
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

            _context.Attach(SaleDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleDetailsExists(SaleDetails.Id))
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

        private bool SaleDetailsExists(int id)
        {
          return (_context.SaleDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
