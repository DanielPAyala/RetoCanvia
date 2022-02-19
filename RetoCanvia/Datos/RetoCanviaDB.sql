USE [master]
GO
/****** Object:  Database [RetoCanvia]    Script Date: 18/02/2022 07:31:16 ******/
CREATE DATABASE [RetoCanvia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RetoCanvia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RetoCanvia.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RetoCanvia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RetoCanvia_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RetoCanvia] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RetoCanvia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RetoCanvia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RetoCanvia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RetoCanvia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RetoCanvia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RetoCanvia] SET ARITHABORT OFF 
GO
ALTER DATABASE [RetoCanvia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RetoCanvia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RetoCanvia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RetoCanvia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RetoCanvia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RetoCanvia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RetoCanvia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RetoCanvia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RetoCanvia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RetoCanvia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RetoCanvia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RetoCanvia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RetoCanvia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RetoCanvia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RetoCanvia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RetoCanvia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RetoCanvia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RetoCanvia] SET RECOVERY FULL 
GO
ALTER DATABASE [RetoCanvia] SET  MULTI_USER 
GO
ALTER DATABASE [RetoCanvia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RetoCanvia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RetoCanvia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RetoCanvia] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RetoCanvia] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RetoCanvia] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RetoCanvia', N'ON'
GO
ALTER DATABASE [RetoCanvia] SET QUERY_STORE = OFF
GO
USE [RetoCanvia]
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 18/02/2022 07:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[CarreraId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NULL,
 CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED 
(
	[CarreraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 18/02/2022 07:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[EstudianteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Apellidos] [nvarchar](100) NULL,
	[CarreraId] [int] NULL,
 CONSTRAINT [PK_Estudiante] PRIMARY KEY CLUSTERED 
(
	[EstudianteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Estudiante]  WITH CHECK ADD  CONSTRAINT [FK_ESTUDIANTE_CARRERA] FOREIGN KEY([CarreraId])
REFERENCES [dbo].[Carrera] ([CarreraId])
GO
ALTER TABLE [dbo].[Estudiante] CHECK CONSTRAINT [FK_ESTUDIANTE_CARRERA]
GO
/****** Object:  StoredProcedure [dbo].[sp_consultar_carrera]    Script Date: 18/02/2022 07:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_consultar_carrera]
as
begin
	select * from Carrera;
end;
GO
/****** Object:  StoredProcedure [dbo].[sp_consultar_carrera_id]    Script Date: 18/02/2022 07:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_consultar_carrera_id]
@id int
as begin
	select * from Carrera
	where CarreraId = @id;
end;
GO
/****** Object:  StoredProcedure [dbo].[sp_consultar_estudiante]    Script Date: 18/02/2022 07:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_consultar_estudiante]
as
begin
	select * from Estudiante;
end;
GO
/****** Object:  StoredProcedure [dbo].[sp_consultar_estudiante_id]    Script Date: 18/02/2022 07:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_consultar_estudiante_id]
@id int
as begin
	select * from Estudiante
	where EstudianteId = @id;
end;
GO
/****** Object:  StoredProcedure [dbo].[sp_editar_carrera]    Script Date: 18/02/2022 07:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_editar_carrera]
@id int,
@nombre varchar(200)
as begin
	update Carrera
	set Nombre = @nombre
	where CarreraId = @id;
end;
GO
/****** Object:  StoredProcedure [dbo].[sp_editar_estudiante]    Script Date: 18/02/2022 07:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_editar_estudiante]
@id int,
@nombre varchar(100),
@apellido varchar(100),
@carreraid int
as begin
	update Estudiante
	set Nombre=@nombre, Apellidos= @apellido, CarreraId=@carreraid
	where EstudianteId = @id;
end;
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_carrera]    Script Date: 18/02/2022 07:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_eliminar_carrera]
@id int
as begin
	delete from Carrera
	where CarreraId = @id;
end;
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_estudiante]    Script Date: 18/02/2022 07:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_eliminar_estudiante]
@id int
as begin
	delete from Estudiante
	where EstudianteId = @id;
end;
GO
/****** Object:  StoredProcedure [dbo].[sp_guardar_carrera]    Script Date: 18/02/2022 07:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_guardar_carrera]
@nombre varchar(200)
as begin
	insert into Carrera(Nombre)
	values(@nombre);
end;
GO
/****** Object:  StoredProcedure [dbo].[sp_guardar_estudiante]    Script Date: 18/02/2022 07:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_guardar_estudiante]
@nombre varchar(100),
@apellido varchar(100),
@carreraid int
as begin
	insert into Estudiante(Nombre, Apellidos, CarreraId)
	values(@nombre, @apellido, @carreraid);
end;
GO
USE [master]
GO
ALTER DATABASE [RetoCanvia] SET  READ_WRITE 
GO
