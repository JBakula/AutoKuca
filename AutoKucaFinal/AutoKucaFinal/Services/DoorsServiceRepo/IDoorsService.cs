using AutoKucaFinal.Models;

namespace AutoKucaFinal.Services.DoorsServiceRepo
{
    public interface IDoorsService
    {
        ICollection<Doors> GetDoors();
    }
}
