--===========================================================
-- Author:		Edison Vidal
-- Create date: 24/06/2017
-- Description: Inserto la entidad votacion
--===========================================================

IF NOT EXISTS(SELECT 1 FROM [GEN_Entidad] WHERE Clave = 'Votacion')
BEGIN
	INSERT INTO [dbo].[GEN_Entidad]( 	
		[Clave],
		[Descripcion],
		[Borrado],

		[FechaUltModif],
		[FechaAlta],
		[UsuarioUltModif],
		[UsuarioAlta]	
	)
	VALUES(
		'Votacion'
		,N'Votacion'
		,0
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END	