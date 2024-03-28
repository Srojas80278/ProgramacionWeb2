using SalonPrograAvanzadaWeb.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace SalonPrograAvanzadaWeb.Models
{
    public interface IUsuarioModel
    {
        public UsuarioEnt? IniciarSesion(UsuarioEnt entidad);

        public List<SelectListItem>? ConsultNationality();
        public int RegisterAccount(UsuarioEnt entidad);
        public int RecoverAccount(UsuarioEnt entidad);
        public int? ChangePassword(UsuarioRecoverEnt entidad);

        public int UpdateState(UsuarioEnt entidad);

    }
}