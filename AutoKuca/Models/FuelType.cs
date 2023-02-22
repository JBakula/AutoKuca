using System.ComponentModel.DataAnnotations;

namespace AutoKuca.Models
{
    public class FuelType
    {
        public int FuelTypeId { get;set; }
        [Required]
        public string FuelTypeName { get; set; } = "";

        public ICollection<Car> Car { get; set; }
    }
}
