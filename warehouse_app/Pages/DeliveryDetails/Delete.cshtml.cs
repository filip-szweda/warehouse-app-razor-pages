using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.DeliveryDetails
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
      public warehouse_lib.Model.DeliveryDetails DeliveryDetails { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DeliveryDetails == null)
            {
                return NotFound();
            }

            var deliverydetails = await _context.DeliveryDetails.FirstOrDefaultAsync(m => m.Id == id);

            if (deliverydetails == null)
            {
                return NotFound();
            }
            else 
            {
                DeliveryDetails = deliverydetails;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.DeliveryDetails == null)
            {
                return NotFound();
            }
            var deliverydetails = await _context.DeliveryDetails.FindAsync(id);

            if (deliverydetails != null)
            {
                DeliveryDetails = deliverydetails;
                _context.DeliveryDetails.Remove(DeliveryDetails);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
