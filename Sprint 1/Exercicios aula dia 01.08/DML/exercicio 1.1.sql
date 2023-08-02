--DML 

USE Exercicio_1_1


--Inserção de valores
INSERT INTO Pessoa(Nome, CNH)
VALUES ('Miguel','1245780936'), ('Joelson','1244480076')

--INSERT INTO Pessoa VALUES ('Miguel','1245780936')

INSERT INTO Email (IdPessoa, Endereco)
VALUES (1,'mlm5608@gmail.com.br')

INSERT INTO Telefone (IdPessoa, Numero)
VALUES (2,'998743560'),(1,'989546328')

SELECT * FROM Pessoa
SELECT * FROM Email
SELECT * FROM Telefone