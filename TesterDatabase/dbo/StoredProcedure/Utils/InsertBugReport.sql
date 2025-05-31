CREATE PROCEDURE InsertBugReport
(
    @TituloReporte NVARCHAR(MAX),
    @MensajeReporte NVARCHAR(MAX),
    @IdReporte INT OUTPUT
)
AS
BEGIN
    INSERT INTO BugReport (TituloReporte, MensajeReporte)
    VALUES (@TituloReporte, @MensajeReporte);
    SET @IdReporte = SCOPE_IDENTITY();
END;
GO