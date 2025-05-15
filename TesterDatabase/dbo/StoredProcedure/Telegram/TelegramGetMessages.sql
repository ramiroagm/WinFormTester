CREATE PROCEDURE [dbo].[TelegramGetMessages]
	@chatId bigint NULL,
	@userName nvarchar(MAX) NULL,
	@msgSentTime datetime NULL
AS
	SELECT m.ChatId AS 'ChatId', m.Message AS 'Message', t.TypeId AS 'TypeId', t.TypeName AS 'TypeName', m.UserName AS 'UserName', m.MsgSentTime AS 'MsgSentTime'
	FROM Telegram_MessageLog m
	INNER JOIN Telegram_MessageType t ON m.MessageTypeId = t.TypeId 
	WHERE (@chatId IS NULL OR m.ChatId = @chatId)
	AND (@userName IS NULL OR m.UserName = @userName)
	AND (@msgSentTime IS NULL OR m.MsgSentTime <= @msgSentTime)
RETURN
