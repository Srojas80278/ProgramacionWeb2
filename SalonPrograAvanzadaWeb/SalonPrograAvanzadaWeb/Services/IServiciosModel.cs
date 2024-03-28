using SalonPrograAvanzadaWeb.Entities;

namespace SalonPrograAvanzadaWeb.Services
{
    public interface IServiciosModel
    {

        ServiciosRespuesta? ConsultarServicios();

        ServiciosRespuesta? RegistrarServicios(ServiciosEnt entidad);

        ServiciosRespuesta? ActualizarServicio(ServiciosEnt entidad);

        ServiciosRespuesta? EliminarServicio(long idServicio);

    }
}
