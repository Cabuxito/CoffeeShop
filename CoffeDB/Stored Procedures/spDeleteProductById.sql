CREATE PROCEDURE [dbo].[spDeleteProductById]
	@ProductID int
AS
	DELETE FROM Products WHERE Product_ID = @ProductID
RETURN 0
