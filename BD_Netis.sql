CREATE DATABASE [BD_Netis]
GO

USE [BD_Netis]
GO
/****** Object:  Table [dbo].[SOAT]    Script Date: 08/07/2016 13:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SOAT](
	[IdSoat] [int] IDENTITY(1,1) NOT NULL,
	[Placa] [varchar](50) NOT NULL,
	[Marca] [varchar](100) NULL,
	[Categoria] [varchar](100) NULL,
	[FechaInicio] [varchar](50) NULL,
	[Contratante] [varchar](250) NULL,
	[Año] [int] NULL,
	[Documento] [varchar](50) NULL,
	[Modelo] [varchar](100) NULL,
	[NroAsientos] [int] NULL,
	[Direccion] [varchar](max) NULL,
	[UsoDiario] [nvarchar](50) NULL,
	[NroSerie] [varchar](50) NULL,
 CONSTRAINT [PK_SOAT] PRIMARY KEY CLUSTERED 
(
	[IdSoat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SAT]    Script Date: 08/07/2016 13:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SAT](
	[IdSAT] [int] NOT NULL,
	[Placa] [varchar](50) NOT NULL,
	[Tipo] [varchar](50) NULL,
	[Monto] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SAT] PRIMARY KEY CLUSTERED 
(
	[IdSAT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Policia]    Script Date: 08/07/2016 13:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Policia](
	[IdPolicia] [int] NOT NULL,
	[Documento] [varchar](10) NOT NULL,
	[TieneAntecedentes] [bit] NULL,
	[FechaDetencion] [datetime] NULL,
	[EstadoDetencion] [int] NULL,
 CONSTRAINT [PK_Policia] PRIMARY KEY CLUSTERED 
(
	[IdPolicia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 08/07/2016 13:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[IdPerfil] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 08/07/2016 13:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[Descrippcion] [nchar](10) NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccesoDisponible]    Script Date: 08/07/2016 13:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccesoDisponible](
	[IdPerfil] [int] NULL,
	[HoraInicio] [varchar](50) NULL,
	[HoraFin] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/07/2016 13:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdPerfil] [int] NULL,
	[Nombre] [varchar](250) NULL,
	[Apellido] [varchar](250) NULL,
	[Dni] [varchar](10) NULL,
	[Correo] [varchar](200) NULL,
	[Contraseña] [varchar](20) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleSOAT]    Script Date: 08/07/2016 13:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleSOAT](
	[IdDetalleSoat] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdSoat] [int] NOT NULL,
	[Estado] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_DetalleSOAT_SOAT]    Script Date: 08/07/2016 13:56:03 ******/
ALTER TABLE [dbo].[DetalleSOAT]  WITH CHECK ADD  CONSTRAINT [FK_DetalleSOAT_SOAT] FOREIGN KEY([IdSoat])
REFERENCES [dbo].[SOAT] ([IdSoat])
GO
ALTER TABLE [dbo].[DetalleSOAT] CHECK CONSTRAINT [FK_DetalleSOAT_SOAT]
GO
/****** Object:  ForeignKey [FK_DetalleSOAT_Usuario]    Script Date: 08/07/2016 13:56:03 ******/
ALTER TABLE [dbo].[DetalleSOAT]  WITH CHECK ADD  CONSTRAINT [FK_DetalleSOAT_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[DetalleSOAT] CHECK CONSTRAINT [FK_DetalleSOAT_Usuario]
GO
/****** Object:  ForeignKey [FK_Usuario_Perfil]    Script Date: 08/07/2016 13:56:03 ******/
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([IdPerfil])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
