using Telegram.Bot.Types.ReplyMarkups;
using TesterProject.BusinessEntities;
using TesterProject.BusinessLogic.Interfaces;

namespace TesterProject.BusinessLogic.TelegramBot
{
    public class TelegramInlineKeyboardAction(ITelegramDatabaseInformation databaseInfo)
    {
        private readonly ITelegramDatabaseInformation _databaseInfo = databaseInfo;

        public static List<InlineKeyboardButton> InlineRequest()
        {
            List<InlineKeyboardButton> l =
            [
                InlineKeyboardButton.WithCallbackData(TelegramBotMenu.GetMessageLog),
                InlineKeyboardButton.WithCallbackData("Test 2"),
            ];
            return l;
        }

        public async Task<IEnumerable<TelegramResult>> InlineAction(string action, long chatId)
        {
            return action switch
            {
                nameof(TelegramBotMenu.GetMessageLog) => await _databaseInfo.GetInformation(chatId),
                _ => [],
            };
        }
    }
}
