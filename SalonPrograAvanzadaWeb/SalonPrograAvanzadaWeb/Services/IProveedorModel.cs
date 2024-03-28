using SalonPrograAvanzadaWeb.Entities;

namespace SalonPrograAvanzadaWeb.Services
{
    public interface IProveedorModel
    {
		ProveedorRespuesta? ConsultarProveedores();
		ProveedorRespuesta? ConsultarUnProveedor(long id_proveedor);

		Respuesta? RegistrarProveedor(ProveedorEnt entidad);
		Respuesta? ActualizarProveedor(ProveedorEnt entidad);

		Respuesta? BorrarProveedor(long id_proveedor);
	}
}
