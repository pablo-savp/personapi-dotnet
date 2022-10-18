using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    public class TelefonoController : Controller
    {
        private readonly persona_dbContext _context;

        public TelefonoController(persona_dbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {

            return View(await _context.Telefonos.ToListAsync());
        }
    }
}
