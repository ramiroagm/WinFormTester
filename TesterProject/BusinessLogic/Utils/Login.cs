using TesterProject.BusinessEntities.Utils;
using TesterProject.BusinessLogic.Interfaces.Utils;
using TesterProject.BusinessLogic.PasswordManager;
using TesterProject.DataAccess.Utils;

namespace TesterProject.BusinessLogic.Utils
{
    public class Login : ILogin
    {
        public async Task<Usuario?> VerifyLogin(string userName, string password)
        {
            AuthService authService = new();
            try
            {
                Usuario? user = await authService.GetUsuario(userName);
                if (user != null)
                {
                    bool match = PasswordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt);
                    if (match)
                    {
                        user.Roles = await authService.GetRolesByUsuarioId(user.Id);
                    }
                    else
                    {
                        user = null;
                    }
                }

                return user;
            }
            catch
            {
                throw;
            }
        }

        public  List<int> GetRolesPermitidosParaPagina(string pageRoute)
        {
            AuthService authService = new();
            try
            {
                return authService.GetRolesPermitidosParaPagina(pageRoute);
            }
            catch
            {
                throw;
            }
        }
    }
}
