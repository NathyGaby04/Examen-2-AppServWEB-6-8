CREATE DATABASE [DBExamen];
GO

USE [DBExamen]
GO
/****** Object:  Table [dbo].[FotoInfraccion]    Script Date: 3/31/2025 7:13:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FotoInfraccion](
	[idFoto] [int] IDENTITY(1,1) NOT NULL,
	[NombreFoto] [varchar](50) NOT NULL,
	[idInfraccion] [int] NOT NULL,
 CONSTRAINT [PK_FotoInfraccion] PRIMARY KEY CLUSTERED 
(
	[idFoto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Infraccion]    Script Date: 3/31/2025 7:13:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Infraccion](
	[idFotoMulta] [int] IDENTITY(1,1) NOT NULL,
	[PlacaVehiculo] [varchar](10) NOT NULL,
	[FechaInfraccion] [datetime] NOT NULL,
	[TipoInfraccion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Infraccion] PRIMARY KEY CLUSTERED 
(
	[idFotoMulta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 3/31/2025 7:13:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[Placa] [varchar](10) NOT NULL,
	[TipoVehiculo] [varchar](50) NOT NULL,
	[Marca] [varchar](50) NOT NULL,
	[Color] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[Placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FotoInfraccion]  WITH CHECK ADD  CONSTRAINT [FK_FotoInfraccion_Infraccion] FOREIGN KEY([idInfraccion])
REFERENCES [dbo].[Infraccion] ([idFotoMulta])
GO
ALTER TABLE [dbo].[FotoInfraccion] CHECK CONSTRAINT [FK_FotoInfraccion_Infraccion]
GO
ALTER TABLE [dbo].[Infraccion]  WITH CHECK ADD  CONSTRAINT [FK_Infraccion_Vehiculo] FOREIGN KEY([PlacaVehiculo])
REFERENCES [dbo].[Vehiculo] ([Placa])
GO
ALTER TABLE [dbo].[Infraccion] CHECK CONSTRAINT [FK_Infraccion_Vehiculo]
GO
