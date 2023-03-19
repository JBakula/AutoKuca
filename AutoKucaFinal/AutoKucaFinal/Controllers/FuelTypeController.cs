using AutoKucaFinal.DTOs;
using AutoKucaFinal.Services.FuelTypeRepo;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoKucaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypeController : ControllerBase
    {
        private readonly IFuelTypeService _fuelTypeService;
        private readonly IMapper _mapper;
        public FuelTypeController(IFuelTypeService fuelTypeService,IMapper mapper)
        {
            _fuelTypeService = fuelTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFuelTypes() 
        {
            var FuelTypes = _mapper.Map<List<FuelTypesResponse>>(_fuelTypeService.GetFuelTypes());
            return Ok(FuelTypes);
        }
    }
}
