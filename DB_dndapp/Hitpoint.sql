USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[HitPoint]    Script Date: 31/01/2018 19:43:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HitPoint](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hitPointsAVG] [int] NOT NULL,
	[die] [int] NOT NULL,
	[bonusCon] [int] NOT NULL,
	[typeDie] [int] NOT NULL,
	[bonusMultiplied] [int] NOT NULL,
 	CONSTRAINT [PK_dbo.HitPoint] PRIMARY KEY CLUSTERED ( [id] ASC)
	WITH (
		PAD_INDEX = OFF,
		STATISTICS_NORECOMPUTE = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON
	)
)

GO

