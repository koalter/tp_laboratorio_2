USE [Cea.Lorenzo.2A]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
[Id] [int] IDENTITY(1,1) NOT NULL,
[Modelo] [varchar](50) NOT NULL,
[Ram] [int] NOT NULL,
[Rom] [int] NOT NULL,
[Tamanio] [varchar](50) NOT NULL,
[Procesador] [varchar](50) NOT NULL,
[Camara] [int] NOT NULL,
) ON [PRIMARY]
GO