using TesterBlazor.Models;

namespace TesterBlazor.Services
{
    public class TelegramService
    {
        private readonly HttpClient _httpClient;

        public TelegramService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<TelegramApiResult>> GetTelegramMessagesAsync(long? chatId, string? userName, DateTime? msgSentTime)
        {
            var result = await _httpClient.GetFromJsonAsync<List<TelegramApiResult>>($"TelegramGetInfo?ChatId={chatId}&UserName={userName}&msgSentTime={msgSentTime}");
            return result ?? [];
        }
    }
}