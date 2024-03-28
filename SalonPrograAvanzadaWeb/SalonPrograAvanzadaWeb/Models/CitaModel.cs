using SalonPrograAvanzadaWeb.Entities;
using SalonPrograAvanzadaWeb.Services;

namespace SalonPrograAvanzadaWeb.Models
{
    public class CitaModel(HttpClient _http, IConfiguration _configuration) : ICitaModel
    {

        public CitaRespuesta? LeerCitas()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Cita/LeerCitas";
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CitaRespuesta>().Result;

            return null;
        }

        public CitaRespuesta? CrearCita(CitaEnt entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Cita/CrearCita";

            JsonContent body = JsonContent.Create(entidad);
            var RespuestaApi = _http.PostAsync(url, body).Result;
            if (RespuestaApi.IsSuccessStatusCode)
                return RespuestaApi.Content.ReadFromJsonAsync<CitaRespuesta>().Result;
            return null;
        }

        public CitaRespuesta? ActualizarCita(CitaEnt entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Cita/ActualizarCita";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CitaRespuesta>().Result;

            return null;
        }

        public CitaRespuesta? EliminarCita(long idCita)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Cita/EliminarCita?idCita=" + idCita;
            var resp = _http.DeleteAsync(url).Result;
            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CitaRespuesta>().Result;

            return null;
        }
    }
}
