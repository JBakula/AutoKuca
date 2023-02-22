using AutoKuca.Models;
using AutoKuca.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoKuca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly CarsDbContext ctx;
        public BrandController(CarsDbContext context) 
        { 
            ctx = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            return Ok(await ctx.Brands
                            .OrderBy(b=>b.BrandName)
                            .ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddBrand(BrandRequest request)
        {
            var newBrand = new Brand()
            {
                BrandName = request.BrandName
            };
            await ctx.Brands.AddAsync(newBrand);
            await ctx.SaveChangesAsync();
            return Ok(newBrand);    
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBrand(BrandRequest request, [FromRoute] int id)
        {
            var BrandForUpdate = await ctx.Brands.FindAsync(id);
            if(BrandForUpdate != null)
            {
                BrandForUpdate.BrandName = request.BrandName;
                await ctx.SaveChangesAsync();
                return Ok(BrandForUpdate);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBrand([FromRoute] int id)
        {
            var BrandForDelete = await ctx.Brands.FindAsync(id);
            if (BrandForDelete != null) {
                ctx.Brands.Remove(BrandForDelete);
                await ctx.SaveChangesAsync();
                return Ok(BrandForDelete);
            }
            return NotFound();
        }
        
    }
}
