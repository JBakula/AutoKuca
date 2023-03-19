using AutoKucaFinal.Services.BrandServiceRepo;
using AutoKucaFinal.Services.BrandService;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoKucaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService) 
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult GetBrands()
        {
            var brands = _brandService.GetBrands();
            
            return Ok(brands);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetSingleBrand([FromRoute]int id)
        {
            if (!_brandService.BrandExist(id))
            {
                return NotFound();
            }
            var brand = _brandService.GetBrandById(id);
            return Ok(brand);
        }
        [HttpGet]
        [Route("/models/{id:int}")]
        public IActionResult GetModelsByBrandId([FromRoute] int id)
        {
            if (!_brandService.BrandExist(id))
            {
                return NotFound();
            }

            var models = _brandService.GetModelsByBrandId(id);
            return Ok(models);
        }
    }
}
