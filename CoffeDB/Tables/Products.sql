CREATE TABLE [dbo].[Products](
	[Product_ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [int] NULL,
	[Quantity] [int] NULL,
	[PathToImg] [nvarchar](50) NULL, 
    [type] NVARCHAR(50) NULL
)