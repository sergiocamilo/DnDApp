USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[AbilityScore]    Script Date: 31/01/2018 19:34:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AbilityScore](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NULL,
	[shortName] [nvarchar](32) NULL,
	[value] [int] NOT NULL,
	[modValue] [int] NOT NULL,
	[savingThrow] [bit] NOT NULL,

	[bonus] [int] NOT NULL DEFAULT ((0)),
	[inputValue] [int] NOT NULL DEFAULT ((0)),

 	CONSTRAINT [PK_dbo.AbilityScore] PRIMARY KEY CLUSTERED ( [id] ASC)
	WITH (
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	)
)

GO



