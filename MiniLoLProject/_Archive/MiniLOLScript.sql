ALTER TABLE [dbo].[MinLoLChampions] DROP CONSTRAINT [FK_MinLoLChampions_MinLoLUltimates]
GO
ALTER TABLE [dbo].[MinLoLChampions] DROP CONSTRAINT [FK_MinLoLChampions_MinLoLRoles]
GO
/****** Object:  Table [dbo].[MinLoLUltimates]    Script Date: 3/11/2016 1:37:40 PM ******/
DROP TABLE [dbo].[MinLoLUltimates]
GO
/****** Object:  Table [dbo].[MinLoLRoles]    Script Date: 3/11/2016 1:37:40 PM ******/
DROP TABLE [dbo].[MinLoLRoles]
GO
/****** Object:  Table [dbo].[MinLoLChampions]    Script Date: 3/11/2016 1:37:40 PM ******/
DROP TABLE [dbo].[MinLoLChampions]
GO
/****** Object:  Table [dbo].[MinLoLChampions]    Script Date: 3/11/2016 1:37:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MinLoLChampions](
	[Name] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[ChampIcon] [nvarchar](200) NOT NULL,
	[ChampPic] [nvarchar](200) NOT NULL,
	[ChampBio] [nvarchar](max) NOT NULL,
	[ChampID] [int] IDENTITY(1,1) NOT NULL,
	[UltimateID] [int] NOT NULL,
	[ChampRoleID] [int] NOT NULL,
 CONSTRAINT [PK_MinLoLChampions_1] PRIMARY KEY CLUSTERED 
(
	[ChampID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MinLoLRoles]    Script Date: 3/11/2016 1:37:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MinLoLRoles](
	[ChampRoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](25) NOT NULL,
	[RoleDescription] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MinLoLRoles] PRIMARY KEY CLUSTERED 
(
	[ChampRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MinLoLUltimates]    Script Date: 3/11/2016 1:37:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MinLoLUltimates](
	[UltimateID] [int] IDENTITY(1,1) NOT NULL,
	[UltimateName] [nvarchar](100) NOT NULL,
	[UltimateIcon] [nvarchar](200) NOT NULL,
	[UltimatePic] [nvarchar](200) NOT NULL,
	[UltimateDescription] [nvarchar](200) NOT NULL,
	[UltimateCost] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_MinLoLUltimates] PRIMARY KEY CLUSTERED 
(
	[UltimateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[MinLoLChampions] ON 

INSERT [dbo].[MinLoLChampions] ([Name], [Title], [ChampIcon], [ChampPic], [ChampBio], [ChampID], [UltimateID], [ChampRoleID]) VALUES (N'Aatrox', N'the Darkin Blade', N'Aatrox.png', N'Aatrox.jpg', N'Aatrox is a legendary warrior, one of only five that remain of an ancient race known as the Darkin. He wields his massive blade with grace and poise, slicing through legions in a style that is hypnotic to behold. With each foe felled, Aatrox''s seemingly living blade drinks in their blood, empowering him and fueling his brutal, elegant campaign of slaughter.The earliest tale of Aatrox is as old as recorded history. It tells of a war between two great factions remembered only as the Protectorate and the Magelords. Over time, the Magelords won a series of crushing victories, leaving them on the brink of obliterating their sworn enemy forever. On the day of their final confrontation, the Protectorate army found themselves outnumbered, exhausted, and poorly equipped. They braced for inevitable defeat.Just when all hope seemed lost, Aatrox appeared among the ranks of the Protectorate. With but a few words, he urged the soldiers to fight to the last before throwing himself into battle. His presence inspired the desperate warriors. At first, they could only watch in awe as this unknown hero cleaved through their enemies, his body and blade moving in unison as if one being. Soon, the warriors found themselves imbued with a potent thirst for battle. They followed Aatrox into the fray, each fighting with the furious strength of ten until they had won a most unlikely victory.', 1, 1, 2)
INSERT [dbo].[MinLoLChampions] ([Name], [Title], [ChampIcon], [ChampPic], [ChampBio], [ChampID], [UltimateID], [ChampRoleID]) VALUES (N'Ahri', N'the Nine-Tailed Fox', N'Ahri.png', N'Ahri.jpg', N'Unlike other foxes that roamed the woods of southern Ionia, Ahri had always felt a strange connection to the magical world around her; a connection that was somehow incomplete. Deep inside, she felt the skin she had been born into was an ill fit for her and dreamt of one day becoming human. Her goal seemed forever out of reach, until she happened upon the wake of a human battle. It was a grisly scene, the land obscured by the forms of wounded and dying soldiers. She felt drawn to one: a robed man encircled by a waning field of magic, his life quickly slipping away. She approached him and something deep inside of her triggered, reaching out to the man in a way she couldn''t understand. His life essence poured into her, carried on invisible strands of magic. The sensation was intoxicating and overwhelming. As her reverie faded, she was delighted to discover that she had changed. Her sleek white fur had receded and her body was long and lithe - the shape of the humans who lay scattered about her.', 4, 3, 3)
SET IDENTITY_INSERT [dbo].[MinLoLChampions] OFF
SET IDENTITY_INSERT [dbo].[MinLoLRoles] ON 

INSERT [dbo].[MinLoLRoles] ([ChampRoleID], [RoleName], [RoleDescription]) VALUES (1, N'Assassin', N'Kills things in like 1 hit')
INSERT [dbo].[MinLoLRoles] ([ChampRoleID], [RoleName], [RoleDescription]) VALUES (2, N'Fighter', N'Super OP, Tanky, Does Damage, Never Dies')
INSERT [dbo].[MinLoLRoles] ([ChampRoleID], [RoleName], [RoleDescription]) VALUES (3, N'Mage', N'Shoots Lasers and stuff')
INSERT [dbo].[MinLoLRoles] ([ChampRoleID], [RoleName], [RoleDescription]) VALUES (4, N'Support', N'Buys wards and heals people')
INSERT [dbo].[MinLoLRoles] ([ChampRoleID], [RoleName], [RoleDescription]) VALUES (5, N'Tank', N'Was super op for a while, During tank meta days')
INSERT [dbo].[MinLoLRoles] ([ChampRoleID], [RoleName], [RoleDescription]) VALUES (6, N'Marksman', N'The toxic role.')
SET IDENTITY_INSERT [dbo].[MinLoLRoles] OFF
SET IDENTITY_INSERT [dbo].[MinLoLUltimates] ON 

INSERT [dbo].[MinLoLUltimates] ([UltimateID], [UltimateName], [UltimateIcon], [UltimatePic], [UltimateDescription], [UltimateCost]) VALUES (1, N'Massacre', N'AatroxR.png', N'AatroxR.jpg', N'Aatrox draws in the blood of his foes, damaging all nearby enemy champions around him and gaining increased Attack Speed and bonus Attack Range for a short duration.', N'No Cost')
INSERT [dbo].[MinLoLUltimates] ([UltimateID], [UltimateName], [UltimateIcon], [UltimatePic], [UltimateDescription], [UltimateCost]) VALUES (3, N'Spirit Rush', N'AhriR.png', N'AhriR.jpg', N'Ahri dashes forward and fires essence bolts, damaging 3 nearby enemies (prioritizes Champions). Spirit Rush can be cast up to three times before going on cooldown.', N'100 Mana')
SET IDENTITY_INSERT [dbo].[MinLoLUltimates] OFF
ALTER TABLE [dbo].[MinLoLChampions]  WITH CHECK ADD  CONSTRAINT [FK_MinLoLChampions_MinLoLRoles] FOREIGN KEY([ChampRoleID])
REFERENCES [dbo].[MinLoLRoles] ([ChampRoleID])
GO
ALTER TABLE [dbo].[MinLoLChampions] CHECK CONSTRAINT [FK_MinLoLChampions_MinLoLRoles]
GO
ALTER TABLE [dbo].[MinLoLChampions]  WITH CHECK ADD  CONSTRAINT [FK_MinLoLChampions_MinLoLUltimates] FOREIGN KEY([UltimateID])
REFERENCES [dbo].[MinLoLUltimates] ([UltimateID])
GO
ALTER TABLE [dbo].[MinLoLChampions] CHECK CONSTRAINT [FK_MinLoLChampions_MinLoLUltimates]
GO
