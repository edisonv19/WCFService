--===========================================================
-- Author:		Edison Vidal
-- Create date: 24/06/2017
-- Description: Inserto los valores de votación.
--===========================================================

DECLARE @IdEntidad INT
SELECT @IdEntidad = IdEntidad FROM [GEN_Entidad] WHERE [Clave] = 'Votacion';

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'Votacion' AND Valor = '1' AND IdEntidad = @IdEntidad)
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
		'Votacion'
		,N'v1.png'
		,'1'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'Votacion' AND Valor = '2' AND IdEntidad = @IdEntidad)
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
		'Votacion'
		,N'v2.png'
		,'2'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'Votacion' AND Valor = '3' AND IdEntidad = @IdEntidad)
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
		'Votacion'
		,N'v3.png'
		,'3'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'Votacion' AND Valor = '4' AND IdEntidad = @IdEntidad)
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
		'Votacion'
		,N'v4.png'
		,'4'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'Votacion' AND Valor = '5' AND IdEntidad = @IdEntidad)
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
		'Votacion'
		,N'v5.png'
		,'5'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;