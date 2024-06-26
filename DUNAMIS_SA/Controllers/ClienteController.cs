using DUNAMIS_SA.Data;
using DUNAMIS_SA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DUNAMIS_SA.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult RegistrarCliente()
        {
            // Asegúrate de pasar un modelo vacío a la vista
            return View(new Cliente());
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(cliente);
        }
    }
}
