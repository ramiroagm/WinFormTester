using Microsoft.Data.SqlClient;
using TesterProject.BusinessEntities.Utils;

namespace TesterProject.DataAccess.Utils
{
    public class Ubicacion : DatabaseConnector
    {
        public static async Task<List<Pais>> ObtenerPaises()
        {
            List<Pais> paises = [];

            // Se utiliza el llamado asyncrono de secret manager para evitar bloqueos desde Blazor
            string? _connectionString = await GetConnectionStringAsync();
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("GetPaises", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            connection.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Pais pais = new()
                {
                    NombrePais = reader["Nombre"]?.ToString() ?? string.Empty,
                    IdPais = Convert.ToInt32(reader["IdPais"].ToString())
                };
                paises.Add(pais);
            }

            return paises;
        }

        public static async Task<List<Departamento>> ObtenerDepartamentos(int pais)
        {
            List<Departamento> departamentos = [];

            // Se utiliza el llamado asyncrono de secret manager para evitar bloqueos desde Blazor
            string? _connectionString = await GetConnectionStringAsync();
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("GetDepartamentosPorPais", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@IdPais", pais);

            connection.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Departamento departamento = new()
                {
                    NombreDepartamento = reader["Nombre"]?.ToString() ?? string.Empty,
                    IdDepartamento = Convert.ToInt32(reader["IdDepartamento"].ToString()),
                };

                departamentos.Add(departamento);
            }

            return departamentos;
        }

        public static async Task<List<Localidad>> ObtenerLocalidades(int departamento)
        {
            List<Localidad> localidades = [];

            // Se utiliza el llamado asyncrono de secret manager para evitar bloqueos desde Blazor
            string? _connectionString = await GetConnectionStringAsync();
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("GetLocalidadesPorDepartamento", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@IdDepartamento", departamento);

            connection.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Localidad localidad = new()
                {
                    IdLocalidad = Convert.ToInt32(reader["IdLocalidad"].ToString()),
                    NombreLocalidad = reader["Nombre"]?.ToString() ?? string.Empty
                };

                localidades.Add(localidad);
            }

            return localidades;
        }
    }
}