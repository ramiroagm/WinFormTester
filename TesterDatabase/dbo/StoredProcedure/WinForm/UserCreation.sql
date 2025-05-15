CREATE PROCEDURE [dbo].[UserCreation]
	@username nvarchar(MAX),
	@passwordHash nvarchar(MAX),
	@salt varbinary(MAX)
AS
	INSERT INTO  Test_Users (Test_UserName, Test_PasswordHash, Test_Salt) VALUES (@username, @passwordHash, @salt)
RETURN 0
