using AutoKucaFinal.Models;

namespace AutoKucaFinal.DTOs
{
    public class CarDetailsResponse
    {
        public int CarId { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }
        public float? NumberOfKilometers { get; set; }
        public float? Volume { get; set; }
        public int? HorsePower { get; set; }
        public int? KW { get; set; }
        public string? CoverImage { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string DoorsNumber { get; set; }
        public string TransmissionTypeName { get; set; }
        public string FuelTypeName { get; set; }
        public List<ImageResponse> Images { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
