USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Skill]    Script Date: 31/01/2018 20:30:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Skill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nameSkill] [int] NOT NULL,
	[value] [int] NOT NULL,
	[bonus] [int] NOT NULL,
	[total] [int] NOT NULL,
 	CONSTRAINT [PK_dbo.Skill] PRIMARY KEY CLUSTERED([id] ASC)
	WITH (
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	)
)

GO


