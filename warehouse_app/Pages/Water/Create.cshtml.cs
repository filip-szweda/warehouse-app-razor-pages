using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using warehouse_app.Data;

namespace warehouse_app.Pages.Water
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public CreateModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PackagingId"] = new SelectList(_context.PackagingTypes, "Id", "Type");
        ViewData["ProducerId"] = new SelectList(_context.Companies, "Id", "Name");
        ViewData["TypeId"] = new SelectList(_context.WaterTypes, "Id", "Type");
            return Page();
        }

        [BindProperty]
        public warehouse_lib.Model.Water Water { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Waters == null || Water == null)
            {
                return Page();
            }

            _context.Waters.Add(Water);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
