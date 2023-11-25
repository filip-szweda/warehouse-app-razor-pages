﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.SaleDetails
{
    public class DeleteModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public DeleteModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public warehouse_app.Data.SaleDetails SaleDetails { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SaleDetails == null)
            {
                return NotFound();
            }

            var saledetails = await _context.SaleDetails.FirstOrDefaultAsync(m => m.Id == id);

            if (saledetails == null)
            {
                return NotFound();
            }
            else 
            {
                SaleDetails = saledetails;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SaleDetails == null)
            {
                return NotFound();
            }
            var saledetails = await _context.SaleDetails.FindAsync(id);

            if (saledetails != null)
            {
                SaleDetails = saledetails;
                _context.SaleDetails.Remove(SaleDetails);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
