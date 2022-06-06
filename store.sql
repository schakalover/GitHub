USE [master]
GO
/****** Object:  Database [Stored]    Script Date: 06/06/2022 09:44:50 a. m. ******/
CREATE DATABASE [Stored]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Stored', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS2016\MSSQL\DATA\Stored.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Stored_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS2016\MSSQL\DATA\Stored_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Stored] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Stored].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Stored] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Stored] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Stored] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Stored] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Stored] SET ARITHABORT OFF 
GO
ALTER DATABASE [Stored] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Stored] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Stored] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Stored] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Stored] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Stored] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Stored] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Stored] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Stored] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Stored] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Stored] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Stored] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Stored] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Stored] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Stored] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Stored] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Stored] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Stored] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Stored] SET  MULTI_USER 
GO
ALTER DATABASE [Stored] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Stored] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Stored] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Stored] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Stored] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Stored] SET QUERY_STORE = OFF
GO
USE [Stored]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Stored]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 06/06/2022 09:44:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[Description] [varchar](150) NULL,
	[Price] [decimal](18, 0) NULL,
	[Total_in_shelf] [int] NULL,
	[Total_in_vault] [int] NULL,
	[Store_id] [int] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 06/06/2022 09:44:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[Address] [varchar](250) NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_Store] FOREIGN KEY([Store_id])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_Store]
GO
USE [master]
GO
ALTER DATABASE [Stored] SET  READ_WRITE 
GO
