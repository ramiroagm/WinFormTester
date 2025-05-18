CREATE PROCEDURE [dbo].[InfoCredito_GetNucleosPorPersona]
    @DOCUMENTO INT
AS
BEGIN
    SELECT n.*
    FROM [dbo].[InfoCredito_Nucleos] n
    WHERE n.DOCUMENTO = @DOCUMENTO
END
GO