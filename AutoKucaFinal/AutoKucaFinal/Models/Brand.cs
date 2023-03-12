using System.ComponentModel.DataAnnotations;

namespace AutoKucaFinal.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        public string BrandName { get; set; } = "";
        public ICollection<Model> Models { get; set; }  
        
    }
}
