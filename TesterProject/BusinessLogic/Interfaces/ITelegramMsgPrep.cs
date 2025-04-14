using Telegram.Bot.Types;
using Telegram.Bot;
using TesterProject.BusinessEntities;

namespace TesterProject.BusinessLogic.Interfaces
{
    public interface ITelegramMsgPrep
    {
        void PrepareMessage(TelegramBotClient bot, CallbackQuery query, TelegramResult result);
    }
}