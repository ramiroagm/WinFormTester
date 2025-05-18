using Telegram.Bot.Types;
using Telegram.Bot;
using TesterProject.BusinessEntities.Telegram;

namespace TesterProject.BusinessLogic.Interfaces.Telegram
{
    public interface ITelegramMsgPrep
    {
        void PrepareMessage(TelegramBotClient bot, CallbackQuery query, TelegramResult result);
    }
}