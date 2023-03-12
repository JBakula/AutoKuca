using System.ComponentModel.DataAnnotations;

namespace AutoKucaFinal.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageName { get; set; } = "";
        [Required]
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
