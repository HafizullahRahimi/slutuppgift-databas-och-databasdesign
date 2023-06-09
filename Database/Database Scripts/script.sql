USE [master]
GO
/****** Object:  Database [PragueParkingDB]    Script Date: 2022-12-02 16:10:15 ******/
CREATE DATABASE [PragueParkingDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PragueParkingDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\PragueParkingDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PragueParkingDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\PragueParkingDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PragueParkingDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PragueParkingDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PragueParkingDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PragueParkingDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PragueParkingDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PragueParkingDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PragueParkingDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PragueParkingDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PragueParkingDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PragueParkingDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PragueParkingDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PragueParkingDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PragueParkingDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PragueParkingDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PragueParkingDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PragueParkingDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PragueParkingDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PragueParkingDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PragueParkingDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PragueParkingDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PragueParkingDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PragueParkingDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PragueParkingDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PragueParkingDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PragueParkingDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PragueParkingDB] SET  MULTI_USER 
GO
ALTER DATABASE [PragueParkingDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PragueParkingDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PragueParkingDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PragueParkingDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PragueParkingDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PragueParkingDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PragueParkingDB', N'ON'
GO
ALTER DATABASE [PragueParkingDB] SET QUERY_STORE = OFF
GO
USE [PragueParkingDB]
GO
/****** Object:  Table [dbo].[ParkingPlaces]    Script Date: 2022-12-02 16:10:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingPlaces](
	[ParkingPlaceID] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](3) NOT NULL,
 CONSTRAINT [PK_ParkingPlaces] PRIMARY KEY CLUSTERED 
(
	[ParkingPlaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[First 20 ParkingPlaces]    Script Date: 2022-12-02 16:10:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[First 20 ParkingPlaces] AS
SELECT TOP 20 * FROM  ParkingPlaces;
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 2022-12-02 16:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleTypeID] [tinyint] NOT NULL,
	[NumberPlate] [nvarchar](50) NOT NULL,
	[DriverFullName] [nvarchar](250) NOT NULL,
	[MobileNumber] [nvarchar](30) NULL,
	[Email] [nvarchar](250) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[First 40 Vehicles Is Active]    Script Date: 2022-12-02 16:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[First 40 Vehicles Is Active] AS
SELECT TOP 40 * FROM  Vehicles
Where Active = 1;
GO
/****** Object:  Table [dbo].[ParkingBills]    Script Date: 2022-12-02 16:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingBills](
	[RegNumber] [int] IDENTITY(100,1) NOT NULL,
	[VehicleID] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[ArrivalDate] [smalldatetime] NOT NULL,
	[DepartureDate] [smalldatetime] NULL,
	[StoppagePeriod] [nvarchar](200) NULL,
	[Bill] [smallmoney] NULL,
 CONSTRAINT [PK_ParkingBills] PRIMARY KEY CLUSTERED 
(
	[RegNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[First 40 ParkingBills Is Active]    Script Date: 2022-12-02 16:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[First 40 ParkingBills Is Active] AS
SELECT TOP 40 * FROM  ParkingBills
Where Active = 1;
GO
/****** Object:  Table [dbo].[ParkingPlaceParts]    Script Date: 2022-12-02 16:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingPlaceParts](
	[ParkingPlacePartID] [tinyint] IDENTITY(1,1) NOT NULL,
	[ParkingPlaceID] [tinyint] NOT NULL,
	[PartID] [tinyint] NOT NULL,
	[RegNumber] [int] NULL,
 CONSTRAINT [PK_ParkingPlaceParts] PRIMARY KEY CLUSTERED 
(
	[ParkingPlacePartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[First 40 ParkingPlaceParts]    Script Date: 2022-12-02 16:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[First 40 ParkingPlaceParts] AS
SELECT TOP 40 * FROM  ParkingPlaceParts;
GO
/****** Object:  Table [dbo].[VehicleTypes]    Script Date: 2022-12-02 16:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleTypes](
	[VehicleTypeID] [tinyint] IDENTITY(1,1) NOT NULL,
	[VehicleType] [varchar](10) NOT NULL,
 CONSTRAINT [PK_VehicleTypes] PRIMARY KEY CLUSTERED 
(
	[VehicleTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_ParkingBills_Vehicles_VehicleTypes]    Script Date: 2022-12-02 16:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_ParkingBills_Vehicles_VehicleTypes]
AS
SELECT dbo.ParkingBills.RegNumber, dbo.ParkingBills.Active, dbo.ParkingBills.VehicleID, dbo.Vehicles.VehicleTypeID, dbo.VehicleTypes.VehicleType, dbo.Vehicles.NumberPlate, dbo.Vehicles.Active AS VehicleActive
FROM   dbo.ParkingBills INNER JOIN
             dbo.Vehicles ON dbo.ParkingBills.VehicleID = dbo.Vehicles.VehicleID INNER JOIN
             dbo.VehicleTypes ON dbo.Vehicles.VehicleTypeID = dbo.VehicleTypes.VehicleTypeID
GO
/****** Object:  View [dbo].[View_ParkingPlaceParts_ParkingBills_Vehicles_VehicleTypes]    Script Date: 2022-12-02 16:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_ParkingPlaceParts_ParkingBills_Vehicles_VehicleTypes]
AS
SELECT dbo.ParkingPlaceParts.ParkingPlacePartID, dbo.ParkingPlaceParts.ParkingPlaceID, dbo.ParkingPlaceParts.PartID, dbo.ParkingPlaceParts.RegNumber, dbo.ParkingBills.VehicleID, dbo.VehicleTypes.VehicleType, dbo.Vehicles.NumberPlate, dbo.Vehicles.DriverFullName, 
             dbo.ParkingBills.ArrivalDate, dbo.ParkingBills.DepartureDate, dbo.ParkingBills.StoppagePeriod, dbo.ParkingBills.Bill
FROM   dbo.ParkingBills INNER JOIN
             dbo.ParkingPlaceParts ON dbo.ParkingBills.RegNumber = dbo.ParkingPlaceParts.RegNumber INNER JOIN
             dbo.Vehicles ON dbo.ParkingBills.VehicleID = dbo.Vehicles.VehicleID INNER JOIN
             dbo.VehicleTypes ON dbo.Vehicles.VehicleTypeID = dbo.VehicleTypes.VehicleTypeID
GO
/****** Object:  Table [dbo].[Parts]    Script Date: 2022-12-02 16:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parts](
	[PartID] [tinyint] IDENTITY(1,1) NOT NULL,
	[Part] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Parts] PRIMARY KEY CLUSTERED 
(
	[PartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ParkingBills] ON 

INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (100, 3, 0, CAST(N'2022-11-24T15:06:00' AS SmallDateTime), CAST(N'2022-12-02T15:24:00' AS SmallDateTime), N'192:18', 7692.0000)
INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (101, 1, 1, CAST(N'2022-11-26T19:45:00' AS SmallDateTime), NULL, NULL, NULL)
INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (102, 2, 0, CAST(N'2022-11-25T23:10:00' AS SmallDateTime), CAST(N'2022-12-02T15:44:00' AS SmallDateTime), N'160:34', 12845.3333)
INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (104, 1, 1, CAST(N'2022-12-01T18:28:00' AS SmallDateTime), NULL, NULL, NULL)
INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (110, 27, 0, CAST(N'2022-12-01T18:49:00' AS SmallDateTime), CAST(N'2022-12-02T15:40:00' AS SmallDateTime), N'20:51', 1668.0000)
INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (111, 28, 1, CAST(N'2022-12-01T18:49:00' AS SmallDateTime), NULL, NULL, NULL)
INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (112, 29, 1, CAST(N'2022-12-01T18:50:00' AS SmallDateTime), NULL, NULL, NULL)
INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (113, 30, 1, CAST(N'2022-12-01T18:53:00' AS SmallDateTime), NULL, NULL, NULL)
INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (114, 31, 1, CAST(N'2022-12-01T19:01:00' AS SmallDateTime), NULL, NULL, NULL)
INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (115, 32, 1, CAST(N'2022-12-01T19:03:00' AS SmallDateTime), NULL, NULL, NULL)
INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (116, 33, 0, CAST(N'2022-12-01T19:07:00' AS SmallDateTime), CAST(N'2022-12-02T15:28:00' AS SmallDateTime), N'20:20', 1626.6667)
INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (117, 34, 1, CAST(N'2022-12-02T14:46:00' AS SmallDateTime), NULL, NULL, NULL)
INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (118, 35, 0, CAST(N'2022-12-02T14:49:00' AS SmallDateTime), CAST(N'2022-12-02T15:16:00' AS SmallDateTime), N'0:26', 17.3333)
INSERT [dbo].[ParkingBills] ([RegNumber], [VehicleID], [Active], [ArrivalDate], [DepartureDate], [StoppagePeriod], [Bill]) VALUES (119, 36, 0, CAST(N'2022-12-02T15:58:00' AS SmallDateTime), CAST(N'2022-12-02T16:01:00' AS SmallDateTime), N'0:3', 4.0000)
SET IDENTITY_INSERT [dbo].[ParkingBills] OFF
GO
SET IDENTITY_INSERT [dbo].[ParkingPlaceParts] ON 

INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (1, 1, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (2, 1, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (3, 2, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (4, 2, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (5, 3, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (6, 3, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (7, 4, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (8, 4, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (9, 5, 1, 113)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (10, 5, 2, 113)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (11, 6, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (12, 6, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (13, 7, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (14, 7, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (15, 8, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (16, 8, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (17, 9, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (18, 9, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (19, 10, 1, 104)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (20, 10, 2, 115)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (21, 11, 1, 117)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (22, 11, 2, 117)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (23, 12, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (24, 12, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (25, 13, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (26, 13, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (27, 14, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (28, 14, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (29, 15, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (30, 15, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (31, 16, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (32, 16, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (33, 17, 1, 111)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (34, 17, 2, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (35, 18, 1, 112)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (36, 18, 2, 112)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (37, 19, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (38, 19, 2, 114)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (39, 20, 1, NULL)
INSERT [dbo].[ParkingPlaceParts] ([ParkingPlacePartID], [ParkingPlaceID], [PartID], [RegNumber]) VALUES (40, 20, 2, NULL)
SET IDENTITY_INSERT [dbo].[ParkingPlaceParts] OFF
GO
SET IDENTITY_INSERT [dbo].[ParkingPlaces] ON 

INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (1, N'P01')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (2, N'P02')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (3, N'P03')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (4, N'P04')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (5, N'P05')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (6, N'P06')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (7, N'P07')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (8, N'P08')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (9, N'P09')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (10, N'P10')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (11, N'P11')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (12, N'P12')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (13, N'P13')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (14, N'P14')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (15, N'P15')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (16, N'P16')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (17, N'P17')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (18, N'P18')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (19, N'P19')
INSERT [dbo].[ParkingPlaces] ([ParkingPlaceID], [Name]) VALUES (20, N'P20')
SET IDENTITY_INSERT [dbo].[ParkingPlaces] OFF
GO
SET IDENTITY_INSERT [dbo].[Parts] ON 

INSERT [dbo].[Parts] ([PartID], [Part]) VALUES (1, N'Part1')
INSERT [dbo].[Parts] ([PartID], [Part]) VALUES (2, N'Part2')
SET IDENTITY_INSERT [dbo].[Parts] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicles] ON 

INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (1, 2, N'HKL012', N'Wille Svendson', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (2, 1, N'LPO657', N'Tove Svendson', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (3, 2, N'LER654', N'Kari Pettersen', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (14, 2, N'BBB300', N'Ali', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (15, 2, N'KLK345', N'William', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (16, 1, N'MM4589', N'Neo Neo', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (17, 1, N'GGH890', N'Aljjdsk jdj', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (18, 1, N'JOK', N'Karim', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (19, 1, N'KKK300', N'MAnan', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (20, 1, N'KLO657', N'kjsjk', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (21, 1, N'HOL000', N'kimdd', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (22, 1, N'PPP900', N'karin', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (23, 1, N'GGDF43', N'sfdf', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (24, 1, N'GG9870', N'df', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (25, 1, N'GDGUUY', N'sf', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (26, 1, N'SDG75', N'sdfsf', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (27, 1, N'KJI3S', N'hhhhhhhhh', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (28, 2, N'FSF545', N'sfsf', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (29, 1, N'DSF', N'sfds55', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (30, 1, N'DFGS', N'fsf', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (31, 2, N'GFKJ43', N'dfsf', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (32, 2, N'DDKK', N'sfdg', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (33, 1, N'54DF', N'sfd', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (34, 1, N'KNM700', N'Javad', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (35, 2, N'LLL490', N'Karim', NULL, NULL, 1)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [NumberPlate], [DriverFullName], [MobileNumber], [Email], [Active]) VALUES (36, 1, N'KKJD890', N'Wiliam ', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Vehicles] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleTypes] ON 

INSERT [dbo].[VehicleTypes] ([VehicleTypeID], [VehicleType]) VALUES (1, N'Car')
INSERT [dbo].[VehicleTypes] ([VehicleTypeID], [VehicleType]) VALUES (2, N'MC')
SET IDENTITY_INSERT [dbo].[VehicleTypes] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Number]    Script Date: 2022-12-02 16:10:16 ******/
ALTER TABLE [dbo].[ParkingPlaces] ADD  CONSTRAINT [UQ_Number] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Status]    Script Date: 2022-12-02 16:10:16 ******/
ALTER TABLE [dbo].[Parts] ADD  CONSTRAINT [UQ_Status] UNIQUE NONCLUSTERED 
(
	[Part] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicles_Active]    Script Date: 2022-12-02 16:10:16 ******/
CREATE NONCLUSTERED INDEX [IX_Vehicles_Active] ON [dbo].[Vehicles]
(
	[Active] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Vehicles_NumberPlate]    Script Date: 2022-12-02 16:10:16 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Vehicles_NumberPlate] ON [dbo].[Vehicles]
(
	[NumberPlate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_VehicleType]    Script Date: 2022-12-02 16:10:16 ******/
ALTER TABLE [dbo].[VehicleTypes] ADD  CONSTRAINT [UQ_VehicleType] UNIQUE NONCLUSTERED 
(
	[VehicleType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ParkingBills]  WITH CHECK ADD  CONSTRAINT [FK_ParkingBills_Vehicles] FOREIGN KEY([VehicleID])
REFERENCES [dbo].[Vehicles] ([VehicleID])
GO
ALTER TABLE [dbo].[ParkingBills] CHECK CONSTRAINT [FK_ParkingBills_Vehicles]
GO
ALTER TABLE [dbo].[ParkingPlaceParts]  WITH CHECK ADD  CONSTRAINT [FK_ParkingPlaceParts_ParkingBills] FOREIGN KEY([RegNumber])
REFERENCES [dbo].[ParkingBills] ([RegNumber])
GO
ALTER TABLE [dbo].[ParkingPlaceParts] CHECK CONSTRAINT [FK_ParkingPlaceParts_ParkingBills]
GO
ALTER TABLE [dbo].[ParkingPlaceParts]  WITH CHECK ADD  CONSTRAINT [FK_ParkingPlaceParts_ParkingPlaces] FOREIGN KEY([ParkingPlaceID])
REFERENCES [dbo].[ParkingPlaces] ([ParkingPlaceID])
GO
ALTER TABLE [dbo].[ParkingPlaceParts] CHECK CONSTRAINT [FK_ParkingPlaceParts_ParkingPlaces]
GO
ALTER TABLE [dbo].[ParkingPlaceParts]  WITH CHECK ADD  CONSTRAINT [FK_ParkingPlaceParts_Parts] FOREIGN KEY([PartID])
REFERENCES [dbo].[Parts] ([PartID])
GO
ALTER TABLE [dbo].[ParkingPlaceParts] CHECK CONSTRAINT [FK_ParkingPlaceParts_Parts]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_VehicleTypes] FOREIGN KEY([VehicleTypeID])
REFERENCES [dbo].[VehicleTypes] ([VehicleTypeID])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_VehicleTypes]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[37] 2[15] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ParkingBills"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 206
               Right = 290
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Vehicles"
            Begin Extent = 
               Top = 9
               Left = 347
               Bottom = 206
               Right = 572
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "VehicleTypes"
            Begin Extent = 
               Top = 9
               Left = 629
               Bottom = 152
               Right = 851
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ParkingBills_Vehicles_VehicleTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ParkingBills_Vehicles_VehicleTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[49] 2[6] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ParkingBills"
            Begin Extent = 
               Top = 31
               Left = 361
               Bottom = 228
               Right = 594
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ParkingPlaceParts"
            Begin Extent = 
               Top = 34
               Left = 72
               Bottom = 231
               Right = 324
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Vehicles"
            Begin Extent = 
               Top = 38
               Left = 630
               Bottom = 235
               Right = 855
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "VehicleTypes"
            Begin Extent = 
               Top = 63
               Left = 934
               Bottom = 206
               Right = 1156
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ParkingPlaceParts_ParkingBills_Vehicles_VehicleTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ParkingPlaceParts_ParkingBills_Vehicles_VehicleTypes'
GO
USE [master]
GO
ALTER DATABASE [PragueParkingDB] SET  READ_WRITE 
GO
