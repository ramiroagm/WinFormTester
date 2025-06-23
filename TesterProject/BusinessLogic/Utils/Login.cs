using TesterProject.BusinessEntities.Utils;
using TesterProject.BusinessLogic.PasswordManager;
using TesterProject.DataAccess.Utils;

namespace TesterProject.BusinessLogic.Utils
{
    public class Login
    {
        public static async Task<Usuario?> VerifyLoginAsync(string userName, string password)
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
    }
}
