CREATE TABLE [dbo].[Contact](
	[Contact_ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Ticket] [nvarchar](max) NULL,
	[Status] [nvarchar](50) NULL)