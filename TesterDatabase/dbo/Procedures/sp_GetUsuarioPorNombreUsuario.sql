CREATE PROCEDURE sp_GetUsuarioPorNombreUsuario
    @NombreUsuario NVARCHAR(100)
AS
BEGIN
    SELECT Id, NombreUsuario, Email, PasswordHash
    FROM Usuarios
    WHERE NombreUsuario = @NombreUsuario;
END