--===========================================================
-- Author:		Edison Vidal
-- Create date: 08/04/2018
-- Description: Inserto los valores de TipoPregunta.
--===========================================================

DECLARE @IdEntidad INT
SELECT @IdEntidad = IdEntidad FROM [GEN_Entidad] WHERE [Clave] = 'Actividad';

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'TipoPregunta' AND Valor = 'MCH' AND IdEntidad = @IdEntidad)
BEGIN
	INSERT INTO [dbo].[GEN_Valores]( 	
		[Campo]			
		,[Descripcion]	
		,[Valor] 		
		,[Borrado]		
		,[IdEntidad]		

		,[FechaUltModif]	
		,[FechaAlta]		
		,[UsuarioUltModif]
		,[UsuarioAlta]
	)
	VALUES(
		'TipoPregunta'
		,N'Múltiple choise'
		,'MCH'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'TipoPregunta' AND Valor = 'FEC' AND IdEntidad = @IdEntidad)
BEGIN
	INSERT INTO [dbo].[GEN_Valores]( 	
		[Campo]			
		,[Descripcion]	
		,[Valor] 		
		,[Borrado]		
		,[IdEntidad]		

		,[FechaUltModif]	
		,[FechaAlta]		
		,[UsuarioUltModif]
		,[UsuarioAlta]
	)
	VALUES(
		'TipoPregunta'
		,N'Fecha'
		,'FEC'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'TipoPregunta' AND Valor = 'HOR' AND IdEntidad = @IdEntidad)
BEGIN
	INSERT INTO [dbo].[GEN_Valores]( 	
		[Campo]			
		,[Descripcion]	
		,[Valor] 		
		,[Borrado]		
		,[IdEntidad]		

		,[FechaUltModif]	
		,[FechaAlta]		
		,[UsuarioUltModif]
		,[UsuarioAlta]
	)
	VALUES(
		'TipoPregunta'
		,N'Horario'
		,'HOR'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'TipoPregunta' AND Valor = 'TXT' AND IdEntidad = @IdEntidad)
BEGIN
	INSERT INTO [dbo].[GEN_Valores]( 	
		[Campo]			
		,[Descripcion]	
		,[Valor] 		
		,[Borrado]		
		,[IdEntidad]		

		,[FechaUltModif]	
		,[FechaAlta]		
		,[UsuarioUltModif]
		,[UsuarioAlta]
	)
	VALUES(
		'TipoPregunta'
		,N'Texto'
		,'TXT'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'TipoPregunta' AND Valor = 'SCA' AND IdEntidad = @IdEntidad)
BEGIN
	INSERT INTO [dbo].[GEN_Valores]( 	
		[Campo]			
		,[Descripcion]	
		,[Valor] 		
		,[Borrado]		
		,[IdEntidad]		

		,[FechaUltModif]	
		,[FechaAlta]		
		,[UsuarioUltModif]
		,[UsuarioAlta]
	)
	VALUES(
		'TipoPregunta'
		,N'Escala'
		,'SCA'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;