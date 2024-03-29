USE [db_devsis_estoque]
GO
/****** Object:  Table [dbo].[tb_item]    Script Date: 04/07/2019 00:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](15) NOT NULL,
	[descricao] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_solicitacao]    Script Date: 04/07/2019 00:06:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_solicitacao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data_criacao] [date] NOT NULL,
	[status] [varchar](15) NOT NULL,
	[data_finalizacao] [date] NOT NULL,
	[usuario] [varchar](20) NULL,
	[prioridade] [varchar](30) NOT NULL,
	[item1] [varchar](50) NOT NULL,
	[item2] [varchar](50) NULL,
	[item3] [varchar](50) NULL,
	[qtd1] [varchar](3) NOT NULL,
	[qtd2] [varchar](3) NULL,
	[qtd3] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_usuario]    Script Date: 04/07/2019 00:06:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[setor] [varchar](25) NOT NULL,
	[login] [varchar](50) NOT NULL,
	[senha] [varchar](25) NOT NULL,
	[nivel] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
