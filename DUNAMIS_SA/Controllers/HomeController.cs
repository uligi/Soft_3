using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DUNAMIS_SA.Data;
using System.Security.Claims;

namespace DUNAMIS_SA.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var roleID = User.IsInRole("Admin") ? 1 : 2;
            var userName = User.Identity.Name;

            ViewBag.RoleID = roleID;
            ViewBag.UserName = userName;
            return View();
        }

        public IActionResult Error()
        {
            ViewBag.ErrorMessage = "No puedes regresar a la página anterior. Estás siendo redirigido a la página principal.";
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
