using System.ComponentModel.DataAnnotations;

namespace AutoKucaFinal.Models
{
    public class Doors
    {
        [Key]
        public int DoorsId { get; set; }
        public string DoorsNumber { get; set; } = "";
        public ICollection<Car> Cars { get; set; }
    }
}
