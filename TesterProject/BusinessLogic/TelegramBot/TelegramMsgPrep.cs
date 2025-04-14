using Telegram.Bot.Types;
using Telegram.Bot;
using TesterProject.BusinessEntities;
using TesterProject.BusinessLogic.Interfaces;

namespace TesterProject.BusinessLogic.TelegramBot
{
    public class TelegramMsgPrep : ITelegramMsgPrep
    {
        public async void PrepareMessage(TelegramBotClient bot, CallbackQuery query, TelegramResult result)
        {
            result.Message ??= "[No message provided]";

            switch (result.RequestMediaType)
            {
                case (int)RequestMediaType.TEXT:
                    await bot.SendMessage(query.From.Id, result.Message);
                    break;
                case (int)RequestMediaType.IMAGE:
                    await bot.SendPhoto(query.From.Id, "https://upload.wikimedia.org/wikipedia/commons/8/85/Logo-Test.png", result.Message);
                    break;
                default:
                    break;
            }
        }
    }
}
