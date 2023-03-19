using AutoKucaFinal.Models;

namespace AutoKucaFinal.Services.FuelTypeRepo
{
    public class FuelTypeService:IFuelTypeService
    {
        private readonly AutoKucaDbContext _context;
        public FuelTypeService(AutoKucaDbContext context) {
            _context = context;
        }
        public ICollection<FuelType> GetFuelTypes()
        {
            return _context.FuelTypes.OrderBy(f => f.FuelTypeName).ToList();
        }
    }
}
