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
        public ICollection<Model> GetModelsById(int id)
        {
            return _context.Models.Where(m => m.ModelId == id).ToList();
        }
        public bool ModelExist(int id)
        {
            return _context.Models.Any(m => m.ModelId == id);
        }
    }
}
