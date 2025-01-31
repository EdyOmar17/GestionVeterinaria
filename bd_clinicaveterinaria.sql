-- Crear base de datos
CREATE DATABASE GestionVeterinaria;
USE GestionVeterinaria;

select*from RegistroEliminados
go
-- Tabla Usuario
CREATE TABLE Usuario (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nom_User VARCHAR(50),
	Nick VARCHAR(50) not null,  
    Contraseña VARCHAR(255),
	CONSTRAINT uk_unico UNIQUE (Nick,Nom_User)
);
go
-- Tabla Dueño
CREATE TABLE Dueño (
    ID_Dueño INT IDENTITY(1,1) PRIMARY KEY,
    DNI CHAR(8),
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    Direccion NVARCHAR(100),
    Telefono NVARCHAR(15),
    CorreoElectronico NVARCHAR(100)
);
go
-- Tabla Mascota
CREATE TABLE Mascota (
    ID_Mascota CHAR(6) PRIMARY KEY,
    Nombre NVARCHAR(50),
    Especie NVARCHAR(50),
    Raza NVARCHAR(50),
    Fecha_nac DATE,
    ID_Dueño INT,
    FOREIGN KEY (ID_Dueño) REFERENCES Dueño(ID_Dueño)
);
go
-- Alteramos la Tabla Mascotas para que agregue el Diagnostico
ALTER TABLE Mascota
ADD Diagnostico NVARCHAR(500);
go
-- Tabla Especialización
CREATE TABLE Especializacion (
    ID_Especializacion CHAR(6) PRIMARY KEY,
    NombreEspecializacion NVARCHAR(100)
);
go
-- Tabla Veterinario
CREATE TABLE Veterinario (
    ID_Veterinario INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    ID_Especializacion CHAR(6),
    Telefono NVARCHAR(15),
    FOREIGN KEY (ID_Especializacion) REFERENCES Especializacion(ID_Especializacion)
);
go
-- Tabla Cita
CREATE TABLE Cita (
    ID_Cita INT PRIMARY KEY IDENTITY(1,1),
    ID_Mascota CHAR(6),
    ID_Veterinario INT,
    Fecha DATE,
    Motivo NVARCHAR(255),
    Diagnostico NVARCHAR(255),
    FOREIGN KEY (ID_Mascota) REFERENCES Mascota(ID_Mascota),
    FOREIGN KEY (ID_Veterinario) REFERENCES Veterinario(ID_Veterinario)
);
go
-- Tabla Tratamiento
CREATE TABLE Tratamiento (
    ID_Tratamiento CHAR(6) PRIMARY KEY,
    ID_Cita INT,
    NombreTratamiento NVARCHAR(100),
    DosisDuracion NVARCHAR(255),
    FOREIGN KEY (ID_Cita) REFERENCES Cita(ID_Cita)
);
go
-- Tabla Factura
CREATE TABLE Factura (
    ID_Factura CHAR(6) PRIMARY KEY,
    ID_Dueño INT,
    Fecha DATE,
    Monto DECIMAL(10,2),
    FOREIGN KEY (ID_Dueño) REFERENCES Dueño(ID_Dueño)
);
go
-- Tabla DetalleFactura
CREATE TABLE DetalleFactura (
    ID_Detalle CHAR(6) PRIMARY KEY,
    ID_Factura CHAR(6),
    Descripcion NVARCHAR(255),
    Cant INT,
    Precio DECIMAL(10,2),
    FOREIGN KEY (ID_Factura) REFERENCES Factura(ID_Factura)
);
go
-- Registros para la tabla Dueño
INSERT INTO Dueño (DNI, Nombre, Apellido, Direccion, Telefono, CorreoElectronico) VALUES 
('12345678', 'Juan', 'Perez', 'Calle Falsa 123', '987654321', 'juan.perez@mail.com'),
('87654321', 'Maria', 'Gomez', 'Avenida Siempre Viva 742', '987654322', 'maria.gomez@mail.com'),
('11223344', 'Carlos', 'Diaz', 'Pasaje Infinito 456', '987654323', 'carlos.diaz@mail.com'),
('44332211', 'Ana', 'Lopez', 'Boulevard Central 890', '987654324', 'ana.lopez@mail.com'),
('56789012', 'Luis', 'Martinez', 'Calle del Sol 678', '987654325', 'luis.martinez@mail.com');
go
-- Registros para la tabla Mascota
INSERT INTO Mascota (ID_Mascota, Nombre, Especie, Raza, Fecha_nac, ID_Dueño) VALUES 
('M001', 'Firulais', 'Perro', 'Labrador', '2015-06-01', 1),
('M002', 'Michi', 'Gato', 'Siames', '2017-08-15', 2),
('M003', 'Rex', 'Perro', 'Pastor Aleman', '2016-12-20', 3),
('M004', 'Nemo', 'Pez', 'Goldfish', '2020-01-10', 4),
('M005', 'Bella', 'Conejo', 'Enano', '2018-03-30', 5);
go
-- Registros para la tabla Especializacion
INSERT INTO Especializacion (ID_Especializacion, NombreEspecializacion) VALUES 
('E001', 'Veterinaria General'),
('E002', 'Cirugia Veterinaria'),
('E003', 'Dermatologia Veterinaria'),
('E004', 'Oncologia Veterinaria'),
('E005', 'Cardiologia Veterinaria');
go
-- Registros para la tabla Veterinario
INSERT INTO Veterinario (Nombre, Apellido, ID_Especializacion, Telefono) VALUES 
('Laura', 'Gomez', 'E001', '999222333'),
('Pedro', 'Martinez', 'E002', '999888777'),
('Sofia', 'Lopez', 'E003', '989888777'),
('Jorge', 'Rodriguez', 'E004', '977888666'),
('Elena', 'Fernandez', 'E005', '900000888');
go
-- Registros para la tabla Cita
INSERT INTO Cita (ID_Mascota, ID_Veterinario, Fecha, Motivo, Diagnostico) VALUES 
('M001', 1, '2024-01-10', 'Chequeo General', 'Saludable'),
('M002', 2, '2024-02-15', 'Problemas de piel', 'Dermatitis'),
('M003', 3, '2024-03-20', 'Cirugía', 'Recuperado de cirugía'),
('M004', 4, '2024-04-25', 'Chequeo General', 'Saludable'),
('M005', 5, '2024-05-30', 'Problemas cardiacos', 'Arritmia tratada');
go
-- Registros para la tabla Tratamiento
INSERT INTO Tratamiento (ID_Tratamiento, ID_Cita, NombreTratamiento, DosisDuracion) VALUES 
('T001', 1, 'Vacunas', 'Una vez al año'),
('T002', 2, 'Antibioticos', '7 días'),
('T003', 3, 'Cura post cirugía', '2 semanas'),
('T004', 4, 'Alimentación especial', 'Continuo'),
('T005', 5, 'Medicamento cardiaco', 'Diario');
go
-- Registros para la tabla Factura
INSERT INTO Factura (ID_Factura, ID_Dueño, Fecha, Monto) VALUES 
('F001', 1, '2024-01-10', 100.00),
('F002', 2, '2024-02-15', 150.00),
('F003', 3, '2024-03-20', 300.00),
('F004', 4, '2024-04-25', 100.00),
('F005', 5, '2024-05-30', 250.00);
go
-- Registros para la tabla DetalleFactura
INSERT INTO DetalleFactura (ID_Detalle, ID_Factura, Descripcion, Cant, Precio) VALUES 
('DF001', 'F001', 'Consulta General', 1, 100.00),
('DF002', 'F002', 'Tratamiento Dermatológico', 1, 150.00),
('DF003', 'F003', 'Cirugía', 1, 300.00),
('DF004', 'F004', 'Chequeo General', 1, 100.00),
('DF005', 'F005', 'Medicamento cardiaco', 1, 250.00);
go
Select*from Cita
Select*from DetalleFactura
Select*from Dueño
Select*from Especializacion
Select*from Factura
Select*from Mascota
Select*from Tratamiento
Select*from Veterinario
go
--Procedimiento almacenado para Encriptar la Contrasaña de los Usuarios
CREATE PROCEDURE usp_usuario
    @Nom_User VARCHAR(50),
    @Nick VARCHAR(20),
    @password VARCHAR(200),
    @nt VARCHAR(200) OUTPUT
AS
BEGIN
    DECLARE @ID INT;
    DECLARE @n INT, @c VARCHAR(2);
    DECLARE @simbolo CHAR(1);
    SET @nt = '';
    SET @password = REVERSE(LTRIM(RTRIM(@password)));
    SET @n = 0;
    WHILE @n < LEN(@password)
    BEGIN
        SET @n = @n + 1;
        SET @c = CAST(ASCII(UPPER(SUBSTRING(@password, @n, 2))) + 1 AS CHAR(2));
        SET @simbolo = CHAR(FLOOR(RAND() * 255 + 1));
        SET @nt = @nt + @simbolo + @c;
    END;

    INSERT INTO Usuario (Nom_User, Nick, Contraseña)
    VALUES (@Nom_User, @Nick, @nt);

    -- Obtener el ID generado
    SELECT @ID = SCOPE_IDENTITY();

    RETURN @ID;
END;
go
--Codigo ASCII
SELECT CHAR(66);
SELECT CHAR(floor(rand()*255));
SELECT CHAR(floor(rand()*255));
SELECT ASCII('b');
go
--Registros de mi Tabla Usuario y agregando al procedimiento
EXECUTE usp_usuario 'Keiber Rojas','KRojas','chamo',''
EXECUTE usp_usuario 'Edy Reyes','EReyes','peruano',''
EXECUTE usp_usuario 'Johnny Diaz','JDiaz','profesor',''
EXECUTE usp_usuario 'Admin','ADN','notelasabes',''
SELECT * FROM Usuario
go
--Convierte caracteres a codigo ASCII
SELECT ASCII('a')
SELECT ASCII('f')
SELECT ASCII('l')
SELECT ASCII('a')
SELECT CHAR(66)
go
--Visualizar la Contraseña Encriptada
select Contraseña from Usuario where nick='ADN'
go
--Procedimiento almacenado para Desencriptar la Contrasaña de los Usuarios
CREATE PROCEDURE usp_desencriptar
    @Nick VARCHAR(20)
AS
BEGIN
    DECLARE @t VARCHAR(255);
    DECLARE @n INT, @c VARCHAR(2), @nt VARCHAR(200);
    DECLARE @simbolo CHAR(1);

    SELECT @t = Contraseña FROM Usuario WHERE Nick = @Nick;
    
    SET @nt = '';
    SET @n = 2;

    WHILE @n < LEN(@t)
    BEGIN
        SET @c = CHAR(CAST(SUBSTRING(@t, @n, 2) AS INT) - 1);
        SET @n = @n + 3;
        SET @nt = @nt + @c;
    END
    
    SET @nt = REVERSE(LTRIM(RTRIM(@nt)));
    
    SELECT Clave = @nt;
END;
go
--Desencripta la Contraseña especifica del Usuario seleccionado
EXECUTE usp_desencriptar 'KRojas';
EXECUTE usp_desencriptar 'JDiaz';
EXECUTE usp_desencriptar 'EReyes';
SELECT * FROM Usuario;
go
-- Procedimiento para insertar un nuevo dueño
CREATE PROCEDURE InsertarDueño
    @DNI CHAR(8),
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Direccion NVARCHAR(100),
    @Telefono NVARCHAR(15),
    @CorreoElectronico NVARCHAR(100)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Dueño WHERE DNI = @DNI)
    BEGIN
        INSERT INTO Dueño (DNI, Nombre, Apellido, Direccion, Telefono, CorreoElectronico)
        VALUES (@DNI, @Nombre, @Apellido, @Direccion, @Telefono, @CorreoElectronico);
    END
    ELSE
    BEGIN
        -- Opcional: Podrías devolver un código de error si el dueño ya existe
        RAISERROR('El dueño ya existe', 16, 1);
    END
END;
go
-- Procedimiento para insertar una nueva mascota
CREATE PROCEDURE InsertarMascota
	@ID_Mascota CHAR(6),
    @Nombre NVARCHAR(50),
    @Especie NVARCHAR(50),
    @Raza NVARCHAR(50),
    @Fecha_nac DATE,
    @DNI CHAR(8),
	@Veterinario nvarchar(50),
    @Motivo NVARCHAR(255),
	@FechaCita DATE
AS
BEGIN
    DECLARE @DueñoID INT;
    SELECT @DueñoID = ID_Dueño FROM Dueño WHERE DNI = @DNI;
	DECLARE @ID_Veterinario int;
	SELECT @ID_Veterinario = ID_Veterinario from Veterinario where CONCAT(Nombre, ' ', Apellido) = @Veterinario;

    IF @DueñoID IS NULL
    BEGIN
        RAISERROR('El dueño con el DNI proporcionado no existe.', 16, 1);
        RETURN;
    END

    -- Insertar la nueva mascota
    INSERT INTO Mascota (ID_Mascota, Nombre, Especie, Raza, Fecha_nac, ID_Dueño)
    VALUES (@ID_Mascota, @Nombre, @Especie, @Raza, @Fecha_nac, @DueñoID);

    -- Insertar la cita para la nueva mascota
    INSERT INTO Cita (ID_Mascota, ID_Veterinario, Fecha, Motivo, Diagnostico)
    VALUES (@ID_Mascota, @ID_Veterinario, @FechaCita, @Motivo, '');
END;
go
-- Procedimiento para cargar los veterinarios
CREATE PROCEDURE CargarVeterinarios
AS
BEGIN
    SELECT ID_Veterinario, Nombre, Apellido, ID_Especializacion, Telefono
    FROM Veterinario;
END;
go
--Procedimiento almacenado de Listado
-- Listado Veterinario
CREATE PROCEDURE ListadoVeterinarios
AS
BEGIN
    SELECT ID_Veterinario, Nombre, Apellido, ID_Especializacion, Telefono
    FROM Veterinario;
END;
go
-- Listado Mascota
CREATE PROCEDURE ListadoMascotasPorVeterinario
    @ID_Veterinario INT
AS
BEGIN
    SELECT 
		c.ID_Cita,
		c.Fecha AS FechaCita,
        v.ID_Veterinario,
		v.Nombre AS NombreVeterinario, 
		v.Apellido AS ApellidoVeterinario,
		c.Fecha,
		c.Diagnostico,
        m.ID_Mascota,
        m.Nombre AS NombreMascota,
        m.Especie,
        m.Raza,
        m.Fecha_nac,
        d.Nombre AS NombreDueño,
        d.Apellido AS ApellidoDueño
    FROM 
        Veterinario v
    INNER JOIN 
        Cita c ON v.ID_Veterinario = c.ID_Veterinario
    INNER JOIN 
        Mascota m ON c.ID_Mascota = m.ID_Mascota
    INNER JOIN 
        Dueño d ON m.ID_Dueño = d.ID_Dueño
    WHERE 
        v.ID_Veterinario = @ID_Veterinario
    ORDER BY 
        m.ID_Mascota;
END;
go
-- Actualizar el Cita
CREATE PROCEDURE ActualizarDiagnostico
    @ID_Cita VARCHAR(50),
    @NuevoDiagnostico NVARCHAR(500)
AS
BEGIN
    UPDATE Cita
    SET Diagnostico = @NuevoDiagnostico
    WHERE ID_Cita = @ID_Cita;
END;
go
--Procedimiento Almacenado para Consultas de Dueño a Mascota
CREATE PROCEDURE usp_ObtenerDueños
AS
BEGIN
    SELECT ID_Dueño, DNI, Nombre, Apellido, Direccion, Telefono, CorreoElectronico
    FROM Dueño; -- Esta es tu tabla
END;
GO

CREATE PROCEDURE usp_ObtenerMascotasPorDueño
    @ID_DUEÑO INT
AS
BEGIN
    SELECT ID_Mascota, Nombre, Especie, Raza, Fecha_nac
    FROM Mascota
    WHERE ID_Dueño = @ID_DUEÑO; -- Filtrar por el ID del dueño
END;
GO

-- Procedimiento Almacenado Mejor Veterinario por Cita
CREATE PROCEDURE ObtenerVeterinariosPorCitaEnRango
    @FechaInicio DATE,
    @FechaFin DATE
AS
BEGIN
    SELECT 
        v.ID_Veterinario,
        v.Nombre,
        v.Apellido,
        v.Telefono,
        c.ID_Cita,
        c.Fecha
    FROM 
        Veterinario v
    INNER JOIN 
        Cita c ON v.ID_Veterinario = c.ID_Veterinario
    WHERE 
        c.Fecha BETWEEN @FechaInicio AND @FechaFin
    ORDER BY 
        c.Fecha;
END;
go
--DROP PROCEDURE ObtenerVeterinariosPorCitaEnRango

-- Procedimiento almacenado para agregar Imagen
CREATE TABLE Mascota_Imagen (
    ID_Imagen INT PRIMARY KEY IDENTITY,
    ID_Mascota CHAR(6),
    Imagen VARBINARY(MAX),
    FOREIGN KEY (ID_Mascota) REFERENCES Mascota(ID_Mascota)
);
go
-- Procedimiento almacenado para mostrar imagen
CREATE PROCEDURE usp_AgregarImagen
    @ID_Mascota CHAR(6),
    @Imagen VARBINARY(MAX)
AS
BEGIN
    INSERT INTO Mascota_Imagen (ID_Mascota, Imagen)
    VALUES (@ID_Mascota, @Imagen);
END;
go
-- Procedimiento Almacenado para Mostrar Imagen
CREATE PROCEDURE usp_MostrarImagen
    @ID_Mascota CHAR(6)
AS
BEGIN
    SELECT Imagen
    FROM Mascota_Imagen
    WHERE ID_Mascota = @ID_Mascota;
END;
go
-- Buscar Mascota por ID
CREATE PROCEDURE usp_BuscarMascotaPorID
    @ID_Mascota CHAR(6)
AS
BEGIN
    SELECT Nombre
    FROM Mascota
    WHERE ID_Mascota = @ID_Mascota;
END;
go
-- Alteramos la el SP de Mascota_Imagen por FK_Mascota_Imagen_ID_Mascota
ALTER TABLE Mascota_Imagen
DROP CONSTRAINT FK_Mascota_Imagen_ID_Mascota; -- Cambia el nombre de la restricción si es diferente
go
ALTER TABLE Mascota_Imagen
ADD CONSTRAINT FK_Mascota_Imagen_ID_Mascota
FOREIGN KEY (ID_Mascota) REFERENCES Mascota(ID_Mascota) ON DELETE CASCADE;
go
-- Procedimiento Almacenado para Cita
CREATE PROCEDURE sp_ObtenerCitas
AS
BEGIN
    SELECT 
        C.ID_Cita,
        C.ID_Mascota,
        M.Nombre AS Nombre_Mascota,
        C.ID_Veterinario,
        V.Nombre AS Nombre_Veterinario,
        C.Fecha,
        C.Motivo,
        C.Diagnostico
    FROM 
        Cita C
    INNER JOIN 
        Mascota M ON C.ID_Mascota = M.ID_Mascota
    INNER JOIN 
        Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
    ORDER BY 
        C.Fecha;
END;
go
-- Creamos los CRUDS que se utilizaran --
-- Creamos Procedimiento Almacenado para Actualizar Mascotas usp_Actualizar_Mascota
CREATE PROCEDURE usp_Actualizar_Mascota
    @ID_MASCOTA CHAR(6),
    @NOMBRE VARCHAR(50) = NULL,
    @RAZA VARCHAR(50) = NULL,
    @ESPECIE VARCHAR(50) = NULL,
    @FECHA_NAC DATE = NULL
AS
BEGIN
    -- Verificar si la mascota existe antes de actualizar
    IF EXISTS (SELECT 1 FROM Mascota WHERE ID_Mascota = @ID_MASCOTA)
    BEGIN
        -- Iniciar la sentencia de actualización
        UPDATE Mascota
        SET
            Nombre = COALESCE(@NOMBRE, Nombre),
            Raza = COALESCE(@RAZA, Raza),
            Especie = COALESCE(@ESPECIE, Especie),
            Fecha_nac = COALESCE(@FECHA_NAC, Fecha_nac)
        WHERE ID_Mascota = @ID_MASCOTA;

        RETURN 1;  -- Retorna 1 si la actualización fue exitosa
    END
    ELSE
    BEGIN
        RETURN 0;  -- Retorna 0 si la mascota no existe
    END
END;
GO

-- Procedimiento Alamcenado para Llamar Tabla Macota
CREATE PROCEDURE ListadoMascotas
AS
BEGIN
    SELECT 
        ID_Mascota,
        Nombre,
        Especie,
        Raza,
        Fecha_nac,
        ID_Dueño
    FROM 
        Mascota;
END;
go
-- Procedimiento Almacenado para Eliminar la Mascota de la Tabla
CREATE PROCEDURE EliminarMascota
    @ID_Mascota CHAR(6)
AS
BEGIN
	DELETE FROM Cita 
	WHERE ID_Mascota = @ID_Mascota;
    DELETE FROM Mascota
    WHERE ID_Mascota = @ID_Mascota;
END;
go
--DROP PROCEDURE EliminarMascota

-- Tabla para Eliminar Registros Mascota, Dueño y Mascota_Imagen
CREATE TABLE RegistroEliminados (
    ID_Registro INT PRIMARY KEY IDENTITY,
    ID_Dueño INT,
    DNI CHAR(8),
    NombreDueño NVARCHAR(50),
    ApellidoDueño NVARCHAR(50),
    Direccion NVARCHAR(100),
    Telefono NVARCHAR(15),
    CorreoElectronico NVARCHAR(100),
    ID_Mascota CHAR(6),
    NombreMascota NVARCHAR(50),
    Especie NVARCHAR(50),
    Raza NVARCHAR(50),
    Fecha_nac DATE,
    Diagnostico NVARCHAR(500),
    Imagen VARBINARY(MAX),
    FechaEliminacion DATETIME DEFAULT GETDATE()
);
go
-- Trigger para la tabla Dueño
CREATE TRIGGER trg_DeleteDueño
ON Dueño
AFTER DELETE
AS
BEGIN
    INSERT INTO RegistroEliminados (ID_Dueño, DNI, NombreDueño, ApellidoDueño, Direccion, Telefono, CorreoElectronico, FechaEliminacion)
    SELECT d.ID_Dueño, d.DNI, d.Nombre, d.Apellido, d.Direccion, d.Telefono, d.CorreoElectronico, GETDATE()
    FROM Deleted d;
END;
go
-- Trigger para la tabla Mascota
CREATE TRIGGER trg_DeleteMascota
ON Mascota
AFTER DELETE
AS
BEGIN
    INSERT INTO RegistroEliminados (ID_Dueño, ID_Mascota, NombreMascota, Especie, Raza, Fecha_nac, Diagnostico, FechaEliminacion)
    SELECT m.ID_Dueño, m.ID_Mascota, m.Nombre, m.Especie, m.Raza, m.Fecha_nac, m.Diagnostico, GETDATE()
    FROM Deleted m;
END;
go
-- Trigger para la tabla Mascota_Imagen
CREATE TRIGGER trg_DeleteMascotaImagen
ON Mascota_Imagen
AFTER DELETE
AS
BEGIN
    INSERT INTO RegistroEliminados (ID_Mascota, Imagen, FechaEliminacion)
    SELECT mi.ID_Mascota, mi.Imagen, GETDATE()
    FROM Deleted mi;
END;
go
-- Creamos un Procedimiento Almacenado que Reporte Dueño - Mascota
CREATE PROCEDURE usp_GenerarReporteDueñosMascotas
AS
BEGIN
    SELECT 
        D.ID_Dueño,
        D.DNI,
        D.Nombre AS Nombre_Dueño,
        D.Apellido,
        D.Direccion,
        D.Telefono,
        D.CorreoElectronico,
        M.ID_Mascota,
        M.Nombre AS Nombre_Mascota,
        M.Especie,
        M.Raza,
        M.Fecha_nac
    FROM 
        Dueño D
    LEFT JOIN 
        Mascota M ON D.ID_Dueño = M.ID_Dueño
    ORDER BY 
        D.Apellido, D.Nombre, M.Nombre;
END;
go
--DROP PROCEDURE usp_GenerarReporteDueñosMascotas

-- Creamos un Procedimiento Almacenado que Reporte Mascota - Cita - Veterinario
CREATE PROCEDURE usp_GenerarReporteMascotasCitasVeterinarios
AS
BEGIN
    SELECT 
        M.ID_Mascota,
        M.Nombre AS Nombre_Mascota,
        M.Especie,
        M.Raza,
        M.Fecha_nac AS Fecha_Nacimiento,
        C.ID_Cita,
        C.Fecha AS Fecha_Cita,
        C.Motivo,
        V.ID_Veterinario,
        V.Nombre AS Nombre_Veterinario,
        V.Apellido AS Apellido_Veterinario
    FROM 
        Mascota M
    LEFT JOIN 
        Cita C ON M.ID_Mascota = C.ID_Mascota
    LEFT JOIN 
        Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
    ORDER BY 
        M.Nombre, C.Fecha;
END;
