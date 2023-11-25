using System.ComponentModel.DataAnnotations;

namespace warehouse_app.Data
{
    public class SaleDetails
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Number of bottles value is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of bottles value should be at least 1.")]
        public int NumberOfBottles { get; set; }

        public Water Water { get; set; }
        public int WaterId { get; set; }

        public Sale Sale { get; set; }
        public int SaleId { get; set; }
    }
}
