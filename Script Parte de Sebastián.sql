-- Declarar que el correo es único en la tabla "Proveedores".
ALTER TABLE [dbo].[Proveedores]
ADD CONSTRAINT UQ_Email UNIQUE ([email]);

-- #1 Procedimiento Almacenado Proveedores | Crear Proveedor:123123
CREATE PROCEDURE prov_CrearProveedor
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
CREATE PROCEDURE prov_LeerProveedores
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

-- #3 Procedimiento Almacenado Proveedores | Leer un único Proveedores:

CREATE PROCEDURE prov_ConsultarUnProveedor
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
-- EXEC prov_ConsultarUnProveedor @id_proveedor = 20; 


-- #4 Procedimiento Almacenado Proveedores | Actualizar Proveedor:
CREATE PROCEDURE prov_ActualizarProveedores
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
CREATE PROCEDURE prov_BorrarProveedor
    @id_proveedor BIGINT
AS
BEGIN
    DELETE FROM Proveedores
    WHERE id_proveedor = @id_proveedor;
END
GO
