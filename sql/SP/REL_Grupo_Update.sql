IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Grupo_Update]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Grupo_Update]
END
GO

-- =================================================
-- Author:		Edison Vidal
-- Create date: 11/11/2017
-- Description:	Actualiza un [REL_Grupo]
-- =================================================

CREATE PROCEDURE [dbo].[REL_Grupo_Update]
	@IdGrupo 		INT = NULL,
	@Nombre 		NVARCHAR(100) = NULL,
	@Descripcion 	NVARCHAR(500) = NULL,
	
	@UsuarioUltModif		VARCHAR(100) = NULL,
	@RowId TIMESTAMP = NULL
AS
BEGIN
	UPDATE [REL_Grupo]
	SET
		[Nombre] = @Nombre,
		[Descripcion] = @Descripcion,
		[FechaUltModif] = GETDATE(),
		[UsuarioUltModif] = @UsuarioUltModif
	WHERE
		[Borrado] = 0 AND
		[IdGrupo] = @IdGrupo AND
		[RowId]	= @RowId
END
GO