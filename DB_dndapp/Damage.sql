USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Damage]    Script Date: 31/01/2018 19:43:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Damage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[damage] [int] NOT NULL,
	[typeDamage] [int] NOT NULL,
	
 	CONSTRAINT [PK_dbo.Damage] PRIMARY KEY CLUSTERED ([id] ASC)
	WITH (
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	)
)

GO