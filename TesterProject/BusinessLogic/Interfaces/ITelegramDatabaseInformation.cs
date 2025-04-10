using TesterProject.BusinessEntities;

namespace TesterProject.BusinessLogic.Interfaces
{
    public interface ITelegramDatabaseInformation
    {
        void InsertInformation(TelegramResult result);
        Task<IEnumerable<TelegramResult>> GetInformation(long ChatId);
    }
}
