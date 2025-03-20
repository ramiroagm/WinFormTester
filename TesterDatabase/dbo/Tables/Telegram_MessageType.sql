CREATE TABLE [dbo].[Telegram_MessageType]
(
	[TypeId] SMALLINT NOT NULL , 
    [TypeName] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_Telegram_MessageType] PRIMARY KEY ([TypeId]) 
)
