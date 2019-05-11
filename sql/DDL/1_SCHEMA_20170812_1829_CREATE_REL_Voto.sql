--=========================================================
-- 	Author: Edison Vidal
-- 	Date: 27/05/2017
--	Description: Creación de tabla REL_Voto
--=========================================================

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'REL_Voto')
BEGIN
	CREATE TABLE dbo.[REL_Voto] (
		[IdPersona] 		INT NOT NULL,
		[IdPuntuacion]		INT NOT NULL,
		[Comentario]		NVARCHAR(2000),
		
		[FechaUltModif]		DATETIME,
		[FechaAlta]			DATETIME NOT NULL,
		[UsuarioUltModif]	VARCHAR(100),
		[UsuarioAlta]		VARCHAR(100),
		[RowId]				TIMESTAMP
	);

	ALTER TABLE REL_Voto
	ADD CONSTRAINT PK_REL_Puntuacion PRIMARY KEY (IdPersona,FechaAlta);

	ALTER TABLE REL_Voto
	ADD CONSTRAINT FK_REL_Voto_IdPersona
	FOREIGN KEY (IdPersona) REFERENCES [REL_Persona](IdPersona);
	
	ALTER TABLE REL_Voto
	ADD CONSTRAINT FK_REL_Voto_IdPuntuacion
	FOREIGN KEY (IdPuntuacion) REFERENCES [GEN_Valores](IdValores);
END;