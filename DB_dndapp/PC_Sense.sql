USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Language]    Script Date: 31/01/2018 20:24:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE dbo.PC_Sense(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PC_id] [int]  NOT NULL,
	[Sense_id] [int]  NOT NULL,
	[isTemplate] [bit]  NOT NULL,
 	CONSTRAINT [PK_dbo.PC_Sense] PRIMARY KEY CLUSTERED ( [id] ASC ),
	
	CONSTRAINT FK_PC_Sense_PC 
	FOREIGN KEY ([PC_id])     
    REFERENCES [dbo].[PC] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,

	CONSTRAINT FK_PC_Sense_Sense
	FOREIGN KEY ([Sense_id])     
    REFERENCES [dbo].[Sense] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)