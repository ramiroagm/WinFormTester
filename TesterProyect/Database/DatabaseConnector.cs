using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesterProyect.BusinessEntities;
using TesterProyect.BusinessLogic.PasswordManager;

namespace TesterProyect.Database
{
    public class DatabaseConnector
    {
        public static string ConnectionString { get; } = SecretManagerHelper.AccessSecret(ConstantValues.G_ProjectId, ConstantValues.G_ConnectionString).Result ?? throw new InvalidOperationException($"Could not get data for key: {ConstantValues.G_ConnectionString} in project {ConstantValues.G_ProjectId}");
    }
}
