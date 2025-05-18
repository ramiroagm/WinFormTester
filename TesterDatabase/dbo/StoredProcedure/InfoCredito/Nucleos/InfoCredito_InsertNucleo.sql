CREATE PROCEDURE [dbo].[InfoCredito_CrearNucleo]
    @ID_NUCLEO INT,
    @DOCUMENTO INT,
    @ID_RELACION INT
AS
BEGIN
    INSERT INTO [dbo].[InfoCredito_Nucleos] (
        [ID_NUCLEO],
        [DOCUMENTO],
        [ID_RELACION]
    )
    VALUES (
        @ID_NUCLEO,
        @DOCUMENTO,
        @ID_RELACION
    );
END
GO