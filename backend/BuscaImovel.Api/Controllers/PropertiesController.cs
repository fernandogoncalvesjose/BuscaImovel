using BuscaImovel.Api.DTOs;
using BuscaImovel.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuscaImovel.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PropertyFilterRequestDto filter)
        {
            var properties = await _propertyService.GetPropertiesAsync(filter);
            return Ok(properties);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property is null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        [HttpGet("neighborhoods")]
        public async Task<IActionResult> GetNeighborhoods()
        {
            var neighborhoods = await _propertyService.GetNeighborhoodsAsync();
            return Ok(neighborhoods);
        }

        [HttpGet("sources")]
        public async Task<IActionResult> GetSources()
        {
            var sources = await _propertyService.GetSourcesAsync();
            return Ok(sources);
        }
    }
}
