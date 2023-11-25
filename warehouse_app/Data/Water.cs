using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Concurrent;

namespace warehouse_app.Data
{
    public class Water
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name value is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name value should have between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type value is required.")]
        public WaterType Type { get; set; }
        public int TypeId { get { return Type.Id; } }

        public Company Producer { get; set; }
        public int ProducerId { get { return Producer.Id; } }

        [Range(5, 9, ErrorMessage = "pH value should be between 5 and 9.")]
        public decimal pH { get; set; } = 7.0m;

        public List<Ion> Cations { get; set; }
        public List<Ion> Anions { get; set; }

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

        public PackagingType Packaging { get; set; }
        public int PackagingId { get { return Packaging.Id; } }

        [Required(ErrorMessage = "Photo value is required.")]
        public string Photo { get; set; }

        public List<DeliveryDetails> DeliveryDetails { get; set;}
        public List<SaleDetails> SaleDetails { get; set; }
    }
}
