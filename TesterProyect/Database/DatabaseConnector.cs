using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterProyect.Database
{
    public class DatabaseConnector
    {
        // TODO: Encrypt connection string
        private const string _connectionString = "Data Source=MP200;TrustServerCertificate=True;Integrated Security=SSPI;Initial Catalog=TesterGen";
        public static string ConnectionString => _connectionString;
    }
}
