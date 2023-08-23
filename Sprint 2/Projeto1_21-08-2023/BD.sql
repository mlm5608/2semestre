CREATE DATABASE Filmes_Miguel
USE Filmes_Miguel

CREATE TABLE Genero
(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50)
)

CREATE TABLE Filme
(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero),
	Titulo VARCHAR(50)
)

INSERT INTO Genero VALUES ('Terror'), ('Comédia')

INSERT INTO Filme VALUES ('1', 'A Freira') , ('2', 'As Branquelas')

SELECT * FROM Filme
