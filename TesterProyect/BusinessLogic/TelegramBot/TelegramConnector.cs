using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    public class TelegramConnector
    {
        private TelegramResult? result;

        public async Task<TelegramResult>  InitializeBot()
        {
            // TODO: Testing string
            string token = "7635895694:AAHZN_ZAlZVkmm5I7jiXNfpmz8bgCqiLyR0";

            using CancellationTokenSource cts = new();
            TelegramBotClient bot = new(token, cancellationToken: cts.Token);
            User me = await bot.GetMe();

            bot.OnMessage += async (message, type) => await OnMessage(bot, message, type);
            bot.OnError += async (exception, source) => await OnError(exception, source);
            bot.OnUpdate += async (update) => await OnUpdate(bot, update);

            return result = new()
            {
                ChatId = null,
                Message = "[Bot inicializado]",
                MsgTypeId = (int)TypeEnum.CORRECT_RESPONSE
            };
        }

        public async Task<TelegramResult> OnMessage(TelegramBotClient bot, Message msg, UpdateType type)
        {
            using CancellationTokenSource cts = new();
            int responseId;
            switch (msg.Text)
            {
                case "/start":
                    _ = await bot.SendMessage(msg.Chat, "Elegir una dirección",
                        replyMarkup: new InlineKeyboardMarkup(new[]
                        {
                                InlineKeyboardButton.WithCallbackData("Izquierda"),
                                InlineKeyboardButton.WithCallbackData("Derecha")
                        }));
                    responseId = (int)TypeEnum.CORRECT_RESPONSE;
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

        public async Task<TelegramResult> OnError(Exception exception, HandleErrorSource source)
        {
            result = new TelegramResult
            {
                ChatId = null,
                Message = exception.Message,
                MsgTypeId = (int)TypeEnum.EXCEPTION
            };

            return result;
        }

        public async Task<TelegramResult> OnUpdate(TelegramBotClient bot, Update update)
        {
            if (update.CallbackQuery != null)
            {
                var query = update.CallbackQuery;
                await bot.AnswerCallbackQuery(query.Id, $"Eligió {query.Data}");
                _ = await bot.SendMessage(query.Message!.Chat, $"El usuario {query.From} hizo clic en {query.Data}");

                result = new TelegramResult
                {
                    ChatId = query.Message.Chat.Id,
                    Message = query.Message.Text,
                    MsgTypeId = (int)TypeEnum.CORRECT_RESPONSE
                };
            }

            return result;
        }
    }
}