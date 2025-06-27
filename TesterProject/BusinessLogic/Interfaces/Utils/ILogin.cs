using TesterProject.BusinessEntities.Utils;

namespace TesterProject.BusinessLogic.Interfaces.Utils
{
    public interface ILogin
    {
        Task<Usuario?> VerifyLogin(string userName, string password);
        List<int> GetRolesPermitidosParaPagina(string pageRoute);
    }
}