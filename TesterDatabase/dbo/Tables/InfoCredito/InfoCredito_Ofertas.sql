﻿CREATE TABLE [dbo].[InfoCredito_Ofertas]
(
	[ID_OFERTA] INT NOT NULL PRIMARY KEY, 
    [CUOTA] INT NOT NULL, 
    [MONTO_MAX] INT NULL, 
    [MONTO_MIN] INT NOT NULL DEFAULT 0
)
