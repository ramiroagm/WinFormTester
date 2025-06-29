﻿using Microsoft.Data.SqlClient;
using TesterProject.BusinessEntities.InfoCredito;
using TesterProject.BusinessEntities.Utils;

namespace TesterProject.DataAccess.InfoCredito
{
    public class PersonasDb : DatabaseConnector
    {
        private static readonly string _connectionString = ConnectionString;

        public static async Task<int> CrearPersonaAsync(InfoCreditoPersona persona)
        {
            // Se utiliza el llamado asyncrono de secret manager para evitar bloqueos desde Blazor
            string? _connectionString = await GetConnectionStringAsync();
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("InfoCredito_InsertPersona", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            _ = command.Parameters.AddWithValue("@DOCUMENTO", persona.Documento);
            _ = command.Parameters.AddWithValue("@PRIMER_NOMBRE", persona.PrimerNombre);
            _ = command.Parameters.AddWithValue("@SEGUNDO_NOMBRE", (object?)persona.SegundoNombre ?? DBNull.Value);
            _ = command.Parameters.AddWithValue("@PRIMER_APELLIDO", persona.PrimerApellido);
            _ = command.Parameters.AddWithValue("@SEGUNDO_APELLIDO", (object?)persona.SegundoApellido ?? DBNull.Value);

            _ = command.Parameters.AddWithValue("@ID_LOCALIDAD", persona.Direccion?.Localidad.IdLocalidad);
            _ = command.Parameters.AddWithValue("@CALLE", (object?)persona.Direccion?.Calle ?? DBNull.Value);
            _ = command.Parameters.AddWithValue("@NUMERO", persona.Direccion?.Numero);
            _ = command.Parameters.AddWithValue("@MANZANA", persona.Direccion?.Manzana);
            _ = command.Parameters.AddWithValue("@SOLAR", persona.Direccion?.Solar);
            _ = command.Parameters.AddWithValue("@OBSERVACIONES", persona.Direccion?.Observaciones);

            _ = command.Parameters.AddWithValue("@TEL_MOVIL", (object?)persona.Contacto?.TelMovil ?? DBNull.Value);
            _ = command.Parameters.AddWithValue("@TEL_FIJO", (object?)persona.Contacto?.TelFijo ?? DBNull.Value);
            _ = command.Parameters.AddWithValue("@CORREO_ELECTRONICO", (object?)persona.Contacto?.CorreoElectronico ?? DBNull.Value);
            _ = command.Parameters.AddWithValue("@CORREO_ELECTRONICO_ALT", (object?)persona.Contacto?.CorreoElectronicoAlt ?? DBNull.Value);
            _ = command.Parameters.AddWithValue("@WHATSAPP_URL", (object?)persona.Contacto?.WhatsAppURL ?? DBNull.Value);
            _ = command.Parameters.AddWithValue("@OBSERVACIONES_CONTACTO", (object?)persona.Contacto?.Observaciones ?? DBNull.Value);

            _ = command.Parameters.AddWithValue("@FECHA_NACIMIENTO", persona.FechaNacimiento);

            connection.Open();
            return command.ExecuteNonQuery();
        }

        public static async Task<List<InfoCreditoPersona>> ObtenerPersonas(int? documento = null)
        {
            try
            {
                List<InfoCreditoPersona> personas = [];

                // Se utiliza el llamado asyncrono de secret manager para evitar bloqueos desde Blazor
                string? _connectionString = await GetConnectionStringAsync();
                using SqlConnection connection = new(_connectionString);
                SqlCommand command = new("InfoCredito_GetPersona", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                AddParameter(command, "@DOCUMENTO", documento);
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Pais? pais = new()
                    {
                        NombrePais = reader["NombrePais"]?.ToString() ?? string.Empty
                    };

                    Departamento? departamento = new()
                    {
                        NombreDepartamento = reader["NombreDepartamento"]?.ToString() ?? string.Empty,
                        Pais = pais
                    };

                    Localidad? localidad = new()
                    {
                        NombreLocalidad = reader["NombreLocalidad"]?.ToString() ?? string.Empty,
                        Departamento = departamento
                    };

                    InfoCreditoDireccionPersona? direccion = new()
                    {
                        IdDireccion = Convert.ToInt32(reader["ID_DIRECCION"]),
                        Calle = reader["CALLE"]?.ToString() ?? string.Empty,
                        Numero = reader["NUMERO"] != DBNull.Value ? Convert.ToInt32(reader["NUMERO"]) : 0,
                        Manzana = reader["MANZANA"] != DBNull.Value ? Convert.ToInt32(reader["MANZANA"]) : 0,
                        Solar = reader["SOLAR"] != DBNull.Value ? Convert.ToInt32(reader["SOLAR"]) : 0,
                        Localidad = localidad
                    };

                    InfoCreditoContactoPersona? contacto = new()
                    {
                        TelMovil = reader["TEL_MOVIL"]?.ToString() ?? string.Empty,
                        TelFijo = reader["TEL_FIJO"]?.ToString() ?? string.Empty,
                        CorreoElectronico = reader["CORREO_ELECTRONICO"]?.ToString() ?? string.Empty,
                        CorreoElectronicoAlt = reader["CORREO_ELECTRONICO_ALT"]?.ToString() ?? string.Empty,
                        WhatsAppURL = reader["WHATSAPP_URL"]?.ToString() ?? string.Empty,
                        Observaciones = reader["OBSERVACIONES"]?.ToString() ?? string.Empty
                    };

                    personas.Add(new InfoCreditoPersona
                    {
                        IdPersona = Convert.ToInt32(reader["ID_PERSONA"]),
                        Documento = Convert.ToInt32(reader["DOCUMENTO"]),
                        PrimerNombre = reader["PRIMER_NOMBRE"]?.ToString() ?? string.Empty,
                        SegundoNombre = reader["SEGUNDO_NOMBRE"] as string ?? string.Empty,
                        PrimerApellido = reader["PRIMER_APELLIDO"]?.ToString() ?? string.Empty,
                        SegundoApellido = reader["SEGUNDO_APELLIDO"] as string ?? string.Empty,
                        FechaNacimiento = Convert.ToDateTime(reader["FECHA_NACIMIENTO"]),
                        Direccion = direccion,
                        Contacto = contacto
                    });
                }
                return personas;
            }
            catch
            {
                throw new Exception();
            }
        }

        private static void AddParameter(SqlCommand command, string parameterName, object? value)
        {
            _ = command.Parameters.AddWithValue(parameterName, value ?? DBNull.Value);
        }
    }
}