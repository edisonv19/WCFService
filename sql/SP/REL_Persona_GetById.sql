IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Persona_GetById]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Persona_GetById]
END
GO

-- =============================================
-- Author:		Edison Vidal
-- Create date: 27/05/2017
-- Description:	Obtiene el registro de [REL_Persona] en base a la PK y RowId 
-- =============================================

CREATE PROCEDURE [dbo].[REL_Persona_GetById]
	@IdPersona INT,
	@RowId TIMESTAMP = NULL
AS
BEGIN

	SELECT	Persona.[IdPersona],
			Persona.[Nombre],
			Persona.[Apellido],
			Persona.[DNI],
			Persona.[FecNac],
			Persona.[IdCompania],
			
			Persona.[Borrado],
			Persona.[FechaUltModif],
			Persona.[FechaAlta],
			Persona.[UsuarioUltModif],
			Persona.[UsuarioAlta],
			Persona.[RowId]
	FROM	[REL_Persona] Persona
	WHERE	Persona.[IdPersona] = @IdPersona AND
			((@RowId IS NULL OR Persona.[RowId] = @RowId))
END
GO