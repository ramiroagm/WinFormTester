CREATE TABLE UsuarioRoles (
    UsuarioId INT NOT NULL,
    RolId INT NOT NULL,
    PRIMARY KEY (UsuarioId, RolId),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios([Id]),
    FOREIGN KEY (RolId) REFERENCES Roles(Id)
);