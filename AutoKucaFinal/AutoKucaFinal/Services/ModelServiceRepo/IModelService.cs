using AutoKucaFinal.Models;

namespace AutoKucaFinal.Services.ModelServiceRepo
{
    public interface IModelService
    {
        ICollection<Model> GetModelsByBrandId(int id);
    }
}
