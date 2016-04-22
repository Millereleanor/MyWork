
/****** Object:  Database [FoodieAndTheBlowFish]    Script Date: 4/22/2016 4:01:18 PM ******/
CREATE DATABASE [FoodieAndTheBlowFish]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FoodieAndTheBlowFish', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\FoodieAndTheBlowFish.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FoodieAndTheBlowFish_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\FoodieAndTheBlowFish_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  Table [dbo].[AdminStaticPages]    Script Date: 4/22/2016 4:01:18 PM ******/
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
/****** Object:  Table [dbo].[BlogPost_Tag]    Script Date: 4/22/2016 4:01:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPostTags](
	[BlogId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_BlogPost_Tag] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogPosts]    Script Date: 4/22/2016 4:01:18 PM ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 4/22/2016 4:01:18 PM ******/
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
/****** Object:  Table [dbo].[DeniedPosts]    Script Date: 4/22/2016 4:01:18 PM ******/
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
/****** Object:  Table [dbo].[IdentityClaim]    Script Date: 4/22/2016 4:01:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityClaim](
	[ClaimId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.IdentityClaim] PRIMARY KEY CLUSTERED 
(
	[ClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityLogin]    Script Date: 4/22/2016 4:01:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityLogin](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_IdentityLogin] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityProfile]    Script Date: 4/22/2016 4:01:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdentityProfile](
	[UserId] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](128) NULL,
	[MiddleName] [varchar](128) NULL,
	[LastName] [varchar](128) NULL,
	[CreateBy] [uniqueidentifier] NOT NULL,
	[CreateDate] [smalldatetime] NOT NULL,
	[ModifyBy] [uniqueidentifier] NOT NULL,
	[ModifyDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_IdentityProfile] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IdentityRole]    Script Date: 4/22/2016 4:01:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityRole](
	[RoleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.IdentityRole] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUser]    Script Date: 4/22/2016 4:01:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUser](
	[UserId] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[CreateBy] [uniqueidentifier] NOT NULL,
	[CreateDate] [smalldatetime] NOT NULL,
	[ModifyBy] [uniqueidentifier] NOT NULL,
	[ModifyDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_dbo.IdentityUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUserRole]    Script Date: 4/22/2016 4:01:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserRole](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.IdentityUserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 4/22/2016 4:01:18 PM ******/
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
/****** Object:  Table [dbo].[SubCategories]    Script Date: 4/22/2016 4:01:18 PM ******/
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
/****** Object:  Table [dbo].[Tags]    Script Date: 4/22/2016 4:01:18 PM ******/
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
ALTER TABLE [dbo].[IdentityProfile] ADD  CONSTRAINT [DF_IdentityUserProfile_CreateDate]  DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[IdentityProfile] ADD  CONSTRAINT [DF_IdentityUserProfile_ModifyDate]  DEFAULT (getutcdate()) FOR [ModifyDate]
GO
ALTER TABLE [dbo].[IdentityUser] ADD  CONSTRAINT [DF_IdentityUser_CreateDate]  DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[IdentityUser] ADD  CONSTRAINT [DF_IdentityUser_ModifyDate]  DEFAULT (getutcdate()) FOR [ModifyDate]
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
ALTER TABLE [dbo].[IdentityClaim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityClaim_dbo.IdentityUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUser] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityClaim] CHECK CONSTRAINT [FK_dbo.IdentityClaim_dbo.IdentityUser_UserId]
GO
ALTER TABLE [dbo].[IdentityLogin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityLogin_dbo.IdentityUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUser] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityLogin] CHECK CONSTRAINT [FK_dbo.IdentityLogin_dbo.IdentityUser_UserId]
GO
ALTER TABLE [dbo].[IdentityProfile]  WITH CHECK ADD  CONSTRAINT [FK_IdentityProfile_IdentityUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUser] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityProfile] CHECK CONSTRAINT [FK_IdentityProfile_IdentityUser]
GO
ALTER TABLE [dbo].[IdentityUserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserRole_dbo.IdentityRole_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[IdentityRole] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityUserRole] CHECK CONSTRAINT [FK_dbo.IdentityUserRole_dbo.IdentityRole_RoleId]
GO
ALTER TABLE [dbo].[IdentityUserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserRole_dbo.IdentityUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUser] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityUserRole] CHECK CONSTRAINT [FK_dbo.IdentityUserRole_dbo.IdentityUser_UserId]
GO
USE [master]
GO
ALTER DATABASE [FoodieAndTheBlowFish] SET  READ_WRITE 
GO
