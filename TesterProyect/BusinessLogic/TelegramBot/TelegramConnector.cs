using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot;
using TesterProject.BusinessEntities;
using TesterProject.BusinessLogic.Interfaces;
using TesterProject.BusinessLogic.PasswordManager;

namespace TesterProject.BusinessLogic.TelegramBot
{
    public class TelegramConnector
    {
        private readonly ITelegramDatabaseInformation _databaseInfo;
        private TelegramResult? result;

        public event EventHandler<TelegramResult>? MessageReceived;
        public event EventHandler<TelegramResult>? ErrorOccurred;
        public event EventHandler<TelegramResult>? UpdateOccurred;

        public TelegramConnector() : this(new TelegramDatabaseInformation()) { }

        public TelegramConnector(ITelegramDatabaseInformation databaseInfo)
        {
            _databaseInfo = databaseInfo;
        }

        public async Task<TelegramResult> InitializeBot()
        {
            // string token = await KeyVaultHelper.GetTokenFromKeyVaultAsync(ConstantValues.TelegramKeyValue);
            string token = await SecretManagerHelper.AccessSecret(ConstantValues.G_ProjectId, ConstantValues.G_TelegramKey);

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

            async Task OnMessage(TelegramBotClient bot, Message msg, UpdateType type)
            {
                using CancellationTokenSource cts = new();
                int responseId;
                switch (msg.Text)
                {
                    case "/start":
                        _ = await bot.SendMessage(msg.Chat, "Bienvenido al chat de test.");
                        _ = await bot.SendMessage(msg.Chat, "Elija una de las siguientes opciones disponibles.",
                            replyMarkup: new InlineKeyboardMarkup(
                            [
                                TelegramInlineKeyboardAction.InlineRequest()
                            ]));
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

                MessageReceived?.Invoke(this, result);
                _databaseInfo.InsertInformation(result);
            }

            async Task OnError(Exception exception, HandleErrorSource source)
            {
                result = new TelegramResult
                {
                    ChatId = null,
                    Message = exception.Message,
                    MsgTypeId = (int)TypeEnum.EXCEPTION
                };

                ErrorOccurred?.Invoke(this, result);
            }

            async Task OnUpdate(TelegramBotClient bot, Update update)
            {
                result = null;

                if (update.CallbackQuery != null)
                {
                    CallbackQuery query = update.CallbackQuery;
                    await bot.AnswerCallbackQuery(query.Id, $"Eligió {query.Data}");
                    _ = await bot.SendMessage(query.Message!.Chat, $"El usuario {query.From} hizo clic en {query.Data}");

                    if (query.Data != null)
                    {
                        IEnumerable<TelegramResult> t = await new TelegramInlineKeyboardAction(_databaseInfo).InlineAction(query.Data, query.Message.Chat.Id);
                        List<TelegramResult> results = [];
                        foreach (TelegramResult? a in t)
                        {
                            result = new TelegramResult
                            {
                                ChatId = a.ChatId,
                                Message = a.Message,
                                MsgTypeId = a.MsgTypeId
                            };

                            UpdateOccurred?.Invoke(this, result);
                        }
                    }

                    result = new TelegramResult
                    {
                        ChatId = query.Message.Chat.Id,
                        Message = query.Message.Text,
                        MsgTypeId = (int)TypeEnum.CORRECT_RESPONSE
                    };
                }
                else
                {
                    string messageType = update.Type.ToString();
                }

                result ??= new TelegramResult
                {
                    ChatId = 0,
                    Message = "[No update]",
                    MsgTypeId = (int)TypeEnum.INCORRECT_RESPONSE
                };

                UpdateOccurred?.Invoke(this, result);
                _databaseInfo.InsertInformation(result);
            }
        }
    }
}