USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Language]    Script Date: 31/01/2018 20:24:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE dbo.User_PC(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PC_id] [int]  NOT NULL,
	[User_id] [int]  NOT NULL,
 	CONSTRAINT [PK_dbo.User_PC] PRIMARY KEY CLUSTERED ( [id] ASC ),
	
	CONSTRAINT FK_User_PC_PC 
	FOREIGN KEY ([PC_id])     
    REFERENCES [dbo].[PC] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE,

	CONSTRAINT FK_User_PC_User
	FOREIGN KEY ([User_id])     
    REFERENCES [dbo].[User] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)