namespace SalonPrograAvanzadaWeb.Entities
{
    public class Contabilidad
    {
        public long id_movimiento { get; set; }
        public string? descripcion_movimiento { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha_Movimiento { get; set; }
        public string? tipo_movimiento { get; set; }
        public string? tipo_transaccion { get; set; }
        public decimal? saldo_pendiente { get; set; }
        public string? nombre_producto { get; set; }
        public string? nombre_cliente { get; set; }
        public string? nombre_usuario { get; set; }

    }
    public class ContabilidadRespuesta
    {
        public ContabilidadRespuesta()
        {
            Codigo = "00";
            Mensaje = string.Empty;
            Dato = null;
            Datos = null;
        }

        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public Contabilidad? Dato { get; set; }
        public List<Contabilidad>? Datos { get; set; }
    }
}

