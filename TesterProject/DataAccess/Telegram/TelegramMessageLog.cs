using Microsoft.Data.SqlClient;
using TesterProject.BusinessEntities.Telegram;
using TesterProject.BusinessEntities.Utils;

namespace TesterProject.DataAccess.Telegram
{
    public class TelegramMessageLog : DatabaseConnector
    {
        private static readonly string _connectionString = ConnectionString ?? throw new InvalidOperationException("ConnectionString cannot be null.");

        public static void TelegramLogInformation(TelegramResult result)
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("TelegramMessageLog", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@chatId", result.ChatId);
            command.Parameters.AddWithValue("@message", result.Message);
            command.Parameters.AddWithValue("@messageTypeId", result.MsgTypeId);
            command.Parameters.AddWithValue("@userName", result.UserName);
            command.Parameters.AddWithValue("@msgSentTime", result.MsgSentTime);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public static async Task<List<TelegramResult>> GetLogInformation(long? ChatId, string? UserName, DateTime? MsgSentTime)
        {
            List<TelegramResult> results = [];
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("TelegramGetMessages", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            AddParameter(command, "@chatId", ChatId);
            AddParameter(command, "@userName", UserName);
            AddParameter(command, "@msgSentTime", MsgSentTime);

            connection.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                results.Add(new TelegramResult
                {
                    ChatId = Convert.ToInt64(reader["ChatId"].ToString()),
                    Message = reader["Message"].ToString(),
                    MsgTypeId = Convert.ToInt32(reader["TypeId"].ToString()),
                    MsgSentTime = Convert.ToDateTime(reader["MsgSentTime"].ToString()),
                    RequestMediaType = (int)RequestMediaType.TEXT,
                    UserName = reader["UserName"].ToString()
                });
            }
            return results;
        }

        private static void AddParameter(SqlCommand command, string parameterName, object? value)
        {
            command.Parameters.AddWithValue(parameterName, value ?? DBNull.Value);
        }
    }
}