USE [master]
GO
/****** Object:  Database [dbArandaTest]    Script Date: 20/02/2021 22:56:23 ******/
CREATE DATABASE [dbArandaTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbArandaTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbArandaTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbArandaTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbArandaTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbArandaTest] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbArandaTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbArandaTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbArandaTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbArandaTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbArandaTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbArandaTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbArandaTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbArandaTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbArandaTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbArandaTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbArandaTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbArandaTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbArandaTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbArandaTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbArandaTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbArandaTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbArandaTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbArandaTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbArandaTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbArandaTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbArandaTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbArandaTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbArandaTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbArandaTest] SET RECOVERY FULL 
GO
ALTER DATABASE [dbArandaTest] SET  MULTI_USER 
GO
ALTER DATABASE [dbArandaTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbArandaTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbArandaTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbArandaTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbArandaTest] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbArandaTest', N'ON'
GO
ALTER DATABASE [dbArandaTest] SET QUERY_STORE = OFF
GO
USE [dbArandaTest]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 20/02/2021 22:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RolId] [int] NOT NULL,
	[Crear] [bit] NOT NULL,
	[Ver] [bit] NOT NULL,
	[Editar] [bit] NOT NULL,
	[Eliminar] [bit] NOT NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 20/02/2021 22:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[DateCreation] [datetime] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20/02/2021 22:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](80) NOT NULL,
	[Telefono] [nvarchar](20) NULL,
	[Password] [nvarchar](150) NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[Apellidos] [nvarchar](50) NOT NULL,
	[RolesId] [int] NOT NULL,
	[Block] [bit] NOT NULL,
	[Direccion] [nvarchar](100) NULL,
	[FechaNacimiento] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Permisos] ON 
GO
INSERT [dbo].[Permisos] ([Id], [RolId], [Crear], [Ver], [Editar], [Eliminar]) VALUES (1, 1, 1, 1, 1, 1)
GO
INSERT [dbo].[Permisos] ([Id], [RolId], [Crear], [Ver], [Editar], [Eliminar]) VALUES (2, 2, 0, 1, 0, 0)
GO
INSERT [dbo].[Permisos] ([Id], [RolId], [Crear], [Ver], [Editar], [Eliminar]) VALUES (3, 3, 0, 0, 0, 0)
GO
INSERT [dbo].[Permisos] ([Id], [RolId], [Crear], [Ver], [Editar], [Eliminar]) VALUES (4, 2, 0, 1, 1, 0)
GO
INSERT [dbo].[Permisos] ([Id], [RolId], [Crear], [Ver], [Editar], [Eliminar]) VALUES (5, 4, 0, 1, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Permisos] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id], [RoleName], [DateCreation]) VALUES (1, N'Administrador', CAST(N'2021-02-20T09:38:20.007' AS DateTime))
GO
INSERT [dbo].[Roles] ([Id], [RoleName], [DateCreation]) VALUES (2, N'Asistente', CAST(N'2021-02-20T09:38:31.940' AS DateTime))
GO
INSERT [dbo].[Roles] ([Id], [RoleName], [DateCreation]) VALUES (3, N'Visitante', CAST(N'2021-02-20T09:38:38.490' AS DateTime))
GO
INSERT [dbo].[Roles] ([Id], [RoleName], [DateCreation]) VALUES (4, N'Editor', CAST(N'2021-02-20T09:38:45.287' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Username], [Email], [Telefono], [Password], [Nombres], [Status], [Apellidos], [RolesId], [Block], [Direccion], [FechaNacimiento]) VALUES (1, N'admon', N'yeanmagu@gmail.com', N'+573017192721', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'Yeiner', 0, N'Martinez', 1, 0, N'Cra 81b 48a-20', CAST(N'2021-02-01' AS Date))
GO
INSERT [dbo].[Users] ([Id], [Username], [Email], [Telefono], [Password], [Nombres], [Status], [Apellidos], [RolesId], [Block], [Direccion], [FechaNacimiento]) VALUES (2, N'user1', N'admin@admin.com', N'30212115', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Usuario', 0, N'Visitante', 3, 0, N'calkklkonasf', CAST(N'2021-02-01' AS Date))
GO
INSERT [dbo].[Users] ([Id], [Username], [Email], [Telefono], [Password], [Nombres], [Status], [Apellidos], [RolesId], [Block], [Direccion], [FechaNacimiento]) VALUES (3, N'visitante', N'admin+1@admin.com', N'3018798959', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'VISITANTE', 0, N'ARANDA', 3, 0, N'Calle 23 #45 54', CAST(N'2011-01-20' AS Date))
GO
INSERT [dbo].[Users] ([Id], [Username], [Email], [Telefono], [Password], [Nombres], [Status], [Apellidos], [RolesId], [Block], [Direccion], [FechaNacimiento]) VALUES (6, N'editor', N'admin+2@admin.com', N'3018798959', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'editor', 0, N'editor', 4, 0, N'Calle 23 #45 54', CAST(N'2012-01-20' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E424E624A6]    Script Date: 20/02/2021 22:56:23 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D105348BABBD61]    Script Date: 20/02/2021 22:56:23 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Permisos] ADD  CONSTRAINT [DF_Permisos_Crear]  DEFAULT ((0)) FOR [Crear]
GO
ALTER TABLE [dbo].[Permisos] ADD  CONSTRAINT [DF_Permisos_Ver]  DEFAULT ((0)) FOR [Ver]
GO
ALTER TABLE [dbo].[Permisos] ADD  CONSTRAINT [DF_Permisos_Editar]  DEFAULT ((0)) FOR [Editar]
GO
ALTER TABLE [dbo].[Permisos] ADD  CONSTRAINT [DF_Permisos_Eliminar]  DEFAULT ((0)) FOR [Eliminar]
GO
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_DateCreation]  DEFAULT (getdate()) FOR [DateCreation]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [Block]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RolesId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [dbArandaTest] SET  READ_WRITE 
GO
