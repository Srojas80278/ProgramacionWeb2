IF DB_ID('UtopiaBeautySalon') IS NOT NULL
BEGIN
    DROP DATABASE UtopiaBeautySalon;
END

CREATE DATABASE UtopiaBeautySalon;
GO

USE UtopiaBeautySalon;
GO

---------------PRIMERO SE EJECUTA LO DE ARRIBA-------------




-------------LUEGO SE EJECUTA LO DE ABAJO:---------------------
CREATE TABLE [dbo].[Citas](
	[id_cita] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre_cliente] [varchar](255) NOT NULL,
	[ubicacion] [varchar](255) NULL,
	[fecha_cita] [date] NOT NULL,
	[estilista] [varchar](255) NULL,
	[id_servicio] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contabilidad]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contabilidad](
	[id_movimiento] [bigint] IDENTITY(1,1) NOT NULL,
	[descripcion_movimiento] [varchar](255) NOT NULL,
	[monto] [decimal](10, 2) NOT NULL,
	[fecha_movimiento] [datetime] NOT NULL,
	[tipo_movimiento] [varchar](255) NOT NULL,
	[tipo_transaccion] [varchar](255) NULL,
	[saldo_pendiente] [decimal](10, 2) NULL,
	[id_producto] [bigint] NULL,
	[id_cita] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[id_producto] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre_producto] [varchar](255) NOT NULL,
	[descripcion_producto] [text] NULL,
	[cantidad_stock] [int] NOT NULL,
	[precio_compra] [decimal](10, 2) NULL,
	[precio_venta] [decimal](10, 2) NULL,
	[id_proveedor] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[id_proveedor] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre_proveedor] [varchar](255) NOT NULL,
	[numero_contacto] [varchar](20) NULL,
	[email] [varchar](255) NULL,
	[direccion] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicios](
	[id_servicio] [bigint] IDENTITY(1,1) NOT NULL,
	[titulo_servicio] [varchar](255) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[costo] [decimal](10, 2) NULL,
	[url_imagen] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TNationality]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TNationality](
	[IdNationality] [bigint] IDENTITY(1,1) NOT NULL,
	[NationalityType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TNationality] PRIMARY KEY CLUSTERED 
(
	[IdNationality] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRol]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRol](
	[IdRol] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TRol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TUser]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TUser](
	[IdUser] [bigint] IDENTITY(1,1) NOT NULL,
	[IdRol] [bigint] NOT NULL,
	[IdNationality] [bigint] NULL,
	[Identification] [varchar](20) NOT NULL,
	[NameUser] [varchar](40) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PasswordUser] [nvarchar](100) NOT NULL,
	[ConfPassUser] [nvarchar](100) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[State] [bit] NOT NULL,
	[TempKey] [bit] NOT NULL,
	[TempKeyExp] [datetime] NOT NULL,
	[Distric] [varchar](20) NULL,
	[Street] [varchar](10) NULL,
	[TempCode] [nvarchar](100) NULL,
 CONSTRAINT [PK_TUser] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TNationality] ON 

INSERT [dbo].[TNationality] ([IdNationality], [NationalityType]) VALUES (1, N'Identificación Nacional')
INSERT [dbo].[TNationality] ([IdNationality], [NationalityType]) VALUES (2, N'DNI')
INSERT [dbo].[TNationality] ([IdNationality], [NationalityType]) VALUES (3, N'Cédula de Extranjería')
SET IDENTITY_INSERT [dbo].[TNationality] OFF
GO
SET IDENTITY_INSERT [dbo].[TUser] ON 

INSERT [dbo].[TUser] ([IdUser], [IdRol], [IdNationality], [Identification], [NameUser], [LastName], [Email], [PasswordUser], [ConfPassUser], [Phone], [State], [TempKey], [TempKeyExp], [Distric], [Street], [TempCode]) VALUES (1, 2, 0, N'string', N'string', N'string', N'string', N'473287f8298dba7163a897908', N'473287f8298dba7163a897908', N'string', 1, 0, CAST(N'2024-03-08T15:17:27.817' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TUser] ([IdUser], [IdRol], [IdNationality], [Identification], [NameUser], [LastName], [Email], [PasswordUser], [ConfPassUser], [Phone], [State], [TempKey], [TempKeyExp], [Distric], [Street], [TempCode]) VALUES (2, 2, 1, N'117620845', N'Carlos', N'Zumbado Cárdenas', N'carloszumbadocardenas@gmail.com', N'05defb27bc1c9c1aaf77dddb1', N'582427cabb723aaeed54b3d3c', N'87883883', 1, 1, CAST(N'2024-03-11T21:57:50.393' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TUser] ([IdUser], [IdRol], [IdNationality], [Identification], [NameUser], [LastName], [Email], [PasswordUser], [ConfPassUser], [Phone], [State], [TempKey], [TempKeyExp], [Distric], [Street], [TempCode]) VALUES (3, 2, 1, N'118674563', N'CarlosPrueba', N'Zumbado Cárdenas', N'carloszcardenas6@gmail.com', N'582427cabb723aaeed54b3d3c', N'582427cabb723aaeed54b3d3c', N'87883883', 1, 1, CAST(N'2024-03-11T21:54:20.650' AS DateTime), NULL, NULL, N'gu3H')
INSERT [dbo].[TUser] ([IdUser], [IdRol], [IdNationality], [Identification], [NameUser], [LastName], [Email], [PasswordUser], [ConfPassUser], [Phone], [State], [TempKey], [TempKeyExp], [Distric], [Street], [TempCode]) VALUES (4, 2, 1, N'117630845', N'CarlosTercero', N'Zumbado Cárdenas', N'carlosz.c.czc@gmail.com', N'582427cabb723aaeed54b3d3c', N'582427cabb723aaeed54b3d3c', N'87883883', 1, 1, CAST(N'2024-03-26T21:17:15.857' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TUser] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Email]    Script Date: 27/03/2024 21:54:12 ******/
ALTER TABLE [dbo].[Proveedores] ADD  CONSTRAINT [UQ_Email] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([id_servicio])
REFERENCES [dbo].[Servicios] ([id_servicio])
GO
ALTER TABLE [dbo].[Contabilidad]  WITH CHECK ADD FOREIGN KEY([id_cita])
REFERENCES [dbo].[Citas] ([id_cita])
GO
ALTER TABLE [dbo].[Contabilidad]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[Inventario] ([id_producto])
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[Proveedores] ([id_proveedor])
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCita]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarCita]
    @id_cita BIGINT,
    @nombre_cliente VARCHAR(255),
    @ubicacion VARCHAR(255),
    @fecha_cita DATE,
    @estilista VARCHAR(255),
    @id_servicio BIGINT
AS
BEGIN
    UPDATE Citas
    SET nombre_cliente = @nombre_cliente,
        ubicacion = @ubicacion,
        fecha_cita = @fecha_cita,
        estilista = @estilista,
        id_servicio = @id_servicio
    WHERE id_cita = @id_cita;
END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarServicio]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarServicio]
    @id_servicio BIGINT,
    @titulo_servicio VARCHAR(255),
    @descripcion VARCHAR(255),
    @costo DECIMAL(10, 2),
    @url_imagen VARCHAR(255)
AS
BEGIN
    UPDATE Servicios
    SET titulo_servicio = @titulo_servicio,
        descripcion = @descripcion,
        costo = @costo,
        url_imagen = @url_imagen
    WHERE id_servicio = @id_servicio;
END
GO
/****** Object:  StoredProcedure [dbo].[ChangePassword]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[ChangePassword]
    @Codigo NVARCHAR(100),
    @Email VARCHAR(50),
    @PasswordUser VARCHAR(25)
AS
BEGIN
    -- Verificar si el correo electrónico y el código coinciden en la base de datos
    IF EXISTS (
        SELECT 1 
        FROM TUser
        WHERE Email = @Email 
          AND TempCode = @Codigo
    )
    BEGIN
        -- Actualizar la contraseña del usuario con la nueva contraseña encriptada
        UPDATE TUser
        SET PasswordUser = @PasswordUser,
            TempCode = NULL  -- Limpiar el código temporal
        WHERE Email = @Email
          AND TempCode = @Codigo

        -- Retorna 1 para indicar que se ha restablecido la contraseña exitosamente
        RETURN 1;
    END
    ELSE
    BEGIN
        -- Retorna 0 para indicar que el correo electrónico y/o el código no son válidos
        RETURN 0;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarContabilidad]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ConsultarContabilidad]
AS
BEGIN
    SELECT 
        co.id_movimiento,
        co.descripcion_movimiento,
        co.monto,
        co.fecha_movimiento,
        co.tipo_movimiento,
        co.tipo_transaccion,
        SUM(co.monto) OVER (ORDER BY co.fecha_movimiento, co.id_movimiento) AS saldo_pendiente,
        p.nombre_producto AS nombre_producto,
        ci.nombre_cliente AS nombre_cliente
    FROM Contabilidad co
    LEFT JOIN Inventario p ON co.id_producto = p.id_producto
    LEFT JOIN Citas ci ON co.id_cita = ci.id_cita
    ORDER BY co.fecha_movimiento, co.id_movimiento;
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarServicios]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConsultarServicios]
    @id_servicio BIGINT = NULL
AS
BEGIN
    IF @id_servicio IS NULL
    BEGIN
        SELECT * FROM Servicios;
    END
    ELSE
    BEGIN
        SELECT * FROM Servicios WHERE id_servicio = @id_servicio;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultNationality]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultNationality]
	
AS
BEGIN
	
	select IdNationality 'value', NationalityType 'text' from TNationality

END
GO
/****** Object:  StoredProcedure [dbo].[CrearCita]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CrearCita]
    @nombre_cliente VARCHAR(255),
    @ubicacion VARCHAR(255),
    @fecha_cita DATE,
    @estilista VARCHAR(255),
    @id_servicio BIGINT
AS
BEGIN
    INSERT INTO Citas (nombre_cliente, ubicacion, fecha_cita, estilista, id_servicio)
    VALUES (@nombre_cliente, @ubicacion, @fecha_cita, @estilista, @id_servicio);
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCita]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarCita]
    @id_cita BIGINT
AS
BEGIN
    DELETE FROM Citas WHERE id_cita = @id_cita;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarServicio]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarServicio]
    @id_servicio BIGINT
AS
BEGIN
    DELETE FROM Servicios WHERE id_servicio = @id_servicio;
END
GO
/****** Object:  StoredProcedure [dbo].[inv_ConsultarInventario]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
EXEC inv_RegistrarInventario 
    @nombre_producto = 'Prod1ucto d1e Ejemplo',
    @descripcion_producto = 'Este es un producto de ejemplo para propósitos de prueba.',
    @cantidad_stock = 50,
    @precio_compra = 15.75,
    @precio_venta = 25.99,
    @id_proveedor = 22; 
SELECT * FROM [Inventario];
*/

-- #2 Procedimiento Almacenado -- Inventario -- | Leer Inventario:

CREATE PROCEDURE [dbo].[inv_ConsultarInventario]
AS
BEGIN
    SELECT I.[id_producto], 
           I.[nombre_producto], 
           I.[descripcion_producto], 
           I.[cantidad_stock], 
           I.[precio_compra], 
           I.[precio_venta], 
           P.[nombre_proveedor] AS Proveedor
    FROM [dbo].[Inventario] AS I
    INNER JOIN [dbo].[Proveedores] AS P ON I.[id_proveedor] = P.[id_proveedor];
END
GO
/****** Object:  StoredProcedure [dbo].[inv_RegistrarInventario]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Código para la tabla Inventario:

-- #1 Procedimiento Almacenado -- Inventario -- | Crear Inventario:

CREATE PROCEDURE [dbo].[inv_RegistrarInventario]
    @nombre_producto varchar(255),
    @descripcion_producto text,
    @cantidad_stock int,
    @precio_compra decimal(10, 2),
    @precio_venta decimal(10, 2),
    @id_proveedor bigint
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[Inventario] WHERE [nombre_producto] = @nombre_producto)
    BEGIN
        INSERT INTO [dbo].[Inventario] (
            [nombre_producto],
            [descripcion_producto],
            [cantidad_stock],
            [precio_compra],
            [precio_venta],
            [id_proveedor]
        ) VALUES (
            @nombre_producto,
            @descripcion_producto,
            @cantidad_stock,
            @precio_compra,
            @precio_venta,
            @id_proveedor
        );
    END
END
GO
/****** Object:  StoredProcedure [dbo].[LeerCitas]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LeerCitas]
    @id_cita BIGINT = NULL
AS
BEGIN
    IF @id_cita IS NULL
    BEGIN
        SELECT * FROM Citas;
    END
    ELSE
    BEGIN
        SELECT * FROM Citas WHERE id_cita = @id_cita;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Login]
	@Email varchar(50),
	@PasswordUser varchar(25)
AS
BEGIN
	SELECT IdUser, IdRol, Identification, NameUser, LastName, Email, Phone FROM [dbo].[TUser] WHERE Email = @Email and PasswordUser=@PasswordUser and State = 1
END
GO
/****** Object:  StoredProcedure [dbo].[prov_ActualizarProveedores]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- EXEC prov_ConsultarUnProveedor @id_proveedor = 20; 


-- #4 Procedimiento Almacenado Proveedores | Actualizar Proveedor:
CREATE PROCEDURE [dbo].[prov_ActualizarProveedores]
    @id_proveedor BIGINT,
    @nombre_proveedor VARCHAR(255),
    @numero_contacto VARCHAR(20),
    @email VARCHAR(255),
    @direccion VARCHAR(255)	
AS
BEGIN
    -- Verificar si el correo electrónico ya está siendo utilizado por otro proveedor y que no tome en cuenta su mismo email.
    IF NOT EXISTS (SELECT 1 FROM Proveedores WHERE email = @email AND id_proveedor != @id_proveedor) -- AND id_proveedor != @id_proveedor explicacion: Esta condición adicional asegura que la consulta excluya al proveedor actual que está siendo actualizado, evitando así que el correo electrónico se considere duplicado debido a su propio registro existente.
    BEGIN
        UPDATE Proveedores
        SET 
            nombre_proveedor = @nombre_proveedor,
            numero_contacto  = @numero_contacto,
            email            = @email,
            direccion        = @direccion
        WHERE 
            id_proveedor = @id_proveedor;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[prov_BorrarProveedor]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* Código para probar el SP en la base de datos:
EXEC prov_ActualizarProveedores 
    @id_proveedor = 13,
    @nombre_proveedor = 'CAMBIOTOTAER',
    @numero_contacto = 'PruebaSwagger2SPACTUALIZAR',
    @email = 'nuevo@proveedor.com',
    @direccion = 'PruebaSwagger2';

SELECT * FROM Proveedores;
*/


-- #5 Procedimiento Almacenado Proveedores | Borrar Proveedor:
CREATE PROCEDURE [dbo].[prov_BorrarProveedor]
    @id_proveedor BIGINT
AS
BEGIN
    DELETE FROM Proveedores
    WHERE id_proveedor = @id_proveedor;
END
GO
/****** Object:  StoredProcedure [dbo].[prov_ConsultarUnProveedor]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- #3 Procedimiento Almacenado Proveedores | Leer un único Proveedores:

CREATE PROCEDURE [dbo].[prov_ConsultarUnProveedor]
    @id_proveedor INT
AS
BEGIN
    SELECT id_proveedor, 
           nombre_proveedor, 
           numero_contacto, 
           email, 
           direccion 
    FROM Proveedores
    WHERE id_proveedor = @id_proveedor;
END
GO
/****** Object:  StoredProcedure [dbo].[prov_CrearProveedor]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- #1 Procedimiento Almacenado Proveedores | Crear Proveedor:123123
CREATE PROCEDURE [dbo].[prov_CrearProveedor]
    @nombre_proveedor    varchar(255),
    @numero_contacto     varchar(20),
    @email               varchar(255),
    @direccion           varchar(255)
AS
BEGIN
    -- Verifica si el correo electrónico recibido ya existe en la tabla
    IF NOT EXISTS (SELECT 1 FROM Proveedores WHERE email = @email)
    BEGIN
        -- Si el correo electrónico no existe, entonces que se haga la insersión de datos:
        INSERT INTO Proveedores 
            (nombre_proveedor,  numero_contacto,  email,  direccion)
        VALUES
            (@nombre_proveedor, @numero_contacto, @email, @direccion)
    END
END
GO
/****** Object:  StoredProcedure [dbo].[prov_LeerProveedores]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Código para probar el SP en la base de datos:

EXEC prov_CrearProveedor
    @nombre_proveedor = 'Proveedor Ejemplo',
    @numero_contacto = '123456789',
    @email = 'proveedasdor@exampldasdasdre.com',
    @direccion = '123 Calle Principal, Ciudad'

	Select * from Proveedores;
	DELETE FROM PROVEEDORES;
*/


-- #2 Procedimiento Almacenado Proveedores | Leer Proveedores:
CREATE PROCEDURE [dbo].[prov_LeerProveedores]
AS
BEGIN
    SELECT id_proveedor, 
	nombre_proveedor, 
	numero_contacto, 
	email, 
	direccion 
    FROM Proveedores;
END
GO
/****** Object:  StoredProcedure [dbo].[RecoverAccount]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecoverAccount]
	@Email	VARCHAR(50)
AS
BEGIN
	
	SELECT	IdUser, NameUser, Email
	FROM	TUser
	WHERE	(Email = @Email)
		AND State		= 1

END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarServicio]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarServicio]
    @titulo_servicio VARCHAR(255),
    @descripcion VARCHAR(255),
    @costo DECIMAL(10, 2),
    @url_imagen VARCHAR(255)
AS
BEGIN
    INSERT INTO Servicios (titulo_servicio, descripcion, costo, url_imagen)
    VALUES (@titulo_servicio, @descripcion, @costo, @url_imagen);
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrerAccount]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[RegistrerAccount]
	@IdNationality bigint,
	@Identification varchar(20),
	@NameUser	varchar(40),
	@LastName   varchar(30) ,
	@Email		varchar(50),
	@PasswordUser	varchar(25), 
	@ConfPassUser varchar(25),
	@Phone varchar(15)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM [dbo].[TUser] WHERE Email = @Email or Identification = @Identification)
    BEGIN
		INSERT INTO [dbo].[TUser] (IdNationality, Identification, NameUser, LastName, Email, PasswordUser, ConfPassUser, Phone, State,TempKey,TempKeyExp,idRol)
		VALUES (@IdNationality, @Identification, @NameUser, @LastName, @Email, @PasswordUser,@ConfPassUser, @Phone, 1, 0, GETDATE(),2)
	END
	ELSE
    BEGIN
        -- El nuevo correo electrónico ya está en uso, devolver un código de error
        RETURN 1;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateState]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateState]
	@IdUser BIGINT
AS
BEGIN

	UPDATE	TUser
	SET		State = (CASE WHEN State = 1 THEN 0 ELSE 1 END)
	WHERE	IdUser = @IdUser

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTempKey]    Script Date: 27/03/2024 21:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateTempKey]
	@IdUser				bigint,
	@TempKey	varchar(4)
AS
BEGIN

	UPDATE dbo.TUser
	SET TempCode = @TempKey,
		TempKey = 1,
        TempKeyExp = DATEADD(mi,30,GETDATE())
	WHERE IdUser = @IdUser

END
GO


CREATE OR ALTER TRIGGER TRG_InsertInventario
ON Inventario
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @idProducto BIGINT, @precioVenta DECIMAL(10, 2), @cantidad INT, @tipoMovimiento VARCHAR(255), @tipoTransaccion VARCHAR(255), @cantidadAnterior INT

    SELECT @idProducto = INSERTED.id_producto, @precioVenta = INSERTED.precio_venta, @cantidad = INSERTED.cantidad_stock
    FROM INSERTED

    IF EXISTS (SELECT * FROM DELETED)
    BEGIN
        SELECT @cantidadAnterior = d.cantidad_stock FROM DELETED d
        SET @tipoMovimiento = CASE 
                                WHEN @cantidadAnterior > @cantidad THEN 'Venta de producto'
                                ELSE 'Compra de producto'
                              END

        -- Ajustar el monto según si es compra o venta
        SET @precioVenta = CASE 
                                WHEN @cantidadAnterior > @cantidad THEN @precioVenta  -- Venta
                                ELSE -@precioVenta -- Compra, se hace negativo
                           END
    END
    ELSE
    BEGIN
        -- Para el caso de INSERT, asumimos que es una compra y hacemos el monto negativo
        SET @tipoMovimiento = 'Compra de producto'
        SET @precioVenta = -@precioVenta
    END

    INSERT INTO Contabilidad(descripcion_movimiento, monto, fecha_movimiento, tipo_movimiento, id_producto, tipo_transaccion)
    VALUES (@tipoMovimiento, @precioVenta, GETDATE(), @tipoMovimiento, @idProducto, 'Sinpe')
END
GO

CREATE OR ALTER TRIGGER TRG_InsertCita
ON Citas
AFTER INSERT
AS
BEGIN
    DECLARE @idCita BIGINT, @nombreCliente VARCHAR(255), @descripcionServicio VARCHAR(255), 
            @costoServicio DECIMAL(10, 2)

    SELECT 
        @idCita = i.id_cita, 
        @nombreCliente = i.nombre_cliente,
        @costoServicio = s.costo,
        @descripcionServicio = s.descripcion
    FROM 
        INSERTED i
        INNER JOIN Servicios s ON i.id_servicio = s.id_servicio

    INSERT INTO Contabilidad(descripcion_movimiento, monto, fecha_movimiento, tipo_movimiento, id_cita, tipo_transaccion)
    VALUES ('Cita para: ' + @nombreCliente + ' - ' + @descripcionServicio, @costoServicio, GETDATE(), 'Ingreso por servicio', @idCita, 'Sinpe')
END
GO

USE [master]
GO
ALTER DATABASE [UtopiaBeautySalon] SET  READ_WRITE 
GO
