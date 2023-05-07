USE [master]
GO
/****** Object:  Database [payspacedb]    Script Date: 2023/05/07 17:04:27 ******/
CREATE DATABASE [payspacedb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'payspacedb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\payspacedb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'payspacedb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\payspacedb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [payspacedb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [payspacedb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [payspacedb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [payspacedb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [payspacedb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [payspacedb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [payspacedb] SET ARITHABORT OFF 
GO
ALTER DATABASE [payspacedb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [payspacedb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [payspacedb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [payspacedb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [payspacedb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [payspacedb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [payspacedb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [payspacedb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [payspacedb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [payspacedb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [payspacedb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [payspacedb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [payspacedb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [payspacedb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [payspacedb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [payspacedb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [payspacedb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [payspacedb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [payspacedb] SET  MULTI_USER 
GO
ALTER DATABASE [payspacedb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [payspacedb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [payspacedb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [payspacedb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [payspacedb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [payspacedb] SET QUERY_STORE = OFF
GO
USE [payspacedb]
GO
/****** Object:  Table [dbo].[brackets]    Script Date: 2023/05/07 17:04:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[brackets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PercentageRate] [int] NOT NULL,
	[From] [bigint] NOT NULL,
	[To] [bigint] NOT NULL,
 CONSTRAINT [PK_brackets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[calculations]    Script Date: 2023/05/07 17:04:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[calculations](
	[Id] [int] NOT NULL,
	[PostalCodeId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[MonthlyIncome] [decimal](10, 2) NOT NULL,
	[CalculatedValue] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_calculations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[postalcodes]    Script Date: 2023/05/07 17:04:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[postalcodes](
	[Id] [int] NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[CalculationType] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_postalcodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[calculations]  WITH CHECK ADD  CONSTRAINT [FK_calculations_postalcodes] FOREIGN KEY([PostalCodeId])
REFERENCES [dbo].[postalcodes] ([Id])
GO
ALTER TABLE [dbo].[calculations] CHECK CONSTRAINT [FK_calculations_postalcodes]
GO
USE [master]
GO
ALTER DATABASE [payspacedb] SET  READ_WRITE 
GO
