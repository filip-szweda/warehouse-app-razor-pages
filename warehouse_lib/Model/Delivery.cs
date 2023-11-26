using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace warehouse_lib.Model
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee value is required.")]
        public string Employee { get; set; }

        public Company? Supplier { get; set; }
        public int? SupplierId { get; set; }

        public DateTime DeliveryDate { get; set; }

        public List<DeliveryDetails>? DeliveryDetails { get; set; } = null;
    }
}
