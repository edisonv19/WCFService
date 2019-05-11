--=========================================================
-- 	Author: Edison Vidal
-- 	Date: 04/08/2017
--	Description: Creación de tabla REL_Usuario
--=========================================================

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'REL_Usuario')
BEGIN
    CREATE TABLE dbo.[REL_Usuario] (
		[Usuario]		VARCHAR(100) COLLATE Modern_Spanish_CS_AS NOT NULL,
		[Pass]			VARCHAR(64) COLLATE Modern_Spanish_CS_AS NOT NULL,
		[IdPersona]		INT NOT NULL,
		[EsAdmin]		BIT NOT NULL DEFAULT 0,
		
		[Borrado]			BIT NOT NULL,
		[FechaUltModif]		DATETIME,
		[FechaAlta]			DATETIME,
		[UsuarioUltModif]	VARCHAR(100),
		[UsuarioAlta]		VARCHAR(100),
		[RowId]				TIMESTAMP
	);

	ALTER TABLE REL_Usuario
	ADD CONSTRAINT PK_REL_Usuario PRIMARY KEY (Usuario);
	
	ALTER TABLE REL_Usuario
	ADD CONSTRAINT FK_REL_Usuario_IdPersona
	FOREIGN KEY (IdPersona) REFERENCES [REL_Persona](IdPersona);
END;