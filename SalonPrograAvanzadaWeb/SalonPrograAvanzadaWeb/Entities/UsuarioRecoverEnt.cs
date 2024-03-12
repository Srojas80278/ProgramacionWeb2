namespace SalonPrograAvanzadaWeb.Entities
{
    public class UsuarioRecoverEnt
    {
        public string Codigo { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordUser { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}