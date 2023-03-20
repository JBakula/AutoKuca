using AutoKucaFinal.Services.BrandServiceRepo;
using AutoKucaFinal.Services.BrandService;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AutoKucaFinal.DTOs;

namespace AutoKucaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        public BrandController(IBrandService brandService, IMapper mapper) 
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBrands()
        {
            var brands = _mapper.Map<List<BrandResponse>>(_brandService.GetBrands());
            
            return Ok(brands);
        }

        [HttpPost]
        public IActionResult AddBrand(BrandRequest brandRequest)
        {
            if (brandRequest.BrandName == "")
            {
                return BadRequest();
            }

            if (!_brandService.AddBrand(brandRequest))
            {
                return StatusCode(500);
            }
            else
            {
                return Ok("Successfully created!!");
            }
            
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateBrand(BrandRequest brandRequest, [FromRoute] int id)
        {
            if (brandRequest.BrandName == "")
            {
                return BadRequest();
            }
            if (!_brandService.BrandExist(id))
            {
                return NotFound();
            }
            else
            {
                if (!_brandService.UpdateBrand(brandRequest,id))
                {
                    return StatusCode(500);
                }
                else
                {
                    return Ok("Successfully updated!!");
                }
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteBrand(int id)
        {
            if (!_brandService.BrandExist(id))
            {
                return NotFound();
            }
            if (!_brandService.DeleteBrand(id))
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
