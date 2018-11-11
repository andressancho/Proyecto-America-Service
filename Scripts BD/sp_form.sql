use americaservice



select * from Formulario



insert into Formulario values ('101470159','Luis','','Jimenez', 'Arroyo',null,1,0,0,'',GETDATE(), 100000,88888888, 'lja@gmail.com','Cartago',1,0,1,'si',1,1,0,0,1,0,'si',1,1)
insert into Formulario values ('201120684','Camila','', 'Rodriguez' ,'Hernandez',null,1,1,0,'',GETDATE(), 150000,88888887,'crh@gmail.com','Alajuela',0,1,0,'si',0,0,0,0,0,1,'si',1,0)
insert into Formulario values ('102400475','Pablo','', 'Mora', 'Navas',null,1,0,0,'',GETDATE(), 750000,88888886,'pamona@gmail.com','San José',1,1,1,'si',1,1,1,0,0,1,'si',1,1)

------------------------------------------------Obtener Formularios---------------------------------------------
create procedure dbo.obtener_formularios
as
begin
	select * from Formulario
end

exec obtener_formularios

--------------------------------------------Obtener por....-----------------------------------------

create procedure dbo.obtener_por_exp_callcenter
as
begin
	select * from Formulario where exp_call_center=1
end

create procedure dbo.obtener_por_exp_servicio_cliente
as
begin
	select * from Formulario where exp_servicio_cliente=1
end

exec obtener_por_exp_servicio_cliente

create procedure dbo.obtener_por_exp_cobros
as
begin
	select * from Formulario where exp_cobros=1
end
create procedure dbo.obtener_por_exp_ventas
as
begin
	select * from Formulario where exp_ventas=1
end

create procedure dbo.obtener_por_excel
as
begin
	select * from Formulario where excel=1
end


create procedure dbo.obtener_por_bachillerato
as
begin
	select * from Formulario where bachillerato=1
end

------------------------------------Eliminar Formulario-------------------------------------------
create procedure [dbo].[eliminar_formulario]
@cedula varchar(20)
as
begin
	DELETE FROM Formulario
	WHERE cedula = @cedula;
end 

---------------------------Filtrar Formularios------------------------------
create procedure dbo.filtrar_formularios
@call_center bit,
@ventas bit,
@servicio_cliente bit,
@cobros bit,
@excel bit,
@bachillerato bit

as begin
select * from Formulario where exp_ventas=@ventas and exp_call_center=@call_center and exp_servicio_cliente = @servicio_cliente and exp_cobros = @cobros and excel = @excel and bachillerato = @bachillerato
end

exec filtrar_formularios @ventas=0, @call_center=1, @servicio_cliente=1, @cobros=1, @excel=1, @bachillerato=1


