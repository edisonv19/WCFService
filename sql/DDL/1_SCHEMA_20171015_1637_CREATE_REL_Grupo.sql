--=========================================================
-- 	Author: Edison Vidal
-- 	Date: 15/10/2017
--	Description: Creación de tabla REL_Grupo
--=========================================================

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'REL_Grupo')
BEGIN
    CREATE TABLE dbo.[REL_Grupo] (
		[IdGrupo] 		INT IDENTITY(1,1),
		[Nombre]		NVARCHAR(100) NOT NULL,
		[Descripcion]	NVARCHAR(500),
		[IdCompania]	INT NOT NULL,
		
		[Borrado]			BIT NOT NULL,
		[FechaUltModif]		DATETIME,
		[FechaAlta]			DATETIME,
		[UsuarioUltModif]	VARCHAR(100),
		[UsuarioAlta]		VARCHAR(100),
		[RowId]				TIMESTAMP
	);

	ALTER TABLE REL_Grupo
	ADD CONSTRAINT PK_REL_Grupo PRIMARY KEY (IdGrupo);
	
	ALTER TABLE REL_Grupo
	ADD CONSTRAINT FK_REL_Grupo_IdCompania
	FOREIGN KEY (IdCompania) REFERENCES [REL_Compania](IdCompania);
END;