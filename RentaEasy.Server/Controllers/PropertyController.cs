using Microsoft.AspNetCore.Mvc;
using RentaEasy.Application.Services;
using RentaEasy.Core.Entities;

namespace RentaEasy.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyService _service;

        public PropertyController(PropertyService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetProperties() => Ok(_service.GetAllProperties());

        [HttpPost]
        public IActionResult AddProperty([FromBody] Property property)
        {
            _service.AddProperty(property);
            return CreatedAtAction(nameof(GetProperties), property);
        }
    }
}
