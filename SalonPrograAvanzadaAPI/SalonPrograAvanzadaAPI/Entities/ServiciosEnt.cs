namespace SalonPrograAvanzadaAPI.Entities
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
        public string Codigo { get; set; } 
        public string Mensaje { get; set; }
        public object Datos { get; set; } // Considera usar un tipo más específico si es posible
    }
}