using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using warehouse_app.Data;

namespace warehouse_app.Pages.SaleDetails
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
        ViewData["SaleId"] = new SelectList(_context.Sales, "Id", "Id");
        ViewData["WaterId"] = new SelectList(_context.Waters, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public warehouse_app.Data.SaleDetails SaleDetails { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SaleDetails == null || SaleDetails == null)
            {
                return Page();
            }

            _context.SaleDetails.Add(SaleDetails);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
