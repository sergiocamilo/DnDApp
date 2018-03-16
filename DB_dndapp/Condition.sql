USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Condition]    Script Date: 31/01/2018 19:40:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Condition](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[condition] [int] NOT NULL,
 	CONSTRAINT [PK_dbo.Condition] PRIMARY KEY CLUSTERED ( [id] ASC )
	WITH (
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	)
)

GO



