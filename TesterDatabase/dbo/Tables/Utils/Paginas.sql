CREATE TABLE [dbo].[Paginas]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Descripcion] NVARCHAR(MAX) NOT NULL, 
    [PaginaRuta] NVARCHAR(MAX) NOT NULL
)
