CREATE PROCEDURE [dbo].[spGetProductById]
	@ProductID int
AS
	SELECT * FROM Products WHERE Product_ID = @ProductID;
RETURN 0
