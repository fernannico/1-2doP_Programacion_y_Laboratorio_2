USE UTN_D2;

DELETE FROM USUARIOS;
DBCC CHECKIDENT(USUARIOS, RESEED, 0);

INSERT INTO USUARIOS(TIPO_USUARIO, MAIL, DINERO, CONTRASENA) 
VALUES('Vendedor','vendedor4@gmail.com', null,	1475),('Vendedor','vendedor2@gmail.com',null,5741),('Vendedor','vendedor3@gmail.com',null,2586),
		('Cliente','cliente1@gmail.com',100000,6852),('Cliente','cliente2@gmail.com',50000,3695),('Cliente','cliente3@gmail.com',10000,5963);

SELECT TOP (20) *  FROM [UTN_D2].[dbo].[USUARIOS]