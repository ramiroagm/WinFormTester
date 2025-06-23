CREATE TABLE Usuarios (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [UserName] NVARCHAR(256) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    [PasswordSalt] VARBINARY(MAX) NOT NULL, 
    [FechaCreacion] DATE NULL DEFAULT GetDate()
);