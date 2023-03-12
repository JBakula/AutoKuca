using System.ComponentModel.DataAnnotations;

namespace AutoKucaFinal.Models
{
    public class FuelType
    {
        [Key]
        public int FuelTypeId { get; set; }
        [Required]
        public string FuelTypeName { get; set; } = "";
        public ICollection<Car> Cars { get; set; }
    }
}
