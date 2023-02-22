using System.ComponentModel.DataAnnotations;

namespace AutoKuca.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        public string Model { get; set; } = "";
        [Required]
        public int Year { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public float? NumberOfKilometers { get; set; }
        public float? Volume { get;set; }
        public int? HorsePower { get; set; }
        public int? KW { get; set; }


        [Required]
        public int BrandId { get; set; }
        
        public Brand Brand { get; set; } 

        public int? ColorId { get; set; }
        public Color Color { get; set; }

        public int TransmissionTypeId { get; set; }
        public TransmissionType TransmissionType { get; set; }
        
        public int DoorsId { get; set; }
        public Doors Doors { get; set; }

        public int FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
