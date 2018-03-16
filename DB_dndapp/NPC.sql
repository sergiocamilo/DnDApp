USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Language]    Script Date: 31/01/2018 20:24:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE dbo.NPC(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](128) NULL,
	
	[typecreature] [int] NOT NULL,
	[tag] [nvarchar](max) NULL,
	[alignmentMorality] [int] NOT NULL,
	[alignmentAttitude] [int] NOT NULL,
	[telepathy] [int] NOT NULL,

	[size_id] [int] NULL, --FK
	[armorclass_id] [int] NULL, --FK
	[hitPoint_id] [int] NULL, --FK
	[challenge_id] [int] NULL, --FK

 	CONSTRAINT [PK_dbo.NPC] PRIMARY KEY CLUSTERED ( [id] ASC )
)

ALTER TABLE [dbo].[NPC]  
WITH CHECK ADD CONSTRAINT [FK_dbo.NPC_dbo.Armor_armorClass_id] 
FOREIGN KEY([armorClass_id])
REFERENCES [dbo].[Armor] ([id])
GO

ALTER TABLE [dbo].[NPC] 
CHECK CONSTRAINT [FK_dbo.NPC_dbo.Armor_armorClass_id]
GO

ALTER TABLE [dbo].[NPC]  
WITH CHECK ADD  CONSTRAINT [FK_dbo.NPC_dbo.Challenge_challenge_id] 
FOREIGN KEY([challenge_id])
REFERENCES [dbo].[Challenge] ([id])
GO

ALTER TABLE [dbo].[NPC] 
CHECK CONSTRAINT [FK_dbo.NPC_dbo.Challenge_challenge_id]
GO

ALTER TABLE [dbo].[NPC]  
WITH CHECK ADD  CONSTRAINT [FK_dbo.NPC_dbo.HitPoint_hitPoint_id] 
FOREIGN KEY([hitPoint_id])
REFERENCES [dbo].[HitPoint] ([id])
GO

ALTER TABLE [dbo].[NPC] 
CHECK CONSTRAINT [FK_dbo.NPC_dbo.HitPoint_hitPoint_id]
GO

ALTER TABLE [dbo].[NPC]  
WITH CHECK ADD  CONSTRAINT [FK_dbo.NPC_dbo.Size_size_id] 
FOREIGN KEY([size_id])
REFERENCES [dbo].[Size] ([id])
GO

ALTER TABLE [dbo].[NPC] 
CHECK CONSTRAINT [FK_dbo.NPC_dbo.Size_size_id]
GO