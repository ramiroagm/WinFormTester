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
    @OBSERVACIONES NVARCHAR(MAX) = NULL,

    -- Parámetros del contacto
    @TEL_MOVIL NVARCHAR(MAX) = NULL,
    @TEL_FIJO NVARCHAR(MAX) = NULL,
    @CORREO_ELECTRONICO NVARCHAR(MAX) = NULL,
    @CORREO_ELECTRONICO_ALT NVARCHAR(MAX) = NULL,
    @WHATSAPP_URL NVARCHAR(MAX) = NULL,
    @OBSERVACIONES_CONTACTO NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM dbo.InfoCredito_Personas WHERE DOCUMENTO = @DOCUMENTO)
    BEGIN
        UPDATE dbo.InfoCredito_Personas
        SET ACTIVO = 0, FECHA_ACTUALIZACION = GETDATE()
        WHERE DOCUMENTO = @DOCUMENTO AND ACTIVO = 1;
    END

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

    -- Insertar dirección
    INSERT INTO [dbo].[InfoCredito_Contactos] (
        [TEL_MOVIL],
        [TEL_FIJO],
        [CORREO_ELECTRONICO],
        [CORREO_ELECTRONICO_ALT],
        [WHATSAPP_URL],
        [OBSERVACIONES]
    )
    VALUES (
        @TEL_MOVIL,
        @TEL_FIJO,
        @CORREO_ELECTRONICO,
        @CORREO_ELECTRONICO_ALT,
        @WHATSAPP_URL,
        @OBSERVACIONES_CONTACTO
    );

    DECLARE @NEW_ID_CONTACTO INT = SCOPE_IDENTITY();

    -- Insertar persona
    INSERT INTO [dbo].[InfoCredito_Personas] (
        [DOCUMENTO],
        [PRIMER_NOMBRE],
        [SEGUNDO_NOMBRE],
        [PRIMER_APELLIDO],
        [SEGUNDO_APELLIDO],
        [ID_DIRECCION],
        [FECHA_NACIMIENTO],
        [ACTIVO],
        [FECHA_ACTUALIZACION],
        [ID_CONTACTO]
    )
    VALUES (
        @DOCUMENTO,
        @PRIMER_NOMBRE,
        @SEGUNDO_NOMBRE,
        @PRIMER_APELLIDO,
        @SEGUNDO_APELLIDO,
        @NEW_ID_DIRECCION,
        @FECHA_NACIMIENTO,
        1, -- Siempre activo para la nueva versión
        GETDATE(),
        @NEW_ID_CONTACTO
    );

END