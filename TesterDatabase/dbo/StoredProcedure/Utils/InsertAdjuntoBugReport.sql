CREATE PROCEDURE InsertAdjuntoReporte
(
    @IdReporte INT,
    @NombreAdjunto NVARCHAR(MAX),
    @RutaAdjunto NVARCHAR(MAX)
)
AS
BEGIN
    INSERT INTO AdjuntoReporte (NombreAdjunto, RutaAdjunto, IdReporte)
    VALUES (@NombreAdjunto, @RutaAdjunto, @IdReporte);
END;
GO