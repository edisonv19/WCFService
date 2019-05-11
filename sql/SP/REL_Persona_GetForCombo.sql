IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Persona_GetForCombo]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Persona_GetForCombo]
END
GO

-- =============================================
-- Author:		Edison Vidal
-- Create date: 22/10/2017
-- Description:	Obtiene registros de [REL_Persona] en base a la los filtros
-- =============================================

CREATE PROCEDURE [dbo].[REL_Persona_GetForCombo]
	@IdCompania INT = NULL
AS
BEGIN

	SELECT	Persona.[IdPersona] AS [Value],
			Persona.[Nombre] + ' ' + Persona.[Apellido] AS Description
	FROM	[REL_Persona] Persona
	WHERE	Persona.[Borrado] = 0 AND
			Persona.[IdCompania] = @IdCompania
END
GO