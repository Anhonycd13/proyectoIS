USE [db_gstore_medic]
GO
/****** Object:  Table [dbo].[tb_antecedentes]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_antecedentes](
	[id] [int] NOT NULL,
	[descripcion] [nvarchar](max) NULL,
	[estado] [varchar](20) NULL,
	[tipo] [varchar](20) NULL,
	[fecha_creacion] [datetime] NULL,
	[fecha_modificacion] [datetime] NULL,
	[tb_personas_id] [int] NOT NULL,
	[tb_tipo_antecedentes_id] [int] NOT NULL,
	[tb_usuarios_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_categoria_datos_a]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_categoria_datos_a](
	[id] [int] NOT NULL,
	[nombre] [varchar](255) NULL,
	[fecha_creado] [datetime] NULL,
	[fecha_modificado] [datetime] NULL,
	[tb_usuarios_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_categoria_datos_b]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_categoria_datos_b](
	[id] [int] NOT NULL,
	[nombre] [varchar](255) NULL,
	[fecha_creado] [datetime] NULL,
	[fecha_modificado] [datetime] NULL,
	[tb_usuarios_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_citas]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_citas](
	[id] [int] NOT NULL,
	[fecha_creacion] [datetime] NULL,
	[fecha_cita] [datetime] NULL,
	[fecha_realizada] [datetime] NULL,
	[fecha_cancelada] [datetime] NULL,
	[nombre] [varchar](255) NULL,
	[dpi] [varchar](20) NULL,
	[descripcion] [text] NULL,
	[tipo] [int] NULL,
	[estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_configuraciones]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_configuraciones](
	[tipo] [varchar](255) NOT NULL,
	[valor] [nvarchar](max) NULL,
	[fecha_modificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_consultas]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_consultas](
	[id] [int] NOT NULL,
	[descripcion] [nvarchar](max) NULL,
	[fecha_creado] [datetime] NULL,
	[fecha_modificado] [datetime] NULL,
	[tb_personas_id] [int] NOT NULL,
	[tb_usuarios_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_datos]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_datos](
	[id] [int] NOT NULL,
	[descripcion] [text] NULL,
	[fecha_creado] [datetime] NULL,
	[fecha_modificado] [datetime] NULL,
	[fecha_ultima_impresion] [datetime] NULL,
	[tb_categoria_datos_a_id] [int] NOT NULL,
	[tb_categoria_datos_b_id] [int] NOT NULL,
	[tb_personas_id] [int] NOT NULL,
	[tb_consultas_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_horarios_disponibles]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_horarios_disponibles](
	[id] [int] NOT NULL,
	[fecha_creado] [datetime] NULL,
	[fecha] [datetime] NULL,
	[hora_inicio] [varchar](15) NULL,
	[hora_final] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_personas]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_personas](
	[id] [int] NOT NULL,
	[nombre] [varchar](255) NULL,
	[fecha_nacimiento] [date] NULL,
	[direccion] [varchar](255) NULL,
	[telefono_1] [varchar](20) NULL,
	[telefono_2] [varchar](20) NULL,
	[correo] [varchar](30) NULL,
	[fecha_creacion] [datetime] NULL,
	[fecha_modificacion] [datetime] NULL,
	[fecha_ultima_visita] [datetime] NULL,
	[estado] [varchar](20) NULL,
	[tipo] [varchar](20) NULL,
	[dpi] [varchar](15) NULL,
	[tb_usuarios_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_personas_roles]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_personas_roles](
	[id] [int] NOT NULL,
	[tb_personas_id] [int] NOT NULL,
	[tb_roles_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_productos]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_productos](
	[id] [int] NOT NULL,
	[fecha_creacion] [datetime] NULL,
	[descripcion] [varchar](255) NULL,
	[precio] [decimal](18, 2) NULL,
	[unidades] [decimal](18, 2) NULL,
	[estado] [varchar](255) NULL,
	[tipo] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_recetas]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_recetas](
	[id] [int] NOT NULL,
	[observaciones] [text] NULL,
	[fecha_creado] [datetime] NULL,
	[fecha_modificado] [datetime] NULL,
	[tb_consultas_id] [int] NOT NULL,
	[tb_usuarios_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_recetas_detalle]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_recetas_detalle](
	[id] [int] NOT NULL,
	[descripcion] [text] NULL,
	[fecha_creado] [datetime] NULL,
	[fecha_modificado] [datetime] NULL,
	[tb_recetas_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_roles]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_roles](
	[id] [int] NOT NULL,
	[nombre] [varchar](255) NULL,
	[tipo] [varchar](20) NULL,
	[estado] [varchar](20) NULL,
	[fecha_creado] [datetime] NULL,
	[fecha_modificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_tipo_antecedentes]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_tipo_antecedentes](
	[id] [int] NOT NULL,
	[nombre] [varchar](255) NULL,
	[tipo] [varchar](20) NULL,
	[estado] [varchar](20) NULL,
	[fecha_creado] [datetime] NULL,
	[fecha_modificado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_usuarios]    Script Date: 11/02/2023 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_usuarios](
	[id] [int] NOT NULL,
	[nombre] [varchar](255) NULL,
	[usuario] [varchar](15) NULL,
	[password] [text] NULL,
	[fecha_creado] [datetime] NULL,
	[fecha_modificado] [datetime] NULL,
	[fecha_ultimo_acceso] [datetime] NULL,
	[tipo] [varchar](20) NULL,
	[estado] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_antecedentes]  WITH CHECK ADD  CONSTRAINT [FK_tb_antecedentes_tb_tipo_antecedentes] FOREIGN KEY([tb_tipo_antecedentes_id])
REFERENCES [dbo].[tb_tipo_antecedentes] ([id])
GO
ALTER TABLE [dbo].[tb_antecedentes] CHECK CONSTRAINT [FK_tb_antecedentes_tb_tipo_antecedentes]
GO
ALTER TABLE [dbo].[tb_antecedentes]  WITH CHECK ADD  CONSTRAINT [FK_tb_antecedentes_tb_usuarios] FOREIGN KEY([tb_usuarios_id])
REFERENCES [dbo].[tb_usuarios] ([id])
GO
ALTER TABLE [dbo].[tb_antecedentes] CHECK CONSTRAINT [FK_tb_antecedentes_tb_usuarios]
GO
ALTER TABLE [dbo].[tb_categoria_datos_a]  WITH CHECK ADD  CONSTRAINT [FK_tb_categoria_datos_a_tb_usuarios] FOREIGN KEY([tb_usuarios_id])
REFERENCES [dbo].[tb_usuarios] ([id])
GO
ALTER TABLE [dbo].[tb_categoria_datos_a] CHECK CONSTRAINT [FK_tb_categoria_datos_a_tb_usuarios]
GO
ALTER TABLE [dbo].[tb_categoria_datos_b]  WITH CHECK ADD  CONSTRAINT [FK_tb_categoria_datos_b_tb_usuarios] FOREIGN KEY([tb_usuarios_id])
REFERENCES [dbo].[tb_usuarios] ([id])
GO
ALTER TABLE [dbo].[tb_categoria_datos_b] CHECK CONSTRAINT [FK_tb_categoria_datos_b_tb_usuarios]
GO
ALTER TABLE [dbo].[tb_consultas]  WITH CHECK ADD  CONSTRAINT [FK_tb_consultas_tb_usuarios] FOREIGN KEY([tb_usuarios_id])
REFERENCES [dbo].[tb_usuarios] ([id])
GO
ALTER TABLE [dbo].[tb_consultas] CHECK CONSTRAINT [FK_tb_consultas_tb_usuarios]
GO
ALTER TABLE [dbo].[tb_datos]  WITH CHECK ADD  CONSTRAINT [FK_tb_datos_tb_categoria_datos_a1] FOREIGN KEY([tb_categoria_datos_a_id])
REFERENCES [dbo].[tb_categoria_datos_a] ([id])
GO
ALTER TABLE [dbo].[tb_datos] CHECK CONSTRAINT [FK_tb_datos_tb_categoria_datos_a1]
GO
ALTER TABLE [dbo].[tb_datos]  WITH CHECK ADD  CONSTRAINT [FK_tb_datos_tb_categoria_datos_b] FOREIGN KEY([tb_categoria_datos_b_id])
REFERENCES [dbo].[tb_categoria_datos_b] ([id])
GO
ALTER TABLE [dbo].[tb_datos] CHECK CONSTRAINT [FK_tb_datos_tb_categoria_datos_b]
GO
ALTER TABLE [dbo].[tb_datos]  WITH CHECK ADD  CONSTRAINT [FK_tb_datos_tb_consultas] FOREIGN KEY([tb_consultas_id])
REFERENCES [dbo].[tb_consultas] ([id])
GO
ALTER TABLE [dbo].[tb_datos] CHECK CONSTRAINT [FK_tb_datos_tb_consultas]
GO
ALTER TABLE [dbo].[tb_datos]  WITH CHECK ADD  CONSTRAINT [FK_tb_datos_tb_personas] FOREIGN KEY([tb_personas_id])
REFERENCES [dbo].[tb_personas] ([id])
GO
ALTER TABLE [dbo].[tb_datos] CHECK CONSTRAINT [FK_tb_datos_tb_personas]
GO
ALTER TABLE [dbo].[tb_personas]  WITH CHECK ADD  CONSTRAINT [FK_tb_personas_tb_usuarios] FOREIGN KEY([tb_usuarios_id])
REFERENCES [dbo].[tb_usuarios] ([id])
GO
ALTER TABLE [dbo].[tb_personas] CHECK CONSTRAINT [FK_tb_personas_tb_usuarios]
GO
ALTER TABLE [dbo].[tb_personas_roles]  WITH CHECK ADD  CONSTRAINT [FK_tb_personas_roles_tb_personas] FOREIGN KEY([tb_personas_id])
REFERENCES [dbo].[tb_personas] ([id])
GO
ALTER TABLE [dbo].[tb_personas_roles] CHECK CONSTRAINT [FK_tb_personas_roles_tb_personas]
GO
ALTER TABLE [dbo].[tb_personas_roles]  WITH CHECK ADD  CONSTRAINT [FK_tb_personas_roles_tb_roles] FOREIGN KEY([tb_roles_id])
REFERENCES [dbo].[tb_roles] ([id])
GO
ALTER TABLE [dbo].[tb_personas_roles] CHECK CONSTRAINT [FK_tb_personas_roles_tb_roles]
GO
