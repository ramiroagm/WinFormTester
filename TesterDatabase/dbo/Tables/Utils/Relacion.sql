CREATE TABLE [dbo].[Relacion]
(
	[IdRelacion] INT NOT NULL PRIMARY KEY, 
    [NombreRelacion] NVARCHAR(MAX) NOT NULL, 
    [Activo] BIT NOT NULL DEFAULT 1
)
