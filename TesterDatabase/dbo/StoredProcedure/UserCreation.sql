CREATE PROCEDURE [dbo].[UserCreation]
	@username nvarchar(MAX),
	@passwordHash nvarchar(MAX),
	@salt varbinary(MAX)
AS
	INSERT INTO Users (Test_Username, Test_PasswordHash, Test_Salt) VALUES (@username, @passwordHash, @salt)
RETURN 0
