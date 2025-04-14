CREATE PROCEDURE [dbo].[TelegramMessageLog]
	@chatId BIGINT,
	@message NVARCHAR(MAX),
	@messageTypeId SMALLINT,
	@userName NVARCHAR(MAX),
	@msgSentTime DATETIME
AS
	INSERT INTO Telegram_MessageLog (ChatId, Message, MessageTypeId, UserName, MsgSentTime) VALUES (@chatId, @message, @messageTypeId, @userName, @msgSentTime)
RETURN 0
