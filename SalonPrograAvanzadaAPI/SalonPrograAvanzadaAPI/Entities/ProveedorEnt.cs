namespace SalonPrograAvanzadaAPI.Entities
{
	public class ProveedorEnt
	{
		public long id_proveedor { get; set; }
		public string nombre_proveedor { get; set; } = string.Empty;
		public string numero_contacto { get; set; } = string.Empty;
		public string email { get; set; } = string.Empty;
		public string direccion { get; set; } = string.Empty;

	}

	public class ProveedorRespuesta
	{
		public ProveedorRespuesta()
		{
			Codigo = "1"; //Te retorno 1 si fue exitosa la operación.
			Mensaje = string.Empty;
			Dato = null;
			Datos = null;
		}

		public string Codigo { get; set; }
		public string Mensaje { get; set; }
		public ProveedorEnt? Dato { get; set; }
		public List<ProveedorEnt>? Datos { get; set; }
	}
}
