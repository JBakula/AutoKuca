using AutoKucaFinal.DTOs;
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
        public bool AddBrand(BrandRequest brandRequest)
        {
            Brand newBrand = new Brand()
            {
                BrandName = brandRequest.BrandName
            };
            _context.Brands.Add(newBrand);
            return Save();
        }
        public bool UpdateBrand(BrandRequest brandRequest, int id)
        {
            
            var brand = _context.Brands.Find(id);
            if (brand != null)
            {
                brand.BrandName = brandRequest.BrandName;
                return Save();
            }
            else
            {
                return false;
            }
            

        }
        public bool DeleteBrand(int id)
        {
            var brand = _context.Brands.Find(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                return Save();
            }
            else
            {
                return false;
            }
        }
        public bool BrandExist(int id)
        {
            return _context.Brands.Any(b => b.BrandId == id);
        }
        public bool Save()
        {
            var check = _context.SaveChanges();
            return check > 0 ? true : false;
        }
    }
}
