using Telegram.Bot.Types;
using TesterProject.BusinessEntities.Telegram;

namespace TesterProject.BusinessLogic.Interfaces.Telegram
{
    public interface ITelegramDatabaseInformation
    {
        void InsertInformation(TelegramResult result);
        Task<IEnumerable<TelegramResult>> GetInformation(long? ChatId, string? UserName, DateTime? MsgSentTime);
        Task<TelegramResult> GetSingleInformation(CallbackQuery query);
    }
}
