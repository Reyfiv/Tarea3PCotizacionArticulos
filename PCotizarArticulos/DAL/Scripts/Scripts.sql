CREATE DATABASE ArticulosDb
GO
USE ArticulosDb
GO
CREATE TABLE Articulos
(
	ArticuloId int primary key identity,
	FechaVencimiento DateTime,
	Descripcion varchar(80),
	Precio int,
	Existencia int,
	CantidadCotizada int
);