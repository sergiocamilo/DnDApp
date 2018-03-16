USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Challenge]    Script Date: 31/01/2018 19:40:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Challenge](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[value] [nvarchar](max) NULL,
	[xp] [int] NOT NULL,
	[proficiencyBonus] [int] NOT NULL,
 	CONSTRAINT [PK_dbo.Challenge] PRIMARY KEY CLUSTERED ([id] ASC)
	WITH (
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	)
)

GO

