using System.ComponentModel.DataAnnotations;

namespace AutoKuca.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        public string BrandName { get; set; } = "";

        public ICollection<Car> Car { get; set; }  
    }
}
