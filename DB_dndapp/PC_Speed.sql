USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Language]    Script Date: 31/01/2018 20:24:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE dbo.PC_Speed(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PC_id] [int]  NOT NULL,
	[Speed_id] [int]  NOT NULL,
	[isTemplate] [bit]  NOT NULL,
 	CONSTRAINT [PK_dbo.PC_Speed] PRIMARY KEY CLUSTERED ( [id] ASC ),
	
	CONSTRAINT FK_PC_Speed_PC 
	FOREIGN KEY ([PC_id])     
    REFERENCES [dbo].[PC] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,

	CONSTRAINT FK_PC_Speed_Speed
	FOREIGN KEY ([Speed_id])     
    REFERENCES [dbo].[Speed] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)