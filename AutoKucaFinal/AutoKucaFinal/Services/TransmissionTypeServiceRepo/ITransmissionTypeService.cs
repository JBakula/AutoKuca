using AutoKucaFinal.Models;

namespace AutoKucaFinal.Services.TransmissionTypeServiceRepo
{
    public interface ITransmissionTypeService
    {
        public ICollection<TransmissionType> GetTransmissionTypes();

    }
}
