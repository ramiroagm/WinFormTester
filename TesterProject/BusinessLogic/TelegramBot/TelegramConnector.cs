﻿using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TesterProject.BusinessEntities.Telegram;
using TesterProject.BusinessEntities.Utils;
using TesterProject.BusinessLogic.Interfaces.Telegram;
using TesterProject.BusinessLogic.PasswordManager;

namespace TesterProject.BusinessLogic.TelegramBot
{
    public class TelegramConnector(ITelegramDatabaseInformation databaseInfo)
    {
        private readonly ITelegramDatabaseInformation _databaseInfo = databaseInfo;
        private readonly TelegramMsgPrep _telegramMsgPrep = new();

        private TelegramResult? result;
        private TelegramBotClient? bot;

        public event EventHandler<TelegramResult?>? MessageReceived;
        public event EventHandler<TelegramResult?>? ErrorOccurred;
        public event EventHandler<TelegramResult?>? UpdateOccurred;

        public TelegramConnector() : this(new TelegramDatabaseInformation()) { }

        public async Task<TelegramResult?> InitializeBot()
        {
            if (bot == null)
            {
                string token = await SecretManagerHelper.AccessSecretAsync(ConstantValues.G_ProjectId, ConstantValues.G_TelegramKey);
                //string token = await Task.FromResult(CredentialManagerHelper.ReadSecret(ConstantValues.CM_TelegramKey) ?? throw new Exception("No se configuró correctamente el mensaje en Credential Manager"));
                using CancellationTokenSource cts = new();
                bot = new(token, cancellationToken: cts.Token);

                User test = await bot.GetMe();

                bot.OnMessage += async (message, type) => await OnMessage(bot, message, type);
                bot.OnError += OnError;
                bot.OnUpdate += async (update) => await OnUpdate(bot, update);

                return result = new()
                {
                    ChatId = null,
                    Message = "[Bot inicializado]",
                    MsgTypeId = (int)TypeEnum.CORRECT_RESPONSE,
                    MsgSentTime = DateTime.Now
                };
            }
            else
            {
                return result = new()
                {
                    ChatId = null,
                    Message = "[Bot se intentó inicializar pero ya corría]",
                    MsgTypeId = (int)TypeEnum.CORRECT_RESPONSE,
                    MsgSentTime = DateTime.Now
                };
            }

            async Task OnMessage(TelegramBotClient bot, Message msg, UpdateType type)
            {
                using CancellationTokenSource cts = new();
                int responseId;
                switch (msg.Text)
                {
                    case "/start":
                        _ = await bot.SendMessage(msg.Chat, "Bienvenido al chat de testeo: elija una de las siguientes opciones disponibles.",
                            replyMarkup: new InlineKeyboardMarkup(
                            [
                                TelegramInlineKeyboardAction.InlineRequest()
                            ]));
                        responseId = (int)TypeEnum.CORRECT_RESPONSE;
                        break;
                    case "/quit":
                        _ = await bot.SendMessage(msg.Chat, "Saliendo del bot...");
                        responseId = (int)TypeEnum.CORRECT_RESPONSE;
                        cts.Cancel();
                        break;
                    default:
                        _ = await bot.SendMessage(msg.Chat, "Por favor, seleccione un elemento del menú o escriba: \"/start\"");
                        responseId = (int)TypeEnum.CORRECT_RESPONSE;
                        break;
                }

                result = new TelegramResult
                {
                    ChatId = msg.Chat.Id,
                    Message = msg.Text ?? "",
                    MsgTypeId = responseId,
                    UserName = msg.Chat.Username ?? "[Status Update]",
                    MsgSentTime = DateTime.Now
                };

                MessageReceived?.Invoke(this, result);
                _databaseInfo.InsertInformation(result);
            }

            async Task OnError(Exception exception, HandleErrorSource source)
            {
                await Task.Delay(1000);
                result = new TelegramResult
                {
                    ChatId = null,
                    Message = exception.Message,
                    MsgTypeId = (int)TypeEnum.EXCEPTION,
                    MsgSentTime = DateTime.Now
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
                        TelegramResult t = await new TelegramInlineKeyboardAction(_databaseInfo).InlineAction(query);
                        result = new TelegramResult
                        {
                            ChatId = t.ChatId,
                            Message = t.Message,
                            MsgTypeId = t.MsgTypeId,
                            MsgSentTime = DateTime.Now,
                            UserName = query.From.Username,
                            RequestMediaType = t.RequestMediaType
                        };

                        _telegramMsgPrep.PrepareMessage(bot, query, result);
                        UpdateOccurred?.Invoke(this, result);
                    }
                    else
                    {
                        result = new TelegramResult
                        {
                            ChatId = query.From.Id,
                            Message = query.Message.Text,
                            MsgTypeId = (int)TypeEnum.CORRECT_RESPONSE,
                            MsgSentTime = DateTime.Now,
                            UserName = query.From.Username
                        };
                    }
                }
                else
                {
                    string messageType = update.Type.ToString();

                    result ??= new TelegramResult
                    {
                        ChatId = 0,
                        Message = "[No update]",
                        MsgTypeId = (int)TypeEnum.INCORRECT_RESPONSE,
                        MsgSentTime = DateTime.Now,
                        UserName = "[Status Update]"
                    };
                }

                UpdateOccurred?.Invoke(this, result);
                _databaseInfo.InsertInformation(result);
            }
        }

        public async void SendMessage(int? chatId, string userName, string text)
        {
            if (bot != null)
            {
                // TODO: Por ahora solo enviar a usuario id
                if (chatId == null && userName[..1] == "@")
                {
                    _ = await bot.SendMessage(userName, text);
                }
                else if (chatId != null)
                {
                    _ = await bot.SendMessage(chatId, text); 
                }
                else
                {
                    throw new Exception(userName + " no es un nombre de usuario válido");
                }
            }
            else
            {
                result ??= new TelegramResult
                {
                    ChatId = 0,
                    Message = "[Cann't send message]",
                    MsgTypeId = (int)TypeEnum.INCORRECT_RESPONSE,
                    MsgSentTime = DateTime.Now,
                    UserName = "[Status Update]"
                };
            }
        }
    }
}