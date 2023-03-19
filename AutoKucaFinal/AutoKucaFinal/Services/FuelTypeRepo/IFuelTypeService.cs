using AutoKucaFinal.Models;

namespace AutoKucaFinal.Services.FuelTypeRepo
{
    public interface IFuelTypeService
    {
        ICollection<FuelType> GetFuelTypes();
    }
}
