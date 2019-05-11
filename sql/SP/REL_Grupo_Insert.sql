IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Grupo_Insert]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Grupo_Insert]
END
GO

-- =================================================
-- Author:		Edison Vidal
-- Create date: 15/10/2017
-- Description:	Inserta un [REL_Grupo]
-- =================================================

CREATE PROCEDURE [dbo].[REL_Grupo_Insert]
	@IdGrupo 		INT = NULL OUTPUT,
	@Nombre 		NVARCHAR(100) = NULL,
	@Descripcion 	NVARCHAR(500) = NULL,
	@IdCompania		INT = NULL,
	
	@UsuarioAlta		VARCHAR(100) = NULL,
	
	@RowId TIMESTAMP = NULL OUTPUT
	
AS
BEGIN
	INSERT INTO [REL_Grupo] (
			[Nombre],
			[Descripcion],
			[IdCompania],
			
			[Borrado],
			[FechaAlta],
			[UsuarioAlta],
			[FechaUltModif],
			[UsuarioUltModif]
			)
	VALUES (
			@Nombre,
			@Descripcion,
			@IdCompania,
			
			0,
			GETDATE(),
			@UsuarioAlta,
			GETDATE(),
			@UsuarioAlta
	)

	SELECT	@IdGrupo = [IdGrupo],
			@RowId = [RowId]
	FROM 	[REL_Grupo]
	WHERE 	[IdGrupo] = IDENT_CURRENT('REL_Grupo')

END
GO
