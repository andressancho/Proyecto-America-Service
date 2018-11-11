use americaservice

INSERT INTO  Usuario values ('000000000', 'admin','admin', 'admin','admin', GETDATE(),GETDATE(),'A',null,null,'admin','123','A');
INSERT INTO  Usuario values ('206620142', 'David','Alejandro', 'Villalobos','Alfaro', GETDATE(),GETDATE(),'A',null,null,'dvillalobs','123','S');
INSERT INTO  Usuario values ('101230123', 'Mariana','', 'Ramirez','Soto', GETDATE(),GETDATE(),'A',null,'Davi Villalobs','mramirez','123','C');
INSERT INTO  Usuario values ('301110215', 'Kevin','Antonio', 'Rodriguez','Salas', GETDATE(),GETDATE(),'I',null,null,'krodriguez','123','C');


drop procedure iniciar_sesion
CREATE PROCEDURE dbo.iniciar_sesion
@usuario varchar(20),
@contrasena varchar(20)

AS

BEGIN 
	
	if exists (	select * from Usuario where usuario =@usuario and contrasena = @contrasena)
	begin
		select cedula, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, cumpleanos, fecha_ingreso, estado, desempeno_pruebas, supervisor, tipo from Usuario where usuario = @usuario
	end

END

exec iniciar_sesion @usuario = 'admin', @contrasena = 'admin'

drop procedure obtener_perfil
CREATE PROCEDURE dbo.obtener_perfil
@cedula varchar(20)

AS

BEGIN 
	
	
	select * from Usuario where cedula = @cedula


END

exec obtener_perfil @cedula= '101230123'

------------------------------------------------Crear Perfil-----------------------------------
drop procedure crear_perfil

CREATE PROCEDURE dbo.crear_perfil
@cedula varchar(20),
@primer_nombre varchar(50),
@segundo_nombre varchar(50),
@primer_apellido varchar(50),
@segundo_apellido varchar(50),
@cumpleanos datetime,
@ingreso datetime,
@supervisor varchar(60),
@tipo char(1),
@usuario varchar(20),
@contrasena varchar(20)
AS

BEGIN 

	if not exists( select * from Usuario where usuario = @usuario or cedula=@cedula)
	begin
	INSERT INTO  Usuario values (@cedula, @primer_nombre,@segundo_nombre,@primer_apellido, @segundo_apellido, @cumpleanos,@ingreso,default,null,@supervisor,@usuario,@contrasena,@tipo);	

	end

END

exec crear_perfil @cedula = '10250125', @primer_nombre = 'Raúl', @primer_apellido= 'Gonzalez',@segundo_nombre = 'Raúl', @segundo_apellido= 'Gonzalez', 
@cumpleanos = '10/07/1995' ,@ingreso = '10/07/1995', @usuario='rgonzalez', @contrasena='12345678', @tipo= 'A', @supervisor=''

----------------------------------------------Editar Perfil------------------------------
CREATE PROCEDURE [dbo].[editar_perfil]
@cedula varchar(20),
@primer_nombre varchar(50),
@segundo_nombre varchar(50),
@primer_apellido varchar(50),
@segundo_apellido varchar(50),
@cumpleanos datetime,
@ingreso datetime,
@estado char(1),
@supervisor varchar(60),
@tipo char(1)

AS
BEGIN 
	
	UPDATE Usuario
	SET primer_nombre = @primer_nombre,segundo_nombre=@segundo_nombre, primer_apellido= @primer_apellido, segundo_apellido=@segundo_apellido, cumpleanos= @cumpleanos, fecha_ingreso=@ingreso, estado=@estado, supervisor=@supervisor, tipo=@tipo
	WHERE cedula = @cedula;		

END
-----------------------Obtener Perfiles------------------------------
create procedure dbo.obtener_perfiles
as
begin
	select * from Usuario 
end

exec obtener_perfiles

-----------------------------------------------Filtrar Perfiles-------------------------------------------

create procedure dbo.filtrar_perfiles
@filtro varchar(1)

as
begin select * from Usuario where estado=@filtro
end

exec filtrar_perfiles @filtro='I'
-----------------------------------------------Eliminar Perfil--------------------------------
create procedure [dbo].[eliminar_perfil]
@cedula varchar(20)
as
begin
	DELETE FROM Usuario
	WHERE cedula = @cedula;
end 