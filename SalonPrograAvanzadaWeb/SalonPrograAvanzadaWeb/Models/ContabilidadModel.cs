
using Microsoft.AspNetCore.Http;
using SalonPrograAvanzadaWeb.Entities;
using SalonPrograAvanzadaWeb.Services;
using System.Net.Http.Headers;

namespace SalonPrograAvanzadaWeb.Models
{
    public class ContabilidadModel(HttpClient _http, IConfiguration _configuration) : IContabilidadModel
    {
        public ContabilidadRespuesta? ConsultarContabilidad()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Contabilidad/ConsultarContabilidad";
          
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ContabilidadRespuesta>().Result;

            return null;
        }

    }
}

