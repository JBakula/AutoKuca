using AutoKucaFinal.DTOs;
using AutoKucaFinal.Services.DoorsServiceRepo;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoKucaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorsController : ControllerBase
    {
        private readonly IDoorsService _doorsService;
        private readonly IMapper _mapper;
        public DoorsController(IDoorsService doorsService, IMapper mapper) 
        {
            _doorsService = doorsService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetDoors()
        {
            var doors = _mapper.Map<List<DoorsResponse>>(_doorsService.GetDoors());
            return Ok(doors);
        }
    }
}
