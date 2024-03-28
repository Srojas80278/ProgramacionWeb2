using SalonPrograAvanzadaWeb.Entities;

namespace SalonPrograAvanzadaWeb.Services
{
    public interface ICitaModel
    {
        CitaRespuesta? LeerCitas();

        CitaRespuesta? CrearCita(CitaEnt entidad);

        CitaRespuesta? ActualizarCita(CitaEnt entidad);

        CitaRespuesta? EliminarCita(long idCita);

    }
}
