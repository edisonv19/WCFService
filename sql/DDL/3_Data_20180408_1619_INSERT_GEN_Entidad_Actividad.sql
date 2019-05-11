--===========================================================
-- Author:		Edison Vidal
-- Create date: 08/04/2017
-- Description: Inserto la entidad Actividad
--===========================================================

IF NOT EXISTS(SELECT 1 FROM [GEN_Entidad] WHERE Clave = 'Actividad')
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
		'Actividad'
		,N'Actividad'
		,0
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END	