using AutoKucaFinal.DTOs;
using AutoKucaFinal.Services.CarRepo;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoKucaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        
        public CarController(ICarService carService) 
        {
            _carService = carService;
            
        }
        [HttpPost]
        public IActionResult AddCar([FromForm] CarRequest carRequest)
        {
            if(carRequest.Year == 0 || !_carService.IsModelExist(carRequest.ModelId) || carRequest.FuelTypeId==0 || carRequest.TransmissionTypeId == 0)
            {
                return BadRequest();
            }
            if (!_carService.AddCar(carRequest))
            {
                return StatusCode(500);
            }
            else
            {
                return Ok("Successfully added");
            }
            
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCar([FromForm] CarRequest carRequest, [FromRoute] int id)
        {
            if (carRequest.Year == 0 || !_carService.IsModelExist(carRequest.ModelId) || carRequest.FuelTypeId == 0 || carRequest.TransmissionTypeId == 0)
            {
                return BadRequest();
            }
            if (!_carService.UpdateCar(carRequest, id))
            {
                return StatusCode(500);
            }
            else
            {
                return Ok("Successfully updated");
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCar(int id)
        {
            if (_carService.DeleteCar(id))
            {
                return Ok("Successfully deleted");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{page:int}")]
        public IActionResult GetCars([FromRoute] int page)
        {
            var cars = _carService.GetCars(page);
            if (cars != null)
            {
                return Ok(cars);
            }
            
            return NotFound();
        }

        [HttpGet]
        [Route("details/{id:int}")]
        public IActionResult GetSingleCar([FromRoute] int id)
        {
            if (_carService.IsCarExist(id))
            {
                return Ok(_carService.GetSingleCar(id));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
