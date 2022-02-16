CREATE PROCEDURE [dbo].[spUpdateCoffe]
	@ProductID int,
	@ProductName nvarchar(50),
	@ProductDescription nvarchar(MAX),
	@ProductPrice int
AS
	UPDATE Products SET Name = @ProductName, Description = @ProductDescription, Price = @ProductPrice WHERE Product_ID = @ProductID 
RETURN 0
