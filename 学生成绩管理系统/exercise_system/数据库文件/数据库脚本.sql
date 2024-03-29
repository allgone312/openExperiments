USE [master]
GO
/****** Object:  Database [DB_Student]    Script Date: 07/09/2017 20:19:53 ******/
CREATE DATABASE [DB_Student] ON  PRIMARY 
( NAME = N'DB_Student', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\DB_Student.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB_Student_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\DB_Student_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_Student] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Student].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Student] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [DB_Student] SET ANSI_NULLS OFF
GO
ALTER DATABASE [DB_Student] SET ANSI_PADDING OFF
GO
ALTER DATABASE [DB_Student] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [DB_Student] SET ARITHABORT OFF
GO
ALTER DATABASE [DB_Student] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [DB_Student] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [DB_Student] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [DB_Student] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [DB_Student] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [DB_Student] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [DB_Student] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [DB_Student] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [DB_Student] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [DB_Student] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [DB_Student] SET  DISABLE_BROKER
GO
ALTER DATABASE [DB_Student] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [DB_Student] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [DB_Student] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [DB_Student] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [DB_Student] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [DB_Student] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [DB_Student] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [DB_Student] SET  READ_WRITE
GO
ALTER DATABASE [DB_Student] SET RECOVERY FULL
GO
ALTER DATABASE [DB_Student] SET  MULTI_USER
GO
ALTER DATABASE [DB_Student] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DB_Student] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_Student', N'ON'
GO
USE [DB_Student]
GO
/****** Object:  Table [dbo].[T_Major]    Script Date: 07/09/2017 20:19:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Major](
	[mid] [int] IDENTITY(1,1) NOT NULL,
	[major] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[mid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_role]    Script Date: 07/09/2017 20:19:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_role](
	[rid] [int] IDENTITY(1000,1) NOT NULL,
	[username] [nvarchar](20) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[rid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Major_list]    Script Date: 07/09/2017 20:19:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Major_list](
	[mlid] [int] NOT NULL,
	[mid] [int] NOT NULL,
	[majorin] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[mlid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Class]    Script Date: 07/09/2017 20:19:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Class](
	[classid] [bigint] NOT NULL,
	[mlid] [int] NOT NULL,
	[cyear] [int] NOT NULL,
	[pnum] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[classid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Student]    Script Date: 07/09/2017 20:19:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Student](
	[mainid] [bigint] IDENTITY(1000000,1) NOT NULL,
	[idnumber] [bigint] NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[time] [datetime] NOT NULL,
	[sex] [nchar](2) NOT NULL,
	[birthdate] [datetime] NOT NULL,
	[nation] [nchar](5) NOT NULL,
	[birthplace] [nvarchar](50) NOT NULL,
	[mlid] [int] NOT NULL,
	[classid] [bigint] NOT NULL,
	[studid] [bigint] NOT NULL,
	[address] [nvarchar](200) NULL,
	[phone] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[mainid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF__T_Class__pnum__33D4B598]    Script Date: 07/09/2017 20:19:55 ******/
ALTER TABLE [dbo].[T_Class] ADD  DEFAULT ((0)) FOR [pnum]
GO
/****** Object:  ForeignKey [FK__T_Major_lis__mid__0CBAE877]    Script Date: 07/09/2017 20:19:55 ******/
ALTER TABLE [dbo].[T_Major_list]  WITH CHECK ADD FOREIGN KEY([mid])
REFERENCES [dbo].[T_Major] ([mid])
GO
/****** Object:  ForeignKey [FK__T_Class__mlid__173876EA]    Script Date: 07/09/2017 20:19:55 ******/
ALTER TABLE [dbo].[T_Class]  WITH CHECK ADD FOREIGN KEY([mlid])
REFERENCES [dbo].[T_Major_list] ([mlid])
GO
/****** Object:  ForeignKey [FK__T_Student__class__32E0915F]    Script Date: 07/09/2017 20:19:55 ******/
ALTER TABLE [dbo].[T_Student]  WITH CHECK ADD FOREIGN KEY([classid])
REFERENCES [dbo].[T_Class] ([classid])
GO
/****** Object:  ForeignKey [FK__T_Student__mlid__31EC6D26]    Script Date: 07/09/2017 20:19:55 ******/
ALTER TABLE [dbo].[T_Student]  WITH CHECK ADD FOREIGN KEY([mlid])
REFERENCES [dbo].[T_Major_list] ([mlid])
GO
