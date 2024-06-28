# Soft_3

-- Crear la base de datos
CREATE DATABASE DUNAMIS_SA;
GO

USE DUNAMIS_SA;
GO

-- Crear tablas
CREATE TABLE Provincia (
    ProvinciaID INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(255) NOT NULL
);

CREATE TABLE Canton (
    CantonID INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(255) NOT NULL,
    ProvinciaID INT NOT NULL,
    FOREIGN KEY (ProvinciaID) REFERENCES Provincia(ProvinciaID)
);

CREATE TABLE Distrito (
    DistritoID INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(255) NOT NULL,
    CantonID INT NOT NULL,
    FOREIGN KEY (CantonID) REFERENCES Canton(CantonID)
);

CREATE TABLE Direccion (
    DireccionID INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(255) NOT NULL,
    DistritoID INT NOT NULL,
    FOREIGN KEY (DistritoID) REFERENCES Distrito(DistritoID)
);

CREATE TABLE TipoTelefono (
    TipoTelefonoID INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(255) NOT NULL
);

CREATE TABLE Telefono (
    TelefonoID INT PRIMARY KEY IDENTITY(1,1),
    Numero VARCHAR(50) NOT NULL,
    TipoTelefonoID INT NOT NULL,
    FOREIGN KEY (TipoTelefonoID) REFERENCES TipoTelefono(TipoTelefonoID)
);

CREATE TABLE TipoCorreo (
    TipoCorreoID INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(255) NOT NULL
);

CREATE TABLE Correo (
    CorreoID INT PRIMARY KEY IDENTITY(1,1),
    DireccionCorreo VARCHAR(255) NOT NULL,
    TipoCorreoID INT NOT NULL,
    FOREIGN KEY (TipoCorreoID) REFERENCES TipoCorreo(TipoCorreoID)
);

CREATE TABLE TipoPago (
    TipoPagoID INT PRIMARY KEY IDENTITY(1,1),
    Tipo VARCHAR(255) NOT NULL
);

CREATE TABLE Pago (
    PagoID INT PRIMARY KEY IDENTITY(1,1),
    PagoDescripcion VARCHAR(255) NOT NULL,
    TipoPagoID INT NOT NULL,
    FOREIGN KEY (TipoPagoID) REFERENCES TipoPago(TipoPagoID)
);

CREATE TABLE Persona (
    Cedula INT PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL,
    Apellido1 VARCHAR(255) NOT NULL,
    Apellido2 VARCHAR(255) NOT NULL,
    DireccionID INT NOT NULL,
    TelefonoID INT NOT NULL,
    CorreoID INT NOT NULL,
    PagoID INT NOT NULL,
    FOREIGN KEY (DireccionID) REFERENCES Direccion(DireccionID),
    FOREIGN KEY (TelefonoID) REFERENCES Telefono(TelefonoID),
    FOREIGN KEY (CorreoID) REFERENCES Correo(CorreoID),
    FOREIGN KEY (PagoID) REFERENCES Pago(PagoID)
);

CREATE TABLE TipoCliente (
    TipoClienteID INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(45) NOT NULL
);

CREATE TABLE Cliente (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Cedula INT NOT NULL,
    TipoClienteID INT NOT NULL,
    FOREIGN KEY (Cedula) REFERENCES Persona(Cedula),
    FOREIGN KEY (TipoClienteID) REFERENCES TipoCliente(TipoClienteID)
);

CREATE TABLE TipoRol (
    TipoRolID INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(45) NOT NULL
);

CREATE TABLE Rol (
    RolID INT PRIMARY KEY IDENTITY(1,1),
    TipoRolID INT NOT NULL,
    Descripcion VARCHAR(255) NOT NULL,
    FOREIGN KEY (TipoRolID) REFERENCES TipoRol(TipoRolID)
);

CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Correo VARCHAR(255) NOT NULL,
    Contrasena VARCHAR(255) NOT NULL,
    RolID INT NOT NULL,
    Cedula INT NOT NULL,
    FOREIGN KEY (RolID) REFERENCES Rol(RolID),
    FOREIGN KEY (Cedula) REFERENCES Persona(Cedula)
);

CREATE TABLE TipoDeCarga (
    TipoDeCargaID INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(255) NOT NULL,
    TarifaPorKilo DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Carga (
    CargaID INT PRIMARY KEY IDENTITY(1,1),
    Peso DECIMAL(10, 2) NOT NULL,
    FechaEnvio DATE NOT NULL,
    Destino VARCHAR(255) NOT NULL,
    TipoDeCargaID INT NOT NULL,
    ClienteID INT NOT NULL,
    FOREIGN KEY (TipoDeCargaID) REFERENCES TipoDeCarga(TipoDeCargaID),
    FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID)
);

CREATE TABLE TipoImpuesto (
    TipoImpuestoID INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(255) NOT NULL
);

CREATE TABLE Impuesto (
    ImpuestoID INT PRIMARY KEY IDENTITY(1,1),
    Monto DECIMAL(10, 2) NOT NULL,
    TipoImpuestoID INT NOT NULL,
    FOREIGN KEY (TipoImpuestoID) REFERENCES TipoImpuesto(TipoImpuestoID)
);

CREATE TABLE TipoDescuento (
    TipoDescuentoID INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(255) NOT NULL
);

CREATE TABLE Descuento (
    DescuentoID INT PRIMARY KEY IDENTITY(1,1),
    Monto DECIMAL(10, 2) NOT NULL,
    TipoDescuentoID INT NOT NULL,
    FOREIGN KEY (TipoDescuentoID) REFERENCES TipoDescuento(TipoDescuentoID)
);

CREATE TABLE Factura (
    FacturaID INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    TotalSinDescuento DECIMAL(10, 2) NOT NULL,
    TotalFinal DECIMAL(10, 2) NOT NULL,
    ClienteID INT NOT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID)
);

CREATE TABLE DetalleDeFactura (
    DetalleDeFacturaID INT PRIMARY KEY IDENTITY(1,1),
    Total DECIMAL(10, 2) NOT NULL,
    FacturaID INT NOT NULL,
    CargaID INT NOT NULL,
    UsuarioID INT NOT NULL,
    ImpuestoID INT NOT NULL,
    DescuentoID INT NOT NULL,
    FechaDeEmision DATETIME NOT NULL,
    FOREIGN KEY (FacturaID) REFERENCES Factura(FacturaID),
    FOREIGN KEY (CargaID) REFERENCES Carga(CargaID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (ImpuestoID) REFERENCES Impuesto(ImpuestoID),
    FOREIGN KEY (DescuentoID) REFERENCES Descuento(DescuentoID)
);
GO
