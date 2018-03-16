USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[SpecialTrait]    Script Date: 31/01/2018 20:31:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SpecialTrait](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	
 	CONSTRAINT [PK_dbo.SpecialTrait] PRIMARY KEY CLUSTERED ([id] ASC)	
	WITH (
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	)
)

GO
