using AutoKucaFinal.Models;

namespace AutoKucaFinal.Services.DoorsServiceRepo
{
    public class DoorsService:IDoorsService
    {
        private readonly AutoKucaDbContext _context;
        public DoorsService(AutoKucaDbContext context) { 
            _context = context;
        }
        public ICollection<Doors> GetDoors()
        {
            return _context.Doors.ToList();
        }
    }
}
