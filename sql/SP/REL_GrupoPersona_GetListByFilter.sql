IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_GrupoPersona_GetListByFilter]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_GrupoPersona_GetListByFilter]
END
GO

-- =============================================
-- Author:		Edison Vidal
-- Create date: 26/11/2017
-- Description:	Obtiene registros de [REL_GrupoPersona] en base a la los filtros
-- =============================================

CREATE PROCEDURE [dbo].[REL_GrupoPersona_GetListByFilter]
	@IdGrupo 	INT = NULL,
	@IdPersona 	INT = NULL
AS
BEGIN
	SELECT	GrupoPersona.[IdPersona],
			GrupoPersona.[IdGrupo]
	FROM	[REL_GrupoPersona] GrupoPersona
	WHERE	(@IdGrupo IS NULL OR GrupoPersona.[IdGrupo] = @IdGrupo) AND
			(@IdPersona IS NULL OR GrupoPersona.[IdPersona] = @IdPersona)
END
GO