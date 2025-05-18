CREATE TABLE Localidades (
    [IdLocalidad] INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    [IdDepartamento] INT NOT NULL,
    FOREIGN KEY ([IdDepartamento]) REFERENCES Departamentos([IdDepartamento])
);