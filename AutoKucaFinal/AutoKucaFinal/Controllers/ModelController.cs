
using AutoKucaFinal.Services.ModelServiceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoKucaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;
        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetModelById([FromRoute] int id)
        {
            if (!_modelService.ModelExist(id))
            {
                return NotFound();
            }
            var models = _modelService.GetModelsById(id);
            return Ok(models);
        }
    }
}
