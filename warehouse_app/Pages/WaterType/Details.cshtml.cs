using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.WaterType
{
    public class DetailsModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public DetailsModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public warehouse_lib.Model.WaterType WaterType { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.WaterTypes == null)
            {
                return NotFound();
            }

            var watertype = await _context.WaterTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (watertype == null)
            {
                return NotFound();
            }
            else 
            {
                WaterType = watertype;
            }
            return Page();
        }
    }
}
