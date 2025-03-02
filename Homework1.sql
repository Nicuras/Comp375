USE [BookDb]
GO
/****** Object:  Table [dbo].[books]    Script Date: 2/17/2025 1:12:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books](
	[BookID] [int] NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Stock] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[electronics]    Script Date: 2/17/2025 1:12:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[electronics](
	[ElectronicID] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Stock] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ElectronicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchases]    Script Date: 2/17/2025 1:12:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchases](
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[BookID] [int] NULL,
	[ElectronicID] [int] NULL,
	[Email] [varchar](100) NOT NULL,
	[PurchaseNumber] [int] NULL,
	[PurchaseDate] [date] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[purchases]  WITH CHECK ADD FOREIGN KEY([BookID])
REFERENCES [dbo].[books] ([BookID])
GO
ALTER TABLE [dbo].[purchases]  WITH CHECK ADD FOREIGN KEY([ElectronicID])
REFERENCES [dbo].[electronics] ([ElectronicID])
GO
