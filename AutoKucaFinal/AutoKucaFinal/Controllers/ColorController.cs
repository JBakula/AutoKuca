using AutoKucaFinal.DTOs;
using AutoKucaFinal.Services.ColorServiceRepo;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoKucaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IColorService _colorService;

        public ColorController(IMapper mapper, IColorService colorService)
        {
            _mapper = mapper;
            _colorService = colorService;
        }
        [HttpGet]
        public IActionResult GetColors()
        {
            var colors = _mapper.Map<List<ColorResponse>>(_colorService.GetColors());
            return Ok(colors);
        }
    }
}
