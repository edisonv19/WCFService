IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_GrupoPersona_Delete]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_GrupoPersona_Delete]
END
GO

-- =================================================
-- Author:		Edison Vidal
-- Create date: 06/11/2017
-- Description:	Deletea un [REL_GrupoPersona]
-- =================================================

CREATE PROCEDURE [dbo].[REL_GrupoPersona_Delete]
	@IdGrupo 		INT = NULL,
	@IdPersona 		INT = NULL
AS
BEGIN
	DELETE 	[REL_GrupoPersona]
	WHERE	(@IdGrupo IS NULL OR [IdGrupo] = @IdGrupo ) AND
			(@IdPersona IS NULL OR [IdPersona] = @IdPersona);

END
GO
