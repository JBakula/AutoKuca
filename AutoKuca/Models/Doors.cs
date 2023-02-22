using System.ComponentModel.DataAnnotations;

namespace AutoKuca.Models
{
    public class Doors
    {
        public int DoorsId { get; set; }
        [Required]
        public string Value { get; set; } = "";

        public ICollection<Car> Car { get; set; }
    }
}
