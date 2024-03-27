using SalonPrograAvanzadaWeb.Entities;
using SalonPrograAvanzadaWeb.Services;

namespace SalonPrograAvanzadaWeb.Models
{
    public class ServiciosModel(HttpClient _http, IConfiguration _configuration) : IServiciosModel
    {

        public ServiciosRespuesta? ConsultarServicios()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Servicios/ConsultarServicios";
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ServiciosRespuesta>().Result;

            return null;
        }

        public ServiciosRespuesta? RegistrarServicios(ServiciosEnt entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Servicios/RegistrarServicios";

            JsonContent body = JsonContent.Create(entidad);
            var RespuestaApi = _http.PostAsync(url, body).Result;
            if (RespuestaApi.IsSuccessStatusCode)
                return RespuestaApi.Content.ReadFromJsonAsync<ServiciosRespuesta>().Result;
            return null;
        }

        public ServiciosRespuesta? ActualizarServicio(ServiciosEnt entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Servicios/ActualizarServicio";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ServiciosRespuesta>().Result;

            return null;
        }

        public ServiciosRespuesta? EliminarServicio(long idServicio)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Cita/EliminarServicio?idServicio=" +idServicio;
            var resp = _http.DeleteAsync(url).Result;
            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ServiciosRespuesta>().Result;

            return null;
        }
    }
}
