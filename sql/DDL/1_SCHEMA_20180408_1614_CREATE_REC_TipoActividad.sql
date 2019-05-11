--=========================================================
-- 	Author: Edison Vidal
-- 	Date: 08/04/2018
--	Description: Creación de tabla REC_TipoActividad
--=========================================================

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'REC_TipoActividad')
BEGIN
    CREATE TABLE dbo.[REC_TipoActividad] (
		[IdTipoActividad] 		INT IDENTITY(1,1),
		[Codigo]			VARCHAR(50),
		[Descripcion]		VARCHAR(100),
		[IdTipoPregunta]	INT NOT NULL,
		[IdSeccion]			INT NOT NULL,
		[Orden]				INT NULL,
		
		[Borrado]			BIT NOT NULL,
		[FechaUltModif]		DATETIME,
		[FechaAlta]			DATETIME,
		[UsuarioUltModif]	VARCHAR(100),
		[UsuarioAlta]		VARCHAR(100),
		[RowId]				TIMESTAMP
	);

	ALTER TABLE REC_TipoActividad
	ADD CONSTRAINT PK_REC_TipoActividad PRIMARY KEY (IdTipoActividad);
	
	ALTER TABLE REC_TipoActividad
	ADD CONSTRAINT FK_REC_TipoActividad_IdTipoPregunta
	FOREIGN KEY (IdTipoPregunta) REFERENCES [GEN_Valores](IdValores);
	
	ALTER TABLE REC_TipoActividad
	ADD CONSTRAINT FK_REC_TipoActividad_IdSeccion
	FOREIGN KEY (IdSeccion) REFERENCES [GEN_Valores](IdValores);
END;