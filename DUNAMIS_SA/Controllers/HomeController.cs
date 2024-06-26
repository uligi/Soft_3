using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DUNAMIS_SA.Data;

namespace DUNAMIS_SA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var roleID = HttpContext.Session.GetInt32("RoleID");
            ViewBag.RoleID = roleID;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
