CREATE PROCEDURE [dbo].[InfoCredito_GetPersonasPorNucleo]
    @ID_NUCLEO INT = NULL,
    @DOCUMENTO INT = NULL
AS
BEGIN
    SELECT p.*
    FROM [dbo].[InfoCredito_Nucleos] n
    INNER JOIN [dbo].[InfoCredito_Personas] p ON n.DOCUMENTO = p.DOCUMENTO
    WHERE
        (@ID_NUCLEO IS NULL OR n.ID_NUCLEO = @ID_NUCLEO)
        AND (
            @DOCUMENTO IS NULL
            OR n.ID_NUCLEO IN (
                SELECT ID_NUCLEO
                FROM [dbo].[InfoCredito_Nucleos]
                WHERE DOCUMENTO = @DOCUMENTO
            )
        )
END
GO