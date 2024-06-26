using Microsoft.AspNetCore.Mvc;
using DUNAMIS_SA.Models;
using DUNAMIS_SA.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DUNAMIS_SA.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Correo == email && u.Contrasena == password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserID", user.UsuarioID);
                HttpContext.Session.SetInt32("RoleID", user.RolID);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
