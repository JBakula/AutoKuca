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
            return _context.Models.Where(m => m.BrandId == id).ToList();
        }
    }
}
