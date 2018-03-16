USE [DnDAppDB]


CREATE TABLE dbo.NPC_Condition(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NPC_id] [int]  NOT NULL,
	[Condition_id] [int]  NOT NULL,
 	CONSTRAINT [PK_dbo.NPC_Condition] PRIMARY KEY CLUSTERED ( [id] ASC ),
	
	CONSTRAINT FK_NPC_Condition_NPC 
	FOREIGN KEY ([NPC_id])     
    REFERENCES [dbo].[NPC] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,

	CONSTRAINT FK_NPC_Condition_Condition
	FOREIGN KEY ([Condition_id])     
    REFERENCES [dbo].[Condition] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)