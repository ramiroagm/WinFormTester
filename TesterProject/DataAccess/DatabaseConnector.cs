using TesterProject.BusinessEntities.Utils;
using TesterProject.BusinessLogic.PasswordManager;

namespace TesterProject.DataAccess
{
    public class DatabaseConnector
    {
        public static string? ConnectionString { get; }
        public static string? GetConnectionString()
        {
            // Desde aquí se debe llamar la conexión de secretos correcta en deploy para el momento.
            //return GetCredentialManagerConnectionString();
            return GetGoogleCloudConnectionString();
        }

        public static Task<string?> GetConnectionStringAsync()
        {
            // Desde aquí se debe llamar a la conexión de secretos (async) correcta en deploy para el momento.
            //return GetCredentialManagerConnectionStringAsync();
            return GetGoogleCloudConnectionStringAsync();
        }

        private static async Task<string?> GetGoogleCloudConnectionStringAsync()
        {
            return await SecretManagerHelper.AccessSecretAsync(ConstantValues.G_ProjectId, ConstantValues.G_ConnectionString) ?? throw new InvalidOperationException($"Could not get data for key: {ConstantValues.G_ConnectionString} in project {ConstantValues.G_ProjectId}");
        }

        private static string? GetGoogleCloudConnectionString()
        {
            return SecretManagerHelper.AccessSecret(ConstantValues.G_ProjectId, ConstantValues.G_ConnectionString) ?? throw new InvalidOperationException($"Could not get data for key: {ConstantValues.G_ConnectionString} in project {ConstantValues.G_ProjectId}");
        }

        private static async Task<string?> GetCredentialManagerConnectionStringAsync()
        {
            return await Task.FromResult(CredentialManagerHelper.ReadSecret(ConstantValues.CM_ConnectionString));
        }

        private static string? GetCredentialManagerConnectionString()
        {
            return CredentialManagerHelper.ReadSecret(ConstantValues.CM_ConnectionString);
        }
    }
}