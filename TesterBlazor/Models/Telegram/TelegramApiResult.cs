namespace TesterBlazor.Models.Telegram
{
    public class TelegramApiResult
    {
        public string? Message { get; set; }
        public long? ChatId { get; set; }
        public string? UserName { get; set; }
        public DateTime MsgSentTime { get; set; }
        public int MsgTypeId { get; set; }
        public int RequestMediaType { get; set; }
    }
}
