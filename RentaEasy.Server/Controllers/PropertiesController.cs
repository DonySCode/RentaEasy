using Microsoft.AspNetCore.Mvc;
using RentaEasy.Application.Services;
using RentaEasy.Core.Entities;

namespace RentaEasy.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertyService _service;

        public PropertiesController(PropertyService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public IActionResult GetPropery(int id) => Ok(_service.GetPropertyById(id));

        [HttpGet]
        public IActionResult GetProperties() => Ok(_service.GetAllProperties());

        [HttpPost]
        public IActionResult AddProperty([FromBody] Property property)
        {
            _service.AddProperty(property);
            return CreatedAtAction(nameof(GetProperties), property);
        }

        [HttpPut]
        public IActionResult UpdateProperty([FromBody] Property property)
        {
            _service.UpdateProperty(property);
            return CreatedAtAction(nameof(GetProperties), property);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(int id)
        {
            _service.DeleteProperty(id);
            return NoContent();
        }
    }
}
