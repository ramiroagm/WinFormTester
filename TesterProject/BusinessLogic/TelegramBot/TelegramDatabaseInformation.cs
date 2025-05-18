using Telegram.Bot.Types;
using TesterProject.BusinessEntities.Telegram;
using TesterProject.BusinessEntities.Utils;
using TesterProject.BusinessLogic.Interfaces.Telegram;
using TesterProject.DataAccess.Telegram;

namespace TesterProject.BusinessLogic.TelegramBot
{
    public class TelegramDatabaseInformation : ITelegramDatabaseInformation
    {
        public void InsertInformation(TelegramResult result) => TelegramMessageLog.TelegramLogInformation(result);

        public async Task<IEnumerable<TelegramResult>> GetInformation(long? ChatId, string? UserName, DateTime?  MsgSentTime)
        {
            return await TelegramMessageLog.GetLogInformation(ChatId, UserName, MsgSentTime);
        }

        public async Task<TelegramResult> GetSingleInformation(CallbackQuery query)
        {
            var messagesTask = GetInformation(query.From.Id, null, null);
            var result = await MapToSingleChatMessage(messagesTask, query.From.Username);
            return result ?? throw new InvalidOperationException("No message found for the given ChatId.");
        }

        private static async Task<TelegramResult?> MapToSingleChatMessage(Task<IEnumerable<TelegramResult>> messagesTask, string? UserName)
        {
            var messages = await messagesTask;
            string newReturn = $"Messages from {UserName ?? "[Unnamed user]"}: {Environment.NewLine}";
            foreach (var message in messages)
            {
                newReturn += $"Mensaje {message.Message} [{message.MsgSentTime}]{Environment.NewLine}";
            }

            return new TelegramResult
            {
                UserName = UserName,
                ChatId = messages.FirstOrDefault()?.ChatId,
                Message = newReturn,
                MsgSentTime = DateTime.Now,
                MsgTypeId = (int)TypeEnum.CORRECT_RESPONSE,
                RequestMediaType = (int)RequestMediaType.TEXT
            };
        }
    }
}