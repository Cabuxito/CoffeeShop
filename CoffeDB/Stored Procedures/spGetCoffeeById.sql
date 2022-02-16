CREATE PROCEDURE [dbo].[spGetCoffeeById]
	@coffeeId int
AS
	SELECT * FROM Products WHERE Product_ID = @coffeeId
RETURN 0