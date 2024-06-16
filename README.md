# Soft_3

-- Crear la base de datos
CREATE DATABASE DunamisSA;
GO

-- Usar la base de datos recién creada
USE DunamisSA;
GO

-- Crear la tabla de Clientes
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Cedula NVARCHAR(20) NOT NULL UNIQUE,
    Correo NVARCHAR(100) NOT NULL
);
GO

-- Crear la tabla de Tarifas
CREATE TABLE Tarifas (
    TarifaID INT PRIMARY KEY IDENTITY(1,1),
    Codigo NVARCHAR(10) NOT NULL,
    Descripcion NVARCHAR(100),
    PrecioPorKilo DECIMAL(18, 2) NOT NULL
);
GO

-- Crear la tabla de Facturas
CREATE TABLE Facturas (
    FacturaID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT NOT NULL,
    Fecha DATETIME NOT NULL,
    MontoTotal DECIMAL(18, 2) NOT NULL,
    Descuento DECIMAL(18, 2) NOT NULL,
    Impuesto DECIMAL(18, 2) NOT NULL,
    MontoFinal DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
);
GO

-- Crear la tabla de Detalles de Facturas
CREATE TABLE DetallesFactura (
    DetalleID INT PRIMARY KEY IDENTITY(1,1),
    FacturaID INT NOT NULL,
    TarifaID INT NOT NULL,
    Peso DECIMAL(18, 2) NOT NULL,
    Monto DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (FacturaID) REFERENCES Facturas(FacturaID),
    FOREIGN KEY (TarifaID) REFERENCES Tarifas(TarifaID)
);
GO

-- Insertar datos iniciales en la tabla de Tarifas
INSERT INTO Tarifas (Codigo, Descripcion, PrecioPorKilo) VALUES 
('C1', 'Carga Fabril', 500.00),
('C2', 'Carga Perecedera', 300.00),
('C3', 'Carga Liviana', 200.00),
('C4', 'Carga Pesada', 100.00);
GO
