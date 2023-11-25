using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using warehouse_app.Data;

namespace warehouse_app.Pages.DeliveryDetails
{
    public class CreateModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public CreateModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeliveryId"] = new SelectList(_context.Deliveries, "Id", "Id");
        ViewData["WaterId"] = new SelectList(_context.Waters, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public warehouse_app.Data.DeliveryDetails DeliveryDetails { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.DeliveryDetails == null || DeliveryDetails == null)
            {
                return Page();
            }

            _context.DeliveryDetails.Add(DeliveryDetails);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
