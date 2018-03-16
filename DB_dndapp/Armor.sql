USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Armor]    Script Date: 31/01/2018 19:39:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Armor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [int] NOT NULL,
	[baseArmor] [int] NOT NULL,
	[bonus] [int] NOT NULL,
	[maxDexMod] [int] NOT NULL,
	[total] [int] NOT NULL,
	[stealth] [bit] NOT NULL,
	[shield] [bit] NOT NULL,
 	CONSTRAINT [PK_dbo.Armor] PRIMARY KEY CLUSTERED ( [id] ASC)
	WITH (
		PAD_INDEX = OFF,
		STATISTICS_NORECOMPUTE = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON
	)
)

GO

