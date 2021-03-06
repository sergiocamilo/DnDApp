USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Language]    Script Date: 31/01/2018 20:24:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE dbo.NPC_Skill(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NPC_id] [int]  NOT NULL,
	[Skill_id] [int]  NOT NULL,
 	CONSTRAINT [PK_dbo.NPC_Skill] PRIMARY KEY CLUSTERED ( [id] ASC ),
	
	CONSTRAINT FK_NPC_Skill_NPC 
	FOREIGN KEY ([NPC_id])     
    REFERENCES [dbo].[NPC] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,

	CONSTRAINT FK_NPC_Skill_Skill
	FOREIGN KEY ([Skill_id])     
    REFERENCES [dbo].[Skill] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)