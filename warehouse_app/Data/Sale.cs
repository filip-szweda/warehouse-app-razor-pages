using System.ComponentModel.DataAnnotations;

namespace warehouse_app.Data
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer value is required.")]
        public Person Customer { get; set; }
        public int CustomerId { get; set; }

        public DateTime SaleDate { get; set; }

        public List<SaleDetails>? SaleDetails { get; set; }
    }
}
