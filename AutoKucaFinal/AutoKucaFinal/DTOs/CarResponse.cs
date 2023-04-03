namespace AutoKucaFinal.DTOs
{
    public class CarResponse
    {
        public int CarId { get; set; }
        public string BrandName { get; set; } = "";
        public string ModelName { get; set; } = "";
        public int Year { get; set; }
        public string? CoverImage { get; set; } = "";
        public float? NumberOfKilometers { get; set; }
        public float Price { get; set; }
        public string FuelTypeName { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
