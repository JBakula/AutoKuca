using AutoKuca.Models;
using AutoKuca.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoKuca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarsDbContext ctx;
        public CarController(CarsDbContext context) { 
            ctx = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            return Ok(await ctx.Cars.OrderByDescending(c => c.CreatedAt).ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddCar(CarRequest request)
        {
            var newCar = new Car()
            {
                Model = request.Model,
                Year = request.Year,
                Price = request.Price,
                NumberOfKilometers = request.NumberOfKilometers,
                Volume = request.Volume,
                HorsePower = request.HorsePower,
                KW = request.KW,
                BrandId = request.BrandId,
                ColorId = request.ColorId,
                TransmissionTypeId = request.TransmissionTypeId,
                DoorsId = request.DoorsId,
                FuelTypeId = request.FuelTypeId,
                CreatedAt = DateTime.Now
            };
            await ctx.Cars.AddAsync(newCar);
            await ctx.SaveChangesAsync();
            return Ok(newCar);  

        }
    }
}
