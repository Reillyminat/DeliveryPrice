USE [master]
GO
/****** Object:  Database [DeliveryService]    Script Date: 15.06.2021 7:39:04 ******/
CREATE DATABASE [DeliveryService]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DeliveryService', FILENAME = N'C:\Program Files\MSSQL14.MSSQLSERVER\MSSQL\DATA\DeliveryService.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DeliveryService_log', FILENAME = N'C:\Program Files\MSSQL14.MSSQLSERVER\MSSQL\DATA\DeliveryService_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DeliveryService] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DeliveryService].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DeliveryService] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DeliveryService] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DeliveryService] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DeliveryService] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DeliveryService] SET ARITHABORT OFF 
GO
ALTER DATABASE [DeliveryService] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DeliveryService] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DeliveryService] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DeliveryService] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DeliveryService] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DeliveryService] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DeliveryService] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DeliveryService] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DeliveryService] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DeliveryService] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DeliveryService] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DeliveryService] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DeliveryService] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DeliveryService] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DeliveryService] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DeliveryService] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DeliveryService] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DeliveryService] SET RECOVERY FULL 
GO
ALTER DATABASE [DeliveryService] SET  MULTI_USER 
GO
ALTER DATABASE [DeliveryService] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DeliveryService] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DeliveryService] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DeliveryService] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DeliveryService] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DeliveryService', N'ON'
GO
ALTER DATABASE [DeliveryService] SET QUERY_STORE = OFF
GO
USE [DeliveryService]
GO
/****** Object:  Table [dbo].[Appliances]    Script Date: 15.06.2021 7:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appliances](
	[ApplianceId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[GuaranteeInMonths] [numeric](18, 0) NULL,
	[HeightInMeters] [decimal](18, 0) NULL,
	[WidthInMeters] [decimal](18, 0) NULL,
	[DepthInMeters] [decimal](18, 0) NULL,
	[Price] [money] NOT NULL,
	[Amount] [int] NULL,
	[ProducingCountry] [nvarchar](50) NULL,
	[Type] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Appliance] PRIMARY KEY CLUSTERED 
(
	[ApplianceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppliancesTypes]    Script Date: 15.06.2021 7:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppliancesTypes](
	[TypeId] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[ScopeOfApplication] [nvarchar](50) NULL,
 CONSTRAINT [PK_AppliancesTypes] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 15.06.2021 7:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ApplianceId] [int] NOT NULL,
	[BuyingDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 15.06.2021 7:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Telephone] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appliances]  WITH CHECK ADD  CONSTRAINT [FK_Appliances_AppliancesTypes] FOREIGN KEY([Type])
REFERENCES [dbo].[AppliancesTypes] ([TypeId])
GO
ALTER TABLE [dbo].[Appliances] CHECK CONSTRAINT [FK_Appliances_AppliancesTypes]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Appliances] FOREIGN KEY([ApplianceId])
REFERENCES [dbo].[Appliances] ([ApplianceId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Appliances]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
USE [master]
GO
ALTER DATABASE [DeliveryService] SET  READ_WRITE 
GO
