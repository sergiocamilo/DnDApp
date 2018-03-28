USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Language]    Script Date: 31/01/2018 20:24:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE dbo.PC_Damage(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PC_id] [int]  NOT NULL,
	[Damage_id] [int]  NOT NULL,
	[isTemplate] [bit]  NOT NULL,
 	CONSTRAINT [PK_dbo.PC_Damage] PRIMARY KEY CLUSTERED ( [id] ASC ),
	
	CONSTRAINT FK_PC_Damage_PC 
	FOREIGN KEY ([PC_id])     
    REFERENCES [dbo].[PC] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,

	CONSTRAINT FK_PC_Damage_Damage
	FOREIGN KEY ([Damage_id])     
    REFERENCES [dbo].[Damage] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)