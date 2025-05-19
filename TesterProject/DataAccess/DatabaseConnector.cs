using TesterProject.BusinessEntities.Utils;
using TesterProject.BusinessLogic.PasswordManager;

namespace TesterProject.DataAccess
{
    public class DatabaseConnector
    {
        public static string ConnectionString { get; } = SecretManagerHelper.AccessSecret(ConstantValues.G_ProjectId, ConstantValues.G_ConnectionString).Result ?? throw new InvalidOperationException($"Could not get data for key: {ConstantValues.G_ConnectionString} in project {ConstantValues.G_ProjectId}");
        public static async Task<string> GetConnectionStringAsync()
        {
            return await SecretManagerHelper.AccessSecret(ConstantValues.G_ProjectId, ConstantValues.G_ConnectionString) ?? throw new InvalidOperationException($"Could not get data for key: {ConstantValues.G_ConnectionString} in project {ConstantValues.G_ProjectId}");
        }
    }
}
