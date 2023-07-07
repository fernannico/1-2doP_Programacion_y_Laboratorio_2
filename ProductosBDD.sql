USE UTN_D2;

DELETE FROM PRODUCTOS;
DBCC CHECKIDENT(PRODUCTOS, RESEED, 0);

INSERT INTO PRODUCTOS (DESCRIPCION, CORTE, KG_EN_STOCK, PRECIO_POR_KG,TIPO_PROD)
VALUES ('res', 'asado', 10, 1830, 'Carne'), ('res', 'bife', 10, 1900, 'Carne'), ('res', 'milanesa', 10, 2389, 'Carne'),
		('res', 'vacio', 10, 2299, 'Carne'), ('pollo', 'milanesa', 10, 600, 'Carne'), ('pollo', 'cuarto trasero', 10, 960, 'Carne'), 
		('pollo', 'suprema',10,1865, 'Carne'), ('chori', null, 10, 1900, 'Embutido'), ('morcilla', null, 10, 1120, 'Embutido'), ('salchicha', null, 10, 500, 'Embutido'),
	   ('salchicha parrillera', null, 10, 550, 'Embutido'), ('longaniza', null, 10, 1600, 'Embutido');

SELECT * FROM PRODUCTOS ORDER BY ID ASC;