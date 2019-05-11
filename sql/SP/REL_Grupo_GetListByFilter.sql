IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Grupo_GetListByFilter]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Grupo_GetListByFilter]
END
GO

-- =============================================
-- Author:		Edison Vidal
-- Create date: 15/10/2017
-- Description:	Obtiene registros de [REL_Grupo] en base a los filtros dados
-- =============================================

CREATE PROCEDURE [dbo].[REL_Grupo_GetListByFilter]
	@IdCompania 	INT = NULL,
	@Nombre 		NVARCHAR(100) = NULL,
	@Descripcion 	NVARCHAR(500) = NULL,
	@IdPersona		INT = NULL,
	@FechaAltaFrom	DATETIME = NULL,
	@FechaAltaTo	DATETIME = NULL
AS
BEGIN

	SELECT	Grupo.[IdGrupo],
			Grupo.[Nombre],
			Grupo.[Descripcion],
			Grupo.[IdCompania],
			Grupo.[FechaAlta],
			Grupo.[RowId]
			
	FROM	[REL_Grupo] Grupo
	WHERE	(Grupo.[Borrado] = 0) AND
			(@IdCompania IS NULL OR Grupo.[IdCompania] = @IdCompania) AND
			(@Nombre IS NULL OR Grupo.[Nombre] like '%'+@Nombre+'%') AND
			(@Descripcion IS NULL OR Grupo.[Descripcion] like '%'+@Descripcion+'%') AND
			(@IdPersona IS NULL OR EXISTS(SELECT 1 FROM [REL_GrupoPersona] gp WHERE gp.IdGrupo = Grupo.IdGrupo AND gp.IdPersona = @IdPersona)) AND
			(@FechaAltaFrom IS NULL OR CONVERT(DATE, Grupo.[FechaAlta]) >= CONVERT(DATE, @FechaAltaFrom)) AND
			(@FechaAltaTo IS NULL OR CONVERT(DATE, Grupo.[FechaAlta]) <= CONVERT(DATE, @FechaAltaTo))
END
GO
