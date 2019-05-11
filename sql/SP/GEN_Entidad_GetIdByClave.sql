IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[GEN_Entidad_GetByIdFilter]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[GEN_Entidad_GetByIdFilter]
END
GO

-- =============================================
-- Author:		Edison Vidal
-- Create date: 26/06/2017
-- Description:	Obtiene los registro de [GEN_Entidad] en base a los filtros pasados por parámetro
-- =============================================

CREATE PROCEDURE [dbo].[GEN_Entidad_GetByIdFilter]
	@Clave VARCHAR(50) = NULL
AS
BEGIN
	SELECT	Entidad.[IdEntidad],
			Entidad.[Descripcion]
	FROM	[GEN_Entidad] Entidad
	WHERE	(Entidad.[Borrado] = 0) AND
			(@Clave = Entidad.[Clave])
END
GO
