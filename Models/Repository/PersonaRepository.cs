using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models;

namespace personapi_dotnet.Models.Repository
{
    public class PersonaRepository : IPersonaRepository
    {

        protected readonly persona_dbContext _context;
        public PersonaRepository(persona_dbContext context) => _context = context;


        public async Task<Persona> CreatePersonaAsync(Persona persona)
        {
            await _context.Set<Persona>().AddAsync(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task<bool> DeletePersonaAsync(Persona persona)
        {
            //var entity = await GetByIdAsync(id);
            if (persona is null)
            {
                return false;
            }
            _context.Set<Persona>().Remove(persona);
            await _context.SaveChangesAsync();

            return true;
        }

        public Persona GetPersonaById(int id)
        {
            return _context.Personas.Find(id);
        }

        public IEnumerable<Persona> GetPersonas()
        {
            return _context.Personas.ToList();
        }

        public async Task<bool> UpdatePersonaAsync(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
