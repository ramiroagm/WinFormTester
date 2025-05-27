using Microsoft.Data.SqlClient;
using TesterProject.BusinessEntities.Utils;

namespace TesterProject.DataAccess.Utils
{
    public class Personas : DatabaseConnector
    {
        public static async Task<List<Relacion>> ObtenerRelaciones()
        {
            List<Relacion> Relaciones = [];

            // Se utiliza el llamado asyncrono de secret manager para evitar bloqueos desde Blazor
            string? _connectionString = await GetConnectionStringAsync();
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("GetRelaciones", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            connection.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Relacion relacion = new()
                {
                    DescripcionRelacion = reader["NombreRelacion"]?.ToString() ?? string.Empty,
                    IdRelacion = Convert.ToInt32(reader["IdRelacion"].ToString())
                };
                Relaciones.Add(relacion);
            }

            return Relaciones;
        }
    }
}
