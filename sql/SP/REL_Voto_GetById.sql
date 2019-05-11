IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Voto_GetById]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Voto_GetById]
END
GO

-- =============================================
-- Author:		Edison Vidal
-- Create date: 12/08/2017
-- Description:	Obtiene el registro de [REL_Voto] en base a la PK y RowId 
-- =============================================

CREATE PROCEDURE [dbo].[REL_Voto_GetById]
	@IdPersona 	INT = NULL,
	@FechaAlta	DATETIME = NULL,
	@RowId TIMESTAMP = NULL
AS
BEGIN

	SELECT	Voto.[IdPersona],
			Voto.[IdPuntuacion],
			Voto.[Comentario],
			
			Voto.[FechaUltModif],
			Voto.[FechaAlta],
			Voto.[UsuarioUltModif],
			Voto.[UsuarioAlta],
			Voto.[RowId]
	FROM	[REL_Voto] Voto
	WHERE	Voto.[IdPersona] = @IdPersona AND
			CONVERT(date, Voto.[FechaAlta]) = CONVERT(date, @FechaAlta) AND
			(@RowId IS NULL OR Voto.[RowId] = @RowId)
END
GO