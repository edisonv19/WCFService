IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Compania_Insert]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Compania_Insert]
END
GO

-- =================================================
-- Author:		Edison Vidal
-- Create date: 12/08/2017
-- Description:	Inserta un [REL_Compania]
-- =================================================

CREATE PROCEDURE [dbo].[REL_Compania_Insert]
	@IdCompania 	INT = NULL OUTPUT,
	@Nombre 		NVARCHAR(200) = NULL,
	@CUIT 			NUMERIC(13) = NULL,
	@TipoCompania	INT = NULL,
	
	@UsuarioAlta	VARCHAR(100) = NULL,
	@RowId TIMESTAMP = NULL OUTPUT
	
AS
BEGIN
	INSERT INTO [REL_Compania] (
			[Nombre],
			[CUIT],
			[TipoCompania],
			
			[Borrado],
			[FechaAlta],
			[UsuarioAlta],
			[FechaUltModif],
			[UsuarioUltModif]
			)
	VALUES (
			@Nombre,
			@CUIT,
			@TipoCompania,
			
			0,
			GETDATE(),
			@UsuarioAlta,
			GETDATE(),
			@UsuarioAlta
	)

	SELECT	@IdCompania = [IdCompania],
			@RowId = [RowId]
	FROM 	[REL_Compania]
	WHERE 	[IdCompania] = IDENT_CURRENT('REL_Compania')

END
GO
