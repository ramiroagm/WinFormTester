using Google.Cloud.SecretManager.V1;

namespace TesterProject.BusinessLogic.PasswordManager
{
    public class SecretManagerHelper
    {
        public static async Task<string> AccessSecret(string projectId, string secretId, string versionId = "latest")
        {
            SecretManagerServiceClient client = SecretManagerServiceClient.Create();
            SecretVersionName secretVersionName = SecretVersionName.FromProjectSecretSecretVersion(projectId, secretId, versionId);
            AccessSecretVersionResponse result = await client.AccessSecretVersionAsync(secretVersionName);
            return result.Payload.Data.ToStringUtf8();
        }
    }
}