using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.DeliveryDetails
{
    public class EditModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public EditModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public warehouse_lib.Model.DeliveryDetails DeliveryDetails { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DeliveryDetails == null)
            {
                return NotFound();
            }

            var deliverydetails =  await _context.DeliveryDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (deliverydetails == null)
            {
                return NotFound();
            }
            DeliveryDetails = deliverydetails;
           ViewData["DeliveryId"] = new SelectList(_context.Deliveries, "Id", "Id");
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

            _context.Attach(DeliveryDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryDetailsExists(DeliveryDetails.Id))
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

        private bool DeliveryDetailsExists(int id)
        {
          return (_context.DeliveryDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
