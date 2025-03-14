using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    public class TelegramConnector()
    {
        public static async Task<TelegramResult> InitializeBot()
        {
            // TODO: Testing string
            string token = "7635895694:AAHZN_ZAlZVkmm5I7jiXNfpmz8bgCqiLyR0";
            TelegramResult result = new();
            int responseId;

            using CancellationTokenSource cts = new();
            TelegramBotClient bot = new(token, cancellationToken: cts.Token);
            User me = await bot.GetMe();
            bool firstRun = true;

            bot.OnMessage += OnMessage;
            bot.OnError += OnError;
            bot.OnUpdate += OnUpdate;

            async Task<TelegramResult> OnMessage(Message msg, UpdateType type)
            {
                switch (msg.Text)
                {
                    case "/start":
                        _ = await bot.SendMessage(msg.Chat, "Elegir una dirección",
                            replyMarkup: new InlineKeyboardButton[] { "Izquierda", "Derecha" });
                        responseId = (int)TypeEnum.CORRECT_RESPONSE;
                        firstRun = false;
                        break;
                    case "/quit":
                        _ = await bot.SendMessage(msg.Chat, "Adiós");
                        responseId = (int)TypeEnum.CORRECT_RESPONSE;
                        cts.Cancel();
                        break;
                    default:
                        _ = await bot.SendMessage(msg.Chat, "Por favor, comienze el chat con \"/start\"");
                        responseId = (int)TypeEnum.CORRECT_RESPONSE;
                        break;
                }

                result = new TelegramResult
                {
                    ChatId = msg.Chat.Id,
                    Message = msg.Text,
                    MsgTypeId = responseId
                };
                
                return result;
            }

            async Task<TelegramResult> OnError(Exception exception, HandleErrorSource source)
            {
                result = new TelegramResult
                {
                    ChatId = null,
                    Message = exception.Message,
                    MsgTypeId = (int)TypeEnum.EXCEPTION
                };

                return result;
            }

            async Task<TelegramResult> OnUpdate(Update update)
            {
                if (update is { CallbackQuery: { } query })
                {
                    await bot.AnswerCallbackQuery(query.Id, $"Eligió {query.Data}");
                    _ = await bot.SendMessage(query.Message!.Chat, $"El usuario {query.From} hizo clic en {query.Data}");
                }
                else
                {
                    query = null;
                }

                result = new TelegramResult
                {
                    ChatId = query != null ? query.Message!.Chat.Id : null,
                    Message = query != null ? query.Message!.Chat.ToString() : null,
                    MsgTypeId = (int)TypeEnum.CORRECT_RESPONSE
                };

                return result;
            }

            return result;
        }
    }
}
