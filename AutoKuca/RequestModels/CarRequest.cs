using System.ComponentModel.DataAnnotations;

namespace AutoKuca.RequestModels
{
    public class CarRequest
    {
        public string Model { get; set; }
        public int Year { get; set; }
        
        public float Price { get; set; }
        public float? NumberOfKilometers { get; set; }
        public float? Volume { get; set; }
        public int? HorsePower { get; set; }
        public int? KW { get; set; }
        public int BrandId { get; set; }
        public int? ColorId { get; set; }
        public int TransmissionTypeId { get; set; }
        public int DoorsId { get; set; }
        public int FuelTypeId { get; set; }
    }
}
