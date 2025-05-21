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

        public static async Task<List<InfoCreditoPersona>> ObtenerNucleos(int? idNucleo = null, int? documento = null)
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
                    Direccion = new InfoCreditoDireccionPersona
                    {
                        IdDireccion = Convert.ToInt32(reader["ID_DIRECCION"]),
                        Localidad = new Localidad()
                        {
                            Departamento = new Departamento()
                            {
                                Pais = new Pais()
                                {
                                    NombrePais = reader["NombrePais"]?.ToString() ?? string.Empty
                                },
                                NombreDepartamento = reader["NombreDepartamento"]?.ToString() ?? string.Empty
                            },
                            NombreLocalidad = reader["NombreLocalidad"]?.ToString() ?? string.Empty
                        },
                    },
                    Contacto = new InfoCreditoContactoPersona
                    {
                        TelMovil = reader["TEL_MOVIL"]?.ToString() ?? string.Empty,
                        TelFijo = reader["TEL_FIJO"]?.ToString() ?? string.Empty,
                        CorreoElectronico = reader["CORREO_ELECTRONICO"]?.ToString() ?? string.Empty,
                        CorreoElectronicoAlt = reader["CORREO_ELECTRONICO_ALT"]?.ToString() ?? string.Empty,
                        WhatsAppURL = reader["WHATSAPP_URL"]?.ToString() ?? string.Empty,
                        Observaciones = reader["OBSERVACIONES_CONTACTO"]?.ToString() ?? string.Empty
                    },
                    FechaNacimiento = Convert.ToDateTime(reader["FECHA_NACIMIENTO"])
                });
            }
            return personas;
        }

        private static void AddParameter(SqlCommand command, string parameterName, object? value)
        {
            _ = command.Parameters.AddWithValue(parameterName, value ?? DBNull.Value);
        }
    }
}