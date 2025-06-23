namespace TesterProject.BusinessEntities.Utils
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public DateTime? FechaCreacion { get; set; }
        public List<Rol> Roles { get; set; } = [];
    } 
}