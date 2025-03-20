CREATE PROCEDURE [dbo].[TelegramMessageLog]
	@chatId BIGINT,
	@message NVARCHAR(MAX),
	@messageTypeId SMALLINT
AS
	INSERT INTO Telegram_MessageLog (ChatId, Message, MessageTypeId) VALUES (@chatId, @message, @messageTypeId)
RETURN 0
