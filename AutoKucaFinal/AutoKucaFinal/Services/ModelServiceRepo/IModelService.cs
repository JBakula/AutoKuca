using AutoKucaFinal.DTOs;
using AutoKucaFinal.Models;

namespace AutoKucaFinal.Services.ModelServiceRepo
{
    public interface IModelService
    {
        ICollection<Model> GetModelsByBrandId(int id);
        public bool AddModel(ModelRequest modelRequest);
        public bool UpdateModel(ModelRequest modelRequest, int id);
        public bool DeleteModel(int id);
        bool isBrandIdExist(int id);
        bool isModelIdExist(int id);

    }
}
