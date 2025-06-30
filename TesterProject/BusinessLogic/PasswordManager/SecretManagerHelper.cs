using Google.Cloud.SecretManager.V1;

namespace TesterProject.BusinessLogic.PasswordManager
{
    public class SecretManagerHelper
    {
        public static async Task<string> AccessSecretAsync(string projectId, string secretId, string versionId = "latest")
        {
            try
            {
                SecretManagerServiceClient client = SecretManagerServiceClient.Create();
                SecretVersionName secretVersionName = SecretVersionName.FromProjectSecretSecretVersion(projectId, secretId, versionId);
                AccessSecretVersionResponse result = await client.AccessSecretVersionAsync(secretVersionName);
                return result.Payload.Data.ToStringUtf8();
            }
            catch
            {
                throw;
            }
        }

        public static string AccessSecret(string projectId, string secretId, string versionId = "latest")
        {
            try
            {
                SecretManagerServiceClient client = SecretManagerServiceClient.Create();
                SecretVersionName secretVersionName = SecretVersionName.FromProjectSecretSecretVersion(projectId, secretId, versionId);
                AccessSecretVersionResponse result = client.AccessSecretVersion(secretVersionName);
                return result.Payload.Data.ToStringUtf8();
            }
            catch
            {
                throw;
            }
        }
    }
}