using System;
using System.Collections.Generic;
using System.Text;

namespace warehouse_lib.DTO
{
    public class BuyWater
    {
        public string Customer { get; set; } = default!;
        public List<BuyWaterDetails> BuyWaterDetails { get; set; } = default!;
    }
}
