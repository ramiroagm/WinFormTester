CREATE PROCEDURE GetDepartamentosPorPais
    @IdPais INT
AS
BEGIN
    SELECT IdDepartamento, Nombre
    FROM Departamentos
    WHERE IdPais = @IdPais
    ORDER BY Nombre
END