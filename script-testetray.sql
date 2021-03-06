USE [BancoTeste]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 15/08/2021 21:37:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[ProdutoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Estoque] [int] NOT NULL,
	[Valor] [decimal](17, 2) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Produto] ON 

INSERT [dbo].[Produto] ([ProdutoId], [Nome], [Estoque], [Valor]) VALUES (3, N'Caixa de Papelao', 300, CAST(100.00 AS Decimal(17, 2)))
INSERT [dbo].[Produto] ([ProdutoId], [Nome], [Estoque], [Valor]) VALUES (2, N'Teste2', 1200, CAST(23000.00 AS Decimal(17, 2)))
INSERT [dbo].[Produto] ([ProdutoId], [Nome], [Estoque], [Valor]) VALUES (4, N'Seringa 10ml', 400, CAST(1.15 AS Decimal(17, 2)))
INSERT [dbo].[Produto] ([ProdutoId], [Nome], [Estoque], [Valor]) VALUES (5, N'Lápis HB', 1000, CAST(0.80 AS Decimal(17, 2)))
INSERT [dbo].[Produto] ([ProdutoId], [Nome], [Estoque], [Valor]) VALUES (6, N'Manta Fleece', 40, CAST(39.90 AS Decimal(17, 2)))
SET IDENTITY_INSERT [dbo].[Produto] OFF
GO
