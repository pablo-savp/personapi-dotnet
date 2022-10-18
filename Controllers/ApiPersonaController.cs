using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repository;

namespace personapi_dotnet.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApiPersonaController : ControllerBase
    {
        private IPersonaRepository _personaRepository;

        public ApiPersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetPersonasAsync))]
        public IEnumerable<Persona> GetPersonasAsync()
        {
            return _personaRepository.GetPersonas();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetPersonaById))]
        public ActionResult<Persona> GetPersonaById(int id)
        {
            var personaByID = _personaRepository.GetPersonaById(id);
            if (personaByID == null)
            {
                return NotFound();
            }
            return personaByID;
        }

        [HttpPost]
        [ActionName(nameof(CreatePersonaAsync))]
        public async Task<ActionResult<Persona>> CreatePersonaAsync(Persona persona)
        {
            await _personaRepository.CreatePersonaAsync(persona);
            return CreatedAtAction(nameof(GetPersonaById), new { id = persona.Cc }, persona);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdatePersona))]
        public async Task<ActionResult> UpdatePersona(int id, Persona persona)
        {
            if (id != persona.Cc)
            {
                return BadRequest();
            }

            await _personaRepository.UpdatePersonaAsync(persona);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeletePersona))]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = _personaRepository.GetPersonaById(id);
            if (persona == null)
            {
                return NotFound();
            }

            await _personaRepository.DeletePersonaAsync(persona);

            return NoContent();
        }
    }

}
