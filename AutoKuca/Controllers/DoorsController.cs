using AutoKuca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoKuca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorsController : ControllerBase
    {
        private readonly CarsDbContext ctx;
        public DoorsController(CarsDbContext context)
        {
            ctx = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoors()
        {
            return Ok(await ctx.Doors
                         .OrderBy(d => d.Value)
                         .ToListAsync());
        }
    }
}
