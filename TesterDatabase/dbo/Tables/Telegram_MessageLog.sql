CREATE TABLE [dbo].[Telegram_MessageLog]
(
	[Id] UNIQUEIDENTIFIER NOT NULL , 
    [ChatId] BIGINT NULL, 
    [Message] NVARCHAR(MAX) NULL, 
    [MessageTypeId] SMALLINT NOT NULL, 
    PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Telegram_MessageLog_ToMessageType] FOREIGN KEY ([MessageTypeId]) REFERENCES [Telegram_MessageType]([TypeId])
)
