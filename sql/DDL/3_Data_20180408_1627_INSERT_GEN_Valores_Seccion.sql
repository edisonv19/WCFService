--===========================================================
-- Author:		Edison Vidal
-- Create date: 08/04/2018
-- Description: Inserto los valores de Seccion.
--===========================================================

DECLARE @IdEntidad INT
SELECT @IdEntidad = IdEntidad FROM [GEN_Entidad] WHERE [Clave] = 'Actividad';

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'Seccion' AND Valor = 'MAN' AND IdEntidad = @IdEntidad)
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
		'Seccion'
		,N'Mañana'
		,'MAN'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'Seccion' AND Valor = 'TAR' AND IdEntidad = @IdEntidad)
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
		'Seccion'
		,N'Tarde'
		,'TAR'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'Seccion' AND Valor = 'NOC' AND IdEntidad = @IdEntidad)
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
		'Seccion'
		,N'Noche'
		,'NOC'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;