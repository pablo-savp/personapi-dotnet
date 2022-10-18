using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.ViewModels;

namespace personapi_dotnet.Controllers
{
    public class PersonaController : Controller
    {
        private readonly persona_dbContext _context;

        public PersonaController(persona_dbContext context ) { 
        
        _context = context;
        
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Personas.ToListAsync());
        }

        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(PersonaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var per = new Persona()
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Genero = model.Genero,
                    Edad = model.Edad,
                    Cc = model.Cedula,
                };
                _context.Add(per);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


    }
}
