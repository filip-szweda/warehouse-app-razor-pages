using System.ComponentModel.DataAnnotations;

namespace warehouse_app.Data
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee value is required.")]
        public Person Employee { get; set; }
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Supplier value is required.")]
        public Company Supplier { get; set; }
        public int SupplierId { get; set; }

        public DateTime DeliveryDate { get; set; }

        public List<DeliveryDetails>? DeliveryDetails { get; set; }
    }
}
