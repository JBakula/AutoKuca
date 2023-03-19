using AutoKucaFinal.DTOs;
using AutoKucaFinal.Services.TransmissionTypeServiceRepo;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoKucaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITransmissionTypeService _transmissionTypeService;
        public TransmissionTypeController(ITransmissionTypeService transmissionTypeService, IMapper mapper)
        {
            _transmissionTypeService = transmissionTypeService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetTransmissionTypes()
        {
            var TransmissionTypes = _mapper.Map<List<TransmissionTypeResponse>>(_transmissionTypeService.GetTransmissionTypes());
            return Ok(TransmissionTypes);
        }
    }
}
