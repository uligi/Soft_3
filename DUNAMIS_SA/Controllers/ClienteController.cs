using Microsoft.AspNetCore.Mvc;
using DUNAMIS_SA.Data;
using DUNAMIS_SA.Models;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCliente(string nombre, int cedula, string direccion, int distritoID, int cantonID, int provinciaID, string correo, int tipoCorreoID, string telefono, int tipoTelefonoID, int tipoClienteID, int pagoID)
        {
            if (ModelState.IsValid)
            {
                var nombreParam = new SqlParameter("@Nombre", nombre);
                var cedulaParam = new SqlParameter("@Cedula", cedula);
                var direccionParam = new SqlParameter("@Direccion", direccion);
                var distritoParam = new SqlParameter("@DistritoID", distritoID);
                var cantonParam = new SqlParameter("@CantonID", cantonID);
                var provinciaParam = new SqlParameter("@ProvinciaID", provinciaID);
                var correoParam = new SqlParameter("@Correo", correo);
                var tipoCorreoParam = new SqlParameter("@TipoCorreoID", tipoCorreoID);
                var telefonoParam = new SqlParameter("@Telefono", telefono);
                var tipoTelefonoParam = new SqlParameter("@TipoTelefonoID", tipoTelefonoID);
                var tipoClienteParam = new SqlParameter("@TipoClienteID", tipoClienteID);
                var pagoParam = new SqlParameter("@PagoID", pagoID);

                await _context.Database.ExecuteSqlRawAsync("EXEC CrearCliente @Nombre, @Cedula, @Direccion, @DistritoID, @CantonID, @ProvinciaID, @Correo, @TipoCorreoID, @Telefono, @TipoTelefonoID, @TipoClienteID, @PagoID",
                    nombreParam, cedulaParam, direccionParam, distritoParam, cantonParam, provinciaParam, correoParam, tipoCorreoParam, telefonoParam, tipoTelefonoParam, tipoClienteParam, pagoParam);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
