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
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("InsertBugReport", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = command.Parameters.AddWithValue("@TituloReporte", reporte.Titulo);
            _ = command.Parameters.AddWithValue("@MensajeReporte", reporte.Mensaje);
            SqlParameter outputIdParam = new("@IdReporte", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            _ = command.Parameters.Add(outputIdParam);

            connection.Open();
            int guardado = command.ExecuteNonQuery();
            int idReporte = Convert.ToInt32(outputIdParam.Value);
            connection.Close();

            if (reporte.Imagenes != null)
            {
                foreach (ReporteImagenes files in reporte.Imagenes)
                {
                    SqlCommand command2 = new("InsertAdjuntoReporte", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = command2.Parameters.AddWithValue("@IdReporte", idReporte);
                    _ = command2.Parameters.AddWithValue("@NombreAdjunto", files.TextoImagen);
                    connection.Open();
                    _ = command2.ExecuteNonQuery();
                }
            }

            return guardado;
        }
    }
}
