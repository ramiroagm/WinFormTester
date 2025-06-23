CREATE PROCEDURE GetUsuarioPorNombreUsuario
    @NombreUsuario NVARCHAR(100)
AS
BEGIN
    SELECT UserName, PasswordHash, FechaCreacion
    FROM Usuarios
    WHERE UserName = @NombreUsuario;
END