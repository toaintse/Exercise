USE [master]
GO
/****** Object:  Database [PRN211_Demo1]    Script Date: 8/28/2020 11:07:47 AM ******/
CREATE DATABASE [PRN211_Demo1]
GO
USE [PRN211_Demo1]
GO
/****** Object:  Table [dbo].[Author_Book]    Script Date: 8/28/2020 11:07:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author_Book](
	[AuthorID] [int] NOT NULL,
	[BookID] [int] NOT NULL,
 CONSTRAINT [PK_Author_Book] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC,
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Authors]    Script Date: 8/28/2020 11:07:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DOB] [date] NOT NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 8/28/2020 11:07:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Year] [int] NOT NULL,
	[Description] [ntext] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Author_Book] ([AuthorID], [BookID]) VALUES (1, 4)
GO
INSERT [dbo].[Author_Book] ([AuthorID], [BookID]) VALUES (1, 6)
GO
INSERT [dbo].[Author_Book] ([AuthorID], [BookID]) VALUES (2, 2)
GO
INSERT [dbo].[Author_Book] ([AuthorID], [BookID]) VALUES (2, 4)
GO
INSERT [dbo].[Author_Book] ([AuthorID], [BookID]) VALUES (3, 2)
GO
INSERT [dbo].[Author_Book] ([AuthorID], [BookID]) VALUES (3, 6)
GO
INSERT [dbo].[Author_Book] ([AuthorID], [BookID]) VALUES (3, 7)
GO
INSERT [dbo].[Author_Book] ([AuthorID], [BookID]) VALUES (4, 2)
GO
INSERT [dbo].[Author_Book] ([AuthorID], [BookID]) VALUES (4, 3)
GO
INSERT [dbo].[Author_Book] ([AuthorID], [BookID]) VALUES (4, 6)
GO
INSERT [dbo].[Author_Book] ([AuthorID], [BookID]) VALUES (4, 7)
GO
INSERT [dbo].[Author_Book] ([AuthorID], [BookID]) VALUES (5, 3)
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

GO
INSERT [dbo].[Authors] ([ID], [Name], [DOB], [Description]) VALUES (1, N'Juval Lowy', CAST(N'1972-12-05' AS Date), NULL)
GO
INSERT [dbo].[Authors] ([ID], [Name], [DOB], [Description]) VALUES (2, N'Joe Kaplan', CAST(N'1980-01-04' AS Date), NULL)
GO
INSERT [dbo].[Authors] ([ID], [Name], [DOB], [Description]) VALUES (3, N'‎Ryan Dunn', CAST(N'1979-12-03' AS Date), NULL)
GO
INSERT [dbo].[Authors] ([ID], [Name], [DOB], [Description]) VALUES (4, N'Mark Schmidt', CAST(N'1969-02-04' AS Date), NULL)
GO
INSERT [dbo].[Authors] ([ID], [Name], [DOB], [Description]) VALUES (5, N'‎Simon Robinson', CAST(N'1876-12-10' AS Date), NULL)
GO
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

GO
INSERT [dbo].[Books] ([ID], [Title], [Year], [Description]) VALUES (2, N'Microsoft Visual C# .NET 2003 Developer''s Cookbook', 2004, N'NET framework can reduce deployment to a simple matter of copying files, in practice for commercial applications things usually aren''t that simple. For example, you probably want the appropriate Registry entries made so that your software ...')
GO
INSERT [dbo].[Books] ([ID], [Title], [Year], [Description]) VALUES (3, N'The .NET Developer''s Guide to Directory Services Programming', 2006, N'NET. Attribute. Value. Conversion. We now know that ADSI converts LDAP data to ADSI data types via schema mapping. Developers who are familiar with programming ADSI in an unmanaged language (Visual Basic 6, VBScript, C++, etc.) .')
GO
INSERT [dbo].[Books] ([ID], [Title], [Year], [Description]) VALUES (4, N'Programming .NET Components', 2003, N'NET loads an assembly, it computes the permissions that assembly is granted: for each Security policy, .NET aggregates the permissions from the code groups satisfied in that policy, and then .NET intersects the policies to find the combined')
GO
INSERT [dbo].[Books] ([ID], [Title], [Year], [Description]) VALUES (6, N'Programming .NET Components: Design and Build .NET Application', 2005, N'Brilliantly compiled by author Juval Lowy, Programming .NET Components, Second Edition is the consummate introduction to the Microsoft .NET Framework--the technology of choice for building components on Windows platforms. From its many lessons, tips, and guidelines, readers will learn how to use the .NET Framework to program reusable, maintainable, and robust components.Following in the footsteps of its best-selling predecessor, Programming .NET Components, Second Edition has been updated to cover .NET 2.0. It remains one of the few practical books available on this topic. ')
GO
INSERT [dbo].[Books] ([ID], [Title], [Year], [Description]) VALUES (7, N'Microsoft .NET: Kick Start', 2003, N'Programming With .NET Introduction Microsoft developers working with Visual Studio and COM/OLE technologies have always enjoyed the benefits of a choice of programming languages for development of applications and components.')
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
ALTER TABLE [dbo].[Author_Book]  WITH CHECK ADD  CONSTRAINT [FK_Author_Book_Authors] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([ID])
GO
ALTER TABLE [dbo].[Author_Book] CHECK CONSTRAINT [FK_Author_Book_Authors]
GO
ALTER TABLE [dbo].[Author_Book]  WITH CHECK ADD  CONSTRAINT [FK_Author_Book_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([ID])
GO
ALTER TABLE [dbo].[Author_Book] CHECK CONSTRAINT [FK_Author_Book_Books]
GO
USE [master]
GO
ALTER DATABASE [PRN211_Demo1] SET  READ_WRITE 
GO
