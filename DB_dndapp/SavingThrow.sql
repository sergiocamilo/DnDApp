USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[SavingThrow]    Script Date: 31/01/2018 20:27:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SavingThrow](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[modName] [nvarchar](max) NULL,
	[value] [int] NOT NULL,
 	CONSTRAINT [PK_dbo.SavingThrow] PRIMARY KEY CLUSTERED ([id] ASC)
	WITH (
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	)
)

GO
