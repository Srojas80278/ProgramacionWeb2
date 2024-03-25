﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonPrograAvanzadaWeb.Entities;
using SalonPrograAvanzadaWeb.Services;

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
                return RedirectToAction("ConsultarProductos", "Producto");
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
	}
}