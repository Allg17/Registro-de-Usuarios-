create database LoginUsuarios
go
use LoginUsuarios
go

create table Usuarios
(
	Id int primary key identity(1,1),
	NUsuario varchar(max),
	Nombre varchar(max),
	Clave varchar(max),
	fecha date,
	Comentario varchar(max),
	
);
go
set dateformat dmy;
go
insert into Usuarios(NUsuario,Nombre,Clave,Fecha,Comentario) values('root','Albert Lopez','123456','19/03/2018','SuperUser');