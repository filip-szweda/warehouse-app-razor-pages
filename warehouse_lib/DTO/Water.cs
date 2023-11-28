using System;
using System.Collections.Generic;
using System.Text;

namespace warehouse_lib.DTO
{
    public class Water
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public int TypeId { get; set; } = default!;

        public int ProducerId { get; set; } = default!;

        public decimal pH { get; set; }
        public List<int> CationsIds { get; set; } = default!;

        public List<int> AnionsIds { get; set; } = default!;

        public string Mineralization { get; set; } = default!;

        public int PackagingTypeId { get; set; } = default!;

        public List<int> DeliveryDetailsIds { get; set; } = default!;

        public List<int> SaleDetailsIds { get; set; } = default!;
    }
}
