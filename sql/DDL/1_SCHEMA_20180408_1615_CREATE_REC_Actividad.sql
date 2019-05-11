--=========================================================
-- 	Author: Edison Vidal
-- 	Date: 08/04/2018
--	Description: Creación de tabla REC_Actividad
--=========================================================

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'REC_Actividad')
BEGIN
    CREATE TABLE dbo.[REC_Actividad] (
		[IdActividad] 		INT IDENTITY(1,1),
		[IdTipoActividad]	INT NOT NULL,
		[Respuesta]			VARCHAR(100),
		
		[Borrado]			BIT NOT NULL,
		[FechaUltModif]		DATETIME,
		[FechaAlta]			DATETIME,
		[UsuarioUltModif]	VARCHAR(100),
		[UsuarioAlta]		VARCHAR(100),
		[RowId]				TIMESTAMP
	);

	ALTER TABLE REC_Actividad
	ADD CONSTRAINT PK_REC_Actividad PRIMARY KEY (IdActividad);
	
	ALTER TABLE REC_Actividad
	ADD CONSTRAINT FK_REC_Actividad_IdTipoActividad
	FOREIGN KEY (IdTipoActividad) REFERENCES [REC_TipoActividad](IdTipoActividad);
END;