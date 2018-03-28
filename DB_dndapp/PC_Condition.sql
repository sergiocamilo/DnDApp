USE [DnDAppDB]


CREATE TABLE dbo.PC_Condition(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PC_id] [int]  NOT NULL,
	[Condition_id] [int]  NOT NULL,
	[isTemplate] [bit]  NOT NULL,
 	CONSTRAINT [PK_dbo.PC_Condition] PRIMARY KEY CLUSTERED ( [id] ASC ),
	
	CONSTRAINT FK_PC_Condition_PC 
	FOREIGN KEY ([PC_id])     
    REFERENCES [dbo].[PC] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,

	CONSTRAINT FK_PC_Condition_Condition
	FOREIGN KEY ([Condition_id])     
    REFERENCES [dbo].[Condition] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)