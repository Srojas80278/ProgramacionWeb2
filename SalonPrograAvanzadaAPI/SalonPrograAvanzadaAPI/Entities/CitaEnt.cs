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
    public class CitaRespuesta
    {
        public CitaRespuesta()
        {
            Codigo = "1"; //Te retorno 1 si fue exitosa la operación.
            Mensaje = string.Empty;
            Dato = null;
            Datos = null;
        }

        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public CitaEnt? Dato { get; set; }
        public List<CitaEnt>? Datos { get; set; }
    }
}