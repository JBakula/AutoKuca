
using AutoKucaFinal.DTOs;
using AutoKucaFinal.Services.ModelServiceRepo;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoKucaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;
        private readonly IMapper _mapper;
        public ModelController(IModelService modelService,IMapper mapper)
        {
            _mapper = mapper;
            _modelService = modelService;
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetModelsByBrandId([FromRoute] int id)
        {
            if (!_modelService.isBrandIdExist(id))
            {
                return NotFound();
            }
            var models = _mapper.Map<List<ModelsResponse>>(_modelService.GetModelsByBrandId(id));
            return Ok(models);
        }
        
    }
}
