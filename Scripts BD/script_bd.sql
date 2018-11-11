CREATE DATABASE [americaservice]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'americaservice', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\americaservice.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'americaservice_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\americaservice _log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [americaservice] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [americaservice].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [americaservice] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [americaservice] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [americaservice] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [americaservice] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [americaservice] SET ARITHABORT OFF 
GO
ALTER DATABASE [americaservice] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [americaservice] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [americaservice] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [americaservice] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [americaservice] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [americaservice] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [americaservice] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [americaservice] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [americaservice] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [americaservice] SET  DISABLE_BROKER 
GO
ALTER DATABASE [americaservice] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [americaservice] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [americaservice] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [americaservice] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [americaservice] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [americaservice] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [americaservice] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [americaservice] SET RECOVERY FULL 
GO
ALTER DATABASE [americaservice] SET  MULTI_USER 
GO
ALTER DATABASE [americaservice] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [americaservice] SET DB_CHAINING OFF 
GO
ALTER DATABASE [americaservice] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [americaservice] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [americaservice] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'americaservice', N'ON'
GO
USE [americaservice]
GO
/****** Object:  Table [dbo].[Formulario]    Script Date: 10/31/2018 10:55:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Formulario](
	[id_formulario] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [varchar](20) NOT NULL,
	[primer_nombre] [varchar](50) NOT NULL,
	[segundo_nombre] [varchar](50) NOT NULL,
	[primer_apellido] [varchar](50) NOT NULL,
	[segundo_apellido] [varchar](50) NOT NULL,
	[id_roleplay] [int] NULL,
	[jornada_diurna] [bit] NOT NULL,
	[jornada_mixta] [bit] NOT NULL,
	[jornada_nocturna] [bit] NOT NULL,
	[justificacion_jornada] [varchar](100) NULL,
	[fecha] [datetime] NOT NULL,
	[salario] [float] NOT NULL,
	[telefono] [numeric](8) NOT NULL,
	[correo] [varchar](30) NOT NULL,
	[domicilio] [varchar](100) NOT NULL,
	[exp_call_center] [bit] NOT NULL,
	[exp_ventas] [bit] NOT NULL,
	[exp_servicio_cliente] [bit] NOT NULL,
	[detalle_experiencias] [varchar](200) NULL,
	[exp_cobros] [bit] NOT NULL,
	[exp_mora30] [bit] NOT NULL,
	[exp_mora60] [bit] NOT NULL,
	[exp_mora90] [bit] NOT NULL,
	[exp_cartera_separada] [bit] NOT NULL,
	[exp_cobro_judicial] [bit] NOT NULL,
	[detalle_exp_cobros] [varchar](200) NULL,
	[excel] [bit] NOT NULL,
	[bachillerato] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_formulario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HistoricoReclutando]    Script Date: 10/31/2018 10:55:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HistoricoReclutando](
	[cedula] [varchar](20) NOT NULL,
	[primer_nombre] [varchar](50) NOT NULL,
	[segundo_nombre] [varchar](50) NOT NULL,
	[primer_apellido] [varchar](50) NOT NULL,
	[segundo_apellido] [varchar](50) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[cantidad] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roleplay]    Script Date: 10/31/2018 10:55:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roleplay](
	[id_roleplay] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[detalle] [varchar](100) NULL,
	[visto_bueno] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_roleplay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/31/2018 10:55:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[cedula] [varchar](20) NOT NULL,
	[primer_nombre] [varchar](50) NOT NULL,
	[segundo_nombre] [varchar](50) NOT NULL,
	[primer_apellido] [varchar](50) NOT NULL,
	[segundo_apellido] [varchar](50) NOT NULL,
	[cumpleanos] [datetime] NOT NULL,
	[fecha_ingreso] [datetime] NOT NULL,
	[estado] [char](1) NOT NULL DEFAULT ('A'),
	[desempeno_pruebas] [float] NULL,
	[supervisor] [varchar](60) NULL,
	[usuario] [varchar](20) NOT NULL,
	[contrasena] [varchar](20) NOT NULL,
	[tipo] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Formulario]  WITH CHECK ADD  CONSTRAINT [FK_Formulario_Roleplay] FOREIGN KEY([id_roleplay])
REFERENCES [dbo].[Roleplay] ([id_roleplay])
GO
ALTER TABLE [dbo].[Formulario] CHECK CONSTRAINT [FK_Formulario_Roleplay]
GO
