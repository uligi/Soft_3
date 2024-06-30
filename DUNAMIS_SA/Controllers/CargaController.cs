using Microsoft.AspNetCore.Mvc;
using DUNAMIS_SA.Data;
using DUNAMIS_SA.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
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

        [HttpGet]
        public IActionResult Index()
        {
            var cargas = _context.Cargas.FromSqlRaw("EXEC ObtenerCargas").ToList();
            return View(cargas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(Carga carga)
        {
            if (ModelState.IsValid)
            {
                if (carga.CargasID == 0)
                {
                    var parameters = new[]
                    {
                        new SqlParameter("@Peso", carga.Peso),
                        new SqlParameter("@FechaEnvio", carga.FechaEnvio),
                        new SqlParameter("@Destino", carga.Destino),
                        new SqlParameter("@TipoDeCargaID", carga.TipoDeCargaID),
                        new SqlParameter("@ClienteID", carga.ClienteID)
                    };

                    await _context.Database.ExecuteSqlRawAsync("EXEC CrearCarga @Peso, @FechaEnvio, @Destino, @TipoDeCargaID, @ClienteID", parameters);
                }
                else
                {
                    var parameters = new[]
                    {
                        new SqlParameter("@CargasID", carga.CargasID),
                        new SqlParameter("@Peso", carga.Peso),
                        new SqlParameter("@FechaEnvio", carga.FechaEnvio),
                        new SqlParameter("@Destino", carga.Destino),
                        new SqlParameter("@TipoDeCargaID", carga.TipoDeCargaID),
                        new SqlParameter("@ClienteID", carga.ClienteID)
                    };

                    await _context.Database.ExecuteSqlRawAsync("EXEC ActualizarCarga @CargasID, @Peso, @FechaEnvio, @Destino, @TipoDeCargaID, @ClienteID", parameters);
                }
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Invalid data." });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var parameter = new SqlParameter("@CargasID", id);
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC EliminarCarga @CargasID", parameter);

            if (result > 0)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Carga not found." });
        }
    }
}
