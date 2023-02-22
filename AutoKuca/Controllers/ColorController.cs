using AutoKuca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoKuca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly CarsDbContext ctx;
        public ColorController(CarsDbContext context) {
            ctx = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetColors() {
            return Ok(await ctx.Colors.OrderBy(c => c.ColorName).ToListAsync());
        }
        
    }
}
