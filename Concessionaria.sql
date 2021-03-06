USE [master]
GO
/****** Object:  Database [Concessionaria]    Script Date: 8/25/2021 11:01:44 AM ******/
CREATE DATABASE [Concessionaria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Concessionaria', FILENAME = N'C:\Users\v.cassano\Concessionaria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Concessionaria_log', FILENAME = N'C:\Users\v.cassano\Concessionaria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Concessionaria] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Concessionaria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Concessionaria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Concessionaria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Concessionaria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Concessionaria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Concessionaria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Concessionaria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Concessionaria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Concessionaria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Concessionaria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Concessionaria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Concessionaria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Concessionaria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Concessionaria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Concessionaria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Concessionaria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Concessionaria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Concessionaria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Concessionaria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Concessionaria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Concessionaria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Concessionaria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Concessionaria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Concessionaria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Concessionaria] SET  MULTI_USER 
GO
ALTER DATABASE [Concessionaria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Concessionaria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Concessionaria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Concessionaria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Concessionaria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Concessionaria] SET QUERY_STORE = OFF
GO
USE [Concessionaria]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Concessionaria]
GO
/****** Object:  Table [dbo].[Auto]    Script Date: 8/25/2021 11:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auto](
	[Alimentazione] [nvarchar](50) NOT NULL,
	[NPosti] [nchar](10) NOT NULL,
	[idAuto] [nchar](10) NOT NULL,
	[idVehicle] [int] NOT NULL,
 CONSTRAINT [PK_Auto] PRIMARY KEY CLUSTERED 
(
	[idAuto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bike]    Script Date: 8/25/2021 11:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bike](
	[ProdYear] [nvarchar](50) NOT NULL,
	[IdBike] [int] NOT NULL,
 CONSTRAINT [PK_Bike] PRIMARY KEY CLUSTERED 
(
	[IdBike] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pulmini]    Script Date: 8/25/2021 11:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pulmini](
	[NPosti] [int] NOT NULL,
	[PulminiId] [int] NOT NULL,
	[IdVehicle] [int] NOT NULL,
 CONSTRAINT [PK_Pulmini_1] PRIMARY KEY CLUSTERED 
(
	[PulminiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 8/25/2021 11:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[Brand] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[IdVehicle] [int] NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[IdVehicle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Vehicle] FOREIGN KEY([IdVehicle])
REFERENCES [dbo].[Vehicle] ([IdVehicle])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Vehicle]
GO
CREATE TABLE [dbo].[Vehicles](
	[Marca] [nvarchar](50) NOT NULL,
	[Modello] [nvarchar](50) NOT NULL,
	[AnnoProd] [int] NULL,
	[Alimentazione] [int] NULL,
	[NPorte] [int] NULL,
	[NPosti] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Discriminator] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Vehicles] ON 

INSERT [dbo].[Vehicles] ([Marca], [Modello], [AnnoProd], [Alimentazione], [NPorte], [NPosti], [Id], [Discriminator]) VALUES (N'Piaggio', N'Mod1', 2012, NULL, NULL, NULL, 3, N'Moto')
INSERT [dbo].[Vehicles] ([Marca], [Modello], [AnnoProd], [Alimentazione], [NPorte], [NPosti], [Id], [Discriminator]) VALUES (N'Fiat', N'Mod2', NULL, 3, 3, NULL, 4, N'Auto')
INSERT [dbo].[Vehicles] ([Marca], [Modello], [AnnoProd], [Alimentazione], [NPorte], [NPosti], [Id], [Discriminator]) VALUES (N'Iveco', N'Mod3', NULL, NULL, NULL, 20, 5, N'Pulmini')
INSERT [dbo].[Vehicles] ([Marca], [Modello], [AnnoProd], [Alimentazione], [NPorte], [NPosti], [Id], [Discriminator]) VALUES (N'Fiat', N'Mod4', NULL, NULL, NULL, 13, 6, N'Pulmini')
INSERT [dbo].[Vehicles] ([Marca], [Modello], [AnnoProd], [Alimentazione], [NPorte], [NPosti], [Id], [Discriminator]) VALUES (N'Lancia', N'Mod1', NULL, 2, 5, NULL, 3, N'Auto')

SET IDENTITY_INSERT [dbo].[Vehicles] OFF
USE [master]
GO
ALTER DATABASE [Concessionaria] SET  READ_WRITE 
GO
