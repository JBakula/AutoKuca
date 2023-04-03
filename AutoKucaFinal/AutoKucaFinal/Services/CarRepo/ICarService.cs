using AutoKucaFinal.DTOs;
using AutoKucaFinal.Models;
namespace AutoKucaFinal.Services.CarRepo
{
    public interface ICarService
    {
        bool AddCar(CarRequest carRequest);
        string GenerateCoverImagePath(IFormFile image);
        bool IsModelExist(int id);
        bool IsCarExist(int id);
        //bool Save();
        bool UpdateCar(CarRequest carRequest, int id);
        bool DeleteCar(int id);
        double NumberOfPages(float numberofItemsPerPage);
        CarResponsePaginated GetCars(int page);
        CarDetailsResponse GetSingleCar(int id);
    }
}
