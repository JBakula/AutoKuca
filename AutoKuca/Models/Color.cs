using System.ComponentModel.DataAnnotations;

namespace AutoKuca.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }
        [Required]
        public string ColorName { get; set; } = "";
        public ICollection<Car> Car { get; set;}
    }
}
