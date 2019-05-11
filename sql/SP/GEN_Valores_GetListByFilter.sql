IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[GEN_Valores_GetListByFilter]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[GEN_Valores_GetListByFilter]
END
GO

-- =============================================
-- Author:		Edison Vidal
-- Create date: 26/06/2017
-- Description:	Obtiene los registro de [GEN_Valores] en base a los filtros pasados por parámetro
-- =============================================

CREATE PROCEDURE [dbo].[GEN_Valores_GetListByFilter]
	@Valor VARCHAR(50) = NULL,
	@Campo VARCHAR(100) = NULL,
	@Descripcion VARCHAR(200) = NULL,
	@ClaveEntidad	VARCHAR(100) = NULL
AS
BEGIN
	DECLARE @IdEntidad INT;
	SET @IdEntidad = (SELECT Entidad.[IdEntidad] FROM [GEN_Entidad] Entidad WHERE Entidad.[Clave] = @ClaveEntidad);

	SELECT	Valores.[IdValores],
			Valores.[Campo],
			Valores.[Valor],
			Valores.[Descripcion],
			Valores.[IdEntidad]
	FROM	[GEN_Valores] Valores
	WHERE	(Valores.[Borrado] = 0) AND
			(@IdEntidad = Valores.[IdEntidad]) AND
			(@Valor IS NULL OR @Valor = Valores.[Valor]) AND
			(@Campo IS NULL OR @Campo = Valores.[Campo]) AND
			(@Descripcion IS NULL OR @Descripcion = Valores.[Descripcion])
END
GO
