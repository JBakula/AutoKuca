using AutoKuca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoKuca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionController : ControllerBase
    {
        private readonly CarsDbContext ctx;
        public TransmissionController(CarsDbContext context) {
            ctx = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTransmissionTypes()
        {
            return Ok(await ctx.TransmissionTypes
                       .OrderBy(t => t.TransmissionTypeName)
                       .ToListAsync());
        }
    }
}
