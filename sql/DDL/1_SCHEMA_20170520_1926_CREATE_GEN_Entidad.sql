--=========================================================
-- 	Author: Edison Vidal
-- 	Date: 24/06/2017
--	Description: Creación de tabla GEN_Entidad
--=========================================================

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GEN_Entidad')
BEGIN
    CREATE TABLE dbo.[GEN_Entidad] (
		[IdEntidad] 	INT IDENTITY(1,1),
		[Clave]			VARCHAR(100) NOT NULL,
		[Descripcion]	NVARCHAR(200) NOT NULL,
		[Borrado]			BIT NOT NULL,
		
		[FechaUltModif]		DATETIME,
		[FechaAlta]			DATETIME,
		[UsuarioUltModif]	VARCHAR(100),
		[UsuarioAlta]		VARCHAR(100),
		[RowId]				TIMESTAMP
	);

	ALTER TABLE dbo.[GEN_Entidad]
	ADD CONSTRAINT PK_GEN_Entidad PRIMARY KEY (IdEntidad);
END;