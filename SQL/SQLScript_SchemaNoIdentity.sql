USE [master]
GO
/****** Object:  Database [FoodieAndTheBlowFish]    Script Date: 4/22/2016 3:26:45 PM ******/
CREATE DATABASE [FoodieAndTheBlowFish]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FoodieAndBlowFish', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\FoodieAndBlowFish.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FoodieAndBlowFish_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\FoodieAndBlowFish_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FoodieAndTheBlowFish].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET ARITHABORT OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET  MULTI_USER 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET DELAYED_DURABILITY = DISABLED 
GO
USE [FoodieAndTheBlowFish]
GO
/****** Object:  Table [dbo].[AdminStaticPages]    Script Date: 4/22/2016 3:26:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminStaticPages](
	[AdminPageId] [int] NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[MiniTitle] [varchar](20) NOT NULL,
	[AdminPageContent] [varchar](max) NOT NULL,
	[CreatedOn] [date] NOT NULL,
 CONSTRAINT [PK_AdminStaticPages] PRIMARY KEY CLUSTERED 
(
	[AdminPageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BlogPost_Tag]    Script Date: 4/22/2016 3:26:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPost_Tag](
	[BlogId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_BlogPost_Tag] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogPosts]    Script Date: 4/22/2016 3:26:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BlogPosts](
	[BlogId] [int] NOT NULL,
	[ContributorId] [uniqueidentifier] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[SubCategoryId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[MainPictureUrl] [varchar](125) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[PostContent] [varchar](max) NOT NULL,
	[Summary] [varchar](255) NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[PublishDate] [date] NULL,
	[ExpirationDated] [date] NULL,
	[ApprovedOn] [date] NOT NULL,
 CONSTRAINT [PK_BlogPosts] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4/22/2016 3:26:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] NOT NULL,
	[Category] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeniedPosts]    Script Date: 4/22/2016 3:26:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeniedPosts](
	[DenialId] [int] NOT NULL,
	[BlogId] [int] NOT NULL,
	[Reason] [varchar](max) NOT NULL,
	[DeniedOn] [date] NOT NULL,
 CONSTRAINT [PK_DeniedPosts] PRIMARY KEY CLUSTERED 
(
	[DenialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 4/22/2016 3:26:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Statuses](
	[StatusId] [int] NOT NULL,
	[Type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SubCategories]    Script Date: 4/22/2016 3:26:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubCategories](
	[SubCategoryId] [int] NOT NULL,
	[SubCategory] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SubCategories] PRIMARY KEY CLUSTERED 
(
	[SubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 4/22/2016 3:26:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tags](
	[TagId] [int] NOT NULL,
	[Tag] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[BlogPost_Tag]  WITH CHECK ADD  CONSTRAINT [FK_BlogPost_Tag_BlogPosts] FOREIGN KEY([BlogId])
REFERENCES [dbo].[BlogPosts] ([BlogId])
GO
ALTER TABLE [dbo].[BlogPost_Tag] CHECK CONSTRAINT [FK_BlogPost_Tag_BlogPosts]
GO
ALTER TABLE [dbo].[BlogPost_Tag]  WITH CHECK ADD  CONSTRAINT [FK_BlogPost_Tag_Tags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([TagId])
GO
ALTER TABLE [dbo].[BlogPost_Tag] CHECK CONSTRAINT [FK_BlogPost_Tag_Tags]
GO
ALTER TABLE [dbo].[BlogPosts]  WITH CHECK ADD  CONSTRAINT [FK_BlogPosts_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[BlogPosts] CHECK CONSTRAINT [FK_BlogPosts_Categories]
GO
ALTER TABLE [dbo].[BlogPosts]  WITH CHECK ADD  CONSTRAINT [FK_BlogPosts_Statuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Statuses] ([StatusId])
GO
ALTER TABLE [dbo].[BlogPosts] CHECK CONSTRAINT [FK_BlogPosts_Statuses]
GO
ALTER TABLE [dbo].[BlogPosts]  WITH CHECK ADD  CONSTRAINT [FK_BlogPosts_SubCategories] FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[SubCategories] ([SubCategoryId])
GO
ALTER TABLE [dbo].[BlogPosts] CHECK CONSTRAINT [FK_BlogPosts_SubCategories]
GO
ALTER TABLE [dbo].[DeniedPosts]  WITH CHECK ADD  CONSTRAINT [FK_DeniedPosts_BlogPosts] FOREIGN KEY([BlogId])
REFERENCES [dbo].[BlogPosts] ([BlogId])
GO
ALTER TABLE [dbo].[DeniedPosts] CHECK CONSTRAINT [FK_DeniedPosts_BlogPosts]
GO
USE [master]
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET  READ_WRITE 
GO
