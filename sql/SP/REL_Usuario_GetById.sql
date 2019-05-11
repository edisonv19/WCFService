IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Usuario_GetById]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Usuario_GetById]
END
GO

-- =============================================
-- Author:		Edison Vidal
-- Create date: 05/08/2017
-- Description:	Obtiene el registro de [REL_Usuario] en base a la PK y RowId 
-- =============================================

CREATE PROCEDURE [dbo].[REL_Usuario_GetById]
	@Usuario VARCHAR(100) = NULL,
	@RowId TIMESTAMP = NULL
AS
BEGIN

	SELECT	Usuario.[Usuario],
			Usuario.[Pass],
			Usuario.[IdPersona],
			Usuario.[EsAdmin],
			
			Usuario.[Borrado],
			Usuario.[FechaUltModif],
			Usuario.[FechaAlta],
			Usuario.[UsuarioUltModif],
			Usuario.[UsuarioAlta],
			Usuario.[RowId]
	FROM	[REL_Usuario] Usuario
	WHERE	Usuario.[Usuario] = @Usuario AND
			((@RowId IS NULL OR Usuario.[RowId] = @RowId))
END
GO