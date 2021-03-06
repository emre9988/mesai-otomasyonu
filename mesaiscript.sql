USE [master]
GO
/****** Object:  Database [MesaiData]    Script Date: 26.04.2022 22:51:42 ******/
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
ALTER DATABASE [MesaiData] SET AUTO_CLOSE OFF 
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
/****** Object:  Table [dbo].[calisangiris]    Script Date: 26.04.2022 22:51:42 ******/
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
/****** Object:  Table [dbo].[calisantablo]    Script Date: 26.04.2022 22:51:42 ******/
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
	[calisanadisoyadi] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[isverengiris]    Script Date: 26.04.2022 22:51:42 ******/
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
/****** Object:  Table [dbo].[işverentablo]    Script Date: 26.04.2022 22:51:42 ******/
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
USE [master]
GO
ALTER DATABASE [MesaiData] SET  READ_WRITE 
GO
