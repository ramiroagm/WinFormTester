﻿--CREATE PROCEDURE [dbo].[InfoCredito_GetNucleosPorPersona]
--    @DOCUMENTO INT
--AS
--BEGIN
--    SELECT n.*
--    FROM [dbo].[InfoCredito_Nucleos] n INNER JOIN [dbo].[InfoCredito_PersonasNucleo] pn ON n.ID_NUCLEO = pn.ID_NUCLEO
--    WHERE pn.DOCUMENTO = @DOCUMENTO
--END
--GO