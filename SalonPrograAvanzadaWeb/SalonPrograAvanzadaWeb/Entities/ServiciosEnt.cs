using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SalonPrograAvanzadaWeb.Entities
{
    public class ServiciosEnt
    {
        public long IdServicio { get; set; }
        public string TituloServicio { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public string UrlImagen { get; set; }

    }
    public class ServiciosRespuesta
    {
        public ServiciosRespuesta()
        {
            Codigo = "1"; //Te retorno 1 si fue exitosa la operación.
            Mensaje = string.Empty;
            Dato = null;
            Datos = null;
        }
    public string Codigo { get; set; }
    public string Mensaje { get; set; }
    public ServiciosEnt? Dato { get; set; }
    public List<ServiciosEnt>? Datos { get; set; }
    }
}

