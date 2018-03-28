USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Language]    Script Date: 31/01/2018 20:24:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE dbo.PC_AbilityScore(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PC_id] [int]  NOT NULL,
	[AbilityScore_id] [int]  NOT NULL,
 	CONSTRAINT [PK_dbo.PC_AbilityScore] PRIMARY KEY CLUSTERED ( [id] ASC ),
	
	CONSTRAINT FK_PC_AbilityScore_PC 
	FOREIGN KEY ([PC_id])     
    REFERENCES [dbo].[PC] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,

	CONSTRAINT FK_PC_AbilityScore_AbilityScore
	FOREIGN KEY ([AbilityScore_id])     
    REFERENCES [dbo].[AbilityScore] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)