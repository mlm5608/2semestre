CREATE DATABASE Health_Clinic_Miguel

--DDL

--TABELAS FORTES 
CREATE TABLE Especialidade
(
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(10) NOT NULL
)

CREATE TABLE TipoUsuario
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(10) NOT NULL
)

CREATE TABLE Clinica
(
	IdClinica INT PRIMARY KEY IDENTITY,
	NomeFantasia VARCHAR(10) NOT NULL,
	Endereco VARCHAR(200) NOT NULL,
	CNPJ CHAR(50) UNIQUE NOT NULL
)

--=========================================================================================
--TABELAS FRACAS

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY, 
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Email VARCHAR(30)NOT NULL UNIQUE,
	Senha VARCHAR(20) NOT NULL UNIQUE,
	DataDeNascimento DATE NOT NULL
)

CREATE TABLE Medico
(
	IdMedico INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEspecialidade INT FOREIGN KEY REFERENCES Especialidade(IdEspecialidade) NOT NULL,
	CRM VARCHAR(13) NOT NULL UNIQUE
)

CREATE TABLE Paciente
(
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	CPF VARCHAR(11) NOT NULL UNIQUE
)

CREATE TABLE Consulta
(
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente) NOT NULL,
	IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico) NOT NULL,
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
	Prontuario VARCHAR(3000) NOT NULL,
	[Data] DATE NOT NULL,
	Horario TIME NOT NULL
)

CREATE TABLE Comentario
(
	IdComentario INT PRIMARY KEY IDENTITY,
	IdConsulta INT FOREIGN KEY REFERENCES Consulta(IdConsulta) NOT NULL,
	Titulo VARCHAR(20) NOT NULL,
	Descricao VARCHAR(3000) NOT NULL
)