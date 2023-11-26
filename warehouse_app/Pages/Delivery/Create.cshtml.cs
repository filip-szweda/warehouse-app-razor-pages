using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using warehouse_app.Data;

namespace warehouse_app.Pages.Delivery
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
        ViewData["SupplierId"] = new SelectList(_context.Companies, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public warehouse_lib.Model.Delivery Delivery { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Deliveries == null || Delivery == null)
            {
                return Page();
            }

            _context.Deliveries.Add(Delivery);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
