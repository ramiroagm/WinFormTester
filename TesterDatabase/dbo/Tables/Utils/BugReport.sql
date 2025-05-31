CREATE TABLE [dbo].[BugReport]
(
	[IdReport] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [TituloReporte] NVARCHAR(MAX) NULL, 
    [MensajeReporte] NVARCHAR(MAX) NULL
)