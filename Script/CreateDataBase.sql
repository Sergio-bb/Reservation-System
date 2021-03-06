USE [master]
GO
/****** Object:  Database [InternationalBusiness_DB]    Script Date: 4/22/2021 7:59:10 AM ******/
CREATE DATABASE [InternationalBusiness_DB]
GO
USE [InternationalBusiness_DB]
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[ExchangeRate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[From] [varchar](3) NOT NULL,
	[To] [varchar](3) NOT NULL,
	[Rate] [float] NOT NULL,
 CONSTRAINT [PK_ExchangeRate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sku] [varchar](5) NOT NULL,
	[Currency] [varchar](3) NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[DateFrom] [datetime2](7) NOT NULL,
	[DateTo] [datetime2](7) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210422004703_begin', N'5.0.1')
GO
SET IDENTITY_INSERT [dbo].[ExchangeRate] ON 
GO
INSERT [dbo].[ExchangeRate] ([Id], [Date], [From], [To], [Rate]) VALUES (9, CAST(N'2021-01-01T00:00:00.0000000' AS DateTime2), N'EUR', N'USD', 1.359)
GO
INSERT [dbo].[ExchangeRate] ([Id], [Date], [From], [To], [Rate]) VALUES (10, CAST(N'2021-01-01T00:00:00.0000000' AS DateTime2), N'CAD', N'EUR', 0.732)
GO
INSERT [dbo].[ExchangeRate] ([Id], [Date], [From], [To], [Rate]) VALUES (11, CAST(N'2021-01-01T00:00:00.0000000' AS DateTime2), N'USD', N'EUR', 0.736)
GO
INSERT [dbo].[ExchangeRate] ([Id], [Date], [From], [To], [Rate]) VALUES (12, CAST(N'2021-01-01T00:00:00.0000000' AS DateTime2), N'EUR', N'CAD', 1.366)
GO
SET IDENTITY_INSERT [dbo].[ExchangeRate] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([Id], [Sku], [Currency], [Amount]) VALUES (1, N'T2006', N'USD', 10)
GO
INSERT [dbo].[Product] ([Id], [Sku], [Currency], [Amount]) VALUES (2, N'M2007', N'CAD', 34.57)
GO
INSERT [dbo].[Product] ([Id], [Sku], [Currency], [Amount]) VALUES (3, N'R2008', N'USD', 17.95)
GO
INSERT [dbo].[Product] ([Id], [Sku], [Currency], [Amount]) VALUES (5, N'T2007', N'EUR', 7.63)
GO
INSERT [dbo].[Product] ([Id], [Sku], [Currency], [Amount]) VALUES (6, N'B2009', N'USD', 21.23)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET ANSI_PADDING ON
GO
