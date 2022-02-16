	CREATE TABLE [dbo].[Orders]
(
	[Orders_ID][int]IDENTITY(1,1) PRIMARY KEY,
	[BuyDato][date],
	[ProductName][nvarchar](50),
	[Product_ID] int FOREIGN KEY REFERENCES Products(Product_ID), 
    [Amount] INT NULL, 
    [Price] INT NULL, 
    [OrderNote] NCHAR(50) NULL,
)
