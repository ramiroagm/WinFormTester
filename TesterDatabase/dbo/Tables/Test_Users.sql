CREATE TABLE [dbo].[Test_Users] (
    [Test_UserID]       INT             IDENTITY (1, 1) NOT NULL,
    [Test_UserName]     VARCHAR (MAX)   NOT NULL,
    [Test_PasswordHash] VARCHAR (MAX)   NOT NULL,
    [Test_Salt]         VARBINARY (MAX) NOT NULL,
    CONSTRAINT [IX_Test_Users] UNIQUE NONCLUSTERED ([Test_UserID] ASC)
);

