using System.ComponentModel.DataAnnotations;

namespace AutoKucaFinal.Models
{
    public class Model
    {
        [Key]
        public int ModelId { get; set; }
        [Required]
        public string ModelName { get; set; } = "";
        public int BrandId { get; set; }
        public Brand Brand { get; set; }    
        public ICollection<Car> Cars { get; set; }
    }
}
