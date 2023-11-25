using System.ComponentModel.DataAnnotations;

namespace warehouse_app.Data
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name value is required.")]
        public string Name { get; set; }

        public List<Sale>? Sales { get; set; }
        public List<Delivery>? Deliveries { get; set; }
    }
}
