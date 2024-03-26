using SalonPrograAvanzadaWeb.Entities;

namespace SalonPrograAvanzadaWeb.Services
{
    public interface IProveedorModel
    {
		ProveedorRespuesta? ConsultarProveedores();

        Respuesta? RegistrarProveedor(ProveedorEnt entidad);
        Respuesta? BorrarProveedor(long id_proveedor);
    }
}
