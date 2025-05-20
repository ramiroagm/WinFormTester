CREATE PROCEDURE GetPaises
AS
BEGIN
    SELECT IdPais, Nombre
    FROM Paises
    ORDER BY Nombre
END