using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.PackagingType
{
    public class DeleteModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public DeleteModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public warehouse_app.Data.PackagingType PackagingType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PackagingTypes == null)
            {
                return NotFound();
            }

            var packagingtype = await _context.PackagingTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (packagingtype == null)
            {
                return NotFound();
            }
            else 
            {
                PackagingType = packagingtype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PackagingTypes == null)
            {
                return NotFound();
            }
            var packagingtype = await _context.PackagingTypes.FindAsync(id);

            if (packagingtype != null)
            {
                PackagingType = packagingtype;
                _context.PackagingTypes.Remove(PackagingType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
