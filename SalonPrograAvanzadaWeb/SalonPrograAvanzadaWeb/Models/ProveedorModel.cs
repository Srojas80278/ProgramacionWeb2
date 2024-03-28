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

		public ProveedorRespuesta? ConsultarUnProveedor(long id_proveedor)
		{
			string url = _configuration.GetSection("settings:UrlApi").Value + "api/Proveedor/ConsultarUnProveedor?id_proveedor=" + id_proveedor;
			var resp = _http.GetAsync(url).Result;

			if (resp.IsSuccessStatusCode)
				return resp.Content.ReadFromJsonAsync<ProveedorRespuesta>().Result;

			return null;
		}

		public Respuesta? ActualizarProveedor(ProveedorEnt entidad)
		{
			string url = _configuration.GetSection("settings:UrlApi").Value + "api/Proveedor/ActualizarProveedor";
			JsonContent body = JsonContent.Create(entidad);
			var resp = _http.PutAsync(url, body).Result;

			if (resp.IsSuccessStatusCode)
				return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

			return null;
		}


		public Respuesta? BorrarProveedor(long id_proveedor)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Proveedor/BorrarProveedor?id_proveedor=" + id_proveedor;
            var resp = _http.DeleteAsync(url).Result;
            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

            return null;
        }
    }
}
