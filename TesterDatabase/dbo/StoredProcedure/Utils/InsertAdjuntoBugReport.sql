CREATE PROCEDURE InsertAdjuntoReporte
(
    @IdReporte INT,
    @NombreAdjunto NVARCHAR(MAX)
)
AS
BEGIN
    INSERT INTO AdjuntoReporte (NombreAdjunto, IdReporte)
    VALUES (@NombreAdjunto, @IdReporte);
END;
GO