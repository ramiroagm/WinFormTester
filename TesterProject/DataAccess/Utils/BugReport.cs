using System.Data;
using Microsoft.Data.SqlClient;
using TesterProject.BusinessEntities.Utils;

namespace TesterProject.DataAccess.Utils
{
    public class BugReport : DatabaseConnector
    {
        private static readonly string _connectionString = ConnectionString;

        public static async Task CrearBug(Bug reporte)
        {
            // Se utiliza el llamado asyncrono de secret manager para evitar bloqueos desde Blazor
            string? _connectionString = await GetConnectionStringAsync();
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
            command.ExecuteNonQuery();

            if (reporte.Imagenes != null)
            {
                foreach (ReporteImagenes files in reporte.Imagenes)
                {
                    SqlCommand secCommand = new("InsertAdjuntoBugReport", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    // TODO ARREGLAR
                    _ = command.Parameters.AddWithValue("@NombreAdjunto", files.TextoImagen);
                    _ = command.Parameters.AddWithValue("@RutaAdjunto", files.TextoImagen);
                    _ = command.Parameters.AddWithValue("@TituloReporte", reporte.Titulo);
                } 
            }
        }
    }
}
