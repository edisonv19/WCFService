--=========================================================
-- 	Author: Edison Vidal
-- 	Date: 27/05/2017
--	Description: Creación de tabla REL_Persona
--=========================================================

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'REL_Persona')
BEGIN
    CREATE TABLE dbo.[REL_Persona] (
		[IdPersona] 	INT IDENTITY(1,1),
		[Nombre]		NVARCHAR(50) NOT NULL,
		[Apellido]		NVARCHAR(50) NOT NULL,
		[DNI]			NUMERIC(8) NOT NULL,
		[FecNac]		DATETIME NOT NULL,
		[IdCompania]	INT NOT NULL,
		
		[Borrado]			BIT NOT NULL,
		[FechaUltModif]		DATETIME,
		[FechaAlta]			DATETIME,
		[UsuarioUltModif]	VARCHAR(100),
		[UsuarioAlta]		VARCHAR(100),
		[RowId]				TIMESTAMP
	);

	ALTER TABLE REL_Persona
	ADD CONSTRAINT PK_REL_Persona PRIMARY KEY (IdPersona);
	
	ALTER TABLE REL_Persona
	ADD CONSTRAINT FK_REL_Persona_IdCompania
	FOREIGN KEY (IdCompania) REFERENCES [REL_Compania](IdCompania);
END;