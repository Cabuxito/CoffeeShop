CREATE PROCEDURE [dbo].[spInputOrderByID]
	@ProductId int
AS
	SELECT * FROM Products WHERE Product_ID = @ProductId
RETURN 0
