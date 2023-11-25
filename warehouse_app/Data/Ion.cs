using System.ComponentModel.DataAnnotations;

namespace warehouse_app.Data
{
    public class Ion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name value is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Symbol value is required.")]
        public string Symbol { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Content value should be at least 0.")]
        public double Content { get; set; }
    }
}
