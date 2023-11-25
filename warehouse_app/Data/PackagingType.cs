using System.ComponentModel.DataAnnotations;

namespace warehouse_app.Data
{
    public class PackagingType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Type value is required.")]
        public string Type { get; set; }

        [Range(0.25, double.MaxValue, ErrorMessage = "Capacity value should be at least 0.25 liters.")]
        public double Capacity { get; set; }
        public List<Water> Waters { get; set; }
    }
}
