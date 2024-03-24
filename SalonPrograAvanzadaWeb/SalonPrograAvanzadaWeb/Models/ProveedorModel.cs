using SalonPrograAvanzadaWeb.Entities;
using SalonPrograAvanzadaWeb.Services;

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
    }
}
