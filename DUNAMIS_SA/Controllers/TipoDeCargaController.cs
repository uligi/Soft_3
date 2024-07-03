using Microsoft.AspNetCore.Mvc;
using DUNAMIS_SA.Data;
using DUNAMIS_SA.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DUNAMIS_SA.Controllers
{
    public class TipoDeCargaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoDeCargaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoDeCarga
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDeCarga.ToListAsync());
        }

        // GET: TipoDeCarga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeCarga = await _context.TipoDeCarga
                .FirstOrDefaultAsync(m => m.TipoDeCargaID == id);
            if (tipoDeCarga == null)
            {
                return NotFound();
            }

            return View(tipoDeCarga);
        }

        // GET: TipoDeCarga/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeCarga/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDeCargaID,Descripcion,TarifaPorKilo")] TipoDeCarga tipoDeCarga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeCarga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeCarga);
        }

        // GET: TipoDeCarga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeCarga = await _context.TipoDeCarga.FindAsync(id);
            if (tipoDeCarga == null)
            {
                return NotFound();
            }
            return View(tipoDeCarga);
        }

        // POST: TipoDeCarga/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoDeCargaID,Descripcion,TarifaPorKilo")] TipoDeCarga tipoDeCarga)
        {
            if (id != tipoDeCarga.TipoDeCargaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeCarga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeCargaExists(tipoDeCarga.TipoDeCargaID))
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
            return View(tipoDeCarga);
        }

        // GET: TipoDeCarga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeCarga = await _context.TipoDeCarga
                .FirstOrDefaultAsync(m => m.TipoDeCargaID == id);
            if (tipoDeCarga == null)
            {
                return NotFound();
            }

            return View(tipoDeCarga);
        }

        // POST: TipoDeCarga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDeCarga = await _context.TipoDeCarga.FindAsync(id);
            _context.TipoDeCarga.Remove(tipoDeCarga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeCargaExists(int id)
        {
            return _context.TipoDeCarga.Any(e => e.TipoDeCargaID == id);
        }
    }
}
