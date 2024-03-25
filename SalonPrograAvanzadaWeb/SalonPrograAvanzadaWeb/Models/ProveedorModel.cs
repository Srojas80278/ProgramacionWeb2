using Microsoft.AspNetCore.Http;
using SalonPrograAvanzadaWeb.Entities;
using SalonPrograAvanzadaWeb.Services;
using System.Net.Http.Headers;

namespace SalonPrograAvanzadaWeb.Models
{
	public class ProveedorModel(HttpClient _http, IConfiguration _configuration) : IProveedorModel
    {

        public Respuesta? RegistrarProveedor(ProveedorEnt entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Proveedor/RegistrarProveedor";

            JsonContent body = JsonContent.Create(entidad);
            var RespuestaApi = _http.PostAsync(url, body).Result;
            if (RespuestaApi.IsSuccessStatusCode)
                return RespuestaApi.Content.ReadFromJsonAsync<Respuesta>().Result;
            return null;
        }

		public ProveedorRespuesta? ConsultarProveedores()
		{
			string url = _configuration.GetSection("settings:UrlApi").Value + "api/Proveedor/ConsultarProveedores";
			var resp = _http.GetAsync(url).Result;

			if (resp.IsSuccessStatusCode)
				return resp.Content.ReadFromJsonAsync<ProveedorRespuesta>().Result;

			return null;
		}
	}
}
