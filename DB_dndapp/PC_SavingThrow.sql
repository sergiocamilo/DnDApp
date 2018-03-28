USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[SavingThrow]    Script Date: 31/01/2018 20:24:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE dbo.PC_SavingThrow(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PC_id] [int]  NOT NULL,
	[SavingThrow_id] [int]  NOT NULL,
	[isTemplate] [bit]  NOT NULL,
 	CONSTRAINT [PK_dbo.PC_SavingThrow] PRIMARY KEY CLUSTERED ( [id] ASC ),
	
	CONSTRAINT FK_PC_SavingThrow_PC 
	FOREIGN KEY ([PC_id])     
    REFERENCES [dbo].[PC] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,

	CONSTRAINT FK_PC_SavingThrow_SavingThrow
	FOREIGN KEY ([SavingThrow_id])     
    REFERENCES [dbo].[SavingThrow] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)