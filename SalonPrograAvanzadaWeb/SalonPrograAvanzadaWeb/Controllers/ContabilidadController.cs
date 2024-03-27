using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonPrograAvanzadaWeb.Entities;
using SalonPrograAvanzadaWeb.Models;
using SalonPrograAvanzadaWeb.Services;

namespace SalonPrograAvanzadaWeb.Controllers
{
    public class ContabilidadController(IContabilidadModel _contabilidadModel) : Controller
    {
        [HttpGet]
        public IActionResult ConsultarContabilidad()
        {
            var resp = _contabilidadModel.ConsultarContabilidad();

            if (resp?.Codigo == "00")
                return View(resp?.Datos);
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View(new List<Contabilidad>());
            }
        }
    }
}
