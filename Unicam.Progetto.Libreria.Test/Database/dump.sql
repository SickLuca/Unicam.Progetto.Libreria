CREATE TABLE [dbo].[Categoria](
	[CategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[NomeCategoria] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Categoria_1] PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibriCategorie]    Script Date: 12/06/2024 19.25.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibriCategorie](
	[LibroId] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
 CONSTRAINT [PK_LibriCategorie] PRIMARY KEY CLUSTERED 
(
	[LibroId] ASC,
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 12/06/2024 19.25.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[LibroId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Autore] [varchar](100) NOT NULL,
	[DataPubblicazione] [datetime] NOT NULL,
	[Editore] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Libro_1] PRIMARY KEY CLUSTERED 
(
	[LibroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 12/06/2024 19.25.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[UtenteId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Cognome] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Utente_1] PRIMARY KEY CLUSTERED 
(
	[UtenteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LibriCategorie]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_LibriCategorie] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([CategoriaId])
GO
ALTER TABLE [dbo].[LibriCategorie] CHECK CONSTRAINT [FK_Categoria_LibriCategorie]
GO
ALTER TABLE [dbo].[LibriCategorie]  WITH CHECK ADD  CONSTRAINT [FK_Libro_LibriCategorie] FOREIGN KEY([LibroId])
REFERENCES [dbo].[Libro] ([LibroId])
GO
ALTER TABLE [dbo].[LibriCategorie] CHECK CONSTRAINT [FK_Libro_LibriCategorie]
GO
USE [master]
GO
ALTER DATABASE [Libreria] SET  READ_WRITE 
GO
