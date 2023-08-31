CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50) not null,
	Email VARCHAR(100) NOT NULL UNIQUE,
	Senha VARCHAR(30) NOT NULL,
	Permissao BIT NOT NULL DEFAULT 0
)

INSERT INTO Usuario VALUES ('Miguel Moreira', 'miguellamarca28@gmail.com', '1234', 1)

select * from Usuario