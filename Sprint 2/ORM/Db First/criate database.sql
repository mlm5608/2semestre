CREATE DATABASE inlock_games_dbFirst_miguel
USE inlock_games_dbFirst_miguel

CREATE TABLE Estudio
(
	IdEstudio UNIQUEIDENTIFIER PRIMARY KEY,
	Nome VARCHAR(100) NOT NULL
)

CREATE TABLE Jogo
(
	IdJogo UNIQUEIDENTIFIER PRIMARY KEY,
	IdEstudio UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Estudio(IdEstudio),
	Nome VARCHAR(100) NOT NULL,
	Descricao VARCHAR(100) NOT NULL,
	DataLancamento DATE NOT NULL,
	Valor SMALLMONEY NOT NULL
)

CREATE TABLE TiposUsuario
(
	IdTipoUsuario UNIQUEIDENTIFIER PRIMARY KEY,
	Titulo VARCHAR(100) NOT NULL
)

CREATE TABLE Usuario
(
	IdUsuario UNIQUEIDENTIFIER PRIMARY KEY,
	IdTipoUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario),
	Email VARCHAR(100) NOT NULL,
	Senha VARCHAR(100) NOT NULL
)

INSERT INTO Estudio
VALUES (NEWID(),'SENAI'),(NEWID(),'SESI'),(NEWID(),'SEBRAE')

SELECT * FROM Estudio

INSERT INTO Jogo
VALUES (NEWID(),'3425F12A-43FF-4C89-AD52-81B207637761','PING PONG','JOGO LEGAL','2023-01-01',500),
	   (NEWID(),'3425F12A-43FF-4C89-AD52-81B207637761','JUCAMOM','CA�A POKEMOM','2022-03-23',2.99)

SELECT * FROM Jogo

INSERT INTO TiposUsuario
VALUES (NEWID(),'administrador'),(NEWID(),'comum')

SELECT * FROM TiposUsuario

INSERT INTO Usuario
VALUES (NEWID(),'6123C4B5-C1E7-469D-954B-C070309CA8FF','adm@adm.com','admin'),
	   (NEWID(),'F2FAD760-D451-4F9B-AA52-BFDD46CA69B4','comum@comum.com','comum')

SELECT * FROM Usuario