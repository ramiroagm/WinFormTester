using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TesterProject.BusinessEntities;
using TesterProject.BusinessLogic.Interfaces.Telegram;

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
                    InlineKeyboardButton.WithCallbackData(TelegramBotMenu.GetSingleImage)
                ];
            return l;
        }

        public async Task<TelegramResult> InlineAction(CallbackQuery query)
        {
            return query.Data switch
            {
                TelegramBotMenu.GetMessageLog => await _databaseInfo.GetSingleInformation(query),
                TelegramBotMenu.GetSingleImage => new TelegramResult
                {
                    ChatId = query.From.Id,
                    Message = "Imagen de prueba",
                    MsgTypeId = (int)TypeEnum.CORRECT_RESPONSE,
                    MsgSentTime = DateTime.Now,
                    RequestMediaType = (int)RequestMediaType.IMAGE
                },
                _ => new TelegramResult
                {
                    ChatId = query.From.Id,
                    Message = "Mensaje inline incorrecto o no configurado",
                    MsgTypeId = (int)TypeEnum.INCORRECT_RESPONSE,
                    MsgSentTime = DateTime.Now,
                    RequestMediaType = (int)RequestMediaType.TEXT
                }
            };
        }
    }
}
