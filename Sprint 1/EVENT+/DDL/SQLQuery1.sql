--DDL 

--CRIANDO BANCO DE DADOS
CREATE DATABASE [Event+]

USE [Event+]

--==================================================================
--CRIANDO TABELAS
CREATE TABLE TiposDeUsuario
(
	IdTiposDeUsuario int PRIMARY KEY IDENTITY,
	Título VARCHAR(20) NOT NULL UNIQUE
)

CREATE TABLE Instituicao
(
	IdInstituicao INT PRIMARY KEY IDENTITY,
	NomeFantasia VARCHAR(25) NOT NULL,
	CNPJ CHAR(14) NOT NULL UNIQUE
)

CREATE TABLE TiposdeEvento 
(
	IdTiposdeEvento INT PRIMARY KEY IDENTITY,
	TituloTipoEvento VARCHAR(25) NOT NULL UNIQUE
)
--==============================================================================================================

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTiposDeUsuario INT FOREIGN KEY REFERENCES TiposDeUsuario(IdTiposDeUsuario) NOT NULL,
	Nome VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL UNIQUE,
	Senha VARCHAR (20) NOT NULL
)

CREATE TABLE Evento
(
	IdEvento INT PRIMARY KEY IDENTITY,
	IdTiposdeEvento INT FOREIGN KEY REFERENCES TiposdeEvento(IdTiposdeEvento) NOT NULL,
	IdInstituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao) NOT NULL,
	Nome VARCHAR(30) NOT NULL,
	Descricao VARCHAR(8000) NOT NULL,
	DataEvento DATE NOT NULL,
	HoraEvento TIME NOT NULL
)


CREATE TABLE PresencaEvento
(
	IdPresencaEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	Situacao BIT DEFAULT(0),
)

CREATE TABLE Comentario
(
	IdComentario INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	Descricao VARCHAR(8000) NOT NULL,
	Exibe BIT DEFAULT(0),
)