CREATE TABLE [dbo].[InfoCredito_PersonasNucleo]
(
	[ID_PERSONA] INT NOT NULL, 
    [ID_NUCLEO] INT NOT NULL, 
    [FECHA_INGRESO] DATE NOT NULL DEFAULT GETDATE(), 
    [ACTIVO] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_InfoCredito_PersonasNucleo_Personas] FOREIGN KEY ([ID_PERSONA]) REFERENCES [InfoCredito_Personas]([ID_PERSONA]), 
    CONSTRAINT [FK_InfoCredito_PersonasNucleo_Nucleo] FOREIGN KEY ([ID_NUCLEO]) REFERENCES [InfoCredito_Nucleos]([ID_NUCLEO]) 
)