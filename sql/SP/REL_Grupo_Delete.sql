IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Grupo_Delete]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Grupo_Delete]
END
GO

-- =================================================
-- Author:		Edison Vidal
-- Create date: 11/11/2017
-- Description:	Elimina un [REL_Grupo]
-- =================================================

CREATE PROCEDURE [dbo].[REL_Grupo_Delete]
	@IdGrupo 		INT = NULL,
	
	@UsuarioUltModif		VARCHAR(100) = NULL,
	@RowId TIMESTAMP = NULL
AS
BEGIN
	UPDATE [REL_Grupo]
	SET
		[Borrado] = 1,
		[FechaUltModif] = GETDATE(),
		[UsuarioUltModif] = @UsuarioUltModif
	WHERE
		[IdGrupo] = @IdGrupo AND
		[RowId]	= @RowId
END
GO