CREATE PROCEDURE GetUsuarioPassword
    @NombreUsuario NVARCHAR(100)
AS
BEGIN
    SELECT Id, UserName, PasswordHash, PasswordSalt
    FROM Usuarios
    WHERE UserName = @NombreUsuario
END