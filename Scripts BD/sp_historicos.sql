use americaservice

INSERT INTO HistoricoReclutando values ('119023455', 'Mauricio','',' Vargas','Montero', 'Reprobado en el proceso de reclutamiento',GETDATE(),1);
INSERT INTO HistoricoReclutando values ('267896435', 'Lidia', 'María', 'Salazar', 'Salas', 'No se presento a la cita',GETDATE(),2);
INSERT INTO HistoricoReclutando values ('114584698', 'Mateo','',' Flores','Acuña', 'Reprobado en mecanografía',GETDATE(),2);

CREATE PROCEDURE dbo.obtener_historico_reclutandos

AS

BEGIN
	SELECT * FROM HistoricoReclutando;
END

-------------------------------------Editar Histórico----------------------------------------
create procedure [dbo].[editar_historico]
@cedula varchar(20),
@primer_nombre varchar(50),
@segundo_nombre varchar(50),
@primer_apellido varchar(50),
@segundo_apellido varchar(50),
@descripcion varchar(200),
@fecha datetime,
@cantidad varchar(20)
as
begin
	UPDATE HistoricoReclutando
	SET primer_nombre = @primer_nombre, segundo_nombre=@segundo_nombre,  primer_apellido= @primer_apellido, segundo_apellido=@segundo_apellido, descripcion= @descripcion, fecha=@fecha, cantidad=@cantidad
	WHERE cedula = @cedula;		
end
-------------------------------------Eliminar Histórico---------------------------------
create procedure [dbo].[eliminar_historico]
@cedula varchar(20)
as
begin
	DELETE FROM HistoricoReclutando
	WHERE cedula = @cedula;
end 
----------------------------------------Obtener Histórico---------------------------------
CREATE PROCEDURE [dbo].[obtener_historico]
@cedula varchar(20)

AS

BEGIN 
	
	
	select cedula, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, descripcion, fecha, cantidad from HistoricoReclutando where cedula = @cedula


END