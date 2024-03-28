using Microsoft.AspNetCore.Mvc;
using SalonPrograAvanzadaWeb.Entities;
using SalonPrograAvanzadaWeb.Models;
using SalonPrograAvanzadaWeb.Services;

namespace SalonPrograAvanzadaWeb.Controllers
{
    public class CitaController(ICitaModel _citaModel) : Controller
    {
        [HttpGet]
        public IActionResult CrearCita()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LeerCitas()
        {
            var respuestaModelo = _citaModel.LeerCitas();

            if (respuestaModelo?.Codigo == "1")
                return View(respuestaModelo?.Datos);
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(new List<CitaEnt>());
            }
        }

        [HttpPost]
        public IActionResult CrearCita(CitaEnt entidad)
        {
            var RespuestaApi = _citaModel.CrearCita(entidad);

            if (RespuestaApi?.Codigo == "1")
                return RedirectToAction("LeerCitas", "Cita");
            else
            {
                return RedirectToAction("ERROR", "Cita");
            }
        }

        [HttpPost]
        public IActionResult ActualizarCita(CitaEnt entidad)
        {
            var respuestaModelo = _citaModel.ActualizarCita(entidad);

            if (respuestaModelo?.Codigo == "1")
                return RedirectToAction("LeerCitas", "Cita");
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View();
            }
        }

        [HttpPost]
        public IActionResult EliminarCita(CitaEnt entidad)
        {
            var respuestaModelo = _citaModel.EliminarCita(entidad.IdCita);

            if (respuestaModelo?.Codigo == "1")
                return RedirectToAction("LeerCitas", "Cita");
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View();
            }
        }
    }
}
