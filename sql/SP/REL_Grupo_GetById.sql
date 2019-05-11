IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Grupo_GetById]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Grupo_GetById]
END
GO

-- =============================================
-- Author:		Edison Vidal
-- Create date: 15/10/2017
-- Description:	Obtiene el registro de [REL_Grupo] en base a la PK y RowId 
-- =============================================

CREATE PROCEDURE [dbo].[REL_Grupo_GetById]
	@IdGrupo INT,
	@RowId TIMESTAMP = NULL
AS
BEGIN

	SELECT	Grupo.[IdGrupo],
			Grupo.[Nombre],
			Grupo.[Descripcion],
			Grupo.[IdCompania],
			
			Grupo.[Borrado],
			Grupo.[FechaUltModif],
			Grupo.[FechaAlta],
			Grupo.[UsuarioUltModif],
			Grupo.[UsuarioAlta],
			Grupo.[RowId]
	FROM	[REL_Grupo] Grupo
	WHERE	Grupo.[IdGrupo] = @IdGrupo AND
			((@RowId IS NULL OR Grupo.[RowId] = @RowId))
END
GO