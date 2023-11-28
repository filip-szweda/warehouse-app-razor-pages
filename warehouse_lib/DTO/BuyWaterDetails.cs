using System;
using System.Collections.Generic;
using System.Text;

namespace warehouse_lib.DTO
{
    public class BuyWaterDetails
    {
        public string Name { get; set; } = default!;
        public int Quantity { get; set; }
        public string Type { get; set; } = default!;
    }
}
