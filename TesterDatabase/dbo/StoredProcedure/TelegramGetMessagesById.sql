CREATE PROCEDURE [dbo].[TelegramGetMessagesById]
	@chatId bigint
AS
	SELECT m.ChatId AS 'ChatId', m.Message AS 'Message', t.TypeId AS 'TypeId', t.TypeName AS 'TypeName', m.UserName AS 'UserName', m.MsgSentTime AS 'MsgSentTime'
	FROM Telegram_MessageLog m
	INNER JOIN Telegram_MessageType t ON m.MessageTypeId = t.TypeId 
	WHERE ChatId = @chatId
RETURN
