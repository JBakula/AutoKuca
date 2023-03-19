using AutoKucaFinal.Models;

namespace AutoKucaFinal.Services.ModelServiceRepo
{
    public interface IModelService
    {
        ICollection<Model> GetModelsById(int id);
        bool ModelExist(int id);

    }
}
