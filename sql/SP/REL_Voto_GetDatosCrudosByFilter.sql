IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Voto_GetDatosCrudosByFilter]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Voto_GetDatosCrudosByFilter]
END
GO

-- =============================================
-- Author:		Edison Vidal
-- Create date: 21/10/2017
-- Description:	Obtiene registros para llenar la grilla de la página DatosCrudos.aspx en base a los filtros dados
-- =============================================

CREATE PROCEDURE [dbo].[REL_Voto_GetDatosCrudosByFilter]
	@IdCompania	INT = NULL,
	@Nombre NVARCHAR(50) = NULL,
	@Apellido NVARCHAR(50) = NULL,
	@IdPuntuacion	INT = NULL,
	@Comentario NVARCHAR(2000) = NULL,
	@FechaAltaFrom	DATETIME = NULL,
	@FechaAltaTo	DATETIME = NULL
AS
BEGIN
	SELECT	persona.[Nombre],
			persona.[Apellido],
			persona.[DNI],
			valor.Valor as Puntuacion,
			voto.[Comentario],			
			voto.[FechaAlta] AS Fecha
	FROM	[REL_Voto] voto INNER JOIN [REL_Persona] persona ON voto.IdPersona = persona.IdPersona
							INNER JOIN [GEN_Valores] valor ON voto.IdPuntuacion = valor.IdValores
	WHERE	(persona.[IdCompania] = @IdCompania) AND
			(@Nombre IS NULL OR persona.[Nombre] LIKE '%' + @Nombre + '%') AND
			(@Apellido IS NULL OR persona.[Apellido] LIKE '%' + @Apellido + '%') AND
			(@IdPuntuacion IS NULL OR valor.[IdValores] = @IdPuntuacion) AND
			(@Comentario IS NULL OR voto.[Comentario] LIKE '%' + @Comentario + '%') AND
			(@FechaAltaFrom IS NULL OR CONVERT(DATE, voto.[FechaAlta]) >= CONVERT(DATE, @FechaAltaFrom)) AND
			(@FechaAltaTo IS NULL OR CONVERT(DATE, voto.[FechaAlta]) <= CONVERT(DATE, @FechaAltaTo))
	ORDER BY
			Voto.[FechaAlta] DESC
END
GO