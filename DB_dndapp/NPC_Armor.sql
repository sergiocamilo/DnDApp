USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Language]    Script Date: 31/01/2018 20:24:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE dbo.NPC_Armor(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NPC_id] [int]  NOT NULL,
	[Armor_id] [int]  NOT NULL,
 	CONSTRAINT [PK_dbo.NPC_Armor] PRIMARY KEY CLUSTERED ( [id] ASC ),
	
	CONSTRAINT FK_NPC_Armor_NPC 
	FOREIGN KEY ([NPC_id])     
    REFERENCES [dbo].[NPC] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,

	CONSTRAINT FK_NPC_Armor_Armor
	FOREIGN KEY ([Armor_id])     
    REFERENCES [dbo].[Armor] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)