using AutoKucaFinal.DTOs;
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
        public bool AddModel(ModelRequest modelRequest)
        {
            if(modelRequest.ModelName == "" || modelRequest.BrandId == 0)
            {
                return false;
            }
            var brand = _context.Brands.Find(modelRequest.BrandId);
            if(brand != null)
            {
                var newModel = new Model()
                {
                    ModelName = modelRequest.ModelName,
                    BrandId = modelRequest.BrandId,
                    Brand = brand
                };
                _context.Models.Add(newModel);
                return Save();
            }
            else
            {
                return false;
            }
            
        }
        public bool UpdateModel(ModelRequest modelRequest, int id) 
        {
            var model = _context.Models.Find(id);
            var brand = _context.Brands.Find(modelRequest.BrandId);
            if(model!=null && brand != null)
            {
                model.Brand = brand;
                model.BrandId = modelRequest.BrandId;
                model.ModelName = modelRequest.ModelName;
                return Save();
            }
            else
            {
                return false;
            }
        }
        public bool DeleteModel(int id)
        {
            var model = _context.Models.Find(id);
            if (model != null)
            {
                _context.Models.Remove(model);
                return Save();
            }
            else
            {
                return false;
            }
        }
        public bool Save()
        {
            var check = _context.SaveChanges();
            return check > 0 ? true : false;
        }
        public bool isModelIdExist(int id)
        {
            return _context.Models.Any(m => m.ModelId == id);
        }
        public bool isBrandIdExist(int id)
        {
            return _context.Brands.Any(m => m.BrandId == id);   
        }
    }
}
