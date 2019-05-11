--=========================================================
-- 	Author: Edison Vidal
-- 	Date: 15/10/2017
--	Description: Creación de tabla REL_GrupoPersona
--=========================================================

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'REL_GrupoPersona')
BEGIN
    CREATE TABLE dbo.[REL_GrupoPersona] (
		[IdGrupo] 		INT NOT NULL,
		[IdPersona]		INT NOT NULL,
		
		[FechaUltModif]		DATETIME,
		[FechaAlta]			DATETIME,
		[UsuarioUltModif]	VARCHAR(100),
		[UsuarioAlta]		VARCHAR(100),
		[RowId]				TIMESTAMP
	);

	ALTER TABLE REL_GrupoPersona
	ADD CONSTRAINT PK_REL_GrupoPersona PRIMARY KEY (IdGrupo, IdPersona);
	
	ALTER TABLE REL_GrupoPersona
	ADD CONSTRAINT FK_REL_GrupoPersona_IdGrupo
	FOREIGN KEY (IdGrupo) REFERENCES [REL_Grupo](IdGrupo);
	
	ALTER TABLE REL_GrupoPersona
	ADD CONSTRAINT FK_REL_GrupoPersona_IdPersona
	FOREIGN KEY (IdPersona) REFERENCES [REL_Persona](IdPersona);
END;