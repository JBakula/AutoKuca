using AutoKucaFinal.Models;

namespace AutoKucaFinal.Services.TransmissionTypeServiceRepo
{
    public class TransmissionTypeService:ITransmissionTypeService
    {
        private readonly AutoKucaDbContext _context;
        public TransmissionTypeService(AutoKucaDbContext context)
        {
            _context = context;
        }
        public ICollection<TransmissionType> GetTransmissionTypes()
        {
            return _context.TransmissionTypes.ToList();
        }
    }
}
