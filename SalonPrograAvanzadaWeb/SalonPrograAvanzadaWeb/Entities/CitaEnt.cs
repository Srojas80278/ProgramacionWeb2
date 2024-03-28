namespace SalonPrograAvanzadaWeb.Entities
{
    public class CitaEnt
    {
        public long IdCita { get; set; }
        public string NombreCliente { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaCita { get; set; }
        public string Estilista { get; set; }
        public long IdServicio { get; set; }
    }
    public class CitaRespuesta
    {
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; }
    }
}
