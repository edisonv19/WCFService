IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Compania_GetById]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Compania_GetById]
END
GO

-- =============================================
-- Author:		Edison Vidal
-- Create date: 12/08/2017
-- Description:	Obtiene el registro de [REL_Compania] en base a la PK y RowId 
-- =============================================

CREATE PROCEDURE [dbo].[REL_Compania_GetById]
	@IdCompania INT,
	@RowId TIMESTAMP = NULL
AS
BEGIN

	SELECT	Compania.[IdCompania],
			Compania.[Nombre],
			Compania.[CUIT],
			Compania.[TipoCompania],
			
			Compania.[Borrado],
			Compania.[FechaUltModif],
			Compania.[FechaAlta],
			Compania.[UsuarioUltModif],
			Compania.[UsuarioAlta],
			Compania.[RowId]
	FROM	[REL_Compania] Compania
	WHERE	Compania.[IdCompania] = @IdCompania AND
			((@RowId IS NULL OR Compania.[RowId] = @RowId))
END
GO