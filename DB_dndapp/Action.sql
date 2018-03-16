USE [DnDAppDB]
GO

/****** Object:  Table [dbo].[Action]    Script Date: 31/01/2018 19:38:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Action](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](128) NULL,
	[limited] [nvarchar](64) NULL,
	[description] [nvarchar](max) NULL,
	
	[bonusDamage] [int] NOT NULL DEFAULT ((0)),
	[range] [int] NOT NULL,
	[target] [nvarchar](max) NULL,
	[damage] [int] NOT NULL,
	[typeAction] [int] NOT NULL DEFAULT ((0)),
	[bonusAttack] [int] NOT NULL DEFAULT ((0)),
	[totalBonusAttack] [int] NOT NULL DEFAULT ((0)),
	[abilityAction] [nvarchar](max) NULL,
	[min] [int] NOT NULL DEFAULT ((0)),
	[max] [int] NOT NULL DEFAULT ((0)),
	[hitDie] [int] NOT NULL DEFAULT ((0)),
	[die] [int] NOT NULL DEFAULT ((0)),
	[abilityDamage] [int] NOT NULL DEFAULT ((0)),
	[typeDamage] [int] NOT NULL DEFAULT ((0)),

	[Actiontype] [int] NOT NULL,
	
 	CONSTRAINT [PK_dbo.Action] PRIMARY KEY CLUSTERED ([id] ASC)
	WITH (
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	)
)

GO

