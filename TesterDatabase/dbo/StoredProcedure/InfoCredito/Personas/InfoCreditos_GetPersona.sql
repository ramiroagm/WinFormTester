CREATE PROCEDURE [dbo].[InfoCredito_GetPersona]
    @DOCUMENTO INT = NULL
AS
BEGIN
    SELECT
        p.[DOCUMENTO],
        p.[PRIMER_NOMBRE],
        p.[SEGUNDO_NOMBRE],
        p.[PRIMER_APELLIDO],
        p.[SEGUNDO_APELLIDO],
        p.[ID_DIRECCION],
        p.[FECHA_NACIMIENTO],
        d.[CALLE],
        d.[NUMERO],
        d.[MANZANA],
        d.[SOLAR],
        c.[CORREO_ELECTRONICO],
        c.[CORREO_ELECTRONICO_ALT],
        c.[OBSERVACIONES],
        c.[TEL_FIJO],
        c.[TEL_MOVIL],
        c.[WHATSAPP_URL],
        lo.[Nombre] AS NombreLocalidad,
        de.[Nombre] AS NombreDepartamento,
        pa.[Nombre] AS NombrePais
    FROM [dbo].[InfoCredito_Personas] p
    INNER JOIN [dbo].[InfoCredito_Contactos] c ON c.ID_CONTACTO = p.ID_CONTACTO
    INNER JOIN [dbo].[InfoCredito_Direcciones] d ON p.ID_DIRECCION = d.ID_DIRECCION
    INNER JOIN [dbo].[Localidades] lo ON d.ID_LOCALIDAD = lo.IdLocalidad
    INNER JOIN [dbo].[Departamentos] de ON lo.IdDepartamento = de.IdDepartamento
    INNER JOIN [dbo].[Paises] pa ON de.IdPais = pa.IdPais
    WHERE
        p.[DOCUMENTO] = @DOCUMENTO
    AND p.[ACTIVO] = 1;
END