CREATE PROCEDURE [dbo].[spDeleteOrderById]
	@OrdersID int
AS
	DELETE FROM Orders WHERE Orders_ID = @OrdersID
RETURN 0
