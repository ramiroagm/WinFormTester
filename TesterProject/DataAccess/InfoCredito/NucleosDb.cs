using Microsoft.Data.SqlClient;
using TesterProject.BusinessEntities.InfoCredito;
using TesterProject.BusinessEntities.Utils;

namespace TesterProject.DataAccess.InfoCredito
{
    public class NucleosDb : DatabaseConnector
    {
        private static readonly string _connectionString = ConnectionString;

        public static void CrearNucleo(InfoCreditoNucleo nucleo)
        {
            foreach (InfoCreditoPersona persona in nucleo.Personas)
            {
                using SqlConnection connection = new(_connectionString);
                SqlCommand command = new("InfoCredito_InsertNucleo", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _ = command.Parameters.AddWithValue("@DOCUMENTO", persona.Documento);
                _ = command.Parameters.AddWithValue("@ID_RELACION", nucleo.Relacion.IdRelacion);

                connection.Open();
                _ = command.ExecuteNonQuery();
            }
        }

        public static async Task<List<InfoCreditoPersona>> ObtenerPersonasPorNucleo(int? idNucleo = null, int? documento = null)
        {
            List<InfoCreditoPersona> personas = [];
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("InfoCredito_GetPersonasPorNucleo", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            AddParameter(command, "@ID_NUCLEO", idNucleo);
            AddParameter(command, "@DOCUMENTO", documento);

            connection.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                personas.Add(new InfoCreditoPersona
                {
                    Documento = Convert.ToInt32(reader["DOCUMENTO"]),
                    PrimerNombre = reader["PRIMER_NOMBRE"]?.ToString() ?? string.Empty,
                    SegundoNombre = reader["SEGUNDO_NOMBRE"] as string ?? string.Empty,
                    PrimerApellido = reader["PRIMER_APELLIDO"]?.ToString() ?? string.Empty,
                    SegundoApellido = reader["SEGUNDO_APELLIDO"] as string ?? string.Empty,
                    FechaNacimiento = Convert.ToDateTime(reader["FECHA_NACIMIENTO"])
                });
            }
            return personas;
        }

        public static async Task<List<InfoCreditoNucleo>> ObtenerNucleo(int? idNucleo = null, int? documento = null)
        {
            List<InfoCreditoNucleo> nucleos = new();
            string? _connectionString = await GetConnectionStringAsync();
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("InfoCredito_GetNucleo", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            if (idNucleo != null)
            {
                AddParameter(command, "@ID_NUCLEO", idNucleo); 
            }

            if (documento != null)
            {
                AddParameter(command, "@DOCUMENTO", documento); 
            }

            connection.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                nucleos.Add(new InfoCreditoNucleo
                {
                    IdNucleo = Convert.ToInt32(reader["ID_NUCLEO"]),
                    Personas =
                    [
                        new() {
                            Documento = Convert.ToInt32(reader["DOCUMENTO"]),
                            PrimerNombre = reader["PRIMER_NOMBRE"]?.ToString() ?? string.Empty,
                            SegundoNombre = reader["SEGUNDO_NOMBRE"] as string ?? string.Empty,
                            PrimerApellido = reader["PRIMER_APELLIDO"]?.ToString() ?? string.Empty,
                            SegundoApellido = reader["SEGUNDO_APELLIDO"] as string ?? string.Empty,
                            FechaNacimiento = Convert.ToDateTime(reader["FECHA_NACIMIENTO"])
                        }
                    ],
                    Relacion = new Relacion
                    {
                        IdRelacion = Convert.ToInt32(reader["IdRelacion"]),
                        DescripcionRelacion = reader["NombreRelacion"]?.ToString() ?? string.Empty
                    }
                });
            }
            return nucleos;
        }

        private static void AddParameter(SqlCommand command, string parameterName, object? value)
        {
            _ = command.Parameters.AddWithValue(parameterName, value ?? DBNull.Value);
        }
    }
}