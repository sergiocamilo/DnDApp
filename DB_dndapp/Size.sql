USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Size]    Script Date: 31/01/2018 20:29:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Size](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[size] [int] NOT NULL,
	[space] [int] NOT NULL,
 	CONSTRAINT [PK_dbo.Size] PRIMARY KEY CLUSTERED ( [id] ASC)
	WITH (
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	)
)

GO

