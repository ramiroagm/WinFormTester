using TesterProject.BusinessEntities.Utils;
using TesterProject.BusinessLogic.PasswordManager;

namespace TesterProject.DataAccess
{
    public class DatabaseConnector
    {
        public static string? ConnectionString { get; }

        public static Task<string?> GetConnectionStringAsync()
        {
            return Task.FromResult(CredentialManagerHelper.ReadSecret(ConstantValues.CM_ConnectionString));
        }

        public static string? GetConnectionString()
        {
            return CredentialManagerHelper.ReadSecret(ConstantValues.CM_ConnectionString);
        }

        [Obsolete("Reutilizar este método solo para consultas por GCLOUD")]
        public static async Task<string> GetGoogleCloudConnectionStringAsync()
        {
            return await SecretManagerHelper.AccessSecret(ConstantValues.G_ProjectId, ConstantValues.G_ConnectionString) ?? throw new InvalidOperationException($"Could not get data for key: {ConstantValues.G_ConnectionString} in project {ConstantValues.G_ProjectId}");
        }
    }
}