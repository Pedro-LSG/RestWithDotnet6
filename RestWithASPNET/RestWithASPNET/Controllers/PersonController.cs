using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Model;
using RestWithASPNET.Services;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_personService.FindAll());
        }
        
        [HttpGet("{identifier}")]
        public IActionResult FindByIdentifier(long identifier)
        {
            var person = _personService.FindByIdentifier(identifier);
            if (person is null) return BadRequest();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person is null) return BadRequest();
            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person is null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{identifier}")]
        public IActionResult Delete(long identifier)
        {
            var person = _personService.FindByIdentifier(identifier);
            _personService.Delete(person);
            return NoContent();
        }
    }
}