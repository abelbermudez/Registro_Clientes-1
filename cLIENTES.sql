CREATE DATABASE ClientesDB;
GO
USE ClientesDB;

CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Telefono NVARCHAR(20),
    Correo NVARCHAR(100)
);