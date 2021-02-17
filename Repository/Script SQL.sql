USE [Empresa]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcionario_Estado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcionario]'))
ALTER TABLE [dbo].[Funcionario] DROP CONSTRAINT [FK_Funcionario_Estado]
GO

USE [Empresa]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Funcionario]') AND type in (N'U'))
DROP TABLE [dbo].[Funcionario]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Estado]') AND type in (N'U'))
DROP TABLE [dbo].[Estado]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Estado](
	[PK_Estado] [int] IDENTITY(1,1) NOT NULL,
	[Sigla] [nvarchar](2) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[PK_Estado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

INSERT INTO Estado (Sigla, Nome) VALUES ('AC', 'Acre');
INSERT INTO Estado (Sigla, Nome) VALUES ('AL', 'Alagoas');
INSERT INTO Estado (Sigla, Nome) VALUES ('AP', 'Amapá');
INSERT INTO Estado (Sigla, Nome) VALUES ('AM', 'Amazonas');
INSERT INTO Estado (Sigla, Nome) VALUES ('BA', 'Bahia');
INSERT INTO Estado (Sigla, Nome) VALUES ('CE', 'Ceará');
INSERT INTO Estado (Sigla, Nome) VALUES ('DF', 'Distrito Federal');
INSERT INTO Estado (Sigla, Nome) VALUES ('ES', 'Espírito Santo');
INSERT INTO Estado (Sigla, Nome) VALUES ('GO', 'Goiás');
INSERT INTO Estado (Sigla, Nome) VALUES ('MA', 'Maranhão');
INSERT INTO Estado (Sigla, Nome) VALUES ('MT', 'Mato Grosso');
INSERT INTO Estado (Sigla, Nome) VALUES ('MS', 'Mato Grosso do Sul');
INSERT INTO Estado (Sigla, Nome) VALUES ('MG', 'Minas Gerais');
INSERT INTO Estado (Sigla, Nome) VALUES ('PA', 'Pará');
INSERT INTO Estado (Sigla, Nome) VALUES ('PB', 'Paraíba');
INSERT INTO Estado (Sigla, Nome) VALUES ('PR', 'Paraná');
INSERT INTO Estado (Sigla, Nome) VALUES ('PE', 'Pernambuco');
INSERT INTO Estado (Sigla, Nome) VALUES ('PI', 'Piauí');
INSERT INTO Estado (Sigla, Nome) VALUES ('RJ', 'Rio de Janeiro');
INSERT INTO Estado (Sigla, Nome) VALUES ('RN', 'Rio Grande do Norte');
INSERT INTO Estado (Sigla, Nome) VALUES ('RS', 'Rio Grande do Sul');
INSERT INTO Estado (Sigla, Nome) VALUES ('RO', 'Rondônia');
INSERT INTO Estado (Sigla, Nome) VALUES ('RR', 'Roraima');
INSERT INTO Estado (Sigla, Nome) VALUES ('SC', 'Santa Catarina');
INSERT INTO Estado (Sigla, Nome) VALUES ('SP', 'São Paulo');
INSERT INTO Estado (Sigla, Nome) VALUES ('SE', 'Sergipe');
INSERT INTO Estado (Sigla, Nome) VALUES ('TO', 'Tocantins');

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Funcionario](
	[PK_Funcionario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Salario] [decimal](18, 2) NULL,
	[FK_Estado] [int] NULL,
 CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED 
(
	[PK_Funcionario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Funcionario]  WITH CHECK ADD  CONSTRAINT [FK_Funcionario_Estado] FOREIGN KEY([FK_Estado])
REFERENCES [dbo].[Estado] ([PK_Estado])
GO

ALTER TABLE [dbo].[Funcionario] CHECK CONSTRAINT [FK_Funcionario_Estado]
GO