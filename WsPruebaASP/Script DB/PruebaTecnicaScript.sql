USE [PruebaASP]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 8/11/2017 11:53:26 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[IdLibros] [int] IDENTITY(1,1) NOT NULL,
	[NombreLibro] [varchar](50) NOT NULL,
	[GeneroLibro] [varchar](50) NOT NULL,
	[PrecioLibro] [int] NOT NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[IdLibros] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 8/11/2017 11:53:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Idusuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[Contraseña] [varchar](20) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[actualizar_libro]    Script Date: 8/11/2017 11:53:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[actualizar_libro]
@idLibro int,
@nombrelibro varchar(50),
@generolibro varchar (20),
@preciolibro int

as
UPDATE Libros

	set NombreLibro = @nombrelibro ,Libros.GeneroLibro = @generolibro,
					  PrecioLibro =@preciolibro
FROM            Libros
							 WHERE IdLibros = @idLibro
GO
/****** Object:  StoredProcedure [dbo].[Consultar_Libro]    Script Date: 8/11/2017 11:53:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Consultar_Libro]

as
   select 
       IdLibros as 'ref',   NombreLibro as 'Nombre del libro', GeneroLibro as ' Genero del libro', PrecioLibro as 'Precio del libro'
	from Libros
GO
/****** Object:  StoredProcedure [dbo].[Consultar_Librotodo]    Script Date: 8/11/2017 11:53:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Consultar_Librotodo]
@id  int
AS
BEGIN
select NombreLibro as 'Nombre del libro', GeneroLibro as 'Género', PrecioLibro as 'Precio'

from Libros

 where IdLibros = @id
 END
GO
/****** Object:  StoredProcedure [dbo].[Insertar_Libro]    Script Date: 8/11/2017 11:53:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insertar_Libro]

@nombrelibro varchar(50),
@GeneroLibro varchar(50),
@PrecioLibro int 
as

insert into Libros
values ( @NombreLibro, @GeneroLibro,@PrecioLibro)
GO
/****** Object:  StoredProcedure [dbo].[Insertar_Usuario]    Script Date: 8/11/2017 11:53:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insertar_Usuario]

@Usuario varchar(50),
@Contraseña varchar(50),
@Nombre varchar(50),
@Email varchar(50) 
as

insert into Usuarios
values ( @Usuario, @Contraseña,@Nombre,@Email)
GO
/****** Object:  StoredProcedure [dbo].[Insertar_Usuario2]    Script Date: 8/11/2017 11:53:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insertar_Usuario2]

@Usuario varchar(50),
@Contraseña varchar(50),
@Nombre varchar(50),
@Email varchar(50) 
as

insert into Usuarios
values ( @Usuario, @Contraseña,@Nombre,@Email)
GO
/****** Object:  StoredProcedure [dbo].[Verificar_usuario]    Script Date: 8/11/2017 11:53:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Verificar_usuario]

@Usuario varchar(50),
@Contrasena varchar(50)
as
	BEGIN	

	SELECT Usuario, Contraseña, Nombre as 'Nombre completo' FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contrasena

	END
GO
