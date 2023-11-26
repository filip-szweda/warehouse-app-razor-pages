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
    public class DetailsModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public DetailsModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public warehouse_lib.Model.PackagingType PackagingType { get; set; } = default!; 

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
    }
}
