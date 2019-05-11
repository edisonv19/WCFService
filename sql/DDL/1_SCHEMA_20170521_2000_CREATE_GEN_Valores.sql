--=========================================================
-- 	Author: Edison Vidal
-- 	Date: 30/05/2017
--	Description: Creación de tabla GEN_Valores
--=========================================================

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GEN_Valores')
BEGIN
    CREATE TABLE dbo.[GEN_Valores] (
		[IdValores] 	INT IDENTITY(1,1),
		[Campo]			VARCHAR(100) NOT NULL,
		[Descripcion]	NVARCHAR(200) NOT NULL,
		[Valor] 		VARCHAR(50) NOT NULL,
		[Borrado]			BIT NOT NULL,
		[IdEntidad]		INT NOT NULL,
		
		[FechaUltModif]		DATETIME,
		[FechaAlta]			DATETIME,
		[UsuarioUltModif]	VARCHAR(100),
		[UsuarioAlta]		VARCHAR(100),
		[RowId]				TIMESTAMP
	);

	ALTER TABLE dbo.[GEN_Valores]
	ADD CONSTRAINT PK_GEN_Valores PRIMARY KEY (IdValores);
	
	ALTER TABLE dbo.[GEN_Valores]
	ADD CONSTRAINT FK_GEN_Valores_GEN_Entidad_IdEntidad
	FOREIGN KEY (IdEntidad) REFERENCES [GEN_Entidad](IdEntidad);
END;