USE [VehicleDB]
GO

/****** Object:  Table [dbo].[Vehicles]    Script Date: 05/07/2012 21:24:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Vehicles](
	[Id] [int] NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[Vin] [char](10) NOT NULL,
	[Make] [varchar](50) NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[Year] [int] NOT NULL,
	[TireSize] [varchar](50) NULL,
	[PropSize] [varchar](50) NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


