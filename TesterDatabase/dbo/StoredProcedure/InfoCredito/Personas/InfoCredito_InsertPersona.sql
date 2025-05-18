CREATE PROCEDURE [dbo].[InfoCredito_InsertPersona]
    -- Parámetros de la persona
    @DOCUMENTO INT,
    @PRIMER_NOMBRE NVARCHAR(MAX),
    @SEGUNDO_NOMBRE NVARCHAR(MAX) = NULL,
    @PRIMER_APELLIDO NVARCHAR(MAX),
    @SEGUNDO_APELLIDO NVARCHAR(MAX) = NULL,
    
    -- Parámetros para la dirección:
    @ID_LOCALIDAD INT,
    @CALLE NVARCHAR(MAX) = NULL,
    @NUMERO INT,
    @MANZANA INT,
    @SOLAR INT,
    @FECHA_NACIMIENTO DATE,
    @OBSERVACIONES NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar dirección
    INSERT INTO [dbo].[InfoCredito_Direcciones] (
        [ID_LOCALIDAD],
        [CALLE],
        [NUMERO],
        [MANZANA],
        [SOLAR],
        [OBSERVACIONES]
    )
    VALUES (
        @ID_LOCALIDAD,
        @CALLE,
        @NUMERO,
        @MANZANA,
        @SOLAR,
        @OBSERVACIONES
    );

    DECLARE @NEW_ID_DIRECCION INT = SCOPE_IDENTITY();

    -- Insertar persona
    INSERT INTO [dbo].[InfoCredito_Personas] (
        [DOCUMENTO],
        [PRIMER_NOMBRE],
        [SEGUNDO_NOMBRE],
        [PRIMER_APELLIDO],
        [SEGUNDO_APELLIDO],
        [ID_DIRECCION],
        [FECHA_NACIMIENTO]
    )
    VALUES (
        @DOCUMENTO,
        @PRIMER_NOMBRE,
        @SEGUNDO_NOMBRE,
        @PRIMER_APELLIDO,
        @SEGUNDO_APELLIDO,
        @NEW_ID_DIRECCION,
        @FECHA_NACIMIENTO
    );
END