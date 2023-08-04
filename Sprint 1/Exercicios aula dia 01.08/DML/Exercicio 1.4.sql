--DML

--INSERINDO NAS TABELAS FORTES 

INSERT INTO TipoDePermissão VALUES ('ADM'), ('Comum')

INSERT INTO Plataforma VALUES ('Optus')

INSERT INTO Artista VALUES ('LIL NAS X'), ('GUSTAVO LIMA'),('BOB MARLEY'),('MATUÊ')

INSERT INTO Estilo VALUES ('POP'), ('REAGGAE'), ('SERTANEJO'), ('RAP'), ('TRAP')

--inserindo nas tabelas fracas

INSERT INTO Usuario VALUES (2,1,'JOÃO', 'jp@email.com'), (1,1,'MATHEUS', 'mathi@gmail.com'), (2,1,'MIGUEL', 'mlm5608@outlook.com'), (2,1,'GIULIA', 'gigi543@hotmail.com')

INSERT INTO PlataformaArtisTa VALUES (1,1), (1,2), (1,3), (1,4)

INSERT INTO Album VALUES (1,'MONTERO', '17/09/2021', 'NEW YORK, NY', '41'), (3,'Uprising!', '21/11/2014', 'EUA', '93') 

INSERT INTO EstiloAlbum VALUES (3, 1), (3, 4), (4,2)

INSERT INTO PlataformaAlbum VALUES (3,1),(4,1)

SELECT * FROM TipoDePermissão
SELECT * FROM Plataforma
SELECT * FROM Artista
SELECT * FROM Estilo
SELECT * FROM Usuario
SELECT * FROM PlataformaArtisTa
SELECT * FROM Album
SELECT * FROM EstiloAlbum
SELECT * FROM PlataformaAlbum


