--===========================================================
-- Author:		Edison Vidal
-- Create date: 12/08/2017
-- Description: Inserto los valores de TipoCompania.
--===========================================================

DECLARE @IdEntidad INT
SELECT @IdEntidad = IdEntidad FROM [GEN_Entidad] WHERE [Clave] = 'TipoCompania';

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'TipoCompania' AND Valor = 'EMP' AND IdEntidad = @IdEntidad)
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
		'TipoCompania'
		,N'Empresa'
		,'EMP'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;

IF NOT EXISTS(SELECT 1 FROM [GEN_Valores] WHERE Campo = 'TipoCompania' AND Valor = 'INS' AND IdEntidad = @IdEntidad)
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
		'TipoCompania'
		,N'Instituciòn'
		,'INS'
		,0
		,@IdEntidad
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END;