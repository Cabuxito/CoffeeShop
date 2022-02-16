CREATE TABLE [dbo].[Users](
	[Users_ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Firstname] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](max) NULL,
	[Username] [nvarchar](50) NULL,
	[Phone] [int] NULL
	)