using AutoKucaFinal.DTOs;
using AutoKucaFinal.Models;

namespace AutoKucaFinal.Services.BrandService
{
    public interface IBrandService
    {
        ICollection<Brand> GetBrands();
        bool BrandExist(int id);
        bool AddBrand(BrandRequest brandRequest);
        bool UpdateBrand(BrandRequest brandRequest, int id);
        bool DeleteBrand(int id);
        bool Save();
       
    }
}
