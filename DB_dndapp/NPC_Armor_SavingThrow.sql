USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[SavingThrow]    Script Date: 31/01/2018 20:24:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE dbo.NPC_SavingThrow(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NPC_id] [int]  NOT NULL,
	[SavingThrow_id] [int]  NOT NULL,
 	CONSTRAINT [PK_dbo.NPC_SavingThrow] PRIMARY KEY CLUSTERED ( [id] ASC ),
	
	CONSTRAINT FK_NPC_SavingThrow_NPC 
	FOREIGN KEY ([NPC_id])     
    REFERENCES [dbo].[NPC] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,

	CONSTRAINT FK_NPC_SavingThrow_SavingThrow
	FOREIGN KEY ([SavingThrow_id])     
    REFERENCES [dbo].[SavingThrow] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)