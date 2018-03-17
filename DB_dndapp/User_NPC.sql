USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Language]    Script Date: 31/01/2018 20:24:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE dbo.User_NPC(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NPC_id] [int]  NOT NULL,
	[User_id] [int]  NOT NULL,
 	CONSTRAINT [PK_dbo.User_NPC] PRIMARY KEY CLUSTERED ( [id] ASC ),
	
	CONSTRAINT FK_User_NPC_NPC 
	FOREIGN KEY ([NPC_id])     
    REFERENCES [dbo].[NPC] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE,

	CONSTRAINT FK_User_NPC_User
	FOREIGN KEY ([User_id])     
    REFERENCES [dbo].[User] ([id])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)