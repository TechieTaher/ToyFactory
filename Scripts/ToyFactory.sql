USE [master]
GO
/****** Object:  Database [ToyFactoryDb]    Script Date: 3/30/2020 4:21:56 PM ******/
CREATE DATABASE [ToyFactoryDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ToyFactoryDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ToyFactoryDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ToyFactoryDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ToyFactoryDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ToyFactoryDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ToyFactoryDb].[dbo].[sp_fulltext_database] @action = 'enable'
end

GO
ALTER DATABASE [ToyFactoryDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ToyFactoryDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ToyFactoryDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ToyFactoryDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ToyFactoryDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ToyFactoryDb] SET  MULTI_USER 
GO
ALTER DATABASE [ToyFactoryDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ToyFactoryDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ToyFactoryDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ToyFactoryDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ToyFactoryDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ToyFactoryDb] SET QUERY_STORE = OFF
GO
USE [ToyFactoryDb]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 3/30/2020 4:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressLine1] [varchar](100) NOT NULL,
	[AddressLine2] [varchar](100) NOT NULL,
	[Locality] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[PostalCode] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationObjectName]    Script Date: 3/30/2020 4:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationObjectName](
	[ApplicationObjectNameId] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationObjectName] [varchar](50) NOT NULL,
	[ApplicationObjectTypeId] [int] NOT NULL,
 CONSTRAINT [PK_ApplicationObjectName] PRIMARY KEY CLUSTERED 
(
	[ApplicationObjectNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationObjectType]    Script Date: 3/30/2020 4:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationObjectType](
	[ApplicationObjectTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationObjectTypeName] [varchar](50) NULL,
 CONSTRAINT [PK_ApplicationObjectType] PRIMARY KEY CLUSTERED 
(
	[ApplicationObjectTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 3/30/2020 4:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[PhoneNo] [bigint] NOT NULL,
	[EmaiId] [varchar](100) NOT NULL,
	[City] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManufactureUnits]    Script Date: 3/30/2020 4:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManufactureUnits](
	[ManufactureUnitId] [int] IDENTITY(1,1) NOT NULL,
	[ManufactureUnitName] [varchar](50) NULL,
	[Address] [varchar](50) NOT NULL,
	[IsWorking] [bit] NOT NULL,
 CONSTRAINT [PK_ManufactureUnits] PRIMARY KEY CLUSTERED 
(
	[ManufactureUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 3/30/2020 4:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 3/30/2020 4:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
	[Discount] [int] NOT NULL,
	[PaymentId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 3/30/2020 4:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentType] [int] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/30/2020 4:21:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[Price] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[HsnCode] [int] NULL,
	[Description] [varchar](200) NOT NULL,
	[ManufactureDate] [datetime] NOT NULL,
	[ManufaturingUnitId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ManufactureUnits] ADD  CONSTRAINT [DF_ManufactureUnits_IsWorking]  DEFAULT ((0)) FOR [IsWorking]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Customers]
GO
ALTER TABLE [dbo].[ApplicationObjectName]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationObjectName_ApplicationObjectType] FOREIGN KEY([ApplicationObjectTypeId])
REFERENCES [dbo].[ApplicationObjectType] ([ApplicationObjectTypeId])
GO
ALTER TABLE [dbo].[ApplicationObjectName] CHECK CONSTRAINT [FK_ApplicationObjectName_ApplicationObjectType]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Address]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Payments] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payments] ([PaymentId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Payments]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ManufactureUnits] FOREIGN KEY([ManufaturingUnitId])
REFERENCES [dbo].[ManufactureUnits] ([ManufactureUnitId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ManufactureUnits]
GO
USE [master]
GO
ALTER DATABASE [ToyFactoryDb] SET  READ_WRITE 
GO
