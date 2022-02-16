CREATE PROCEDURE [dbo].[spInsertNewProduct]
	@ProductName nvarchar(50),
	@ProductDescription nvarchar(MAX),
	@ProductPrice int,
	@ProductQuantity int,
	@PathToImg nvarchar(50),
	@Type nvarchar(50)
AS
	INSERT INTO Products VALUES (@ProductName, @ProductDescription,@ProductPrice,@ProductQuantity, @PathToImg, @Type)
RETURN 0
