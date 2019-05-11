IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_GrupoPersona_Insert]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_GrupoPersona_Insert]
END
GO

-- =================================================
-- Author:		Edison Vidal
-- Create date: 15/10/2017
-- Description:	Inserta un [REL_GrupoPersona]
-- =================================================

CREATE PROCEDURE [dbo].[REL_GrupoPersona_Insert]
	@IdGrupo 		INT = NULL,
	@IdPersona 		INT = NULL,
	
	@UsuarioAlta	VARCHAR(100) = NULL,
	@RowId TIMESTAMP = NULL OUTPUT
AS
BEGIN
	INSERT INTO [REL_GrupoPersona] (
			[IdGrupo],
			[IdPersona],
			
			[FechaAlta],
			[UsuarioAlta],
			[FechaUltModif],
			[UsuarioUltModif]
			)
	VALUES (
			@IdGrupo,
			@IdPersona,
			
			GETDATE(),
			@UsuarioAlta,
			GETDATE(),
			@UsuarioAlta
	);

	SELECT	
			@RowId = [RowId]
	FROM 	[REL_GrupoPersona]
	WHERE 	[IdGrupo] = @IdGrupo AND
			[IdPersona] = @IdPersona;
END
GO