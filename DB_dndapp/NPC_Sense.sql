USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Language]    Script Date: 31/01/2018 20:24:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE dbo.NPC_Sense(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NPC_id] [int]  NOT NULL,
	[Sense_id] [int]  NOT NULL,
 	CONSTRAINT [PK_dbo.NPC_Sense] PRIMARY KEY CLUSTERED ( [id] ASC ),
	
	CONSTRAINT FK_NPC_Sense_NPC 
	FOREIGN KEY ([NPC_id])     
    REFERENCES [dbo].[NPC] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,

	CONSTRAINT FK_NPC_Sense_Sense
	FOREIGN KEY ([Sense_id])     
    REFERENCES [dbo].[Sense] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)