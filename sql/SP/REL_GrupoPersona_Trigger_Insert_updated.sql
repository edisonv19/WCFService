IF EXISTS (SELECT 1 FROM sys.objects WHERE [object_id] = OBJECT_ID(N'[dbo].[REL_GrupoPersona_Trigger_Insert_updated]') AND [type] = N'TR')
BEGIN
	DROP TRIGGER [dbo].[REL_GrupoPersona_Trigger_Insert_updated]
END
GO

-- =================================================
-- Author:		Edison Vidal
-- Create date: 06/11/2017
-- Description:	Trigger para la tabla [REL_GrupoPersona]
-- =================================================

CREATE TRIGGER [dbo].[REL_GrupoPersona_Trigger_Insert_updated]	ON [dbo].[REL_GrupoPersona]
AFTER INSERT, UPDATE
AS
BEGIN	
	IF NOT EXISTS (SELECT 1
				FROM REL_Grupo grupo 	INNER JOIN REL_Persona persona	ON grupo.IdCompania = persona.IdCompania
										INNER JOIN INSERTED i		ON i.IdPersona = persona.IdPersona AND i.IdGrupo = grupo.IdGrupo)
	BEGIN
		RAISERROR('La persona y el grupo no forman parte de una misma compañía', 16, 1);  
	END;
END;
GO

-- Persona y grupo deben tener mismo Idcompania
-- La Compania de la persona y grupo deben coincidir con la que pertenecen