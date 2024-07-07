using Microsoft.AspNetCore.Mvc;
using DUNAMIS_SA.Data;
using DUNAMIS_SA.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

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

        // POST: TipoDeCarga/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("TipoDeCargaID,Descripcion,TarifaPorKilo")] TipoDeCarga tipoDeCarga)
        {
            if (ModelState.IsValid)
            {
                if (tipoDeCarga.TipoDeCargaID == 0)
                {
                    string query = "INSERT INTO TipoDeCarga (Descripcion, TarifaPorKilo) VALUES (@Descripcion, @TarifaPorKilo)";
                    await _context.Database.ExecuteSqlRawAsync(query, new SqlParameter("@Descripcion", tipoDeCarga.Descripcion), new SqlParameter("@TarifaPorKilo", tipoDeCarga.TarifaPorKilo));
                }
                else
                {
                    string query = "UPDATE TipoDeCarga SET Descripcion = @Descripcion, TarifaPorKilo = @TarifaPorKilo WHERE TipoDeCargaID = @TipoDeCargaID";
                    await _context.Database.ExecuteSqlRawAsync(query, new SqlParameter("@Descripcion", tipoDeCarga.Descripcion), new SqlParameter("@TarifaPorKilo", tipoDeCarga.TarifaPorKilo), new SqlParameter("@TipoDeCargaID", tipoDeCarga.TipoDeCargaID));
                }
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // POST: TipoDeCarga/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoDeCarga = await _context.TipoDeCarga.FindAsync(id);
            if (tipoDeCarga == null)
            {
                return NotFound();
            }

            try
            {
                _context.TipoDeCarga.Remove(tipoDeCarga);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        private bool TipoDeCargaExists(int id)
        {
            return _context.TipoDeCarga.Any(e => e.TipoDeCargaID == id);
        }
    }
}
