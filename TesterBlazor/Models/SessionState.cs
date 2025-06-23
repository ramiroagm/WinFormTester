using TesterProject.BusinessEntities.Utils;

namespace TesterBlazor.Models
{
    public class SessionState
    {
        public Usuario? UsuarioActual { get; set; }
        public bool IsAuthenticated => UsuarioActual != null;
    }
}
