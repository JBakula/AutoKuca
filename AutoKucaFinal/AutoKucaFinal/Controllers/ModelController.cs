
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

        [HttpPost]
        public IActionResult CreateNewModel(ModelRequest modelRequest)
        {
            if(modelRequest.ModelName == "" || modelRequest.BrandId == 0)
            {
                return BadRequest();
            }
            if (!_modelService.AddModel(modelRequest))
            {
                return StatusCode(500);
            }
            else
            {
                return Ok("Successfully added!!");
            }
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateModel(ModelRequest modelRequest,[FromRoute] int id)
        {
            if(modelRequest.ModelName == "" || modelRequest.BrandId == 0)
            {
                return BadRequest();
            }
            if (!_modelService.isModelIdExist(id))
            {
                return NotFound();
            }
            if (!_modelService.UpdateModel(modelRequest, id))
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
        public IActionResult DeleteModel([FromRoute] int id)
        {
            if (!_modelService.isModelIdExist(id))
            {
                return NotFound();
            }
            if (!_modelService.DeleteModel(id))
            {
                return StatusCode(500);
            }
            else
            {
                return Ok("Successfully deleted");
            }
        }
        
    }
}
