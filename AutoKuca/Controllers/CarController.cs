using AutoKuca.Models;
using AutoKuca.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

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

            var query = await ctx.Cars.OrderByDescending(c=>c.CreatedAt)
                                 .Select(c => new
                                 {
                                     c.CarId,
                                     c.Brand.BrandName,
                                     c.Model,
                                     c.Price,
                                     c.Year,
                                     c.FuelType.FuelTypeName,
                                     c.NumberOfKilometers

                                 }).ToListAsync();
            //return Ok(await ctx.Cars.OrderByDescending(c => c.CreatedAt).ToListAsync());
            return Ok(query);
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
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetSingleCar([FromRoute] int id)
        {
            var query =await ctx.Cars.Where(c => c.CarId == id)
                                .Select(c => new
                                {
                                    c.CarId,
                                    c.Brand.BrandName,
                                    c.Model,
                                    c.Year,
                                    c.Price,
                                    c.NumberOfKilometers,
                                    c.Volume,
                                    c.HorsePower,
                                    c.KW,
                                    c.Color.ColorName,
                                    c.TransmissionType.TransmissionTypeName,
                                    NumberOfDoors = c.Doors.Value,
                                    c.FuelType.FuelTypeName
                                }).FirstOrDefaultAsync();
            return Ok(query);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCar(CarRequest request,[FromRoute] int id)
        {
            var carToUpdate = await ctx.Cars.FindAsync(id);
            if (carToUpdate != null)
            {
                carToUpdate.BrandId = request.BrandId;
                carToUpdate.Model = request.Model;
                carToUpdate.Year = request.Year;
                carToUpdate.Price = request.Price;
                carToUpdate.NumberOfKilometers = request.NumberOfKilometers;
                carToUpdate.ColorId = request.ColorId;
                carToUpdate.TransmissionTypeId = request.TransmissionTypeId;
                carToUpdate.KW = request.KW;
                carToUpdate.Volume = request.Volume;
                carToUpdate.FuelTypeId = request.FuelTypeId;
                carToUpdate.DoorsId = request.DoorsId;
                carToUpdate.HorsePower = request.HorsePower;

                await ctx.SaveChangesAsync();
                return Ok(carToUpdate);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCar([FromRoute] int id)
        {
            var carToDelete = await ctx.Cars.FindAsync(id);
            if (carToDelete != null)
            {
                ctx.Cars.Remove(carToDelete);
                await ctx.SaveChangesAsync();
                return Ok(carToDelete);
            }
            return NotFound();
        }
    }
}
