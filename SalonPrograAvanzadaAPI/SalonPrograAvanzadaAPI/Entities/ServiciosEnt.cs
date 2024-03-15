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
}