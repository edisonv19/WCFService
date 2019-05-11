IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Usuario_Insert]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Usuario_Insert]
END
GO

-- =================================================
-- Author:		Edison Vidal
-- Create date: 08/08/2017
-- Description:	Inserta un [REL_Usuario]
-- =================================================

CREATE PROCEDURE [dbo].[REL_Usuario_Insert]
	@Usuario 		VARCHAR(100) = NULL OUTPUT,
	@Pass 			VARCHAR(64) = NULL,
	@IdPersona		INT = NULL,
	@EsAdmin		BIT = NULL,
	
	@UsuarioAlta	VARCHAR(100) = NULL,
	@RowId TIMESTAMP = NULL OUTPUT
	
AS
BEGIN
	INSERT INTO [REL_Usuario] (
			[Usuario],
			[Pass],
			[IdPersona],
			[EsAdmin],
			
			[Borrado],
			[FechaAlta],
			[UsuarioAlta],
			[FechaUltModif],
			[UsuarioUltModif]
			)
	VALUES (
			@Usuario,
			@Pass,
			@IdPersona,
			@EsAdmin,
			
			0,
			GETDATE(),
			@UsuarioAlta,
			GETDATE(),
			@UsuarioAlta
	)

	SELECT	@RowId = [RowId]
	FROM 	[REL_Usuario]
	WHERE 	[Usuario] = @Usuario 

END
GO
