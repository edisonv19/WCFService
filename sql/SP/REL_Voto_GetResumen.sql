IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Voto_GetResumen]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Voto_GetResumen]
END
GO

-- =================================================
-- Author:		Edison Vidal
-- Create date: 02/12/2017
-- Description:	Obtiene el resumen de votos de [REL_Voto]
-- =================================================

CREATE PROCEDURE [dbo].[REL_Voto_GetResumen]
	@IdCompania		INT = NULL,
	@FechaAlta		DATETIME = NULL	
AS
BEGIN
	SELECT
		valor.[IdValores],
		valor.[Valor] AS Puntuacion,
		COUNT(*) AS [Cantidad],
		valor.[Descripcion] AS Imagen
	FROM [REL_voto] voto
		INNER JOIN [GEN_Valores] valor ON voto.idPuntuacion = valor.IdValores
		INNER JOIN [REL_Persona] persona ON persona.IdPersona = voto.IdPersona
	WHERE
		(@IdCompania IS NULL OR persona.[IdCompania] = @IdCompania) AND
		(@FechaAlta IS NULL OR CAST(voto.[FechaAlta] AS DATE) = cast(@FechaAlta AS DATE))
	GROUP BY valor.[IdValores], valor.[Valor], valor.[Descripcion]
	UNION
	SELECT
		valor.[IdValores],
		valor.Valor AS Puntuacion,
		0 AS Cantidad,
		valor.Descripcion AS Imagen
	FROM [GEN_Valores] valor INNER JOIN [GEN_Entidad] entidad ON valor.IdEntidad = entidad.IdEntidad AND valor.Campo = 'Votacion' AND entidad.Clave = 'votacion'
	WHERE
		valor.[IdValores] NOT IN (SELECT
									valor2.IdValores
								FROM [REL_voto] voto
									INNER JOIN [GEN_Valores] valor2 ON voto.idPuntuacion = valor2.IdValores
									INNER JOIN [REL_Persona] persona ON persona.IdPersona = voto.IdPersona
								WHERE
									(@IdCompania IS NULL OR persona.[IdCompania] = @IdCompania) AND
									(@FechaAlta IS NULL OR CAST(voto.[FechaAlta] AS DATE) = cast(@FechaAlta AS DATE))
								GROUP BY valor2.IdValores)
	ORDER BY Puntuacion;
END
GO