using Microsoft.AspNetCore.Mvc;
using DUNAMIS_SA.Data;
using DUNAMIS_SA.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index()
        {
            var cargas = await _context.Cargas.Include(c => c.TipoDeCarga).Include(c => c.Cliente).ToListAsync();
            return View(cargas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(Carga carga)
        {
            if (ModelState.IsValid)
            {
                if (carga.CargasID == 0)
                {
                    await _context.Database.ExecuteSqlRawAsync(
                        "EXEC CrearCarga @Peso, @FechaEnvio, @Destino, @TipoDeCargaID, @ClienteID",
                        new SqlParameter("@Peso", carga.Peso),
                        new SqlParameter("@FechaEnvio", carga.FechaEnvio),
                        new SqlParameter("@Destino", carga.Destino),
                        new SqlParameter("@TipoDeCargaID", carga.TipoDeCargaID),
                        new SqlParameter("@ClienteID", carga.ClienteID)
                    );
                }
                else
                {
                    await _context.Database.ExecuteSqlRawAsync(
                        "EXEC ActualizarCarga @CargaID, @Peso, @FechaEnvio, @Destino, @TipoDeCargaID, @ClienteID",
                        new SqlParameter("@CargaID", carga.CargasID),
                        new SqlParameter("@Peso", carga.Peso),
                        new SqlParameter("@FechaEnvio", carga.FechaEnvio),
                        new SqlParameter("@Destino", carga.Destino),
                        new SqlParameter("@TipoDeCargaID", carga.TipoDeCargaID),
                        new SqlParameter("@ClienteID", carga.ClienteID)
                    );
                }
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Invalid data." });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC EliminarCarga @CargaID", new SqlParameter("@CargaID", id));
            return Json(new { success = true });
        }
    }
}
