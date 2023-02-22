using AutoKuca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoKuca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypeController : ControllerBase
    {
        private readonly CarsDbContext ctx;
        public FuelTypeController(CarsDbContext context) {
            ctx = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetFuelTypes()
        {
            return Ok(await ctx.FuelTypes
                         .OrderBy(ft => ft.FuelTypeName)
                         .ToListAsync());          
        }
    }
}
