using System.ComponentModel.DataAnnotations;

namespace warehouse_app.Data
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer value is required.")]
        public string Customer { get; set; }

        public DateTime SaleDate { get; set; }

        public List<SaleDetails>? SaleDetails { get; set; }
    }
}
