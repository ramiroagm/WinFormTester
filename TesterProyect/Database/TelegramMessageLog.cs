using Microsoft.Data.SqlClient;
using TelegramBot;

namespace TesterProyect.Database
{
    public class TelegramMessageLog : DatabaseConnector
    {
        private static readonly string _connectionString = ConnectionString;

        public static void TelegramLogInformation(TelegramResult result)
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("TelegramMessageLog", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@ChatId", result.ChatId);
            command.Parameters.AddWithValue("@Message", result.Message);
            command.Parameters.AddWithValue("@MsgTypeId", result.MsgTypeId);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public static async Task<List<TelegramResult>> GetLogInformation(long ChatId)
        {
            List<TelegramResult> results = [];
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("TelegramGetMessagesById", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ChatId", ChatId);
            connection.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                results.Add(new TelegramResult
                {
                    ChatId = Convert.ToInt64(reader["ChatId"].ToString()),
                    Message = reader["Message"].ToString(),
                    MsgTypeId = Convert.ToInt32(reader["MsgTypeId"].ToString())
                });
            }
            return results;
        }
    }
}