USE [DnDAppDB]


CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](128) NOT NULL UNIQUE,
	[email] [nvarchar](128) NOT NULL UNIQUE,
	[password] [int] NOT NULL,
	[role] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
	[token] [nvarchar](128) NOT NULL,
	CONSTRAINT [PK_dbo.User] PRIMARY KEY(id)
)

/*
USE [DnDAppDB]
GO
/****** Object:  Table [dbo].[User]    Script Date: 14/03/2018 21:52:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](128) NOT NULL,
	[email] [nvarchar](128) NOT NULL,
	[password] [int] NOT NULL,
	[role] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
	[token] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
*/
