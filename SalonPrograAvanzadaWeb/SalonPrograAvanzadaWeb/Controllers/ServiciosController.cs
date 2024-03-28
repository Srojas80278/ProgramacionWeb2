using Microsoft.AspNetCore.Mvc;
using SalonPrograAvanzadaWeb.Entities;
using SalonPrograAvanzadaWeb.Services;

namespace SalonPrograAvanzadaWeb.Controllers
{
    public class ServiciosController (IServiciosModel _serviciosModel) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ConsultarServicios()
        {
            var respuestaModelo = _serviciosModel.ConsultarServicios();

            if (respuestaModelo?.Codigo == "1")
                return View(respuestaModelo?.Datos);
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(new List<ServiciosEnt>());
            }
        }

        [HttpPost]
        public IActionResult RegistrarServicios(ServiciosEnt entidad)
        {
            var RespuestaApi = _serviciosModel.RegistrarServicios(entidad);

            if (RespuestaApi?.Codigo == "1")
                return RedirectToAction("ConsultarServicios", "Servicios");
            else
            {
                return RedirectToAction("ERROR", "Servicios");
            }
        }

        [HttpPost]
        public IActionResult ActualizarServicio(ServiciosEnt entidad)
        {
            var respuestaModelo = _serviciosModel.ActualizarServicio(entidad);

            if (respuestaModelo?.Codigo == "1")
                return RedirectToAction("ConsultarServicios", "Servicios");
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View();
            }
        }

        [HttpPost]
        public IActionResult EliminarServicio(CitaEnt entidad)
        {
            var respuestaModelo = _serviciosModel.EliminarServicio(entidad.IdServicio);

            if (respuestaModelo?.Codigo == "1")
                return RedirectToAction("ConsultarServicios", "Servicios");
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View();
            }
        }
    }
}
