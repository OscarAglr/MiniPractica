Create database Practica
go
use Practica
go
create table Users(
IdUser int primary key identity(1,1),
username varchar(45),
pswrd varchar(100),
rol varchar(45),
estado varchar(20)
)
go

create procedure InsertarUsuario
@username varchar(45),
@pswrd varchar(45),
@rol varchar(45)
AS
BEGIN
INSERT INTO Users(username, pswrd, rol, estado)
VALUES(@username, ENCRYPTBYPASSPHRASE(@pswrd, @pswrd), @rol, 'Habilitado')
END
GO
exec InsertarUsuario 'Admin1', 'Password.1', 'Administrador'

Select * from Users
go
create procedure log_in
@username varchar(45),
@password varchar(45)
AS
if exists(Select top 1 * from Users
where username = @username AND DECRYPTBYPASSPHRASE(@password, pswrd) = @password)
BEGIN
Select 'Aceptado'
END
else
BEGIN
Select 'Denegado'
END

exec log_in 'Admin1', 'Passwor.1'
exec InsertarUsuario 'Larry', 'p123', 'Agregar'
exec InsertarUsuario 'Dab', 'p100', 'Actualizar'
go
create procedure GetRol
@username varchar(45),
@password varchar(45)
AS
Select top 1 rol from Users
where username = @username 
AND DECRYPTBYPASSPHRASE(@password, pswrd) = @password