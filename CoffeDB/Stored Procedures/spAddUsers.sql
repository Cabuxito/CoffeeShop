CREATE PROCEDURE [dbo].[spAddUsers]
	@Firstname nvarchar(50),
	@Lastname nvarchar(50),
	@Email nvarchar(50),
	@Password nvarchar(MAX),
	@Username nvarchar(50),
	@Phone int
AS
	INSERT INTO Users VALUES (@Firstname, @Lastname, @Email, @Password, @Username, @Phone);
RETURN 0