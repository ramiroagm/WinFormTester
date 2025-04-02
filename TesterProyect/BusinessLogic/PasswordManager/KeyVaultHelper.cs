using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace TesterProyect.BusinessLogic.PasswordManager
{
    public class KeyVaultHelper
    {
        public static async Task<string> GetTokenFromKeyVaultAsync(string secretName)
        {
            var client = new SecretClient(new Uri("https://testerappkeys.vault.azure.net/"), new DefaultAzureCredential());
            KeyVaultSecret secret = await client.GetSecretAsync(secretName);
            return secret.Value;
        }
    }
}
