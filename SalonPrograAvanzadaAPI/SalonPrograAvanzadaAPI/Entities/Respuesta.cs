namespace SalonPrograAvanzadaAPI.Entities
{
    public class Respuesta
    {
        public Respuesta()
        {
            Codigo = "1"; //Te retorno 1 si fue exitosa la operación.
            Mensaje = "La operación ha sido exitosa";
        }
        public string Codigo { get; set; }
        public string Mensaje { get; set; }

    }
}
