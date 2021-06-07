USE [master]
GO
/****** Object:  Database [IT-Center]    Script Date: 6/7/2021 8:15:23 PM ******/
CREATE DATABASE [IT-Center]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IT-Center', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\IT-Center.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IT-Center_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\IT-Center_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 COLLATE Cyrillic_General_100_CS_AS
GO
ALTER DATABASE [IT-Center] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IT-Center].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IT-Center] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IT-Center] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IT-Center] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IT-Center] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IT-Center] SET ARITHABORT OFF 
GO
ALTER DATABASE [IT-Center] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IT-Center] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IT-Center] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IT-Center] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IT-Center] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IT-Center] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IT-Center] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IT-Center] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IT-Center] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IT-Center] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IT-Center] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IT-Center] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IT-Center] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IT-Center] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IT-Center] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IT-Center] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IT-Center] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IT-Center] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IT-Center] SET  MULTI_USER 
GO
ALTER DATABASE [IT-Center] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IT-Center] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IT-Center] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IT-Center] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IT-Center] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IT-Center] SET QUERY_STORE = OFF
GO
USE [IT-Center]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FIrstName] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[LastName] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[MiddleName] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NULL,
	[TelephoneNumber] [nvarchar](13) COLLATE Cyrillic_General_100_CS_AS NULL,
	[Email] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detail]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[TypeOfDetailId] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Description] [nvarchar](max) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[Photo] [varbinary](max) NULL,
 CONSTRAINT [PK_Detail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailOfOrder]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailOfOrder](
	[OrderId] [int] NOT NULL,
	[DetailId] [int] NOT NULL,
 CONSTRAINT [PK_DetailOfOrder] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[LastName] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[MiddleName] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateTimeOfCreate] [datetime] NOT NULL,
	[DateTimeOfEnd] [datetime] NOT NULL,
	[ClientId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NULL,
	[Description] [nvarchar](max) COLLATE Cyrillic_General_100_CS_AS NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Descritpion] [nvarchar](max) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[TypeOfProductId] [int] NOT NULL,
	[Photo] [varbinary](max) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOfSale]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOfSale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[SaleId] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_ProductOfSale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateTimeOfSale] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[ClientId] [int] NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[Description] [nvarchar](max) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceOfOrder]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceOfOrder](
	[OrderId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceOfOrderStatusId] [int] NOT NULL,
 CONSTRAINT [PK_ServiceOfOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceOfOrderStatus]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceOfOrderStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
 CONSTRAINT [PK_ServiceOfOrderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfDetail]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
 CONSTRAINT [PK_TypeOfDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfProduct]    Script Date: 6/7/2021 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
 CONSTRAINT [PK_TypeOfProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/7/2021 8:15:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Detail]  WITH CHECK ADD  CONSTRAINT [FK_Detail_TypeOfDetail] FOREIGN KEY([TypeOfDetailId])
REFERENCES [dbo].[TypeOfDetail] ([Id])
GO
ALTER TABLE [dbo].[Detail] CHECK CONSTRAINT [FK_Detail_TypeOfDetail]
GO
ALTER TABLE [dbo].[DetailOfOrder]  WITH CHECK ADD  CONSTRAINT [FK_DetailOfOrder_Detail] FOREIGN KEY([DetailId])
REFERENCES [dbo].[Detail] ([Id])
GO
ALTER TABLE [dbo].[DetailOfOrder] CHECK CONSTRAINT [FK_DetailOfOrder_Detail]
GO
ALTER TABLE [dbo].[DetailOfOrder]  WITH CHECK ADD  CONSTRAINT [FK_DetailOfOrder_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[DetailOfOrder] CHECK CONSTRAINT [FK_DetailOfOrder_Order]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Role]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_User] FOREIGN KEY([Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Client]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Employee]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_TypeOfProduct] FOREIGN KEY([TypeOfProductId])
REFERENCES [dbo].[TypeOfProduct] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_TypeOfProduct]
GO
ALTER TABLE [dbo].[ProductOfSale]  WITH CHECK ADD  CONSTRAINT [FK_ProductOfSale_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductOfSale] CHECK CONSTRAINT [FK_ProductOfSale_Product]
GO
ALTER TABLE [dbo].[ProductOfSale]  WITH CHECK ADD  CONSTRAINT [FK_ProductOfSale_Sale] FOREIGN KEY([SaleId])
REFERENCES [dbo].[Sale] ([Id])
GO
ALTER TABLE [dbo].[ProductOfSale] CHECK CONSTRAINT [FK_ProductOfSale_Sale]
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK_Sale_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK_Sale_Client]
GO
ALTER TABLE [dbo].[ServiceOfOrder]  WITH CHECK ADD  CONSTRAINT [FK_ServiceOfOrder_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[ServiceOfOrder] CHECK CONSTRAINT [FK_ServiceOfOrder_Order]
GO
ALTER TABLE [dbo].[ServiceOfOrder]  WITH CHECK ADD  CONSTRAINT [FK_ServiceOfOrder_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[ServiceOfOrder] CHECK CONSTRAINT [FK_ServiceOfOrder_Service]
GO
ALTER TABLE [dbo].[ServiceOfOrder]  WITH CHECK ADD  CONSTRAINT [FK_ServiceOfOrder_ServiceOfOrderStatus] FOREIGN KEY([ServiceOfOrderStatusId])
REFERENCES [dbo].[ServiceOfOrderStatus] ([Id])
GO
ALTER TABLE [dbo].[ServiceOfOrder] CHECK CONSTRAINT [FK_ServiceOfOrder_ServiceOfOrderStatus]
GO
USE [master]
GO
ALTER DATABASE [IT-Center] SET  READ_WRITE 
GO
