IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_Voto_GetListByFilter]') AND [type] = N'P')
BEGIN
	DROP PROCEDURE [dbo].[REL_Voto_GetListByFilter]
END
GO

-- =============================================
-- Author:		Edison Vidal
-- Create date: 12/08/2017
-- Description:	Obtiene registros de [REL_Voto] en base a los filtros dados
-- =============================================

CREATE PROCEDURE [dbo].[REL_Voto_GetListByFilter]
	@IdPersona 	INT = NULL,
	@Puntuacion	VARCHAR(50) = NULL,
	@Comentario NVARCHAR(2000) = NULL,
	@FechaAltaFrom	DATETIME = NULL,
	@FechaAltaTo	DATETIME = NULL
AS
BEGIN

	SELECT	Voto.[IdPersona],
			Valor.[Valor],
			Voto.[Comentario],
			
			Voto.[FechaUltModif],
			Voto.[FechaAlta],
			Voto.[UsuarioUltModif],
			Voto.[UsuarioAlta],
			Voto.[RowId]
	FROM	[REL_Voto] Voto INNER JOIN GEN_Valores Valor ON Voto.IdPuntuacion = Valor.Valor
	WHERE	(@IdPersona IS NULL OR Voto.[IdPersona] = @IdPersona) AND
			(@Puntuacion IS NULL OR Valor.[Valor] = @Puntuacion) AND
			(@Comentario IS NULL OR Voto.[Comentario] like '%'+@Comentario+'%') AND
			(@FechaAltaFrom IS NULL OR Voto.[FechaAlta] >= @FechaAltaFrom) AND
			(@FechaAltaTo IS NULL OR Voto.[FechaAlta] <= @FechaAltaTo)
END
GO
