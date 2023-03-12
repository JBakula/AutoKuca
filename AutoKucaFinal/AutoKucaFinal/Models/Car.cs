using System.ComponentModel.DataAnnotations;

namespace AutoKucaFinal.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public float Price { get; set; }
        public float? NumberOfKilometers { get; set; }
        public float? Volume { get; set; }
        public int? HorsePower { get; set; }
        public int? KW { get; set; }
        public string? CoverImage { get;set; }

        [Required]
        public int ModelId { get; set; }
        public Model Model { get; set; }

        public int? ColorId { get; set; }
        public Color Color { get; set; }
        [Required]
        public int TransmissionTypeId { get; set; }
        public TransmissionType TransmissionType { get; set; }
        [Required]
        public int FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }

        public int? DoorsId { get; set; }
        public Doors Doors { get; set; }
        public ICollection<Image> Images { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
