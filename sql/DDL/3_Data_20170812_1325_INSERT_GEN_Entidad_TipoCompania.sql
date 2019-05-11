--===========================================================
-- Author:		Edison Vidal
-- Create date: 12/08/2017
-- Description: Inserto la entidad TipoCompania
--===========================================================

IF NOT EXISTS(SELECT 1 FROM [GEN_Entidad] WHERE Clave = 'TipoCompania')
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
		'TipoCompania'
		,N'TipoCompania'
		,0
		
		,GETDATE()
		,GETDATE()
		,'Procesos'
		,'Procesos'
	)
END	