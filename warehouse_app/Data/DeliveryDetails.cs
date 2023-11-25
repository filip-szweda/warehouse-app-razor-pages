using System.ComponentModel.DataAnnotations;

namespace warehouse_app.Data
{
    public class DeliveryDetails
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The number of pallets field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of pallets should be greater than 0.")]
        public int NumberOfPallets { get; set; }

        [Required(ErrorMessage = "The number of bottles per pallet field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of bottles per pallet should be greater than 0.")]
        public int BottlesPerPallet { get; set; }
        
        public Water Water { get; set; }
        public int WaterId { get; set; }

        public Delivery Delivery { get; set; }
        public int DeliveryId { get; set; }
    }
}
