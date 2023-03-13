using AutoKucaFinal.Models;
using AutoKucaFinal.Services.BrandService;

namespace AutoKucaFinal.Services.BrandServiceRepo
{
    public class BrandService : IBrandService
    {
        private readonly AutoKucaDbContext _context;
        public BrandService(AutoKucaDbContext context)
        {
            _context = context;
        }

        public ICollection<Brand> GetBrands()
        {
            return  _context.Brands.OrderBy(b => b.BrandName).ToList();
        }
        public Brand GetBrandById(int id)
        {
            return _context.Brands.Where(b => b.BrandId == id).FirstOrDefault();
        }
    }
}
