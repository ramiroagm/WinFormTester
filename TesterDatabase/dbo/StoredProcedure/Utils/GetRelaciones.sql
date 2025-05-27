CREATE PROCEDURE [dbo].[GetRelaciones]
AS
BEGIN
	SELECT * 
	FROM Relacion
	WHERE Activo = 1
END
