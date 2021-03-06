USE [master]
GO
/****** Object:  Database [MesaiData]    Script Date: 18.05.2022 00:12:21 ******/
CREATE DATABASE [MesaiData]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MesaiData', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MesaiData.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MesaiData_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MesaiData_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MesaiData] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MesaiData].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MesaiData] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MesaiData] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MesaiData] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MesaiData] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MesaiData] SET ARITHABORT OFF 
GO
ALTER DATABASE [MesaiData] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MesaiData] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MesaiData] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MesaiData] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MesaiData] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MesaiData] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MesaiData] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MesaiData] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MesaiData] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MesaiData] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MesaiData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MesaiData] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MesaiData] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MesaiData] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MesaiData] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MesaiData] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MesaiData] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MesaiData] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MesaiData] SET  MULTI_USER 
GO
ALTER DATABASE [MesaiData] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MesaiData] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MesaiData] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MesaiData] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MesaiData] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MesaiData] SET QUERY_STORE = OFF
GO
USE [MesaiData]
GO
/****** Object:  Table [dbo].[admingiris]    Script Date: 18.05.2022 00:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admingiris](
	[kullaniciadi] [varchar](50) NULL,
	[sifre] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[calisangiris]    Script Date: 18.05.2022 00:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[calisangiris](
	[calisanid] [int] NULL,
	[kullaniciadi] [varchar](50) NULL,
	[sifre] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[calisantablo]    Script Date: 18.05.2022 00:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[calisantablo](
	[calisanid] [int] NOT NULL,
	[haftalikmesai] [int] NULL,
	[maas] [int] NULL,
	[prim] [int] NULL,
	[toplammaas] [int] NULL,
	[calisanadisoyadi] [varchar](50) NULL,
	[mesaigunleri] [nvarchar](max) NULL,
	[mesaiucret] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[isverengiris]    Script Date: 18.05.2022 00:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[isverengiris](
	[isverenid] [int] NULL,
	[isverenkullanici] [varchar](50) NULL,
	[sifre] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[işverentablo]    Script Date: 18.05.2022 00:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[işverentablo](
	[isverenid] [int] NOT NULL,
	[mesaiucreti] [int] NULL,
	[prim] [int] NULL,
	[mesaiackapa] [varchar](50) NULL,
	[adisoyadi] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mesaigunlertablo]    Script Date: 18.05.2022 00:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mesaigunlertablo](
	[calisanid] [int] NOT NULL,
	[mesaigunsaat] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mesaitablo]    Script Date: 18.05.2022 00:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mesaitablo](
	[mesai] [varchar](50) NULL,
	[mesaiucret] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[admingiris] ([kullaniciadi], [sifre]) VALUES (N'admin', N'1453')
GO
INSERT [dbo].[calisangiris] ([calisanid], [kullaniciadi], [sifre]) VALUES (1, N'emr', N'1234')
INSERT [dbo].[calisangiris] ([calisanid], [kullaniciadi], [sifre]) VALUES (2, N'emree', N'32323')
INSERT [dbo].[calisangiris] ([calisanid], [kullaniciadi], [sifre]) VALUES (3, N'emreişci', N'1789')
INSERT [dbo].[calisangiris] ([calisanid], [kullaniciadi], [sifre]) VALUES (4, N'sdadas', N'dasas')
INSERT [dbo].[calisangiris] ([calisanid], [kullaniciadi], [sifre]) VALUES (4, N'emrebaba', N'naptın')
INSERT [dbo].[calisangiris] ([calisanid], [kullaniciadi], [sifre]) VALUES (6, N'emre12345678', N'emre')
INSERT [dbo].[calisangiris] ([calisanid], [kullaniciadi], [sifre]) VALUES (7, N'ads', N'das')
INSERT [dbo].[calisangiris] ([calisanid], [kullaniciadi], [sifre]) VALUES (8, N'123456789', N'1234')
INSERT [dbo].[calisangiris] ([calisanid], [kullaniciadi], [sifre]) VALUES (9, N'fsa', N'fsa')
INSERT [dbo].[calisangiris] ([calisanid], [kullaniciadi], [sifre]) VALUES (10, N'emre', N'1453')
GO
INSERT [dbo].[calisantablo] ([calisanid], [haftalikmesai], [maas], [prim], [toplammaas], [calisanadisoyadi], [mesaigunleri], [mesaiucret]) VALUES (1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[calisantablo] ([calisanid], [haftalikmesai], [maas], [prim], [toplammaas], [calisanadisoyadi], [mesaigunleri], [mesaiucret]) VALUES (10, NULL, NULL, NULL, NULL, N'emre gurlenkaya', NULL, NULL)
GO
INSERT [dbo].[isverengiris] ([isverenid], [isverenkullanici], [sifre]) VALUES (1, N'emre', N'1234')
INSERT [dbo].[isverengiris] ([isverenid], [isverenkullanici], [sifre]) VALUES (2, N'emrebaba', N'1513')
INSERT [dbo].[isverengiris] ([isverenid], [isverenkullanici], [sifre]) VALUES (NULL, NULL, NULL)
INSERT [dbo].[isverengiris] ([isverenid], [isverenkullanici], [sifre]) VALUES (4, N'baboli', N'he1315')
INSERT [dbo].[isverengiris] ([isverenid], [isverenkullanici], [sifre]) VALUES (5, N'cdascas', N'cdasdsa')
INSERT [dbo].[isverengiris] ([isverenid], [isverenkullanici], [sifre]) VALUES (6, N'emrenaptınkanki', N'1234')
INSERT [dbo].[isverengiris] ([isverenid], [isverenkullanici], [sifre]) VALUES (7, N'kanka', N'1234')
INSERT [dbo].[isverengiris] ([isverenid], [isverenkullanici], [sifre]) VALUES (8, N'he ', N'he')
INSERT [dbo].[isverengiris] ([isverenid], [isverenkullanici], [sifre]) VALUES (9, N'emre12', N'1234')
INSERT [dbo].[isverengiris] ([isverenid], [isverenkullanici], [sifre]) VALUES (10, N'emrebaba', N'1453')
INSERT [dbo].[isverengiris] ([isverenid], [isverenkullanici], [sifre]) VALUES (11, N'emrepatron', N'1453')
GO
INSERT [dbo].[işverentablo] ([isverenid], [mesaiucreti], [prim], [mesaiackapa], [adisoyadi]) VALUES (1, NULL, NULL, NULL, NULL)
INSERT [dbo].[işverentablo] ([isverenid], [mesaiucreti], [prim], [mesaiackapa], [adisoyadi]) VALUES (5, NULL, NULL, NULL, N'cadsascd')
INSERT [dbo].[işverentablo] ([isverenid], [mesaiucreti], [prim], [mesaiackapa], [adisoyadi]) VALUES (6, NULL, NULL, NULL, N'Emre Baba')
INSERT [dbo].[işverentablo] ([isverenid], [mesaiucreti], [prim], [mesaiackapa], [adisoyadi]) VALUES (7, NULL, NULL, NULL, N'Emre Gurr')
INSERT [dbo].[işverentablo] ([isverenid], [mesaiucreti], [prim], [mesaiackapa], [adisoyadi]) VALUES (9, NULL, NULL, NULL, N'emrerrrr')
INSERT [dbo].[işverentablo] ([isverenid], [mesaiucreti], [prim], [mesaiackapa], [adisoyadi]) VALUES (10, NULL, NULL, NULL, N'Emre BABA')
INSERT [dbo].[işverentablo] ([isverenid], [mesaiucreti], [prim], [mesaiackapa], [adisoyadi]) VALUES (11, NULL, NULL, NULL, N'Emre gurlenkaya')
INSERT [dbo].[işverentablo] ([isverenid], [mesaiucreti], [prim], [mesaiackapa], [adisoyadi]) VALUES (8, NULL, NULL, NULL, N'he he ')
GO
INSERT [dbo].[mesaigunlertablo] ([calisanid], [mesaigunsaat]) VALUES (10, N'17 Mayıs 2022 Salı 2 saat')
INSERT [dbo].[mesaigunlertablo] ([calisanid], [mesaigunsaat]) VALUES (10, N'18 Mayıs 2022 Çarşamba 2 saat')
GO
INSERT [dbo].[mesaitablo] ([mesai], [mesaiucret]) VALUES (N'acik', 12)
GO
USE [master]
GO
ALTER DATABASE [MesaiData] SET  READ_WRITE 
GO
