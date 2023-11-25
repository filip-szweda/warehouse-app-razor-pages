﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using warehouse_app.Data;

namespace warehouse_app.Pages.DeliveryDetails
{
    public class IndexModel : PageModel
    {
        private readonly warehouse_app.Data.ApplicationDbContext _context;

        public IndexModel(warehouse_app.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<warehouse_app.Data.DeliveryDetails> DeliveryDetails { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DeliveryDetails != null)
            {
                DeliveryDetails = await _context.DeliveryDetails
                .Include(d => d.Delivery)
                .Include(d => d.Water).ToListAsync();
            }
        }
    }
}
