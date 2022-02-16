CREATE PROCEDURE [dbo].[spInsertOrders]
	@BuyDato date,
	@ProductName nvarchar(50),
	@Product_ID int,
	@Amount int,
	@Price int,
	@OrderNote nvarchar(50)
	
AS
	INSERT INTO Orders VALUES (@BuyDato, @ProductName, @Product_ID,  @Amount, @Price, @OrderNote)
RETURN 0
