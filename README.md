# Soft_3

CREATE TABLE Provincia (
    ProvinciaID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Canton (
    CantonID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(255) NOT NULL,
    ProvinciaID INT,
    FOREIGN KEY (ProvinciaID) REFERENCES Provincia(ProvinciaID)
);
GO

CREATE TABLE Distrito (
    DistritoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(255) NOT NULL,
    CantonID INT,
    FOREIGN KEY (CantonID) REFERENCES Canton(CantonID)
);
GO

CREATE TABLE Direccion (
    DireccionID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(255) NOT NULL,
    DistritoID INT,
    FOREIGN KEY (DistritoID) REFERENCES Distrito(DistritoID)
);
GO

CREATE TABLE TipoTelefono (
    TipoTelefonoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Telefono (
    TelefonoID INT IDENTITY(1,1) PRIMARY KEY,
    Numero VARCHAR(255) NOT NULL,
    TipoTelefonoID INT,
    FOREIGN KEY (TipoTelefonoID) REFERENCES TipoTelefono(TipoTelefonoID)
);
GO

CREATE TABLE TipoCorreo (
    TipoCorreoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Correo (
    CorreoID INT IDENTITY(1,1) PRIMARY KEY,
    DireccionCorreo VARCHAR(255) NOT NULL,
    TipoCorreoID INT,
    FOREIGN KEY (TipoCorreoID) REFERENCES TipoCorreo(TipoCorreoID)
);
GO

CREATE TABLE TipoPago (
    TipoPagoID INT IDENTITY(1,1) PRIMARY KEY,
    Tipo VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Pago (
    PagoID INT IDENTITY(1,1) PRIMARY KEY,
    PagoDescripcion VARCHAR(255) NOT NULL,
    TipoPagoID INT,
    FOREIGN KEY (TipoPagoID) REFERENCES TipoPago(TipoPagoID)
);
GO

CREATE TABLE Persona (
    Cedula INT PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL,
    Apellido1 VARCHAR(255) NOT NULL,
    Apellido2 VARCHAR(255) NOT NULL,
    DireccionID INT,
    TelefonoID INT,
    CorreoID INT,
    FOREIGN KEY (DireccionID) REFERENCES Direccion(DireccionID),
    FOREIGN KEY (TelefonoID) REFERENCES Telefono(TelefonoID),
    FOREIGN KEY (CorreoID) REFERENCES Correo(CorreoID)
);
GO

CREATE TABLE TipoCliente (
    TipoClienteID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(45) NOT NULL
);
GO

CREATE TABLE Clientes (
    ClienteID INT IDENTITY(1,1) PRIMARY KEY,
    Cedula INT,
    TipoClienteID INT,
    PagoID INT,
    FOREIGN KEY (Cedula) REFERENCES Persona(Cedula),
    FOREIGN KEY (TipoClienteID) REFERENCES TipoCliente(TipoClienteID),
    FOREIGN KEY (PagoID) REFERENCES Pago(PagoID)
);
GO

CREATE TABLE TipoRol (
    TipoRolID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(45) NOT NULL
);
GO

CREATE TABLE Rol (
    RolID INT IDENTITY(1,1) PRIMARY KEY,
    TipoRolID INT,
    Descripcion VARCHAR(255) NOT NULL,
    FOREIGN KEY (TipoRolID) REFERENCES TipoRol(TipoRolID)
);
GO

CREATE TABLE Usuarios (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL,
    Correo VARCHAR(255) NOT NULL,
    Contrasena VARCHAR(255) NOT NULL,
    RolID INT,
    Cedula INT,
    FOREIGN KEY (RolID) REFERENCES Rol(RolID),
    FOREIGN KEY (Cedula) REFERENCES Persona(Cedula)
);
GO

CREATE TABLE TipoDeCarga (
    TipoDeCargaID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(255) NOT NULL,
    TarifaPorKilo DECIMAL(10,2) NOT NULL
);
GO

CREATE TABLE Cargas (
    CargasID INT IDENTITY(1,1) PRIMARY KEY,
    Peso DECIMAL(10,2) NOT NULL,
    FechaEnvio DATE NOT NULL,
    Destino VARCHAR(255) NOT NULL,
    TipoDeCargaID INT,
    ClienteID INT,
    FOREIGN KEY (TipoDeCargaID) REFERENCES TipoDeCarga(TipoDeCargaID),
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
);
GO

CREATE TABLE TipoImpuesto (
    TipoImpuestoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Impuesto (
    ImpuestoID INT IDENTITY(1,1) PRIMARY KEY,
    Monto DECIMAL(10,2) NOT NULL,
    TipoImpuestoID INT,
    FOREIGN KEY (TipoImpuestoID) REFERENCES TipoImpuesto(TipoImpuestoID)
);
GO

CREATE TABLE TipoDescuento (
    TipoDescuentoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Descuento (
    DescuentoID INT IDENTITY(1,1) PRIMARY KEY,
    Monto DECIMAL(10,2) NOT NULL,
    TipoDescuentoID INT,
    FOREIGN KEY (TipoDescuentoID) REFERENCES TipoDescuento(TipoDescuentoID)
);
GO

CREATE TABLE Facturas (
    FacturasID INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE NOT NULL,
    TotalSinDescuento DECIMAL(10,2) NOT NULL,
    TotalFinal DECIMAL(10,2) NOT NULL,
    ClienteID INT,
    CargasID INT,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
    FOREIGN KEY (CargasID) REFERENCES Cargas(CargasID)
);
GO

CREATE TABLE DetallesDeFactura (
    DetallesDeFacturaID INT IDENTITY(1,1) PRIMARY KEY,
    Total DECIMAL(10) NOT NULL,
    FacturaID INT,
    CargasID INT,
    UsuarioID INT,
    ImpuestoID INT,
    DescuentoID INT,
    FechaEmision DATETIME,
    FOREIGN KEY (FacturaID) REFERENCES Facturas(FacturasID),
    FOREIGN KEY (CargasID) REFERENCES Cargas(CargasID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (ImpuestoID) REFERENCES Impuesto(ImpuestoID),
    FOREIGN KEY (DescuentoID) REFERENCES Descuento(DescuentoID)
);
GO
