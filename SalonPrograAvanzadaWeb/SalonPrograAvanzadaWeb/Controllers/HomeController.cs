using Microsoft.AspNetCore.Mvc;
using SalonPrograAvanzadaWeb.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace SalonPrograAvanzadaWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult IniciarSesion()
		{
			return View();
		}

		public IActionResult RegistrarUsuario()
		{
			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
