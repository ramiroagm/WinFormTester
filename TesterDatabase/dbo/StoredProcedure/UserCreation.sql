CREATE PROCEDURE [dbo].[UserCreation]
	@username nvarchar(MAX),
	@passwordHash nvarchar(MAX)
AS
	INSERT INTO Users (Username, PasswordHash) VALUES (@username, @passwordHash)
RETURN 0
