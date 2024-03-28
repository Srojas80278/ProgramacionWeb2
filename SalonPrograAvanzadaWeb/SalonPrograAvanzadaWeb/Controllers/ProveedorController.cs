using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonPrograAvanzadaWeb.Entities;
using SalonPrograAvanzadaWeb.Services;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;

namespace SalonPrograAvanzadaWeb.Controllers
{
    public class ProveedorController(IProveedorModel _proveedorModel) : Controller
    {
        //Abre la vista:
        [HttpGet]
        public IActionResult RegistrarProveedor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarProveedor(ProveedorEnt entidad)
        {
            var RespuestaApi = _proveedorModel.RegistrarProveedor(entidad);

            if (RespuestaApi?.Codigo == "1")
                return RedirectToAction("ConsultarProveedores", "Proveedor");
            else
            {
                return RedirectToAction("ERROR", "Producto");
            }
        }

		[HttpGet]
		public IActionResult ConsultarProveedores()
		{
			var respuestaModelo = _proveedorModel.ConsultarProveedores();

			if (respuestaModelo?.Codigo == "1")
				return View(respuestaModelo?.Datos);
			else
			{
				ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
				return View(new List<ProveedorEnt>());
			}
		}

		[HttpGet]
		public IActionResult ActualizarProveedor(long id_proveedor)
		{
			var respuestaModelo = _proveedorModel.ConsultarUnProveedor(id_proveedor);
			return View(respuestaModelo?.Dato);
		}

		[HttpPost]
		public IActionResult ActualizarProveedor(ProveedorEnt entidad)
		{
			var respuestaModelo = _proveedorModel.ActualizarProveedor(entidad);

			if (respuestaModelo?.Codigo == "1")
				return RedirectToAction("ConsultarProveedores", "Proveedor");
			else
			{
				ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
				return View();
			}
		}

		[HttpPost]
        public IActionResult BorrarProveedor(ProveedorEnt entidad)
        {
            var respuestaModelo = _proveedorModel.BorrarProveedor(entidad.id_proveedor);

            if (respuestaModelo?.Codigo == "1")
                return RedirectToAction("ConsultarProveedores", "Proveedor");
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View();
            }
        }
    }
}
