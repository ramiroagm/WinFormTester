CREATE TABLE [dbo].[AdjuntoReporte]
(
	[IdAdjunto] INT NOT NULL, 
	[NombreAdjunto] NVARCHAR(MAX) NULL, 
	[RutaAdjunto] NVARCHAR(MAX) NULL, 
	[FechaCreacion] DATETIME NOT NULL DEFAULT GETDATE(),
	[IdReporte] INT NOT NULL FOREIGN KEY REFERENCES BugReport(IdReport)
)