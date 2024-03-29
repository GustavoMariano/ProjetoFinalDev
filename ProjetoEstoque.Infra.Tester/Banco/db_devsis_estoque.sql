USE [db_devsis_estoque]
GO
/****** Object:  Table [dbo].[tb_solicitacao]    Script Date: 28/06/2019 02:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_solicitacao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data_criacao] [datetime2](0) NOT NULL,
	[status] [varchar](15) NOT NULL,
	[data_finalizacao] [datetime] NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[prioridade] [varchar](10) NOT NULL,
	[itens] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_usuario]    Script Date: 28/06/2019 02:01:10 ******/
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
	[nivel] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_solicitacao]  WITH CHECK ADD CHECK  (([prioridade]='critico' OR [prioridade]='urgente' OR [prioridade]='media' OR [prioridade]='baixa'))
GO
ALTER TABLE [dbo].[tb_solicitacao]  WITH CHECK ADD CHECK  (([status]='Finalizado' OR [status]='Processando' OR [status]='Cancelado' OR [status]='Aprovado' OR [status]='Pendente'))
GO
ALTER TABLE [dbo].[tb_usuario]  WITH CHECK ADD CHECK  (([nivel]='Comum' OR [nivel]='Admin'))
GO
