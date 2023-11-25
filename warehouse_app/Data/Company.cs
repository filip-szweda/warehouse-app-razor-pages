using System.ComponentModel.DataAnnotations;

namespace warehouse_app.Data
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name value is required.")]
        public string Name { get; set; }

        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Phone number value is invalid.")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Email address is invalid.")]
        public string Email { get; set; }

        public List<Delivery> Deliveries { get; set; }
        
        public List<Water> Waters { get; set; }
    }
}
