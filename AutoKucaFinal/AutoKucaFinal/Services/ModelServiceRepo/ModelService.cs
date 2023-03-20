using AutoKucaFinal.Models;

namespace AutoKucaFinal.Services.ModelServiceRepo
{
    public class ModelService : IModelService
    {
        private readonly AutoKucaDbContext _context;
        public ModelService(AutoKucaDbContext context)
        {
            _context = context;
        }
        
        public ICollection<Model> GetModelsByBrandId(int id)
        {
            return _context.Models.Where(m=>m.BrandId == id).OrderBy(m=>m.ModelName).ToList();
        }
        public bool isBrandIdExist(int id)
        {
            return _context.Brands.Any(m => m.BrandId == id);   
        }
    }
}
