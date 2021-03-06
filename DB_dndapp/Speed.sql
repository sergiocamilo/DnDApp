USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Speed]    Script Date: 31/01/2018 20:31:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Speed](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typeSpeed] [int] NOT NULL,
	[speedft] [int] NOT NULL,
 	CONSTRAINT [PK_dbo.Speed] PRIMARY KEY CLUSTERED ([id] ASC)
	WITH (
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	)
)

GO