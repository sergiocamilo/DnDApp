USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[PC]    Script Date: 31/01/2018 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PC](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[alignmentMorality] [int] NOT NULL,
	[alignmentAttitude] [int] NOT NULL,
	[race] [int] NOT NULL,
	[_class] [int] NOT NULL,
	[background] [int] NOT NULL,
	[armorBonus] [int] NOT NULL,
	[HP] [int] NOT NULL,
	[telepathy] [int] NOT NULL,

	[armorClass_id] [int] NULL, --FK
	[hitPoint_id] [int] NULL, --FK
	[level_id] [int] NULL, --FK
	[size_id] [int] NULL, --FK
 	
	CONSTRAINT [PK_dbo.PC] PRIMARY KEY CLUSTERED ( [id] ASC)	
	WITH (
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	)
)

GO

ALTER TABLE [dbo].[PC]  WITH CHECK ADD  
CONSTRAINT [FK_dbo.PC_dbo.Armor_armorClass_id] 
FOREIGN KEY([armorClass_id])
REFERENCES [dbo].[Armor] ([id])
GO

ALTER TABLE [dbo].[PC] 
CHECK CONSTRAINT [FK_dbo.PC_dbo.Armor_armorClass_id]
GO

ALTER TABLE [dbo].[PC]  WITH CHECK ADD  
CONSTRAINT [FK_dbo.PC_dbo.Challenge_level_id] 
FOREIGN KEY([level_id])
REFERENCES [dbo].[Challenge] ([id])
GO

ALTER TABLE [dbo].[PC] 
CHECK CONSTRAINT [FK_dbo.PC_dbo.Challenge_level_id]
GO

ALTER TABLE [dbo].[PC]  WITH CHECK ADD  
CONSTRAINT [FK_dbo.PC_dbo.HitPoint_hitPoint_id] 
FOREIGN KEY([hitPoint_id])
REFERENCES [dbo].[HitPoint] ([id])
GO

ALTER TABLE [dbo].[PC] 
CHECK CONSTRAINT [FK_dbo.PC_dbo.HitPoint_hitPoint_id]
GO

ALTER TABLE [dbo].[PC]  WITH CHECK ADD  
CONSTRAINT [FK_dbo.PC_dbo.Size_size_id] 
FOREIGN KEY([size_id])
REFERENCES [dbo].[Size] ([id])
GO

ALTER TABLE [dbo].[PC] 
CHECK CONSTRAINT [FK_dbo.PC_dbo.Size_size_id]
GO

