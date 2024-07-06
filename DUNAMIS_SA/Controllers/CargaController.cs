using Microsoft.AspNetCore.Mvc;
using DUNAMIS_SA.Data;
using DUNAMIS_SA.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DUNAMIS_SA.Controllers
{
    public class CargaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CargaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carga
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carga.ToListAsync());
        }

        // GET: Carga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carga = await _context.Carga
                .FirstOrDefaultAsync(m => m.CargaID == id);
            if (carga == null)
            {
                return NotFound();
            }

            return View(carga);
        }

        // GET: Carga/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carga/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CargaID,Peso,FechaEnvio,Destino,TipoDeCargaID,ClienteID")] Carga carga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carga);
        }

        // GET: Carga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carga = await _context.Carga.FindAsync(id);
            if (carga == null)
            {
                return NotFound();
            }
            return View(carga);
        }

        // POST: Carga/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CargaID,Peso,FechaEnvio,Destino,TipoDeCargaID,ClienteID")] Carga carga)
        {
            if (id != carga.CargaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargaExists(carga.CargaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carga);
        }

        // GET: Carga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carga = await _context.Carga
                .FirstOrDefaultAsync(m => m.CargaID == id);
            if (carga == null)
            {
                return NotFound();
            }

            return View(carga);
        }

        // POST: Carga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carga = await _context.Carga.FindAsync(id);
            _context.Carga.Remove(carga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargaExists(int id)
        {
            return _context.Carga.Any(e => e.CargaID == id);
        }
    }
}
