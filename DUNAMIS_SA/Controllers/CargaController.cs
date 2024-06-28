using Microsoft.AspNetCore.Mvc;
using DUNAMIS_SA.Data;
using DUNAMIS_SA.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DUNAMIS_SA.Controllers
{
    public class CargaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CargaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cargas = _context.Cargas.ToList();
            return View(cargas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(Carga carga)
        {
            if (ModelState.IsValid)
            {
                if (carga.CargaID == 0)
                {
                    _context.Cargas.Add(carga);
                }
                else
                {
                    _context.Cargas.Update(carga);
                }
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Invalid data." });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var carga = await _context.Cargas.FindAsync(id);
            if (carga != null)
            {
                _context.Cargas.Remove(carga);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Carga not found." });
        }
    }
}
