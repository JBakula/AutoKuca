using System.ComponentModel.DataAnnotations;

namespace AutoKucaFinal.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get;set; }
        [Required]
        public string ColorName { get; set; } = "";
        public ICollection<Car> Cars { get; set; }
    }
}
