using AutoKucaFinal.Models;

namespace AutoKucaFinal.Services.ColorServiceRepo
{
    public class ColorService:IColorService
    {
        private readonly AutoKucaDbContext _context;
        public ColorService(AutoKucaDbContext context) 
        {
            _context = context;
            
        }
        public ICollection<Color> GetColors()
        {
            return _context.Colors.OrderBy(c=>c.ColorName).ToList();
        }
    }
}
