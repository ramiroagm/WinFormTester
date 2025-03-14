using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TesterAPI.Model;

namespace TesterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet(Name = "GetUsers")]
        public List<Users> Get()
        {
            string connectionString = "Data Source=MP200;TrustServerCertificate=True;Integrated Security=SSPI;Initial Catalog=TesterGen;Max Pool Size=100";
            using SqlConnection connection = new(connectionString);
            // TESTING ONLY
            SqlCommand sqlCommand = new("SELECT Test_UserName FROM Test_Users", connection);
            connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Users> users = [];
            while (reader.Read())
            {
                Users user = new()
                {
                    UserName = reader.GetString(0)
                };
                users.Add(user);
            }
            return users;
        }
    }
}