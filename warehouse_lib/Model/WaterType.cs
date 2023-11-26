using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace warehouse_lib.Model
{
    public class WaterType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Type value is required.")]
        public string Type { get; set; }
        public List<Water>? Waters { get; set; }
    }
}
