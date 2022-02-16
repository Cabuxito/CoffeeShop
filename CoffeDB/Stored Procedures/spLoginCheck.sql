CREATE PROCEDURE [dbo].[spLoginCheck]
	@Username nvarchar(50),
	@Password nvarchar(MAX)
AS
	SELECT * FROM Users WHERE Username = @Username AND Password = @Password
RETURN 0
