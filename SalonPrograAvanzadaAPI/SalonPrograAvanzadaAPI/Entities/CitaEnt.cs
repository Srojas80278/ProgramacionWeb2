namespace SalonPrograAvanzadaAPI.Entities
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
}