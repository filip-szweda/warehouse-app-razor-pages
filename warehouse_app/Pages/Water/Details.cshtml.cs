using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.Water
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public DetailsModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public warehouse_lib.Model.Water Water { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Waters == null)
            {
                return NotFound();
            }

            var water = await _context.Waters.FirstOrDefaultAsync(m => m.Id == id);
            if (water == null)
            {
                return NotFound();
            }
            else 
            {
                Water = water;
            }
            return Page();
        }
    }
}
