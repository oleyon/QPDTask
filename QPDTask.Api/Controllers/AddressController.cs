using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QPDTask.Api.Models;
using QPDTask.Service;
using QPDTask.Service.Models;

namespace QPDTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IDadataService _dadataService;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressController> _logger;

        public AddressController(IDadataService dadataService, IMapper mapper, ILogger<AddressController> logger)
        {
            _dadataService = dadataService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("clean")]
        public async Task<IActionResult> Standardize([FromBody] RawAddressRequest rawAddressRequest)
        {
            try
            {
                var rawAddressModel = _mapper.Map<RawAddressModel>(rawAddressRequest);
                var cleanedAddress = await _dadataService.CleanAddressAsync(rawAddressModel);
                return Ok(cleanedAddress);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                return StatusCode(500, "An error occurred while cleaning the address.");
            }
        }
    }
}
