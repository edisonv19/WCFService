IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Voto_Insert]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Voto_Insert]
END
GO

-- =================================================
-- Author:		Edison Vidal
-- Create date: 12/08/2017
-- Description:	Inserta un [REL_Voto]
-- =================================================

CREATE PROCEDURE [dbo].[REL_Voto_Insert]
	@IdPersona 		INT = NULL,
	@IdPuntuacion	INT = NULL,
	@Comentario		NVARCHAR(2000) = NULL,
	
	@UsuarioAlta	VARCHAR(100) = NULL,
	
	@RowId TIMESTAMP = NULL OUTPUT
	
AS
BEGIN
	INSERT INTO [REL_Voto] (
			[IdPersona],
			[IdPuntuacion],
			[Comentario],
			
			[FechaAlta],
			[UsuarioAlta],
			[FechaUltModif],
			[UsuarioUltModif]
			)
	VALUES (
			@IdPersona,
			@IdPuntuacion,
			@Comentario,
			
			GETDATE(),
			@UsuarioAlta,
			GETDATE(),
			@UsuarioAlta
	)

	SELECT	@RowId = [RowId]
	FROM 	[REL_Voto]
	WHERE 	[IdPersona] = @IdPersona AND
			CONVERT(date, [FechaAlta]) = CONVERT(date, GETDATE())
END
GO
