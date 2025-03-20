CREATE PROCEDURE [dbo].[TelegramGetMessagesById]
	@chatId bigint
AS
	SELECT m.ChatId, m.Message, t.TypeId, t.TypeName 
	FROM Telegram_MessageLog m
	INNER JOIN Telegram_MessageType t ON m.MessageTypeId = t.TypeId 
	WHERE ChatId = @chatId
RETURN
