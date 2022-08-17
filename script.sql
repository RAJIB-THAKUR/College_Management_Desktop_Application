USE [master]
GO
/****** Object:  Database [College_Database]    Script Date: 8/17/2022 11:48:09 AM ******/
CREATE DATABASE [College_Database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DB2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DB2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [College_Database] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [College_Database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [College_Database] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [College_Database] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [College_Database] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [College_Database] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [College_Database] SET ARITHABORT OFF 
GO
ALTER DATABASE [College_Database] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [College_Database] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [College_Database] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [College_Database] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [College_Database] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [College_Database] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [College_Database] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [College_Database] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [College_Database] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [College_Database] SET  ENABLE_BROKER 
GO
ALTER DATABASE [College_Database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [College_Database] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [College_Database] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [College_Database] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [College_Database] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [College_Database] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [College_Database] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [College_Database] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [College_Database] SET  MULTI_USER 
GO
ALTER DATABASE [College_Database] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [College_Database] SET DB_CHAINING OFF 
GO
ALTER DATABASE [College_Database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [College_Database] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [College_Database] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [College_Database] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [College_Database] SET QUERY_STORE = OFF
GO
USE [College_Database]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[add_Id] [int] IDENTITY(1000,1) NOT NULL,
	[Address] [varchar](30) NULL,
	[c_Id] [int] NULL,
	[person_Id] [int] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[add_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[c_Id] [int] IDENTITY(1000,1) NOT NULL,
	[cityName] [varchar](30) NULL,
	[pinCode] [int] NULL,
	[country] [varchar](50) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[c_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[dept_Id] [int] NOT NULL,
	[deptName] [varchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[dept_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacultyRoom]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacultyRoom](
	[Id] [int] NULL,
	[BuildingName] [varchar](50) NULL,
	[RoomNumber] [int] NULL,
	[AllocatedTo] [varchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hostel]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hostel](
	[id] [int] NULL,
	[BuildingName] [varchar](50) NULL,
	[RoomNumber] [int] NULL,
	[AllocatedTo] [varchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[person_Id] [int] IDENTITY(1000,1) NOT NULL,
	[firstName] [varchar](30) NULL,
	[lastName] [varchar](30) NULL,
	[type] [varchar](30) NULL,
	[mobile] [varchar](10) NULL,
	[dept_Id] [int] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[person_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[sem_id] [int] NOT NULL,
	[sem_Name] [varchar](3) NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[sem_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudyingSub]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudyingSub](
	[person_Id] [int] NOT NULL,
	[sub_code] [varchar](7) NOT NULL,
 CONSTRAINT [PK_PersonID_subCode] PRIMARY KEY CLUSTERED 
(
	[person_Id] ASC,
	[sub_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[sub_code] [varchar](7) NOT NULL,
	[sub_name] [varchar](30) NULL,
	[isElective] [bit] NULL,
	[isCommonForAll] [bit] NULL,
	[dept_Id] [int] NULL,
	[sem_id] [int] NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[sub_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1004, N'Purulia', 1001, 1014)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1005, N'Vidhan Nagar', 1002, 1015)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1010, N'Suraj Nagar', 1000, 1017)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1011, N'Raj Nagar', 1003, 1018)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1016, N'Gujar Gally', 1007, 1024)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1017, N'Rishi Nagar', 1006, 1025)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1018, N'Home town', 1003, 1026)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1019, N'Chandni Chowk', 1007, 1027)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1020, N'Chanadan Nagar', 1005, 1028)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1021, N'Poorna Nagar', 1007, 1029)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1022, N'Tollygunje', 1001, 1030)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1023, N'Chands Nagar', 1001, 1013)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1024, N'Rukni', 1008, 1019)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1025, N'Rudra Nagar', 1009, 1020)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1029, N'Chelyama', 1007, 1036)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1030, N'Bandra', 1004, 1037)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1031, N'New Town', 1001, 1038)
INSERT [dbo].[Address] ([add_Id], [Address], [c_Id], [person_Id]) VALUES (1032, N'Sector-38', 1007, 1039)
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([c_Id], [cityName], [pinCode], [country]) VALUES (1000, N'Agra', 735100, N'India')
INSERT [dbo].[City] ([c_Id], [cityName], [pinCode], [country]) VALUES (1001, N'Kolkata', 735101, N'India')
INSERT [dbo].[City] ([c_Id], [cityName], [pinCode], [country]) VALUES (1002, N'Aligarh', 735102, N'India')
INSERT [dbo].[City] ([c_Id], [cityName], [pinCode], [country]) VALUES (1003, N'Delhi', 735103, N'India')
INSERT [dbo].[City] ([c_Id], [cityName], [pinCode], [country]) VALUES (1004, N'Mumbai', 735104, N'India')
INSERT [dbo].[City] ([c_Id], [cityName], [pinCode], [country]) VALUES (1005, N'Pune', 735105, N'India')
INSERT [dbo].[City] ([c_Id], [cityName], [pinCode], [country]) VALUES (1006, N'Patna', 735106, N'India')
INSERT [dbo].[City] ([c_Id], [cityName], [pinCode], [country]) VALUES (1007, N'Gurugram', 735107, N'India')
INSERT [dbo].[City] ([c_Id], [cityName], [pinCode], [country]) VALUES (1008, N'Noida', 735108, N'India')
INSERT [dbo].[City] ([c_Id], [cityName], [pinCode], [country]) VALUES (1009, N'Leh', 735109, N'India')
SET IDENTITY_INSERT [dbo].[City] OFF
GO
INSERT [dbo].[Department] ([dept_Id], [deptName]) VALUES (1, N'CSE')
INSERT [dbo].[Department] ([dept_Id], [deptName]) VALUES (2, N'EE')
INSERT [dbo].[Department] ([dept_Id], [deptName]) VALUES (3, N'IT')
INSERT [dbo].[Department] ([dept_Id], [deptName]) VALUES (4, N'ME')
GO
INSERT [dbo].[FacultyRoom] ([Id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'ASU', 100, N'FACULTY')
INSERT [dbo].[FacultyRoom] ([Id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'ASU', 101, N'FACULTY')
INSERT [dbo].[FacultyRoom] ([Id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'ASU', 102, N'FACULTY')
INSERT [dbo].[FacultyRoom] ([Id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'ZOZILA', 200, N'FACULTY')
INSERT [dbo].[FacultyRoom] ([Id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'ZOZILA', 201, N'FACULTY')
INSERT [dbo].[FacultyRoom] ([Id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (1029, N'ZOZILA', 202, N'FACULTY')
INSERT [dbo].[FacultyRoom] ([Id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (1018, N'GAGRIN', 301, N'FACULTY')
INSERT [dbo].[FacultyRoom] ([Id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'GAGRIN', 302, N'FACULTY')
INSERT [dbo].[FacultyRoom] ([Id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'GAGRIN', 303, N'FACULTY')
INSERT [dbo].[FacultyRoom] ([Id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (1030, N'ALPHA', 401, N'FACULTY')
INSERT [dbo].[FacultyRoom] ([Id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'ALPHA', 402, N'FACULTY')
INSERT [dbo].[FacultyRoom] ([Id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'ALPHA', 403, N'FACULTY')
GO
INSERT [dbo].[Hostel] ([id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (1038, N'RKC', 101, N'STUDENT')
INSERT [dbo].[Hostel] ([id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'RKC', 102, N'STUDENT')
INSERT [dbo].[Hostel] ([id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'RKC', 103, N'STUDENT')
INSERT [dbo].[Hostel] ([id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'RKC', 104, N'STUDENT')
INSERT [dbo].[Hostel] ([id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'RKC', 105, N'STUDENT')
INSERT [dbo].[Hostel] ([id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'BKC', 201, N'STUDENT')
INSERT [dbo].[Hostel] ([id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'BKC', 202, N'STUDENT')
INSERT [dbo].[Hostel] ([id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (1037, N'BKC', 203, N'STUDENT')
INSERT [dbo].[Hostel] ([id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (1025, N'BKC', 204, N'STUDENT')
INSERT [dbo].[Hostel] ([id], [BuildingName], [RoomNumber], [AllocatedTo]) VALUES (NULL, N'BKC', 205, N'STUDENT')
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1013, N'Rajib', N'Thakur', N'Student', N'8576876543', 1)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1014, N'Ram', N'Lala', N'Student', N'1232112321', 3)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1015, N'Vanshika', N'Garg', N'Student', N'1234323456', 2)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1017, N'Shuvam', N'Sharma', N'Student', N'1234323467', 3)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1018, N'Rajesh', N'Roy', N'Faculty', N'1232112345', 3)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1019, N'Aaditya', N'Kuthiala', N'Student', N'4567653218', 2)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1020, N'Raj', N'Singh', N'Student', N'1232123456', 3)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1024, N'Riti', N'Kumari', N'Student', N'1232312345', 1)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1025, N'Krishna', N'Kumar', N'Student', N'5678909876', 2)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1026, N'Albert', N'Json', N'Adminsitrator', N'5676545678', 4)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1027, N'Sumit', N'Goyal', N'Faculty', N'8987678907', 2)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1028, N'Rakesh', N'Malviya', N'Faculty', N'7678909876', 4)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1029, N'Nisha', N'Agarwal', N'Faculty', N'6478484858', 3)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1030, N'Supratik', N'Sarkar', N'Faculty', N'5497678689', 4)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1031, N'Sourav', N'Goswami', N'Student', N'9987678908', 4)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1036, N'Abhishek', N'Tripathi', N'Student', N'8767889988', 2)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1037, N'Ajay', N'Devgan', N'Student', N'7876589087', 1)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1038, N'Arpan', N'Mehta', N'Student', N'8509722478', 1)
INSERT [dbo].[Person] ([person_Id], [firstName], [lastName], [type], [mobile], [dept_Id]) VALUES (1039, N'Jeet', N'Kumar', N'Student', N'8509722769', 1)
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
INSERT [dbo].[Semester] ([sem_id], [sem_Name]) VALUES (1, N'1st')
INSERT [dbo].[Semester] ([sem_id], [sem_Name]) VALUES (2, N'2nd')
INSERT [dbo].[Semester] ([sem_id], [sem_Name]) VALUES (3, N'3rd')
INSERT [dbo].[Semester] ([sem_id], [sem_Name]) VALUES (4, N'4th')
INSERT [dbo].[Semester] ([sem_id], [sem_Name]) VALUES (5, N'5th')
INSERT [dbo].[Semester] ([sem_id], [sem_Name]) VALUES (6, N'6th')
INSERT [dbo].[Semester] ([sem_id], [sem_Name]) VALUES (7, N'7th')
INSERT [dbo].[Semester] ([sem_id], [sem_Name]) VALUES (8, N'8th')
GO
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1013, N'CM-CS50')
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1013, N'EL-CS80')
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1013, N'PC-CS01')
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1013, N'PC-CS02')
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1015, N'CM-EE50')
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1015, N'EL-EE80')
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1015, N'PC-EE01')
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1015, N'PC-EE02')
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1037, N'EL-CS90')
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1038, N'CM-CS50')
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1038, N'EL-CS90')
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1038, N'PC-CS01')
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1038, N'PC-CS02')
INSERT [dbo].[StudyingSub] ([person_Id], [sub_code]) VALUES (1038, N'PC-CS31')
GO
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'CM-CS50', N'Mathematics', 0, 1, 1, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'CM-EE50', N'Mathematics', 0, 1, 2, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'CM-IT50', N'Mathematics', 0, 1, 3, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'CM-ME50', N'Mathematics', 0, 1, 4, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'EL-CS80', N'Physics', 1, 1, 1, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'EL-CS90', N'Chemistry', 1, 1, 1, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'EL-EE80', N'Physics', 1, 1, 2, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'EL-EE90', N'Chemistry', 1, 1, 2, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'EL-IT80', N'Physics', 1, 1, 3, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'EL-IT90', N'Chemistry', 1, 1, 3, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'EL-ME80', N'Physics', 1, 1, 4, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'EL-ME90', N'Chemistry', 1, 1, 4, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-CS01', N'OOPS', 0, 0, 1, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-CS02', N'AUTOMATA', 0, 0, 1, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-CS10', N'Artificial Intelligence', 1, 0, 1, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-CS11', N'Matlab', 1, 0, 1, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-CS21', N'Data Structure', 0, 0, 1, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-CS22', N'Software Engineering', 0, 0, 1, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-CS31', N'Computer Architecture', 0, 0, 1, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-CS55', N'ML', 1, 0, 1, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-EE01', N'Digital Electronics', 0, 0, 2, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-EE02', N'Architecture', 0, 0, 2, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-EE10', N'Basic Electrical', 1, 0, 2, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-EE11', N'Circuit Design', 1, 0, 2, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-EE21', N'Power System', 0, 0, 2, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-EE22', N'Control System', 0, 0, 2, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-IT01', N'DAA', 0, 0, 3, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-IT02', N'TOC', 0, 0, 3, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-IT10', N'Python', 1, 0, 3, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-IT11', N'Cyber Security', 1, 0, 3, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-IT21', N'Operating System', 0, 0, 3, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-IT22', N'DBMS', 0, 0, 3, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-ME01', N'Solid Mechanics', 0, 0, 4, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-ME02', N'Heat Transfer', 0, 0, 4, 2)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-ME10', N'Thermodynamics', 1, 0, 4, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-ME11', N'Autocad', 1, 0, 4, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-ME21', N'Kinematics', 0, 0, 4, 8)
INSERT [dbo].[Subject] ([sub_code], [sub_name], [isElective], [isCommonForAll], [dept_Id], [sem_id]) VALUES (N'PC-ME22', N'3D Printing', 0, 0, 4, 8)
GO
ALTER TABLE [dbo].[City] ADD  CONSTRAINT [df_Country]  DEFAULT ('India') FOR [country]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_City] FOREIGN KEY([c_Id])
REFERENCES [dbo].[City] ([c_Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_City]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Person] FOREIGN KEY([person_Id])
REFERENCES [dbo].[Person] ([person_Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Person]
GO
ALTER TABLE [dbo].[FacultyRoom]  WITH CHECK ADD  CONSTRAINT [FK_FacultyRoom_Person1] FOREIGN KEY([Id])
REFERENCES [dbo].[Person] ([person_Id])
GO
ALTER TABLE [dbo].[FacultyRoom] CHECK CONSTRAINT [FK_FacultyRoom_Person1]
GO
ALTER TABLE [dbo].[Hostel]  WITH CHECK ADD  CONSTRAINT [FK_Hostel_Person] FOREIGN KEY([id])
REFERENCES [dbo].[Person] ([person_Id])
GO
ALTER TABLE [dbo].[Hostel] CHECK CONSTRAINT [FK_Hostel_Person]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Department] FOREIGN KEY([dept_Id])
REFERENCES [dbo].[Department] ([dept_Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Department]
GO
ALTER TABLE [dbo].[StudyingSub]  WITH CHECK ADD  CONSTRAINT [FK_StudyingSub_Person] FOREIGN KEY([person_Id])
REFERENCES [dbo].[Person] ([person_Id])
GO
ALTER TABLE [dbo].[StudyingSub] CHECK CONSTRAINT [FK_StudyingSub_Person]
GO
ALTER TABLE [dbo].[StudyingSub]  WITH CHECK ADD  CONSTRAINT [FK_StudyingSub_Subject] FOREIGN KEY([sub_code])
REFERENCES [dbo].[Subject] ([sub_code])
GO
ALTER TABLE [dbo].[StudyingSub] CHECK CONSTRAINT [FK_StudyingSub_Subject]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Department] FOREIGN KEY([dept_Id])
REFERENCES [dbo].[Department] ([dept_Id])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_Department]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Semester] FOREIGN KEY([sem_id])
REFERENCES [dbo].[Semester] ([sem_id])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_Semester]
GO
/****** Object:  StoredProcedure [dbo].[CityDetails]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CityDetails]
as
Select * from City
go;
GO
/****** Object:  StoredProcedure [dbo].[Insert_Address]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insert_Address]
(
@Address varchar(30),
@c_Id int,
@person_Id int
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10

declare @add_Id int
set @add_Id=0

if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    insert into 
    Address(Address,c_Id,person_Id) values (@Address,@c_Id,@person_Id)
    SET @add_Id = SCOPE_IDENTITY()
    IF(@@error<>0)
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END

RETURN @add_Id

CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[Insert_Elective_Subject]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insert_Elective_Subject]
(
@person_ID INT,
@sub_code varchar(7)
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10


if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END

IF EXISTS (Select * from StudyingSub where person_Id=@person_ID AND sub_code=@sub_code)
BEGIN 
	return 0
END
ELSE
BEGIN
   Insert into StudyingSub(person_Id,sub_code) values (@person_ID,@sub_code)
   return 1
END 


CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[Insert_Faculty]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Insert_Faculty]
(
@Person_Id int,
@Building_Name varchar(50),
@RoomNo int
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10

if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
	UPDATE FacultyRoom
    SET id = @Person_Id
    WHERE @Building_Name = BuildingName and @RoomNo=RoomNumber;
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END


CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[Insert_Hostel]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Insert_Hostel]
(
@Person_Id int,
@Building_Name varchar(50),
@RoomNo int
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10

if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
	UPDATE Hostel
    SET id = @Person_Id
    WHERE @Building_Name = BuildingName and @RoomNo=RoomNumber;
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END


CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[Insert_non_Elective_Subject]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insert_non_Elective_Subject]
(
@person_ID INT,
@sub_code varchar(7)
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10


if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END

IF EXISTS (Select * from StudyingSub where person_Id=@person_ID AND sub_code=@sub_code)
BEGIN 
	return 0
END
ELSE
BEGIN
   Insert into StudyingSub(person_Id,sub_code) values (@person_ID,@sub_code)
   return 1
END 


CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[Insert_Person]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insert_Person]
(
@FirstName varchar(30),
@LastName varchar(30),
@Type varchar(30),
@Mobile varchar(10),
@Dept_Id int
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10

declare @person_Id int
set @person_Id=0

if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    insert into 
    Person(firstName,lastName,type,mobile,dept_Id) values(@FirstName,@LastName,@Type,@Mobile,@Dept_Id)
    SET @person_Id = SCOPE_IDENTITY()
    IF(@@error<>0)

        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END

RETURN @person_Id

CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end

exec Insert_Person 'Raja','Swami','Student','1234565432','1';
select* from Person
--create procedure UpdatePerson
--(@Person_ID int,
--@FirstName varchar(50),
--@LastName varchar(50),
--@Add_ID int,
--@Phone_No varchar(15)
--)
--as
--begin
--update College_Person
--set 
--        FirstName=@FirstName,
--        LastName=@LastName,
--        Add_ID=@Add_ID,
--        Phone_No=@Phone_No
--        where Person_ID=@Person_ID
--end

--    else if @StatementType = 'Delete'
--    begin
--         delete from College_Person
--         where  Person_ID = @Person_ID
--    end
--end

--exec AddPerson 'ram','sar',2,'1236','insert'
GO
/****** Object:  StoredProcedure [dbo].[Insert_Subject]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insert_Subject]
(
@sub_code varchar(7),
@sub_name varchar(30),
@isElective bit,
@isCommonForAll bit,
@Dept_Id int,
@sem_id int
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10

if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    insert into 
    Subject(sub_code,sub_name,isElective,isCommonForAll,Dept_Id,sem_id) values(@sub_code,@sub_name,@isElective,@isCommonForAll,@Dept_Id,@sem_id)
    IF(@@error<>0)

        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END

CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[Insertcity]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insertcity]( @c_Id int,
                            @cityName varchar(30),
                            @pinCode int ,
                            @country varchar(50))
        as
    begin
     INSERT INTO City(c_Id,
                           cityName,
                           pinCode,
                           country
                            )

            VALUES     ( @c_Id ,
                         @cityName ,
                         @pinCode ,
                         @country )

end
GO
/****** Object:  StoredProcedure [dbo].[Return_Person_Id]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Return_Person_Id]
(
@Name varchar(30),
@Type varchar(30)
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10

declare @person_Id int
set @person_Id=0

if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    
    SET @person_Id = SCOPE_IDENTITY()
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END

RETURN (Select person_Id from Person where firstName=@Name and type=@Type)

CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[Select_Sub_Dept_Sem_Wise]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Select_Sub_Dept_Sem_Wise]
(
@Dept_Id int,
@Sem_Id int
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10



if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    Select deptName,sub_code,sub_name,sem_Name,isElective,isCommonForAll
	from Subject inner join Department on Subject.dept_Id = Department.dept_Id 
	inner join Semester on Subject.sem_id = Semester.sem_id
	where Semester.sem_id=@Sem_Id and Department.dept_Id =@Dept_Id
;

    IF(@@error<>0)

        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END



CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end

GO
/****** Object:  StoredProcedure [dbo].[Select_Sub_Dept_Wise]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Select_Sub_Dept_Wise]
(
@Dept_Id int
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10



if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    Select deptName,sub_code,sub_name,sem_Name,isElective,isCommonForAll
	from Subject inner join Department on Subject.dept_Id = Department.dept_Id 
	inner join Semester on Subject.sem_id = Semester.sem_id
	where Department.dept_Id=@Dept_Id;

    IF(@@error<>0)

        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END



CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end

GO
/****** Object:  StoredProcedure [dbo].[SelectAllPerson]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllPerson]
AS
SELECT * FROM Person
GO;
GO
/****** Object:  StoredProcedure [dbo].[SelectPersonWithTypeMobile]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Stored Procedure With Multiple Parameters--
CREATE PROCEDURE [dbo].[SelectPersonWithTypeMobile] @type varchar(30), @mobile varchar(10)
AS
begin
SELECT * FROM Person WHERE type = @type AND mobile =  @mobile
end
;
GO
/****** Object:  StoredProcedure [dbo].[sp_Deallocate_Faculty]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_Deallocate_Faculty]
(
@Person_Id int
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10

if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
	UPDATE FacultyRoom
    SET id = NULL
    WHERE @Person_Id = id;
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END


CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[sp_Deallocate_Hostel]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_Deallocate_Hostel]
(
@Person_Id int
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10

if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
	UPDATE Hostel
    SET id = NULL
    WHERE @Person_Id = id;
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END


CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[sp_Non_Elective_subCode_WRT_Dept_Sem]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Non_Elective_subCode_WRT_Dept_Sem]
(
@Dept_Id int,
@Sem_Id int
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10


if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    Select * from Subject where @Dept_Id=dept_Id AND @Sem_Id=sem_id and isElective=0;
	
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END



CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[sp_RoomNoFaculty_WRT_BuildingName]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_RoomNoFaculty_WRT_BuildingName]
(
@Building_Name varchar(30)
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10


if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    Select * from FacultyRoom where @Building_Name=BuildingName and  id IS NULL;
	
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END



CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[sp_RoomNoHostel_WRT_BuildingName]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_RoomNoHostel_WRT_BuildingName]
(
@Building_Name varchar(30)
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10


if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    Select * from Hostel where @Building_Name=BuildingName and  id IS NULL;
	
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END



CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[sp_Select_Person_Sub]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Select_Person_Sub]
(
@Dept_Id int,
@Sem_Id int,
@Person_Id int
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10


if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    Select Subject.sub_code,sub_name,isElective,isCommonForAll,deptName,sem_Name
	from Subject inner join Department on Subject.dept_Id = Department.dept_Id 
	inner join Semester on Subject.sem_id = Semester.sem_id 
	inner join StudyingSub on Subject.sub_code = StudyingSub.sub_code
	where Semester.sem_id=@Sem_Id and Department.dept_Id =@Dept_Id and StudyingSub.person_Id=@Person_Id
;

    IF(@@error<>0)

        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END



CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end

GO
/****** Object:  StoredProcedure [dbo].[spCheckId_in_Faculty]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spCheckId_in_Faculty]
(
@Search_Id INT
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10


if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END

IF EXISTS (Select * from FacultyRoom where id=@Search_Id)
BEGIN 
	return 1
END
ELSE
BEGIN
   return 0
END 


CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[spCheckId_in_Hostel]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spCheckId_in_Hostel]
(
@Search_Id INT
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10


if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END

IF EXISTS (Select * from Hostel where id=@Search_Id)
BEGIN 
	return 1
END
ELSE
BEGIN
   return 0
END 


CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[spElective_subCode_WRT_Dept_Sem]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spElective_subCode_WRT_Dept_Sem]
(
@Dept_Id int,
@Sem_Id int
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10


if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    Select * from Subject where @Dept_Id=dept_Id AND @Sem_Id=sem_id and isElective=1;
	
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END



CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[spName_WRT_Dept]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spName_WRT_Dept]
(
@dept_Id int
)
as 
begin
set nocount on;
declare @transtarted bit
set @transtarted=0

declare @errorcode int
set @errorcode=10


if(@@TRANCOUNT=0)
 BEGIN
    BEGIN TRANSACTION
    SET @transtarted=1
 END

 BEGIN
    Select * from Person where @dept_Id=dept_Id AND type='Student' ;
	
    IF(@@error<>0)
	
        BEGIN
            SET @errorcode=1
            GOTO CLEANUP
        END
 END
 

IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        COMMIT TRANSACTION
    END



CLEANUP:
    IF(@transtarted=1)
    BEGIN
        SET @transtarted=0
        ROLLBACK TRANSACTION
    END

    return @errorcode


end
GO
/****** Object:  StoredProcedure [dbo].[Student_Subject]    Script Date: 8/17/2022 11:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Student_Subject]
AS
BEGIN  
SELECT Person.person_Id,Person.firstName,Person.lastName,Person.mobile,Person.type,
Subject.sub_code,Subject.sub_name,Subject.isCommonForAll

FROM Person
INNER JOIN Subject
ON Person.dept_Id=Subject.dept_Id
where Person.type='Student';
END
GO
USE [master]
GO
ALTER DATABASE [College_Database] SET  READ_WRITE 
GO
