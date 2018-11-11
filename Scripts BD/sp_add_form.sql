USE americaservice

CREATE PROCEDURE [dbo].[agregar_formulario]
		@cedula varchar(20),
		@primer_nombre varchar(50),
		@segundo_nombre varchar(50),
		@primer_apellido varchar(50),
		@segundo_apellido varchar(50),
		@id_roleplay int,
		@jornada_diurna bit,
		@jornada_mixta bit,
		@jornada_nocturna bit,
		@justificacion_jornada varchar(100),
		@fecha datetime,
		@salario float,
		@telefono numeric(8,0),
		@correo varchar(30),
		@domicilio varchar(100),
		@exp_call_center bit,
		@exp_ventas bit,
		@exp_servicio_cliente bit,
		@detalle_experiencias varchar(200),
		@exp_cobros bit,
		@exp_mora30 bit,
		@exp_mora60 bit,
		@exp_mora90 bit,
		@exp_cartera_separada bit,
		@exp_cobro_judicial bit,
		@detalle_exp_cobros varchar(200),
		@excel bit,
		@bachillerato bit

AS

BEGIN

INSERT INTO [dbo].[Formulario] 
(
      [cedula]
      ,[primer_nombre]
      ,[segundo_nombre]
      ,[primer_apellido]
      ,[segundo_apellido]
      ,[id_roleplay]
      ,[jornada_diurna]
      ,[jornada_mixta]
      ,[jornada_nocturna]
      ,[justificacion_jornada]
      ,[fecha]
      ,[salario]
      ,[telefono]
      ,[correo]
      ,[domicilio]
      ,[exp_call_center]
      ,[exp_ventas]
      ,[exp_servicio_cliente]
      ,[detalle_experiencias]
      ,[exp_cobros]
      ,[exp_mora30]
      ,[exp_mora60]
      ,[exp_mora90]
      ,[exp_cartera_separada]
      ,[exp_cobro_judicial]
      ,[detalle_exp_cobros]
      ,[excel]
      ,[bachillerato])

VALUES (
		@cedula,
		@primer_nombre,
		@segundo_nombre,
		@primer_apellido,
		@segundo_apellido,
		@id_roleplay,
		@jornada_diurna,
		@jornada_mixta,
		@jornada_nocturna,
		@justificacion_jornada,
		@fecha,
		@salario,
		@telefono,
		@correo,
		@domicilio,
		@exp_call_center,
		@exp_ventas,
		@exp_servicio_cliente,
		@detalle_experiencias,
		@exp_cobros,
		@exp_mora30,
		@exp_mora60,
		@exp_mora90,
		@exp_cartera_separada,
		@exp_cobro_judicial,
		@detalle_exp_cobros,
		@excel,
		@bachillerato)

END

------------------------  Set Identity to PK  -------------------------

SET IDENTITY_INSERT [dbo].[Formulario]  ON;  
GO  

------------------------ Test Stored Procedure ------------------------
EXEC agregar_formulario
		@cedula = 12345678,
		@primer_nombre = "test_sp",
		@segundo_nombre = "test_sp",
		@primer_apellido = "test_sp",
		@segundo_apellido = "test_sp",
		@id_roleplay = null,
		@jornada_diurna = 1,
		@jornada_mixta = 1,
		@jornada_nocturna = 0,
		@justificacion_jornada = "test_sp",
		@fecha = "11/04/18",
		@salario = 123456,
		@telefono = 23456439,
		@correo = "test_sp@test_sp",
		@domicilio = "test_sp",
		@exp_call_center = 1,
		@exp_ventas = 1,
		@exp_servicio_cliente = 1,
		@detalle_experiencias = "test_sp",
		@exp_cobros = 0,
		@exp_mora30 = 0,
		@exp_mora60 = 0,
		@exp_mora90 = 0,
		@exp_cartera_separada = 0,
		@exp_cobro_judicial = 1,
		@detalle_exp_cobros = "test_sp",
		@excel = 1,
		@bachillerato = 1
