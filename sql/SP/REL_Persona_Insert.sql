IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Persona_Insert]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Persona_Insert]
END
GO

-- =================================================
-- Author:		Edison Vidal
-- Create date: 27/05/2017
-- Description:	Inserta un [REL_Persona]
-- =================================================

CREATE PROCEDURE [dbo].[REL_Persona_Insert]
	@IdPersona 		INT = NULL OUTPUT,
	@Nombre 		NVARCHAR(50) = NULL,
	@Apellido 		NVARCHAR(50) = NULL,
	@DNI 			NUMERIC(8) = NULL,
	@FecNac 		DATETIME = NULL,
	@IdCompania		INT = NULL,
	
	@UsuarioAlta		VARCHAR(100) = NULL,
	
	@RowId TIMESTAMP = NULL OUTPUT
	
AS
BEGIN
	INSERT INTO [REL_Persona] (
			[Nombre],
			[Apellido],
			[DNI],
			[FecNac],
			[IdCompania],
			
			[Borrado],
			[FechaAlta],
			[UsuarioAlta],
			[FechaUltModif],
			[UsuarioUltModif]
			)
	VALUES (
			@Nombre,
			@Apellido,
			@DNI,
			@FecNac,
			@IdCompania,
			
			0,
			GETDATE(),
			@UsuarioAlta,
			GETDATE(),
			@UsuarioAlta
	)

	SELECT	@IdPersona = [IdPersona],
			@RowId = [RowId]
	FROM 	[REL_Persona]
	WHERE 	[IdPersona] = IDENT_CURRENT('REL_Persona')

END
GO
