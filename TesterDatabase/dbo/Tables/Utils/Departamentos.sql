CREATE TABLE Departamentos (
    [IdDepartamento] INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    [IdPais] INT NOT NULL,
    FOREIGN KEY ([IdPais]) REFERENCES Paises([IdPais])
);