using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace warehouse_lib.Model
{
    public class Water
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name value is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name value should have between 3 and 50 characters")]
        public string Name { get; set; }

        public WaterType? Type { get; set; }
        public int? TypeId { get; set; }

        public Company? Producer { get; set; }
        public int? ProducerId { get; set; }

        [Range(5, 9, ErrorMessage = "pH value should be between 5 and 9.")]
        public decimal pH { get; set; } = 7.0m;

        public List<Cation>? Cations { get; set; }
        public List<Anion>? Anions { get; set; }

        [ReadOnly(true)]
        public string Mineralization
        {
            get
            {
                double cationsSum = Cations?.Sum(c => c.Content) ?? 0;
                double anionsSum = Anions?.Sum(a => a.Content) ?? 0;

                double mineralization = cationsSum + anionsSum;
                switch(mineralization)
                {
                    case double n when (n <= 0.05):
                        return "Very Low Mineralization";
                    case double n when (n <= 0.5):
                        return "Low Mineralization";
                    case double n when (n <= 1.5):
                        return "Medium Mineralization";
                    default:
                        return "High Mineralization";
                }
            }
        }

        public PackagingType? Packaging { get; set; }
        public int? PackagingId { get; set; }

        [Required(ErrorMessage = "Photo value is required.")]
        public string Photo { get; set; }

        public List<DeliveryDetails>? DeliveryDetails { get; set; } = null;
        public List<SaleDetails>? SaleDetails { get; set; } = null;
    }
}
