using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DUNAMIS_SA.Data;

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
            ViewBag.RoleID = roleID;
            return View();
        }

        public IActionResult Error()
        {
            ViewBag.ErrorMessage = "No puedes regresar a la p�gina anterior. Est�s siendo redirigido a la p�gina principal.";
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
