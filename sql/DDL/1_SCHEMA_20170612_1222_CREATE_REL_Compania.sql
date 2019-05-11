--=========================================================
-- 	Author: Edison Vidal
-- 	Date: 12/08/2017
--	Description: Creación de tabla REL_Compania
--=========================================================

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'REL_Compania')
BEGIN
    CREATE TABLE dbo.[REL_Compania] (
		[IdCompania] 	INT IDENTITY(1,1),
		[Nombre]		NVARCHAR(200) NOT NULL,
		[CUIT]			NUMERIC(11) NOT NULL,
		[TipoCompania]	INT NOT NULL,
		
		[Borrado]			BIT NOT NULL,
		[FechaUltModif]		DATETIME,
		[FechaAlta]			DATETIME,
		[UsuarioUltModif]	VARCHAR(100),
		[UsuarioAlta]		VARCHAR(100),
		[RowId]				TIMESTAMP
	);

	ALTER TABLE REL_Compania
	ADD CONSTRAINT PK_REL_Compania PRIMARY KEY (IdCompania);
	
	ALTER TABLE REL_Compania
	ADD CONSTRAINT FK_REL_Compania_TipoCompania
	FOREIGN KEY (TipoCompania) REFERENCES [GEN_Valores](IdValores);
END;