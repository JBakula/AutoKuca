namespace AutoKucaFinal.DTOs
{
    public class CarRequest
    {
        public int Year { get; set; }
        public float Price { get; set; }
        public float NumberOfKilometers { get; set; }
        public float Volume { get; set; }
        public int HorsePower { get; set; }
        public int KW { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int TransmissionTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int DoorsId { get; set; }
        //public string CoverImageName { get; set; } = "";
        public IFormFile? CoverImage { get; set; }
        //public string[] OtherImagesNames { get; set; }
        public IFormFile[]? OtherImages { get; set; }
    }
}
