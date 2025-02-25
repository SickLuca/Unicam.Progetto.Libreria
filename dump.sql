USE [master]
GO
/****** Object:  Database [Libreria]    Script Date: 02/07/2024 19.35.52 ******/
CREATE DATABASE [Libreria]
GO
ALTER DATABASE [Libreria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Libreria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Libreria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Libreria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Libreria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Libreria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Libreria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Libreria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Libreria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Libreria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Libreria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Libreria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Libreria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Libreria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Libreria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Libreria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Libreria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Libreria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Libreria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Libreria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Libreria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Libreria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Libreria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Libreria] SET  MULTI_USER 
GO
ALTER DATABASE [Libreria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Libreria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Libreria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Libreria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Libreria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Libreria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Libreria] SET QUERY_STORE = OFF
GO
USE [Libreria]
GO
/****** Object:  User [progetto]    Script Date: 02/07/2024 19.35.52 ******/
CREATE USER [progetto] FOR LOGIN [progetto] WITH DEFAULT_SCHEMA=[progetto]
GO
ALTER ROLE [db_owner] ADD MEMBER [progetto]
GO
/****** Object:  Schema [progetto]    Script Date: 02/07/2024 19.35.52 ******/
CREATE SCHEMA [progetto]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 02/07/2024 19.35.52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeCategoria] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Categoria_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libri]    Script Date: 02/07/2024 19.35.52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Autore] [varchar](100) NOT NULL,
	[DataPubblicazione] [datetime] NOT NULL,
	[Editore] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Libro_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibriCategorie]    Script Date: 02/07/2024 19.35.52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibriCategorie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LibriId] [int] NOT NULL,
	[CategorieId] [int] NOT NULL,
 CONSTRAINT [PK_LibriCategorie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 02/07/2024 19.35.52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Cognome] [varchar](100) NOT NULL,
	[Password] [varchar](100) MASKED WITH (FUNCTION = 'partial(0, "*****", 0)') NOT NULL,
 CONSTRAINT [PK_Utente_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LibriCategorie]  WITH NOCHECK ADD  CONSTRAINT [FK_LibriCategorie_Categorie] FOREIGN KEY([CategorieId])
REFERENCES [dbo].[Categorie] ([Id])
GO
ALTER TABLE [dbo].[LibriCategorie] CHECK CONSTRAINT [FK_LibriCategorie_Categorie]
GO
ALTER TABLE [dbo].[LibriCategorie]  WITH CHECK ADD  CONSTRAINT [FK_LibriCategorie_Libri] FOREIGN KEY([LibriId])
REFERENCES [dbo].[Libri] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LibriCategorie] CHECK CONSTRAINT [FK_LibriCategorie_Libri]
GO
USE [master]
GO
ALTER DATABASE [Libreria] SET  READ_WRITE 
GO
