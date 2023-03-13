
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
        public IActionResult GetModelsByBrand([FromRoute] int id)
        {
            var models = _modelService.GetModelsByBrandId(id);
            return Ok(models);
        }
    }
}
