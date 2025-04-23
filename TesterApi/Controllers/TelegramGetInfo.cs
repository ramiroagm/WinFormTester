using Microsoft.AspNetCore.Mvc;
using TesterApi.Models;
using TesterProject.BusinessEntities;
using TesterProject.BusinessLogic.Interfaces.Telegram;
using TesterProject.BusinessLogic.TelegramBot;

namespace TesterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelegramGetInfo(ILogger<TelegramGetInfo> logger) : ControllerBase
    {
        private readonly ILogger<TelegramGetInfo> _logger = logger;

        [HttpGet(Name = "GetTelegramMessages")]
        public async Task<List<TelegramApiResult>> Get(long? ChatId, string? UserName, DateTime? MsgSentTime)
        {
            ITelegramDatabaseInformation telegramDatabaseInformation = new TelegramDatabaseInformation();
            IEnumerable<TelegramResult> info = await telegramDatabaseInformation.GetInformation(ChatId, UserName, MsgSentTime);

            List<TelegramApiResult> result = [];
            foreach (TelegramResult i in info)
            {
                result.Add(MapTelegramInformation(i));
            }

            return result;
        }

        private static TelegramApiResult MapTelegramInformation(TelegramResult result)
        {
            return new TelegramApiResult
            {
                Message = result.Message,
                ChatId = result.ChatId,
                UserName = result.UserName,
                MsgSentTime = result.MsgSentTime,
                MsgTypeId = result.MsgTypeId,
                RequestMediaType = result.RequestMediaType
            };
        }
    }
}
