using System.ComponentModel.DataAnnotations;

namespace AutoKucaFinal.Models
{
    public class TransmissionType
    {
        public int TransmissionTypeId { get; set; }
        [Required]
        public string TransmissionTypeName { get; set; } = "";
        public ICollection<Car> Cars { get; set; }
    }
}
