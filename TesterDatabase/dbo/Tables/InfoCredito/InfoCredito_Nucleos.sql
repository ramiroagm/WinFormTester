CREATE TABLE [dbo].[InfoCredito_Nucleos]
(
	[ID_NUCLEO] INT NOT NULL PRIMARY KEY, 
    [DOCUMENTO] INT NULL, 
    [ID_RELACION] INT NOT NULL, 
    CONSTRAINT [FK_InfoCredito_Nucleos_Relacion] FOREIGN KEY ([ID_RELACION]) REFERENCES [Relacion]([IdRelacion]) 
)
