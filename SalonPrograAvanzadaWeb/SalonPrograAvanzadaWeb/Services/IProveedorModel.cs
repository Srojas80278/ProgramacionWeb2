using SalonPrograAvanzadaWeb.Entities;

namespace SalonPrograAvanzadaWeb.Services
{
    public interface IProveedorModel
    {
        Respuesta? RegistrarProveedor(ProveedorEnt entidad);
		ProveedorRespuesta? ConsultarProveedores();
	}
}
