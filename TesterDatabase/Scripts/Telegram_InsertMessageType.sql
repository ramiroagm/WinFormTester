/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- BORRADO DE TABLAS
TRUNCATE TABLE Telegram_MessageLog;
DELETE Telegram_MessageType;
TRUNCATE TABLE Test_Users;

-- CREACION DE REGISTROS BASE
INSERT INTO Telegram_MessageType (TypeId, TypeName) VALUES (0, 'CORRECT_RESPONSE');
INSERT INTO Telegram_MessageType (TypeId, TypeName) VALUES (1, 'INCORRECT_RESPONSE');
INSERT INTO Telegram_MessageType (TypeId, TypeName) VALUES (2, 'ERROR');
INSERT INTO Telegram_MessageType (TypeId, TypeName) VALUES (3, 'INCORRECT_RESPONSE');
INSERT INTO Telegram_MessageType (TypeId, TypeName) VALUES (4, 'EXCEPTION');
INSERT INTO [dbo].[Test_Users]
           ([Test_UserName]
           ,[Test_PasswordHash]
           ,[Test_Salt])
     VALUES
           ('ramiro',
           '1I8OYtkS7EBVjhwS3mUDcA/O3PorhejJuljbIITqbFsbXEO8',
           0xD48F0E62D912EC40558E1C12DE650370);
GO