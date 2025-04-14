namespace TesterApi.Models;

public class TelegramApiResult
{
    public string? Message { get; set; } = null;
    public long? ChatId { get; set; }
    public string? UserName { get; set; } = null;
    public DateTime MsgSentTime { get; set; }
    public int MsgTypeId { get; set; }
    public int RequestMediaType { get; set; }
}
