using System.Data;
using Microsoft.Data.SqlClient;
using TesterProject.BusinessEntities.Utils;

namespace TesterProject.DataAccess.Utils
{
    public class BugReport : DatabaseConnector
    {
        private static readonly string _connectionString = ConnectionString;

        public static async Task<int> CrearBug(Bug reporte)
        {
            // Se utiliza el llamado asyncrono de secret manager para evitar bloqueos desde Blazor
            string? _connectionString = await GetConnectionStringAsync();
            int guardado = -10;
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("InsertBugReport", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            _ = command.Parameters.AddWithValue("@TituloReporte", reporte.Titulo);
            _ = command.Parameters.AddWithValue("@MensajeReporte", reporte.Mensaje);
            SqlParameter outputIdParam = new("@IdReporte", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outputIdParam);

            connection.Open();
            guardado = command.ExecuteNonQuery();
            int idReporte = Convert.ToInt32(outputIdParam.Value);
            connection.Close();

            if (reporte.Imagenes != null)
            {
                foreach (ReporteImagenes files in reporte.Imagenes)
                {
                    _ = new SqlCommand("InsertAdjuntoBugReport", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    _ = command.Parameters.AddWithValue("@IdReporte", idReporte);
                    _ = command.Parameters.AddWithValue("@NombreAdjunto", reporte.Titulo);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return guardado;
        }
    }
}
