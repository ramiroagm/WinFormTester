CREATE PROCEDURE GetLocalidadesPorDepartamento
    @IdDepartamento INT
AS
BEGIN
    SELECT IdLocalidad, Nombre
    FROM Localidades
    WHERE IdDepartamento = @IdDepartamento
    ORDER BY Nombre
END