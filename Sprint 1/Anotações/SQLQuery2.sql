--DDL - Data Definition Language

-- Cria Banco de dados
CREATE DATABASE Joelington;

--Troca o banco de dados que esta sendo usado
USE Joelington

--CRIA A TABELA
CREATE TABLE FUNCIONÁRIOS
(
	IdFuncionario INT PRIMARY KEY IDENTITY, 
	Nome CHAR (50)
)

CREATE TABLE EMPRESAS
(
	IdEmpresa INT PRIMARY KEY IDENTITY,
	IdFuncionario INT FOREIGN KEY REFERENCES FUNCIONÁRIOS(IdFuncionario),
	Nome VARCHAR (20)
)

--aLTERA A TABELA

ALTER TABLE FUNCIONÁRIOS
ADD Cpf VARCHAR(11);

ALTER TABLE FUNCIONÁRIOS
DROP COLUMN Cpf

DROP TABLE FUNCIONÁRIOS;

DROP DATABASE Joelington;
