using TelegramBot;
using TesterProyect.BusinessLogic.Interfaces;

namespace TesterProyect.BusinessLogic.TelegramBot
{
    public class TelegramDatabaseInformation : ITelegramDatabaseInformation
    {
        public void InsertInformation(TelegramResult result) => Database.TelegramMessageLog.TelegramLogInformation(result);

        public async Task<IEnumerable<TelegramResult>> GetInformation(long ChatId)
        {
            return await Database.TelegramMessageLog.GetLogInformation(ChatId);
        }
    }
}
