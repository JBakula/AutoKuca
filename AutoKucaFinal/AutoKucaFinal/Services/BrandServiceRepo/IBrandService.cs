using AutoKucaFinal.Models;

namespace AutoKucaFinal.Services.BrandService
{
    public interface IBrandService
    {
        ICollection<Brand> GetBrands();
        Brand GetBrandById(int id);
        bool BrandExist(int id);
        ICollection<Model> GetModelsByBrandId(int id);
    }
}
